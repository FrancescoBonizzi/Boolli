using System;

namespace Boolli
{
    public class AstInterpreter 
    {
        private bool Visit(AstNode startingNode)
        {
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

            throw new Exception("Something went wrong");
        }

        public bool Interpret(AstNode startingNode)
            => Visit(startingNode);
    }
}
