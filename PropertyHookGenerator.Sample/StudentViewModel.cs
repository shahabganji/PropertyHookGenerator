using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using PropertyHookGenerator.Library;

namespace PropertyHookGenerator.Sample
{
    
    
    public partial class StudentViewModel
    {
        [DidSet(nameof(UpdateStudentName)) , NotNull]
        [Required]
        private string _name;

        [DidSet("UpdateStudentFamily")] 
        private string _family;

        public StudentViewModel(string name)
        {
            _name = name;
        }

        private void UpdateStudentName(string oldValue, string newValue)
        {
            Console.WriteLine("&&&&&&&&&&&");
            Console.Write(_name);
        }
        private void UpdateStudentFamily(string oldValue, string newValue)
        {
            Console.Write(_name);
        }
    }
}
