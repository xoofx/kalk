using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using Kalk.CodeGen;
using Kalk.Core;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Scriban;
using Scriban.Runtime;

namespace Kalk.IntrinsicsGen
{
    class Program
    {
        public class KalkIntrinsicParameterToGenerate : KalkParamDescriptor
        {
            public KalkIntrinsicParameterToGenerate()
            {
            }

            public string Type { get; set; }
            
            public string RealType { get; set; }
            
            public string GenericCompatibleRealType { get; set; }

            public string BaseNativeType { get; set; }
            
            public string NativeType { get; set; }
        }

        public class KalkIntrinsicToGenerate : KalkMemberToGenerate
        {
            public KalkIntrinsicToGenerate()
            {
                Parameters = new List<KalkIntrinsicParameterToGenerate>();
            }

            public string Class { get; set; }

            public string Cpu { get; set; }

            public string ReturnType { get; set; }
            
            public string RealReturnType { get; set; }

            public string GenericCompatibleRealReturnType { get; set; }
            
            public List<KalkIntrinsicParameterToGenerate> Parameters { get; } 
            
            public bool HasPointerArguments { get; set; }
            
            public IMethodSymbol MethodSymbol { get; set; }
            
            public string MethodDeclaration { get; set; }
            
            public string IndirectMethodDeclaration { get; set; }

            public string BaseNativeReturnType { get; set; }

            public string NativeReturnType { get; set; }
            
            public bool IsSupported { get; set; }
        }

        private static readonly HashSet<string> IntrinsicsSupports = new HashSet<string>()
        {
            "SSE",
            "SSE2",
            "SSE3",
            "SSSE3",
            "SSE4.1",
            "SSE4.2",
            "AVX",
            "AVX2",
        };

        /// <summary>
        /// Instructions requiring alignment (via parameter mem_addr)
        /// </summary>
        private static readonly Dictionary<string, int> RequiredAlignments = new Dictionary<string, int>()
        {
            {"mm_load_ps", 16},
            {"mm_loadr_ps", 16},
            {"mm_stream_ps", 16},
            {"mm_store1_ps", 16},
            {"mm_store_ps1", 16},
            {"mm_store_ps", 16},
            {"mm_storer_ps", 16},
            {"mm_load_si128", 16},
            {"mm_store_si128", 16},
            {"mm_stream_si128", 16},
            {"mm_load_pd", 16},
            {"mm_loadr_pd", 16},
            {"mm_stream_pd", 16},
            {"mm_store1_pd", 16},
            {"mm_store_pd1", 16},
            {"mm_store_pd", 16},
            {"mm_storer_pd", 16},
            {"mm_stream_load_si128", 16},
            {"mm256_load_pd", 32},
            {"mm256_store_pd", 32},
            {"mm256_load_ps", 32},
            {"mm256_store_ps", 32},
            {"mm256_load_si256", 32},
            {"mm256_store_si256", 32},
            {"mm256_stream_si256", 32},
            {"mm256_stream_pd", 32},
            {"mm256_stream_ps", 32},
            {"mm256_stream_load_si256", 32},
        };

        private static readonly Dictionary<string, string> FixIntrinsicsDocumentation = new Dictionary<string, string>()
        {
            {"<summary>_MM_FROUND_CUR_DIRECTION; ROUNDPD", "<summary>__m128d _mm_round_pd (__m128d a, _MM_FROUND_CUR_DIRECTION); ROUNDPD"},
            {"<summary>_MM_FROUND_CUR_DIRECTION; ROUNDPS", "<summary>__m128 _mm_round_ps (__m128 a, _MM_FROUND_CUR_DIRECTION); ROUNDPS"},
            {"<summary>_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC; ROUNDPD", "<summary>__m128d _mm_round_pd (__m128d a, _MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC); ROUNDPD"},
            {"<summary>_MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC; ROUNDPS", "<summary>__m128 _mm_round_ps (__m128 a, _MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC); ROUNDPS"},
            {"<summary>_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC; ROUNDPD", "<summary>__m128d _mm_round_pd (__m128d a, _MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC); ROUNDPD"},
            {"<summary>_MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC; ROUNDPS", "<summary>__m128 _mm_round_ps (__m128 a, _MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC); ROUNDPS"},
            {"<summary>_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC; ROUNDPD", "<summary>__m128d _mm_round_pd (__m128d a, _MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC); ROUNDPD"},
            {"<summary>_MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC; ROUNDPS", "<summary>__m128 _mm_round_ps (__m128 a, _MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC); ROUNDPS"}
        };
       
