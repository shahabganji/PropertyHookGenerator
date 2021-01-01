using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace PropertyHookGenerator.Library
{
    internal class FieldDeclarationSyntaxReceiver: ISyntaxReceiver
    {
        private readonly List<FieldDeclarationSyntax> _filedDeclarations;
        public IEnumerable<FieldDeclarationSyntax> FieldDeclarations => _filedDeclarations;

        public FieldDeclarationSyntaxReceiver()
        {
            _filedDeclarations = new List<FieldDeclarationSyntax>();
        }

        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (syntaxNode is FieldDeclarationSyntax fieldDeclarationSyntax 
                && fieldDeclarationSyntax.AttributeLists.Any())
            {
                _filedDeclarations.Add(fieldDeclarationSyntax);
            }
        }
    }
}

//
// public partial class Sample
// {
//     [Didset(nameof(BeforeUpdate))] 
//     [Willset(nameof(BeforeUpdate))]
//     private int _id;
//         
//     private void BeforeUpdate(int before, int after)
//     {
//         // implementation
//     }
//
//     private void AfterUpdate(int before, int after)
//     {
//         // implementation
//     }
// }
//
// public partial class Sample
// {
//     public int Id
//     {
//         get => _id;
//         set
//         {
//             var before = _id;
//             BeforeUpdate(before, value);
//             _id = value;
//             AfterUpdate(before, value);
//         }
//     }
