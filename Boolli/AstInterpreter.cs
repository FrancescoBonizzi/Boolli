using Boolli.Exceptions;
using System;

namespace Boolli
{
    public class AstInterpreter 
    {
        private bool Visit(AstNode startingNode)
        {
            if (startingNode == null)
                throw new ArgumentNullException(nameof(startingNode), "AST starting node cannot be null");

            switch (startingNode)
            {
                case BooleanNode node:
                    return node.Value;

                case NotNode node:
                    return !Visit(node.LeftNode);

                case AndNode node:
                    return Visit(node.LeftNode) && Visit(node.RightNode);

                case OrNode node:
                    return Visit(node.LeftNode) || Visit(node.RightNode);
            }

            throw new UnexpectedNodeException(startingNode);
        }

        public bool Interpret(AstNode startingNode)
            => Visit(startingNode);
    }
}
