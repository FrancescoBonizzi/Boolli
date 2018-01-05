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
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Function name cannot be null or empty");

            Name = name;
            Function = function ?? throw new ArgumentNullException(nameof(function), "I cannot evaluate a null function");
        }
    }
}
