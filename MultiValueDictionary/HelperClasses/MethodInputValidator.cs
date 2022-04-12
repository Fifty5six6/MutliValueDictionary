using MultiValueDictionary.Enums;
using System;
using System.Linq;

namespace MultiValueDictionary.HelperClasses
{
    public class MethodInputValidator
    {

        /// <summary>
        /// Validates the correct amount of arguments were passed for the method called
        /// </summary>
        /// <param name="methodToCall"> MethodType enum to call </param>
        /// <param name="inputArguments"> Input parameters passed from the console </param>
        /// <exception cref="ArgumentException"></exception>
        public void ValidateMethodArguments(MethodType methodToCall,  string[] inputArguments)
        {
            // Removes method argument from inputArguments
            var cleanedArguments = inputArguments.Skip(1).ToArray();

            var argumentsPassedValidation = true;

            switch (methodToCall)
            {
                
                case MethodType.ADD:
                    if (cleanedArguments.Count() != 2)
                        argumentsPassedValidation = false;
                    break;

                case MethodType.MEMBERS:
                    if (cleanedArguments.Count() != 1)
                        argumentsPassedValidation = false;
                    break;

                case MethodType.KEYS:
                    if (cleanedArguments.Count() != 0)
                        argumentsPassedValidation = false;
                    break;

                case MethodType.REMOVE:
                    if (cleanedArguments.Count() != 2)
                        argumentsPassedValidation = false;
                    break;

                case MethodType.REMOVEALL:
                    var clean = cleanedArguments.Count();
                    if (cleanedArguments.Count() != 1)
                        argumentsPassedValidation = false;
                    break;

                case MethodType.CLEAR:
                    if (cleanedArguments.Count() != 0)
                        argumentsPassedValidation = false;
                    break;

                case MethodType.KEYEXISTS:
                    if (cleanedArguments.Count() != 1)
                        argumentsPassedValidation = false;
                    break;

                case MethodType.MEMBEREXISTS:
                    if (cleanedArguments.Count() != 2)
                        argumentsPassedValidation = false;
                    break;

                case MethodType.ALLMEMBERS:
                    if (cleanedArguments.Count() != 0)
                        argumentsPassedValidation = false;
                    break;

                case MethodType.ITEMS:
                    if (cleanedArguments.Count() != 0)
                        argumentsPassedValidation = false;
                    break;
            }

            if (!argumentsPassedValidation)
                throw new ArgumentException($"Incorrect amount of arguments passed for {methodToCall}");
        }


    }
}