        private static List<KalkModuleToGenerate> FindIntrinsics(Compilation compilation)
        {
            var regexName = new Regex(@"^\s*\w+\s+(\w+)\s*\(");
            int count = 0;
            
            var intelDoc = XDocument.Load("intel-intrinsics-data-latest.xml");
            var nameToDoc = intelDoc.Descendants("intrinsic").Where(x => IntrinsicsSupports.Contains(x.Attribute("tech").Value ?? string.Empty)).ToDictionary(x => x.Attribute("name").Value, x => x);
            
            var generatedIntrinsics = new Dictionary<string, KalkIntrinsicToGenerate>();
            
            foreach (var type in new Type[]
            {
                typeof(System.Runtime.Intrinsics.X86.Sse.X64),
                typeof(System.Runtime.Intrinsics.X86.Sse),
                typeof(System.Runtime.Intrinsics.X86.Sse2),
                typeof(System.Runtime.Intrinsics.X86.Sse2.X64),
                typeof(System.Runtime.Intrinsics.X86.Sse3),
                typeof(System.Runtime.Intrinsics.X86.Ssse3),
                typeof(System.Runtime.Intrinsics.X86.Sse41),
                typeof(System.Runtime.Intrinsics.X86.Sse41.X64),
                typeof(System.Runtime.Intrinsics.X86.Sse42),
                typeof(System.Runtime.Intrinsics.X86.Sse42.X64),
                typeof(System.Runtime.Intrinsics.X86.Aes),
                typeof(System.Runtime.Intrinsics.X86.Avx),
                typeof(System.Runtime.Intrinsics.X86.Avx2),
                typeof(System.Runtime.Intrinsics.X86.Bmi1),
                typeof(System.Runtime.Intrinsics.X86.Bmi1.X64),
                typeof(System.Runtime.Intrinsics.X86.Bmi2),
                typeof(System.Runtime.Intrinsics.X86.Bmi2.X64),
                typeof(System.Runtime.Intrinsics.Arm.AdvSimd),
                typeof(System.Runtime.Intrinsics.Arm.AdvSimd.Arm64),
                typeof(System.Runtime.Intrinsics.Arm.Aes),
                typeof(System.Runtime.Intrinsics.Arm.Aes.Arm64),
                typeof(System.Runtime.Intrinsics.Arm.Crc32),
                typeof(System.Runtime.Intrinsics.Arm.Crc32.Arm64),
                typeof(System.Runtime.Intrinsics.Arm.Dp),
                typeof(System.Runtime.Intrinsics.Arm.Dp.Arm64),
                typeof(System.Runtime.Intrinsics.Arm.Rdm),
                typeof(System.Runtime.Intrinsics.Arm.Rdm.Arm64),
                typeof(System.Runtime.Intrinsics.Arm.Sha1),
                typeof(System.Runtime.Intrinsics.Arm.Sha1.Arm64),
                typeof(System.Runtime.Intrinsics.Arm.Sha256),
                typeof(System.Runtime.Intrinsics.Arm.Sha256.Arm64),
            })
            {
                var x86Sse = compilation.GetTypeByMetadataName(type.FullName);
                foreach(var method in x86Sse.GetMembers().OfType<IMethodSymbol>().Where(x => x.IsStatic))
                {
                    if (method.Parameters.Length == 0) continue;

                    var groupName = type.FullName.Substring(type.FullName.LastIndexOf('.') + 1).Replace("+", string.Empty);
                    var docGroupName = type.Name == "X64" || type.Name == "Arm64" ? type.DeclaringType.Name : type.Name;
                    
                    var xmlDocStr = method.GetDocumentationCommentXml();
                    if (string.IsNullOrEmpty(xmlDocStr))
                    {
                        continue;
                    }
                    
                    var xmlDoc = XElement.Parse($"<root>{xmlDocStr.Trim()}</root>");
                    var elements = xmlDoc.Elements().First();

                    var csharpSummary = GetCleanedString(elements);

                    var summaryTrimmed = csharpSummary.Replace("unsigned", string.Empty);
                    var match = regexName.Match(summaryTrimmed);
                    if (!match.Success)
                    {
                        continue;
                    }
                    
                    var rawIntrinsicName = match.Groups[1].Value;
                    var intrinsicName = rawIntrinsicName.TrimStart('_');
                    var cpu = type.FullName.StartsWith("System.Runtime.Intrinsics.X86") ? "X86" : "Arm";

                    var desc = new KalkIntrinsicToGenerate
                    {
                        Name = intrinsicName,
                        Class = groupName,
                        Cpu = cpu,
                        MethodSymbol = method,
                        IsFunc = true,
                    };
                    
                    bool hasInteldoc = false;
                    if (nameToDoc.TryGetValue(rawIntrinsicName, out var elementIntelDoc))
                    {
                        hasInteldoc = true;
                        desc.Description = GetCleanedString(elementIntelDoc.Descendants("description").FirstOrDefault());

                        foreach (var parameter in elementIntelDoc.Descendants("parameter"))
                        {
                            desc.Params.Add(new KalkParamDescriptor(parameter.Attribute("varname").Value, parameter.Attribute("type").Value));
                        }
                        
                        desc.Description = desc.Description.Replace("[round_note]", string.Empty).Trim();
                        desc.Description = desc.Description + "\n\n" + csharpSummary;
                    }
                    else if (cpu == "Arm")
                    {
                        desc.Description = $"{csharpSummary}\n\nInstruction Documentation: [{intrinsicName}](https://developer.arm.com/architectures/instruction-sets/intrinsics/{intrinsicName})";
                    }
                    else
                    {
                        desc.Description = csharpSummary;
                    }

                    // Patching special methods
                    switch (desc.Name)
                    {
                        case "mm_prefetch":
                            if (method.Name.EndsWith("0"))
                            {
                                desc.Name += "0";
                            }
                            else if (method.Name.EndsWith("1"))
                            {
                                desc.Name += "1";
                            }
                            else if (method.Name.EndsWith("2"))
                            {
                                desc.Name += "2";
                            }
                            else if (method.Name.EndsWith("Temporal"))
                            {
                                desc.Name += "nta";
                            }
                            else
                            {
                                goto default;
                            }
                            break;
                        
                        case "mm_round_sd":
                        case "mm_round_ss":
                        case "mm_round_pd":
                        case "mm_round_ps":
                        case "mm256_round_pd":
                        case "mm256_round_ps":
                            Debug.Assert(method.Name.StartsWith("Round"));
                            var postfix = method.Name.Substring("Round".Length);
                            Debug.Assert(hasInteldoc);
                            if (desc.Name != "mm_round_ps" && desc.Name != "mm256_round_ps" && (desc.Params.Count >= 2 && method.Parameters.Length == 1))
                            {
                                desc.Name += "1";
                            }
                            
                            if (!postfix.StartsWith("CurrentDirection"))
                            {
                                postfix = StandardMemberRenamer.Rename(postfix);
                                desc.Name = $"{desc.Name}_{postfix}";
                            }

                            // Remove rounding from doc
                            var index = desc.Params.FindIndex(x => x.Name == "rounding");
                            if (index >= 0)
                            {
                                desc.Params.RemoveAt(index);
                            }
                            break;
                        case "mm_rcp_ss":
                        case "mm_rsqrt_ss":
                        case "mm_sqrt_ss":
                            if (method.Parameters.Length == 1)
                            {
                                desc.Name += "1";
                            }
                            break;
                        
                        case "mm_sqrt_sd":
                        case "mm_ceil_sd":
                        case "mm_floor_sd":
                            if (method.Parameters.Length == 1)
                            {
                                desc.Name += "1";
                            }
                            break;
                            
                        default:
                            if (hasInteldoc)
                            {
                                if (method.Parameters.Length != desc.Params.Count)
                                {
                                    Console.WriteLine($"Parameters not matching for {method.ToDisplayString()}. Expecting: {desc.Params.Count} but got {method.Parameters.Length}  ");
                                }
                            }
                            break;
                    }

                    desc.CSharpName = desc.Name;
                    desc.Names.Add(desc.Name);                    
                    desc.RealReturnType = method.ReturnType.ToDisplayString();
                    if (desc.RealReturnType == "bool") desc.RealReturnType = "KalkBool";
                    desc.ReturnType = method.ReturnType is INamedTypeSymbol retType && retType.IsGenericType ? "object" : desc.RealReturnType;
                    desc.GenericCompatibleRealReturnType = method.ReturnType is IPointerTypeSymbol ? "IntPtr" : desc.RealReturnType;
                    
                    (desc.BaseNativeReturnType, desc.NativeReturnType) = GetBaseTypeAndType(method.ReturnType);

                    desc.HasPointerArguments = false;

                    for (int i = 0; i < method.Parameters.Length; i++)
                    {
                        var intrinsicParameter = new KalkIntrinsicParameterToGenerate();
                        var parameter = method.Parameters[i];
                        intrinsicParameter.Name = i < desc.Params.Count ? desc.Params[i].Name : parameter.Name;

                        var parameterType = method.Parameters[i].Type;
                        intrinsicParameter.Type =  parameterType is INamedTypeSymbol paramType && paramType.IsGenericType || parameterType is IPointerTypeSymbol ? "object" : parameter.Type.ToDisplayString();
                        intrinsicParameter.RealType = parameter.Type.ToDisplayString();
                        intrinsicParameter.GenericCompatibleRealType = parameterType is IPointerTypeSymbol ? "IntPtr" : intrinsicParameter.RealType;
                        if (parameterType is IPointerTypeSymbol)
                        {
                            desc.HasPointerArguments = true;
                        }
                        
                        (intrinsicParameter.BaseNativeType, intrinsicParameter.NativeType) = GetBaseTypeAndType(parameter.Type);
                        desc.Parameters.Add(intrinsicParameter);
                    }
                    
                    // public object mm_add_ps(object left, object right) => ProcessArgs<float, Vector128<float>, float, Vector128<float>, float, Vector128<float>>(left, right, Sse.Add);
                    var methodDeclaration = new StringBuilder();
                    methodDeclaration.Append($"public {desc.ReturnType} {desc.Name}(");
                    for (int i = 0; i < desc.Parameters.Count; i++)
                    {
                        var parameter = desc.Parameters[i];
                        if (i > 0) methodDeclaration.Append(", ");
                        methodDeclaration.Append($"{parameter.Type} {parameter.Name}");
                    }

                    bool isAction = method.ReturnType.ToDisplayString() == "void";
                    desc.IsAction = isAction;
                    desc.IsFunc = !desc.IsAction;
                    
                    methodDeclaration.Append(isAction ? $") => ProcessAction<" : $") => ({desc.ReturnType})ProcessFunc<");

                    var castBuilder = new StringBuilder(isAction ? "Action<" : "Func<");
                    for (int i = 0; i < desc.Parameters.Count; i++)
                    {
                        var parameter = desc.Parameters[i];
                        if (i > 0)
                        {
                            methodDeclaration.Append(", ");
                            castBuilder.Append(", ");
                        }
                        methodDeclaration.Append($"{parameter.BaseNativeType}, {parameter.NativeType}");
                        castBuilder.Append($"{parameter.Type}");
                    }

                    if (!isAction)
                    {
                        if (desc.Parameters.Count > 0)
                        {
                            methodDeclaration.Append(", ");
                            castBuilder.Append(", ");                        
                        }
                        
                        methodDeclaration.Append($"{desc.BaseNativeReturnType}, {desc.NativeReturnType}");
                        castBuilder.Append($"{desc.ReturnType}");
                    }
                    methodDeclaration.Append($">(");
                    castBuilder.Append($">");
                    
                    // Gets any memory alignment
                    RequiredAlignments.TryGetValue(intrinsicName, out int memAlign);
                    
                    for (int i = 0; i < desc.Parameters.Count; i++)
                    {
                        var parameter = desc.Parameters[i];
                        methodDeclaration.Append($"{parameter.Name}, ");
                        if (memAlign > 0 && parameter.Name == "mem_addr")
                        {
                            methodDeclaration.Append($"{memAlign}, ");
                        }
                    }

                    var finalSSEMethod = $"{method.ContainingType.ToDisplayString()}.{method.Name}";
                    var sseMethodName = desc.HasPointerArguments ? $"{groupName}_{method.Name}{count}" : finalSSEMethod;
                    methodDeclaration.Append(sseMethodName);
                    methodDeclaration.Append(");");
                    desc.Cast = $"({castBuilder})";
                    desc.MethodDeclaration = methodDeclaration.ToString();

                    if (desc.HasPointerArguments)
                    {
                        methodDeclaration.Clear();

                        castBuilder.Clear();
                        castBuilder.Append(isAction ? "Action<" : "Func<");
                        for (int i = 0; i < desc.Parameters.Count; i++)
                        {
                            var parameter = desc.Parameters[i];
                            if (i > 0)
                            {
                                castBuilder.Append(", ");
                            }
                            castBuilder.Append($"{parameter.GenericCompatibleRealType}");
                        }

                        if (!isAction)
                        {
                            castBuilder.Append($", {desc.GenericCompatibleRealReturnType}");
                        }
                        castBuilder.Append(">");

                        methodDeclaration.Append($"private unsafe readonly static {castBuilder} {sseMethodName} = new {castBuilder}((");
                        for (int i = 0; i < desc.Parameters.Count; i++)
                        {
                            if (i > 0) methodDeclaration.Append(", ");
                            methodDeclaration.Append($"arg{i}");
                        }
                        methodDeclaration.Append($") => {finalSSEMethod}(");
                        for (int i = 0; i < desc.Parameters.Count; i++)
                        {
                            if (i > 0) methodDeclaration.Append(", ");
                            var parameter = desc.Parameters[i];
                            methodDeclaration.Append($"({parameter.RealType})arg{i}");
                        }
                        methodDeclaration.Append("));");
                        desc.IndirectMethodDeclaration = methodDeclaration.ToString();
                    }

                    desc.Cpu = type.FullName.StartsWith("System.Runtime.Intrinsics.X86") ? "X86" : "Arm";

                    desc.Category = $"Vector Hardware Intrinsics {desc.Cpu} / {docGroupName.ToUpperInvariant()}";

                    generatedIntrinsics.TryGetValue(desc.Name, out var existingDesc);
                    
                    // TODO: handle line for comments
                    desc.Description = desc.Description.Trim().Replace("\r\n", "\n");
                    if (existingDesc == null || desc.Parameters[0].BaseNativeType == "float")
                    {
                        generatedIntrinsics[desc.Name] = desc;
                    }
                    
                    desc.IsSupported = true;
                    
                    count++;
                }
            }
            
            Console.WriteLine($"{generatedIntrinsics.Count} intrinsics");

            var intrinsics = generatedIntrinsics.Values.Where(x => x.IsSupported).ToList();

            var intrinsicsPerClass = intrinsics.GroupBy(x => $"{x.Cpu}{x.Class}").ToDictionary(x => x.Key, y => y.OrderBy(x => x.Name).ToList());

            var modules = new List<KalkModuleToGenerate>();
            foreach (var keyPair in intrinsicsPerClass.OrderBy(x => x.Key))
            {
                var module = new KalkModuleToGenerate
                {
                    Namespace = $"Kalk.Core.Modules.HardwareIntrinsics.{keyPair.Value.First().Cpu}",
                    ClassName = $"{keyPair.Value.First().Class}IntrinsicsModule",
                    Category = keyPair.Value.First().Category
                };
                module.Members.AddRange(keyPair.Value);
                modules.Add(module);
            }

            return modules;
        }

