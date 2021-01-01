using PropertyHookGenerator.Library;

namespace PropertyHookGenerator.Sample
{
    public partial class StudentViewModel
    {
        [DidSet(nameof(BeforeNameUpdate))]
        private string _name;

        private void BeforeNameUpdate(string oldValue, string newValue)
        {
        }
    }
}
