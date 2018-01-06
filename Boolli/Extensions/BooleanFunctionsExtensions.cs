using System;
using System.Threading.Tasks;

namespace Boolli.Extensions
{
    /// <summary>
    /// Syntactic sugar to build Named(Async)BooleanFunction functions
    /// </summary>
    public static class BooleanFunctionsExtensions
    {
        /// <summary>
        /// Syntactic sugar to build a NamedBooleanFunction
        /// </summary>
        /// <param name="function"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static NamedBooleanFunction ToNamedBooleanFunction(this Func<bool> function, string name)
            => new NamedBooleanFunction(name, function);

        /// <summary>
        /// Syntactic sugar to build a NamedAsyncBooleanFunction
        /// </summary>
        /// <param name="function"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static NamedAsyncBooleanFunction ToNamedAsyncBooleanFunction(this Func<Task<bool>> function, string name)
            => new NamedAsyncBooleanFunction(name, function);
    }
}
