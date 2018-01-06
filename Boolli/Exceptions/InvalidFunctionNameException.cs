using System;
using System.Collections.Generic;

namespace Boolli.Exceptions
{
    internal class InvalidFunctionNameException : Exception
    {
        public string FunctionName { get; }

        public InvalidFunctionNameException(
            string functionName,
            IEnumerable<string> forbiddenFunctionNames)
            : base($"{functionName} isn't a valid function name. You cannot use: {string.Join(", ", forbiddenFunctionNames)} as function names")
        {
            FunctionName = functionName;
        }
    }
}
