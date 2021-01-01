using System;
using PropertyHookGenerator.Library;

namespace PropertyHookGenerator.Sample
{
    public partial class StudentViewModel
    {
        [DidSet(nameof(BeforeNameUpdate))]
        private readonly string _name;

        public StudentViewModel(string name)
        {
            _name = name;
        }

        private void BeforeNameUpdate(string oldValue, string newValue)
        {
            Console.Write(_name);
        }
    }
}
