using System;

namespace Boolli.Exceptions
{
    public class EmptyExpressionException : Exception
    {
        public EmptyExpressionException()
        : base("The boolean expression passed to the interpreter is null or empty") { }
    }
}
