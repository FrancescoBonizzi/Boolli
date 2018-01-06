using System;

namespace Boolli.Exceptions
{
    internal class EmptyExpressionException : Exception
    {
        public EmptyExpressionException()
        : base("The boolean expression passed to the interpreter is null or empty") { }
    }
}
