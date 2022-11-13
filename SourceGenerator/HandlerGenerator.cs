using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGenerator
{
    [Generator]
    public class HandlerGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var syntaxTress = context.Compilation.SyntaxTrees;

            var crudables = syntaxTress.Where(x => x.GetText().ToString().Contains("[Crudable]"));

            foreach (var crudable in crudables)
            {
                var classDeclaration = crudable
                    .GetRoot()
                    .DescendantNodes()
                    .OfType<ClassDeclarationSyntax>()
                    .First();

                var className = classDeclaration.Identifier.ToString();

                var source = $@"
                    public class {className}Controller
                    {{
                        
                    }}
                ";
                context.AddSource($"{className}Controller.cs", source);
            }
        }

        public void Initialize(GeneratorInitializationContext context)
        {
#if DEBUG
            if (!Debugger.IsAttached)
            {
                Debugger.Launch();
            }
#endif
        }
    }
}
