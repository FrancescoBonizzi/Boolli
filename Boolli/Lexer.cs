using Boolli.Exceptions;
using Boolli.Extensions;
using System;
using System.Globalization;

namespace Boolli
{
    public class Lexer
    {
        private const char _eofChar = '^';
        private readonly string _input;

        private int _currentPosition;
        private char _currentChar;

        public Lexer(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
                throw new EmptyExpressionException();

            _input = inputString.ToLower(CultureInfo.InvariantCulture);
            _currentPosition = 0;
            _currentChar = _input[_currentPosition];
        }

        private bool IsEOF
         => _currentPosition > _input.Length - 1;

        private void Advance()
        {
            ++_currentPosition;
            if (IsEOF)
            {
                _currentChar = _eofChar;
            }
            else
            {
                _currentChar = _input[_currentPosition];
            }
        }

        private void SkipWhitespaces()
        {
            while (char.IsWhiteSpace(_currentChar) && _currentChar != _eofChar)
                Advance();
        }

        private bool ParseBoolean()
        {
            int startingPosition = _currentPosition;
            while ((!char.IsWhiteSpace(_currentChar) && _currentChar != ')' && _currentChar != '(') && _currentChar != _eofChar)
            {
                Advance();
            }

            string value = _input.Substring(startingPosition, _currentPosition - startingPosition);

            switch (value)
            {
                case "true":
                case "1":
                    return true;

                case "false":
                case "0":
                    return false;
            }

            throw new Exception($"Non boolean value: {value}");
        }

        private Token ParseOperand()
        {
            switch (_currentChar)
            {
                case '(':
                    Advance();
                    return new Token()
                    {
                        TokenType = TokenTypes.Lpar,
                        TokenValue = "("
                    };

                case ')':
                    Advance();
                    return new Token()
                    {
                        TokenType = TokenTypes.Rpar,
                        TokenValue = ")"
                    };
            }

            // Skipping whitespaces
            int startingPosition = _currentPosition;
            while (!char.IsWhiteSpace(_currentChar) && _currentChar != _eofChar)
            {
                Advance();
            }

            string operand = _input.Substring(startingPosition, _currentPosition - startingPosition);

            switch (operand)
            {
                case "and":
                case "&&":
                    Advance();
                    return new Token()
                    {
                        TokenType = TokenTypes.And,
                        TokenValue = operand
                    };

                case "or":
                case "||":
                    Advance();
                    return new Token()
                    {
                        TokenType = TokenTypes.Or,
                        TokenValue = operand
                    };

                case "not":
                case "!":
                    Advance();
                    return new Token()
                    {
                        TokenType = TokenTypes.Not,
                        TokenValue = operand
                    };
            }

            throw new InvalidLexemException(_currentChar, _input, _currentPosition);
        }

        public Token GetNextToken()
        {
            while (_currentChar != _eofChar)
            {
                if (char.IsWhiteSpace(_currentChar))
                {
                    SkipWhitespaces();
                    continue;
                }
                else if (_currentChar == 't'
                    || _currentChar == 'f'
                    || _currentChar == '0'
                    || _currentChar == '1')
                {
                    var boolean = ParseBoolean();
                    return new Token()
                    {
                        TokenType = TokenTypes.Boolean,
                        TokenValue = boolean.ToBoolliString()
                    };
                }
                else
                {
                    return ParseOperand();
                }

                throw new InvalidLexemException(_currentChar, _input, _currentPosition);
            }

            return new Token()
            {
                TokenType = TokenTypes.Eof,
                TokenValue = "None"
            };
        }
    }
}
