using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;

namespace PropertyHookGenerator.Library
{
    [Generator]
    public sealed class PropertyHookGenerator : ISourceGenerator
    {
        public PropertyHookGenerator()
        {
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            #if DEBUG
                System.Diagnostics.Debugger.Launch();
            #endif
            
            context.RegisterForSyntaxNotifications(() => new FieldDeclarationSyntaxReceiver());
        }

        public void Execute(GeneratorExecutionContext context)
        {
            context.AddSource(nameof(DidSetAttribute),
                SourceText.From(Constants.DidSetAttribute, Encoding.UTF8));

            if (!(context.SyntaxReceiver is FieldDeclarationSyntaxReceiver syntaxReceiver))
                return;

            CSharpParseOptions options =
                (context.Compilation as CSharpCompilation)?.SyntaxTrees[0].Options as CSharpParseOptions;
            
            Compilation compilation = context.Compilation.AddSyntaxTrees(
                CSharpSyntaxTree.ParseText(SourceText.From(Constants.DidSetAttribute, Encoding.UTF8), options));
            
            INamedTypeSymbol didSetAttributeSymbol =
                compilation.GetTypeByMetadataName($"System.{nameof(Constants.DidSetAttribute)}");
            
            foreach (var fieldDeclaration in syntaxReceiver.FieldDeclarations)
            {
                SemanticModel model = compilation.GetSemanticModel(fieldDeclaration.SyntaxTree);
                var fieldSymbol = model.GetDeclaredSymbol(fieldDeclaration);

                var attr = fieldSymbol!.GetAttributes().FirstOrDefault(
                    attributeData => attributeData.AttributeClass != null && attributeData.AttributeClass.Equals(didSetAttributeSymbol,
                        SymbolEqualityComparer.Default));
                
                // if it does not have the [DidSet]
                if(attr == null) continue;

                var beforeMethodName = attr.ConstructorArguments.First();
                
            }
        }
    }
}
