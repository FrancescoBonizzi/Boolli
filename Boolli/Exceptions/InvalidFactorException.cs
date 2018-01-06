using System;

namespace Boolli.Exceptions
{
    internal class InvalidFactorException : Exception
    {
        public Token Token { get; }

        public InvalidFactorException(Token token)
            : base($"Token {token.TokenType.ToString()}, with value: {token.TokenValue} is an invalid Factor")
        {
            Token = token;
        }
    }
}
