using System;

namespace Boolli.Exceptions
{
    public class InvalidLexemException : Exception
    {
        public char Symbol { get; }
        public string InputString { get; }
        public int Position { get; }

        public InvalidLexemException(char symbol, string inputString, int position)
            : base($"Invalid lexem found in '{inputString}' at position {position}. Symbol: '{symbol}'")
        {
            Symbol = symbol;
            InputString = inputString;
            Position = position;
        }
    }

}
