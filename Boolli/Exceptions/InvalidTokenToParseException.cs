using System;

namespace Boolli.Exceptions
{
    internal class InvalidTokenToParseException : Exception
    {
        public TokenTypes TokenType { get; }

        public InvalidTokenToParseException(TokenTypes tokenType)
            : base($"Token type {tokenType.ToString()} cannot be eaten")
        {
            TokenType = tokenType;
        }
    }
}
