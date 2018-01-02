using System;

namespace Boolli
{
    public class NamedBooleanFunction
    {
        public string Name { get; }
        public Func<bool> Function { get; }

        public NamedBooleanFunction(
            string name, Func<bool> function)
        {
            Name = name;
            Function = function;
        }
    }
}
