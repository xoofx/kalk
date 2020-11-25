using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using Broslyn;
using Kalk.Core;
using Microsoft.CodeAnalysis;
using Scriban;

namespace Kalk.CodeGen
{
    class Program
    {
        private static readonly Regex RemoveCode = new Regex(@"^\s*```\w*[ \t]*[\r\n]*", RegexOptions.Multiline);

        static async Task Main(string[] args)
        {
            var x = typeof(System.Composition.CompositionContext).Name;

            var rootFolder = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"../../../../.."));
            var siteFolder = Path.Combine(rootFolder, "site");
            var srcFolder = Path.Combine(rootFolder, "src");
            var testsFolder = Path.Combine(srcFolder, "Kalk.Tests");

            var pathToSolution = Path.Combine(srcFolder, @"Kalk.Core", "Kalk.Core.csproj");

            var broResult = CSharpCompilationCapture.Build(pathToSolution);
            var solution = broResult.Workspace.CurrentSolution;
            var project = solution.Projects.First(x => x.Name == "Kalk.Core");

            // Make sure that doc will be parsed
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

            //var kalkEngine = compilation.GetTypeByMetadataName("Kalk.Core.KalkEngine");

            var mapNameToModule = new Dictionary<string, KalkModuleToGenerate>();

            void GetOrCreateModule(ITypeSymbol typeSymbol, string className, AttributeData moduleAttribute, out KalkModuleToGenerate moduleToGenerate)
            {
                if (!mapNameToModule.TryGetValue(className, out moduleToGenerate))
                {
                    moduleToGenerate = new KalkModuleToGenerate()
                    {
                        Namespace = typeSymbol.ContainingNamespace.ToDisplayString(),
                        ClassName = className,
                    };
                    mapNameToModule.Add(className, moduleToGenerate);

                    if (moduleAttribute != null)
                    {
                        moduleToGenerate.Name = moduleAttribute.ConstructorArguments[0].Value.ToString();
                        moduleToGenerate.Names.Add(moduleToGenerate.Name);
                        moduleToGenerate.Category = "Modules (e.g `import Files`)";
                    }

                    ExtractDocumentation(typeSymbol, moduleToGenerate);
                }
            }

            foreach (var type in compilation.GetSymbolsWithName(x => true, SymbolFilter.Type))
            {
                var typeSymbol = type as ITypeSymbol;
                if (typeSymbol == null) continue;

                var moduleAttribute = typeSymbol.GetAttributes().FirstOrDefault(x => x.AttributeClass.Name == "KalkExportModuleAttribute");
                KalkModuleToGenerate moduleToGenerate = null;
                if (moduleAttribute != null)
                {
                    GetOrCreateModule(typeSymbol, typeSymbol.Name, moduleAttribute, out moduleToGenerate);
                }

                foreach (var member in typeSymbol.GetMembers())
                {
                    var attr = member.GetAttributes().FirstOrDefault(x => x.AttributeClass.Name == "KalkExportAttribute");
                    if (attr == null) continue;

                    var name = attr.ConstructorArguments[0].Value.ToString();
                    var category = attr.ConstructorArguments[1].Value.ToString();

                    var containingType = member.ContainingSymbol;
                    var className = containingType.Name;

                    // In case the module is built-in, we still generate a module for it
                    if (moduleToGenerate == null)
                    {
                        GetOrCreateModule(typeSymbol, className, moduleAttribute, out moduleToGenerate);
                    }

                    var method = member as IMethodSymbol;
                    var desc = new KalkMemberToGenerate()
                    {
                        Name = name,
                        XmlId = member.GetDocumentationCommentId(),
                        Category = category,
                        IsCommand = method != null && method.ReturnsVoid
                    };
                    desc.Names.Add(name);
                    
                    if (method != null)
                    {
                        desc.CSharpName = method.Name;
                        
                        var builder = new StringBuilder();
                        desc.IsAction = method.ReturnsVoid;
                        desc.IsFunc = !desc.IsAction;
                        builder.Append(desc.IsAction ? "Action" : "Func");

                        if (method.Parameters.Length > 0 || desc.IsFunc)
                        {
                            builder.Append("<");
                        }

                        for (var i = 0; i < method.Parameters.Length; i++)
                        {
                            var parameter = method.Parameters[i];
                            if (i > 0) builder.Append(", ");
                            builder.Append(GetTypeName(parameter.Type));
                        }

                        if (desc.IsFunc)
                        {
                            if (method.Parameters.Length > 0)
                            {
                                builder.Append(", ");
                            }
                            builder.Append(GetTypeName(method.ReturnType));
                        }

                        if (method.Parameters.Length > 0 || desc.IsFunc)
                        {
                            builder.Append(">");
                        }

                        desc.Cast = $"({builder.ToString()})";
                    }
                    else if (member is IPropertySymbol || member is IFieldSymbol)
                    {
                        desc.CSharpName = member.Name;
                        desc.IsConst = true;
                    }

                    moduleToGenerate.Members.Add(desc);
                    ExtractDocumentation(member, desc);
                }
            }

