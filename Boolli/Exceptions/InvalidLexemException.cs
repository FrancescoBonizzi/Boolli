﻿using System;

namespace Boolli.Exceptions
{
    internal class InvalidLexemException : Exception
    {
        public char Symbol { get; }
        public string InputString { get; }
        public int Position { get; }

        internal InvalidLexemException(char symbol, string inputString, int position)
            : base($"Invalid lexem found in '{inputString}' at position {position}. Symbol: '{symbol}'")
        {
            Symbol = symbol;
            InputString = inputString;
            Position = position;
        }
    }

}
