namespace Boolli
{
    internal class AndNode : AstNode
    {
        public AndNode(Token token, AstNode leftNode, AstNode rightNode)
            : base(token, leftNode, rightNode) { }
    }
}
