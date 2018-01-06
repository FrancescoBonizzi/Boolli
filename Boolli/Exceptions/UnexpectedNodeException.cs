using System;

namespace Boolli.Exceptions
{
    internal class UnexpectedNodeException : Exception
    {
        public AstNode Node { get; }

        public UnexpectedNodeException(AstNode node)
            : base($"Node with token {node.Token.TokenType.ToString()}, {node.Token.TokenValue} is unespected.")
        {
            Node = node;
        }
    }
}
