using Boolli.Exceptions;

namespace Boolli
{
    public class AstParser
    {
        private readonly Lexer _lexer;
        private Token _currentToken;

        public AstParser(Lexer lexer)
        {
            _lexer = lexer;
            _currentToken = _lexer.GetNextToken();
        }

        private void Eat(TokenTypes tokenType)
        {
            if (_currentToken.TokenType == tokenType)
            {
                _currentToken = _lexer.GetNextToken();
            }
            else
            {
                throw new InvalidTokenToParseException(tokenType);
            }
        }

        private AstNode Factor()
        {
            // factor: (not)* factor | boolean | LPAR expr RPAR
            var token = _currentToken;

            if (token.TokenType == TokenTypes.Not)
            {
                Eat(TokenTypes.Not);
                return new NotNode(token, Factor());
            }
            else if (token.TokenType == TokenTypes.Boolean)
            {
                Eat(TokenTypes.Boolean);
                return new BooleanNode(token);
            }
            else if (token.TokenType == TokenTypes.Lpar)
            {
                Eat(TokenTypes.Lpar);
                var node = Expr();
                Eat(TokenTypes.Rpar);
                return node;
            }

            throw new InvalidFactorException(token);
        }

        private AstNode Expr()
        {
            // Grammar:
            // expr: factor((and | or) factor)*
            // factor: (not)* factor | boolean | LPAR expr RPAR
            // boolean: true | false | 0 | 1

            var node = Factor();

            while (_currentToken.TokenType == TokenTypes.And
               || _currentToken.TokenType == TokenTypes.Or)
            {
                var token = _currentToken;

                switch (token.TokenType)
                {
                    case TokenTypes.And:
                        Eat(TokenTypes.And);
                        node = new AndNode(token, node, Factor());
                        break;

                    case TokenTypes.Or:
                        Eat(TokenTypes.Or);
                        node = new OrNode(token, node, Factor());
                        break;
                }

            }

            return node;
        }

        public AstNode Parse()
            => Expr();
    }
}
