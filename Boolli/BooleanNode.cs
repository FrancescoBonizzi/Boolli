using System;

namespace Boolli
{
    public class BooleanNode : AstNode
    {
        public bool Value { get; }

        public BooleanNode(Token token)
            : base(token, null, null)
        {
            Value = Convert.ToBoolean(token.TokenValue);
        }
    }
}
