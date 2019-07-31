using System;

namespace Boolli.Exceptions
{
    internal class EmptyExpressionException : Exception
    {
        internal EmptyExpressionException()
            : base("The boolean expression passed to the interpreter is null or empty") { }
    }
}
