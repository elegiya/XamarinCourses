
namespace ExtensionWordCountInString
{
    /// <summary>
    /// Determines the way which string is splitted by.
    /// </summary>
    public enum SeparateStringOptions 
    {
        /// <summary>
        /// Different words are splitted by spaces, punctuation any number or digit.
        /// </summary>
        WordOnlyFromLetters = 0,

        /// <summary>
        /// Different words are splitted only by spaces or punctiation.
        /// </summary>
        WordFromLettersAndDigits = 1,

        /// <summary>
        /// Different words are splitted only by spaces or system separators.
        /// </summary>
        WordFromSymbolsOtherThanSpaces = 2
    }
}
