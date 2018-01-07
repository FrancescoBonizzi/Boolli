namespace Boolli
{
    /// <summary>
    /// Contains property that define the language
    /// </summary>
    public static class Domain
    {
        /// <summary>
        /// The keywords of this interpreter's language
        /// </summary>
        public static string[] LanguageKeywords { get; } = new string[]
        {
            "and", "or", "&&", "||", "&", "|", "!", "not", "true", "false", "0", "1", "^", "(", ")"
        };

        /// <summary>
        /// The char that represent the end of the expression string
        /// </summary>
        public static char EofChar = '^';
    }
}
