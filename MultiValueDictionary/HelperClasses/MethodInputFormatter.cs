using MultiValueDictionary.Enums;
using System;

namespace MultiValueDictionary.HelperClasses
{
    public class MethodInputFormatter
    {

        public MethodInputFormatter() { }

        /// <summary>
        /// Converts the string input from the user to the correct MethodType
        /// </summary>
        /// <param name="input"> Method name passed in from the console </param>
        /// <returns> Converted MethodType Enum </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MethodType GetMethodType(string input)
        {
            MethodType methodFormatted;

            if (input == null) throw new ArgumentNullException("Must provide some type of method call");
            var result = Enum.TryParse<MethodType>(input, out methodFormatted);

            if (result)
                return methodFormatted;

            return MethodType.BADMETHOD;
        }
    }
}