        private static (string, string) GetBaseTypeAndType(ITypeSymbol type)
        {
            if (type is IPointerTypeSymbol)
            {
                return ("IntPtr", "IntPtr");
            }
            
            var typeStr = type.ToDisplayString();
            string baseType;
            var nativeType = type as INamedTypeSymbol;
            if (nativeType != null && nativeType.TypeArguments.Length > 0)
            {
                baseType = nativeType.TypeArguments[0].ToDisplayString();
            }
            else
            {
                baseType = typeStr;
            }
            return (baseType, typeStr);
        }
        
        
        private static readonly Regex RemoveCode = new Regex(@"^\s*```\w*[ \t]*[\r\n]*", RegexOptions.Multiline);

        static async Task Main(string[] args)
        {
            var rootFolder = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"../../../../.."));
            var srcFolder = Path.Combine(rootFolder, "src");

            // Hack re-add System.Runtime.Intrinsics with doc
            // @"packs/Microsoft.NETCore.App.Ref/5.0.0/ref/net5.0";

            var instances = MSBuildLocator.QueryVisualStudioInstances(new VisualStudioInstanceQueryOptions() {DiscoveryTypes = DiscoveryType.DotNetSdk, WorkingDirectory = AppContext.BaseDirectory});

            MetadataReference intrinsicsAssembly = null;
            foreach (var instance in instances)
            {
                var file = Path.GetFullPath(Path.Combine(instance.MSBuildPath, "..", "..", "packs", "Microsoft.NETCore.App.Ref", "5.0.0", "ref", "net5.0", "System.Runtime.Intrinsics.xml"));
                if (File.Exists(file))
                {
                    var docText = File.ReadAllText(file);
                    foreach (var fixDocPair in FixIntrinsicsDocumentation)
                    {
                        docText = docText.Replace(fixDocPair.Key, fixDocPair.Value);
                    }

                    var docProvider = XmlDocumentationProvider.CreateFromBytes(new UTF8Encoding(false).GetBytes(docText)); 
                    var assemblyPath = Path.ChangeExtension(file, "dll");
                    intrinsicsAssembly = MetadataReference.CreateFromFile(assemblyPath, MetadataReferenceProperties.Assembly, docProvider);
                    break;
                }
            }

