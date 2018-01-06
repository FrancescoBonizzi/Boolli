namespace Boolli
{
    internal class OrNode : AstNode
    {
        public OrNode(Token token, AstNode leftNode, AstNode rightNode)
            : base(token, leftNode, rightNode) { }
    }
}
