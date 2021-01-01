using System;

namespace PropertyHookGenerator.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = new StudentViewModel("Shahab");

            student.Name = "Hamed";
            
            Console.WriteLine("Hello World!");
        }
    }
}
