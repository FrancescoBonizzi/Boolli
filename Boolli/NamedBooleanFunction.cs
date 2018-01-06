using System;

namespace Boolli
{
    /// <summary>
    /// A boolean function with a name
    /// </summary>
    public class NamedBooleanFunction
    {
        /// <summary>
        /// The name of the function
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The function itself
        /// </summary>
        public Func<bool> Function { get; }

        /// <summary>
        /// Constructs a boolean function with a name
        /// </summary>
        /// <param name="name">The function's name. Cannot be null or empty</param>
        /// <param name="function">The function itself. Cannot be null</param>
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
