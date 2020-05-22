using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using Kalk.Core;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using Scriban;

namespace Kalk.CodeGen
{
    class Program
    {
        internal class ModuleToGenerate
        {
            public ModuleToGenerate()
            {
                Members = new List<FuncMember>();
                Descriptors = new List<KalkDescriptor>();
            }

            public string Namespace { get; set; }

            public string ClassName { get; set; }

            public List<FuncMember> Members { get; }

            public List<KalkDescriptor> Descriptors { get; }
        }

        internal class FuncMember
        {
            public string Name { get; set; }

            public string CSharpName { get; set; }

            public bool IsFunc { get; set; }
            
            public bool IsAction { get; set; }

            public bool IsConst { get; set; }

            public string Cast { get; set; }
        }
        
        static async Task Main(string[] args)
        {
            Microsoft.Build.Locator.MSBuildLocator.RegisterDefaults();

            var x = typeof(System.Composition.CompositionContext).Name;

            var workspace = MSBuildWorkspace.Create(new Dictionary<string, string>()
            {
//               {"TargetFramework", "netcoreapp3.1"},
            });

            var srcFolder = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"../../../.."));
            
            var pathToSolution = Path.Combine(srcFolder, @"kalk.sln");
            var solution = await workspace.OpenSolutionAsync(pathToSolution);

            // Force this assembly to reference the following types in order to compile Kalk.Core correctly
            // (this is awful but Roslyn doesn't help us here)
            Console.WriteLine($"Using {typeof(Unsafe).Assembly.FullName}");
            Console.WriteLine($"Using {typeof(CsvHelper.CsvParser).Assembly.FullName}");
            Console.WriteLine($"Using {typeof(HttpClient).Assembly.FullName}");
            Console.WriteLine($"Using {typeof(BigInteger).Assembly.FullName}");
            Console.WriteLine($"Using {typeof(HttpStatusCode).Assembly.FullName}");

            var project = solution.Projects.First(x => x.Name == "Kalk.Core");
            //var scriban = solution.Projects.First(x => x.Name == "Scriban");
            //project = project.AddMetadataReferences(scriban.MetadataReferences);