            var modules = mapNameToModule.Values.OrderBy(x => x.ClassName).ToList();
            
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

{{~ func GenerateDocDescriptor(item) ~}}
            {
                var descriptor = {{ if item.IsModule }}Descriptor{{ else }}Descriptors[""{{ item.Name }}""]{{ end }};
                descriptor.Category = ""{{ item.Category }}"";
                descriptor.Description = @""{{ item.Description | string.replace '""' '""""' }}"";
                descriptor.IsCommand = {{ item.IsCommand }};
            {{~ for param in item.Params ~}}
                descriptor.Params.Add(new KalkParamDescriptor(""{{ param.Name }}"", @""{{ param.Description | string.replace '""' '""""' }}"")  { IsOptional = {{ param.IsOptional }} });
            {{~ end ~}}
                {{~ if item.Returns ~}}
                descriptor.Returns = @""{{ item.Returns | string.replace '""' '""""' }}"";
                {{~ end ~}}
                {{~ if item.Remarks ~}}
                descriptor.Remarks = @""{{ item.Remarks | string.replace '""' '""""' }}"";
                {{~ end ~}}
                {{~ if item.Example ~}}
                descriptor.Example = @""{{ item.Example | string.replace '""' '""""' }}"";
                {{~ end ~}}
            }
{{~ end ~}}
{{~ for module in modules ~}}
namespace {{ module.Namespace }}
{
    public partial class {{ module.ClassName }}
    {
    {{~ if module.Name != 'All' ~}}
        {{~ if module.ClassName == 'KalkEngine' ~}}
        protected void RegisterFunctionsAuto()
        {{~ else ~}}
        protected override void RegisterFunctionsAuto()
        {{~ end ~}}
        {
            {{~ for member in module.Members ~}}
                {{~ if member.IsConst ~}}
            RegisterConstant(""{{ member.Name }}"", {{ member.CSharpName }});
                {{~ else if member.IsFunc ~}}
            RegisterFunction(""{{ member.Name }}"", {{member.Cast}}{{ member.CSharpName }});
                {{~ else if member.IsAction ~}}
            RegisterAction(""{{ member.Name }}"", {{member.Cast}}{{ member.CSharpName }});
                {{~ end ~}}
            {{~ end ~}}
            RegisterDocumentationAuto();
        }

    {{~ end ~}}
        private void RegisterDocumentationAuto()
        {
            {{~ 
            if module.Name 
                GenerateDocDescriptor module
            end
            for item in module.Members
                GenerateDocDescriptor item
            end
            ~}}
        }        
    }
}
{{~ end ~}}
";
            var template = Template.Parse(templateStr);
            
            var result = template.Render(new {modules = modules}, x => x.Name);
            File.WriteAllText(Path.Combine(srcFolder, "Kalk.Core/KalkEngine.generated.cs"), result);


