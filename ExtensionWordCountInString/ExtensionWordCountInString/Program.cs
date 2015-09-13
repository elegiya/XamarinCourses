using System;

namespace ExtensionWordCountInString
{
    /// <summary>
    /// Main application class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry application point.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        private static void Main(string[] args)
        {
            const string RESULT_STRING =
                "Your string contains {0} words. Press any key to exit...";

            Console.WriteLine("Please input your string to counts words: ");
            string inputString = Console.ReadLine();

            Console.WriteLine(
                "Do you want to check string separation symbols between words? Enter \"1\" if you want or \"0\" for using default option.");
            
            bool shouldUseOption;
            int inputOptionNumber;
            shouldUseOption = Int32.TryParse(Console.ReadLine(), out inputOptionNumber) && inputOptionNumber > 0;
            
            if (shouldUseOption)
            {
                Console.WriteLine("Please enter convert option (0-2) if you want:");
                Console.WriteLine("0 - if different words can be splitted by spaces, punctuation any number or digit.");
                Console.WriteLine("1 - if different words can be splitted only by spaces or punctiation.");
                Console.WriteLine("2 - if different words can be splitted only by spaces or system separators.");

                int checkedOptionNumber;
                Int32.TryParse(Console.ReadLine(), out checkedOptionNumber);

                try
                {
                    Console.WriteLine(string.Format(RESULT_STRING,
                        inputString.WordsCount((SeparateStringOptions) checkedOptionNumber)));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("You have entered wrong convertion type! Please check it and try again!");
                }

            }
            else
            {
                Console.WriteLine(string.Format(RESULT_STRING, inputString.WordsCount()));
            }

            Console.ReadKey();
        }
    }
}
