using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Generator;

[Generator]
public class ToStringGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var classes = context.SyntaxProvider
             .CreateSyntaxProvider(
                 predicate: static(node, _) => node is ClassDeclarationSyntax,
                 transform: static(ctx, _) => (ClassDeclarationSyntax)ctx.Node);

        //.Where(c => c.AttributeLists.Count > 0);
        context.RegisterSourceOutput(classes,static (ctx, source) => Execute(ctx, source));
    }

    private static void Execute(SourceProductionContext context, ClassDeclarationSyntax classDeclarationSyntax)
    {
        var namespaceName = "NotYetDefined";
        var className = classDeclarationSyntax.Identifier.Text;
        var fileName = $"{namespaceName}.{className}.g.cs";

        var stringBuilder = new System.Text.StringBuilder();
        stringBuilder.Append($@"namespace {namespaceName}
{{
   partial class {className}
{{
   //Created partial class
}}
}}
");
        context.AddSource(fileName, stringBuilder.ToString());
    }
}