            var testsTemplateStr = @"//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Date: {{ date.now }}
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using NUnit.Framework;

namespace Kalk.Tests
{
{{~ imported = {}; for module in modules; if !(imported[module.Namespace]); imported[module.Namespace] = true; ~}}
    using {{ module.Namespace }};
{{~ end; end ~}}
{{~ for module in modules ~}}

    public partial class {{ module.ClassName }}Tests : KalkTestBase
    {
        {{~ for member in module.Members ~}}
            {{~ if (array.size member.Tests) > 0 ~}}
                {{~ for test in member.Tests ~}}
        /// <summary>
        /// Test for <see cref=""{{ member.XmlId }}""/> or `{{ member.Name }}`.
        /// </summary>
        [TestCase(@""{{ test.Item1 | string.replace '""' '""""' }}"", @""{{ test.Item2 | string.replace '""' '""""' }}"", Category = ""{{ member.Category }}"")]
                {{~ end ~}}
        {{~ if module.Name ~}}
        public static void Test_{{ member.Name }}(string input, string output) => AssertScript(input, output, ""{{module.Name}}"");
        {{~ else ~}}
        public static void Test_{{ member.Name }}(string input, string output) => AssertScript(input, output);
        {{~ end ~}}

            {{~ end ~}}
        {{~ end ~}}
    }
{{~ end ~}}
}
";
            var templateTests = Template.Parse(testsTemplateStr);

            result = templateTests.Render(new { modules = modules }, x => x.Name);
            File.WriteAllText(Path.Combine(testsFolder, "KalkTests.generated.cs"), result);

            // Prism templates
            var prismTemplateStr = @"Prism.languages.kalk.function = /\b(?:{{ functions | array.join '|' }})\b/;
";
            var prismTemplate = Template.Parse(prismTemplateStr);

            var allFunctionNames = modules.SelectMany(x => x.Members.Select(y => y.Name)).ToList();
            // special values
            allFunctionNames.AddRange(new []{"null", "true", "false"});
            // modules
            allFunctionNames.AddRange(new[] {"All", "Csv", "Currencies", "Files", "HardwareIntrinsics", "StandardUnits", "Strings", "Web"});

            allFunctionNames = allFunctionNames.OrderByDescending(x => x.Length).ThenBy(x => x).ToList();
            result = prismTemplate.Render(new { functions = allFunctionNames });
            File.WriteAllText(Path.Combine(siteFolder, ".lunet", "js", "prism-kalk.generated.js"), result);

            // Log any errors if a member doesn't have any doc or tests
            int functionWithMissingDoc = 0;
            int functionWithMissingTests = 0;
            foreach (var module in modules)
            {
                foreach (var member in module.Members)
                {
                    var hasNoDesc = string.IsNullOrEmpty(member.Description);
                    var hasNoTests = member.Tests.Count == 0;
                    if ((hasNoDesc || hasNoTests) && !module.ClassName.Contains("Intrinsics"))
                    {
                        // We don't log for all the matrix constructors, as they are tested separately.
                        if (module.ClassName != "VectorModule" || !member.CSharpName.StartsWith("Create"))
                        {
                            if (hasNoDesc) ++functionWithMissingDoc;
                            if (hasNoTests) ++functionWithMissingTests;
                            Console.WriteLine($"The member {member.Name} => {module.ClassName}.{member.CSharpName} doesn't have {(hasNoTests ? "any tests" + (hasNoDesc ? " and" : "") : "")} {(hasNoDesc ? "any docs" : "")}");
                        }
                    }
                }
            }

