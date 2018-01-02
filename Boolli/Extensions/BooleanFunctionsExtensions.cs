using System;

namespace Boolli.Extensions
{
    public static class BooleanFunctionsExtensions
    {
        public static NamedBooleanFunction ToBooleanFunction(this Func<bool> function, string name)
            => new NamedBooleanFunction(name, function);
    }
}