            if (intrinsicsAssembly == null)
            {
                Console.WriteLine("Unable to find System.Runtime.Intrinsics.xml from dotnet SDK installed");
                Environment.Exit(1);
                return;
            }

            var workspace = new AdhocWorkspace();
            var project = workspace.AddProject("Temp", LanguageNames.CSharp);
            project = project.AddMetadataReference(intrinsicsAssembly);
            workspace.TryApplyChanges(project.Solution);

            // Make sure that doc will be parsed
            project = project.WithCompilationOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
            project = project.WithParseOptions(project.ParseOptions.WithDocumentationMode(DocumentationMode.Parse));

            // Compile the project
            var compilation = await project.GetCompilationAsync();

            var errors = compilation.GetDiagnostics().Where(diagnostic => diagnostic.Severity == DiagnosticSeverity.Error).ToList();

            if (errors.Count > 0)
            {
                Console.WriteLine("Compilation errors:");
                foreach (var error in errors)
                {
                    Console.WriteLine(error);
                }

                Console.WriteLine("Error, Exiting.");
                Environment.Exit(1);
                return;
            }

            var intrinsicModules = FindIntrinsics(compilation);

            
            var templateStr = @"//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Date: {{ date.now }}
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;

{{~ for module in intrinsics ~}}
namespace {{ module.Namespace }}
{
    public partial class {{ module.ClassName }}
    {
        public const string Category = ""{{ module.Category }}"";

