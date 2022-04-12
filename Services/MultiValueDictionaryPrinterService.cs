using MultiValueDictionary.Interfaces;
using System;
using System.Linq;

namespace MultiValueDictionary.Services
{
    public class MultiValueDictionaryPrinterService
    {
        private readonly IMultiValueDictionary<string, string> _dictionary;

        public MultiValueDictionaryPrinterService(IMultiValueDictionary<string, string> dictionary)
        {
            _dictionary = dictionary;
        }

        /// <summary>
        /// Gets user input splits and trims it. Validates it is not longer than the max allowed amount of arguments
        /// </summary>
        /// <returns> Split and trimmed input  </returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public string[] GetUserInputFromConsoleAndValidate()
        {
            Console.Write(">");
            string input = Console.ReadLine().Trim();

            // Split into array 
            var inputSplit = input.Split(" ");

            if (inputSplit.Count() >= 4)
            {
                throw new ArgumentOutOfRangeException("", "To many parameters passed please review documentation for correct structure");
            }

            return inputSplit;
        }
    }

}