            Console.WriteLine($"{modules.Count} modules generated.");
            Console.WriteLine($"{modules.SelectMany(x => x.Members).Count()} functions generated.");
            Console.WriteLine($"{modules.SelectMany(x => x.Members).SelectMany(y => y.Tests).Count()} tests generated.");
            Console.WriteLine($"{functionWithMissingDoc} functions with missing doc.");
            Console.WriteLine($"{functionWithMissingTests} functions with missing tests.");
        }

        private static readonly Regex PromptRegex = new Regex(@"^(\s*)>>>\s");

        private static (string, string)? TryParseTest(string text)
        {
            var testLines = new StringReader(text);
            string line;
            string input = null;
            string output = string.Empty;
            int startColumn = -1;
            while ((line = testLines.ReadLine()) != null)
            {
                line = line.TrimEnd();
                var matchPrompt = PromptRegex.Match(line);
                if (matchPrompt.Success)
                {
                    startColumn = matchPrompt.Groups[1].Length;
                    input += line.Substring(matchPrompt.Length) + Environment.NewLine;
                }
                else
                {
                    if (startColumn < 0) throw new InvalidOperationException($"Expecting a previous prompt line >>> before `{line}`");
                    line = line.Length >= startColumn ? line.Substring(startColumn) : line;
                    // If we have a result with ellipsis `...` we can't test this text.
                    if (line.StartsWith("..."))
                    {
                        return null;
                    }
                    output += line + Environment.NewLine;
                }
            }

            return input != null ? (input.TrimEnd(), output.TrimEnd()) : ((string, string)?)null;
        }

        private static void ExtractDocumentation(ISymbol symbol, KalkDescriptorToGenerate desc)
        {
            var xmlStr = symbol.GetDocumentationCommentXml();
            try
            {

                if (!string.IsNullOrEmpty(xmlStr))
                {
                    var xmlDoc = XElement.Parse(xmlStr);
                    var elements = xmlDoc.Elements().ToList();

                    foreach (var element in elements)
                    {
                        var text = GetCleanedString(element).Trim();
                        if (element.Name == "summary")
                        {
                            desc.Description = text;
                        }
                        else if (element.Name == "param")
                        {
                            var argName = element.Attribute("name")?.Value;
                            if (argName != null && symbol is IMethodSymbol method)
                            {
                                var parameterSymbol = method.Parameters.FirstOrDefault(x => x.Name == argName);
                                bool isOptional = false;
                                if (parameterSymbol == null)
                                {
                                    Console.WriteLine($"Invalid XML doc parameter name {argName} not found on method {method}");
                                }
                                else
                                {
                                    isOptional = parameterSymbol.IsOptional;
                                }

                                desc.Params.Add(new KalkParamDescriptor(argName, text) {IsOptional = isOptional});
                            }
                        }
                        else if (element.Name == "returns")
                        {
                            desc.Returns = text;
                        }
                        else if (element.Name == "remarks")
                        {
                            desc.Remarks = text;
                        }
                        else if (element.Name == "example")
                        {
                            text = RemoveCode.Replace(text, string.Empty);
                            desc.Example = text;
                            var test = TryParseTest(text);
                            if (test != null)
                            {
                                desc.Tests.Add(test.Value);
                            }
                        }
                        else if (element.Name == "test")
                        {
                            text = RemoveCode.Replace(text, string.Empty);
                            var test = TryParseTest(text);
                            if (test != null)
                            {
                                desc.Tests.Add(test.Value);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error while processing `{symbol}` with XML doc `{xmlStr}", ex);
            }
        }


        static string GetTypeName(ITypeSymbol typeSymbol)
        {
            //if (typeSymbol is IArrayTypeSymbol arrayTypeSymbol)
            //{
            //    return GetTypeName(arrayTypeSymbol.ElementType) + "[]";
            //}

            //if (typeSymbol.Name == typeof(Nullable).Name)
            //{
            //    return typeSymbol.ToDisplayString();
            //}
           
            //if (typeSymbol.Name == "String") return "string";
            //if (typeSymbol.Name == "Object") return "object";
            //if (typeSymbol.Name == "Boolean") return "bool";
            //if (typeSymbol.Name == "Single") return "float";
            //if (typeSymbol.Name == "Double") return "double";
            //if (typeSymbol.Name == "Int32") return "int";
            //if (typeSymbol.Name == "Int64") return "long";
            return typeSymbol.ToDisplayString();
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
