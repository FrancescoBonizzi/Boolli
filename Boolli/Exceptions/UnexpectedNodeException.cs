﻿using System;

namespace Boolli.Exceptions
{
    public class UnexpectedNodeException : Exception
    {
        public AstNode Node { get; }

        public UnexpectedNodeException(AstNode node)
            : base($"Node with token {node.Token.TokenType.ToString()}, {node.Token.TokenValue} is unespected.")
        {
            Node = node;
        }
    }
}