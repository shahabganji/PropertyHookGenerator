namespace PropertyHookGenerator.Library
{
    public sealed class Constants
    {
        public const string DidSetAttribute = @"
using System;
namespace PropertyHookGenerator.Library
{
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
}";
    }
}
