namespace Boolli
{
    internal class AstNode
    {
        public Token Token { get; }
        public AstNode LeftNode { get; }
        public AstNode RightNode { get; }

        public AstNode(Token token, AstNode leftNode, AstNode rightNode)
        {
            Token = token;
            LeftNode = leftNode;
            RightNode = rightNode;
        }
    }
}
