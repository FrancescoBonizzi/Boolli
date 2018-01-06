using System;
using System.Threading.Tasks;

namespace Boolli
{
    /// <summary>
    /// An async boolean function with a name
    /// </summary>
    public class NamedAsyncBooleanFunction
    {
        /// <summary>
        /// The name of the function
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The async function itself
        /// </summary>
        public Func<Task<bool>> AsyncFunction { get; }

        /// <summary>
        /// Constructs a boolean async function with a name
        /// </summary>
        /// <param name="name">The function's name. Cannot be null or empty</param>
        /// <param name="asyncFunction">The async function itself. Cannot be null</param>
        public NamedAsyncBooleanFunction(
            string name, Func<Task<bool>> asyncFunction)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Function name cannot be null or empty");

            Name = name;
            AsyncFunction = asyncFunction ?? throw new ArgumentNullException(nameof(asyncFunction), "I cannot evaluate a null function");
        }
    }
}