            string homePath = (Environment.OSVersion.Platform == PlatformID.Unix ||
                               Environment.OSVersion.Platform == PlatformID.MacOSX)
                ? Environment.GetEnvironmentVariable("HOME")
                : Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (assembly.IsDynamic) continue;
                if (assembly.GetName().Name == "Scriban") continue;
                project = project.AddMetadataReference(MetadataReference.CreateFromFile(assembly.Location));
            }

            {
                var refPackage = Path.Combine(homePath, ".nuget", "packages", "mathnet.numerics", "4.9.1", "lib", "netstandard2.0", "MathNet.Numerics.dll");
                project = project.AddMetadataReference(MetadataReference.CreateFromFile(refPackage));
            }
            {
                var refPackage = Path.Combine(homePath, ".nuget", "packages", "System.Text.Encoding.CodePages", "4.7.0", "lib", "netstandard2.0", "System.Text.Encoding.CodePages.dll");
                project = project.AddMetadataReference(MetadataReference.CreateFromFile(refPackage));
            }

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

            var mapNameToModule = new Dictionary<string, ModuleToGenerate>();

            foreach (var type in compilation.GetSymbolsWithName(x => true, SymbolFilter.Type))
            {
                var typeSymbol = type as ITypeSymbol;
                if (typeSymbol == null) continue;

                foreach (var member in typeSymbol.GetMembers())
                {
                    var attr = member.GetAttributes().FirstOrDefault(x => x.AttributeClass.Name == "KalkDocAttribute");
                    if (attr == null) continue;

                    var name = attr.ConstructorArguments[0].Value.ToString();
                    var category = attr.ConstructorArguments[1].Value.ToString();

                    var className = member is ITypeSymbol ? member.Name : member.ContainingSymbol.Name;

                    if (!mapNameToModule.TryGetValue(className, out var moduleToGenerate))
                    {
                        moduleToGenerate = new ModuleToGenerate()
                        {
                            Namespace = member.ContainingNamespace.ToDisplayString(),
                            ClassName = className
                        };
                        mapNameToModule.Add(className, moduleToGenerate);
                    }

                    FuncMember funcMember = null;
                    if (member is IMethodSymbol methodSymbol)
                    {
                        funcMember = new FuncMember()
                        {
                            CSharpName = methodSymbol.Name
                        };
                        var builder = new StringBuilder();
                        funcMember.IsAction = methodSymbol.ReturnsVoid;
                        funcMember.IsFunc = !funcMember.IsAction;
                        builder.Append(funcMember.IsAction ? "Action" : "Func");

                        if (methodSymbol.Parameters.Length > 0 || funcMember.IsFunc)
                        {
                            builder.Append("<");
                        }

                        for (var i = 0; i < methodSymbol.Parameters.Length; i++)
                        {
                            var parameter = methodSymbol.Parameters[i];
                            if (i > 0) builder.Append(", ");
                            builder.Append(GetTypeName(parameter.Type));
                        }

                        if (funcMember.IsFunc)
                        {
                            if (methodSymbol.Parameters.Length > 0)
                            {
                                builder.Append(", ");
                            }
                            builder.Append(GetTypeName(methodSymbol.ReturnType));
                        }

                        if (methodSymbol.Parameters.Length > 0 || funcMember.IsFunc)
                        {
                            builder.Append(">");
                        }

                        funcMember.Cast = $"({builder.ToString()})";
                    }
                    else if (member is IPropertySymbol || member is IFieldSymbol)
                    {
                        funcMember = new FuncMember { CSharpName = member.Name, IsConst = true };
                    }

                    if (funcMember != null)
                    {
                        funcMember.Name = name;
                        moduleToGenerate.Members.Add(funcMember);
                    }

                    var xmlStr = member.GetDocumentationCommentXml();

                    var method = member as IMethodSymbol;

                    var descriptor = new KalkDescriptor
                    {
                        Category = category,
                        IsCommand = method != null && method.ReturnsVoid
                    };
                    moduleToGenerate.Descriptors.Add(descriptor);
                    descriptor.Names.Add(name);

                    if (!string.IsNullOrEmpty(xmlStr))
                    {
                        var xmlDoc = XElement.Parse(xmlStr);
                        var elements = xmlDoc.Elements().ToList();

                        foreach (var element in elements)
                        {
                            var text = Escape(GetCleanedString(element).Trim());
                            if (element.Name == "summary")
                            {
                                descriptor.Description = text;
                            }
                            else if (element.Name == "param")
                            {
                                var argName = element.Attribute("name").Value;
                                if (method != null)
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

                                    descriptor.Params.Add(new KalkParamDescriptor(element.Attribute("name").Value, text) {IsOptional = isOptional});
                                }
                            }
                            else if (element.Name == "returns")
                            {
                                descriptor.Returns = text;
                            }
                            else if (element.Name == "remarks")
                            {
                                descriptor.Remarks = text;
                            }
                        }
                    }
                }
            }


            string Escape(string text) => text.Replace("\"", "\"\"");

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
{{~ for module in modules ~}}

namespace {{ module.Namespace }}
{
    public partial class {{ module.ClassName }}
    {
        protected void RegisterFunctionsAuto()
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

        private void RegisterDocumentationAuto()
        {
            {{~ for item in module.Descriptors ~}}
            {
                var descriptor = Descriptors[""{{ item.Names[0] }}""];
                descriptor.Category = ""{{ item.Category }}"";
                descriptor.Description = @""{{ item.Description }}"";
                descriptor.IsCommand = {{ item.IsCommand }};
            {{~ for param in item.Params ~}}
                descriptor.Params.Add(new KalkParamDescriptor(""{{ param.Name }}"", @""{{ param.Description }}"")  { IsOptional = {{ param.IsOptional }} });
            {{~ end ~}}
                {{~ if item.Returns ~}}
                descriptor.Returns = @""{{ item.Returns }}"";
                {{~ end ~}}
            }
            {{~ end ~}}
        }        
    }
}
{{~ end ~}}
";
            var template = Template.Parse(templateStr);

            var result = template.Render(new {modules = modules}, x => x.Name);
            
            File.WriteAllText(Path.Combine(srcFolder, "Kalk.Core/KalkEngine.generated.cs"), result);
            //Console.WriteLine(result);
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
            return HttpUtility.HtmlDecode(text);
        }

        private class ConsoleProgressReporter : IProgress<ProjectLoadProgress>
        {
            public void Report(ProjectLoadProgress loadProgress)
            {
                var projectDisplay = Path.GetFileName(loadProgress.FilePath);
                if (loadProgress.TargetFramework != null)
                {
                    projectDisplay += $" ({loadProgress.TargetFramework})";
                }

                Console.WriteLine($"{loadProgress.Operation,-15} {loadProgress.ElapsedTime,-15:m\\:ss\\.fffffff} {projectDisplay}");
            }
        }
    }
}
