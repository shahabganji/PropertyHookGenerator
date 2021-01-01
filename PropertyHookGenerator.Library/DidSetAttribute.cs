namespace PropertyHookGenerator.Library
{
    using System;
    
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false , Inherited = false)]
    public sealed class DidSetAttribute : Attribute
    {
        public DidSetAttribute(string methodName)
        {
        }
        
        // public DidSetAttribute(string beforeSetMethod , string afterSetMethod)
        // {
        // }
    }
}
