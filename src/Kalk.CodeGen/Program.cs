using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        static async Task Main(string[] args)
        {
            Microsoft.Build.Locator.MSBuildLocator.RegisterDefaults();

            var x = typeof(System.Composition.CompositionContext).Name;

            var workspace = MSBuildWorkspace.Create(new Dictionary<string, string>()
            {
               {"TargetFramework", "netstandard2.0"},
            });

            
            string homePath = (Environment.OSVersion.Platform == PlatformID.Unix || 
                               Environment.OSVersion.Platform == PlatformID.MacOSX)
                ? Environment.GetEnvironmentVariable("HOME")
                : Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");

            var srcFolder = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"../../../.."));
            
            var pathToSolution = Path.Combine(srcFolder, @"kalk.sln");
            var solution = await workspace.OpenSolutionAsync(pathToSolution);

            var project = solution.Projects.First(x => x.Name == "Kalk.Core");
            var scriban = solution.Projects.First(x => x.Name == "Scriban");
            project = project.AddMetadataReferences(scriban.MetadataReferences);

            var refMathNet = Path.Combine(homePath, ".nuget", "packages", "mathnet.numerics", "4.9.1", "lib", "netstandard2.0", "MathNet.Numerics.dll");
            project = project.AddMetadataReference(MetadataReference.CreateFromFile(refMathNet));
            
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
            
            var kalkEngine = compilation.GetTypeByMetadataName("Kalk.Core.KalkEngine");

            var descriptors = new List<KalkDescriptor>();
            
            foreach (var member in kalkEngine.GetMembers())
            {
                var attr = member.GetAttributes().FirstOrDefault(x => x.AttributeClass.Name == "KalkDocAttribute");
                if (attr == null) continue;
                
                var name = attr.ConstructorArguments[0].Value.ToString();

                
                var xmlStr  = member.GetDocumentationCommentXml();

                if (string.IsNullOrEmpty(xmlStr)) continue;
                
                var xmlDoc = XElement.Parse(xmlStr);

                var elements=  xmlDoc.Elements().ToList();

                var method = member as IMethodSymbol;

                var descriptor = new KalkDescriptor
                {
                    IsCommand = method != null && method.ReturnsVoid
                };

                descriptor.Names.Add(name);
                descriptors.Add(descriptor);

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
                            var parameterSymbol =  method.Parameters.FirstOrDefault(x => x.Name == argName);
                            bool isOptional = false;
                            if (parameterSymbol == null)
                            {
                                Console.WriteLine($"Invalid XML doc parameter name {argName} not found on method {method}");
                            }
                            else
                            {
                                isOptional = parameterSymbol.IsOptional;
                            }
                            descriptor.Params.Add(new KalkParamDescriptor(element.Attribute("name").Value, text) { IsOptional = isOptional });
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

            string Escape(string text) => text.Replace("\"", "\"\"");

            descriptors = descriptors.OrderBy(x => x.Names[0]).ToList();
            
            var templateStr = @"//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Date: {{ date.now }}
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kalk.Core
{
    public partial class KalkEngine
    {
        partial void RegisterDocumentation()
        {
            {{~ for item in descriptors ~}}
            {
                var descriptor = Descriptors[""{{ item.Names[0] }}""];
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
";
            var template = Template.Parse(templateStr);
            var result = template.Render(new {descriptors = descriptors}, x => x.Name);
            
            File.WriteAllText(Path.Combine(srcFolder, "Kalk.Core/KalkEngine.generated.cs"), result);
            //Console.WriteLine(result);
        }

        private static string GetCleanedString(XNode node)
        {
            if (node.NodeType == XmlNodeType.Text)
            {
                return node.ToString();
            }

            var element = (XElement) node;
            var builder = new StringBuilder();
            if (element.Name == "paramref")
            {
                return element.Attribute("name").Value;
            }
            
            foreach (var subElement in element.Nodes())
            {
                builder.Append(GetCleanedString(subElement));
            }

            return builder.ToString();
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
