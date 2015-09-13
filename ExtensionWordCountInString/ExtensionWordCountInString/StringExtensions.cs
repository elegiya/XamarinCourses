using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionWordCountInString
{
    /// <summary>
    /// Class which contains extension method to string class. 
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Counts words number in passed string. Can be depended on passed separators types.
        /// </summary>
        /// <param name="inputString">String to count words.</param>
        /// <param name="options">Separators types.</param>
        /// <returns>Number words in string.</returns>
        public static int WordsCount(this string inputString,
            SeparateStringOptions options = SeparateStringOptions.WordOnlyFromLetters)
        {
            char[] separators = SeparatorsForStringSplit(options);
            return inputString.Split(separators, StringSplitOptions.RemoveEmptyEntries).Count();
        }

        private static char[] SeparatorsForStringSplit(SeparateStringOptions options)
        {
            var allSeparators = Enumerable.Range(char.MinValue, char.MaxValue)
                .Select(c => (char) c).Where(c => !char.IsControl(c));
            IEnumerable<char> actualSeparators;
            switch (options)
            {
                case SeparateStringOptions.WordOnlyFromLetters:
                    actualSeparators = allSeparators.Where(c => !char.IsLetter(c));
                    break;
                case SeparateStringOptions.WordFromLettersAndDigits:
                    actualSeparators =
                        allSeparators.Where(c => !char.IsLetter(c) && !char.IsDigit(c) && !char.IsNumber(c));
                    break;
                case SeparateStringOptions.WordFromSymbolsOtherThanSpaces:
                    actualSeparators = allSeparators.Where(c => char.IsSeparator(c));
                    break;
                default:
                    throw new ArgumentException("You have entered a wrong convert option. Please, check it!");
                    break;
            }

            return actualSeparators.ToArray();
        }
    }
}
