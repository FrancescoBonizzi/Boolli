using System;

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
            //Console.WriteLine(_currentToken);
            if (_currentToken.TokenType == tokenType)
            {
                _currentToken = _lexer.GetNextToken();
            }
            else
                throw new Exception("Boh");
        }

        private AstNode Factor()
        {
            // factor: (not)* factor | boolean | LPAR expr RPAR
            var token = _currentToken;

            if (token.TokenType == TokenTypes.not)
            {
                Eat(TokenTypes.not);
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

            throw new Exception("Invalid factor");
        }

        private AstNode Expr()
        {
            // Grammar:
            // expr: factor((and | or) factor)*
            // factor: (not)* factor | boolean | LPAR expr RPAR
            // boolean: true | false | 0 | 1

            var node = Factor();

            while (_currentToken.TokenType == TokenTypes.and
               || _currentToken.TokenType == TokenTypes.or)
            {
                var token = _currentToken;

                switch (token.TokenType)
                {
                    case TokenTypes.and:
                        Eat(TokenTypes.and);
                        node = new AndNode(token, node, Factor());
                        break;

                    case TokenTypes.or:
                        Eat(TokenTypes.or);
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
