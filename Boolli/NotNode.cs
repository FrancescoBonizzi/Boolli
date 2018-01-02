namespace Boolli
{
    public class NotNode : AstNode
    {
        public NotNode(Token token, AstNode node)
            : base(token, node, null) { }
    }
}
