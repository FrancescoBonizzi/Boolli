using System;
using System.Threading.Tasks;

namespace Boolli
{
    public class NamedAsyncBooleanFunction
    {
        public string Name { get; }
        public Func<Task<bool>> AsyncFunction { get; }

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