        {{~ for member in module.Members ~}}
        /// <summary>
        /// {{ member.Description | string.replace '\n' '\n        ///' }}
        {{~ for param in member.Parameters ~}}
        /// <param name=""{{param.Name}}"">{{param.Description}}</param>
        {{~ end ~}}
        /// </summary>
        [KalkExport(""{{ member.Name }}"", Category)]
        {{ member.MethodDeclaration }}
        {{ member.IndirectMethodDeclaration }}
        {{~ end ~}}
    }
}
{{~ end ~}}
";

            var template = Template.Parse(templateStr);
            var result = template.Render(new {intrinsics = intrinsicModules}, x => x.Name);
            var finalPath = Path.Combine(srcFolder, "Kalk.Core/Modules/HardwareIntrinsics/Intrinsics.generated.cs");
            Console.WriteLine($"Writing intrinsics to {finalPath}");
            // Replace with platform newlines
            result = result.Replace("\r\n", "\n").Replace("\n", Environment.NewLine);
            await File.WriteAllTextAsync(finalPath, result, new UTF8Encoding(false));
        }

        private static string GetCleanedString(XNode node)
        {
            if (node.NodeType == XmlNodeType.Text)
            {
                return node.ToString();
            }

            var element = (XElement) node;
            string text;
            if (element.Name == "paramref")
            {
                text = element.Attribute("name")?.Value ?? string.Empty;
            }
            else
            {

                var builder = new StringBuilder();
                foreach (var subElement in element.Nodes())
                {
                    builder.Append(GetCleanedString(subElement));
                }

                text = builder.ToString();
            }

            if (element.Name == "para")
            {
                text = text + "\n";
            }
            return HttpUtility.HtmlDecode(text);
        }
    }
}
