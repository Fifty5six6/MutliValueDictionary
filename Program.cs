using MultiValueDictionary.HelperClasses;
using MultiValueDictionary.Models;
using MultiValueDictionary.Services;
using System;

namespace MultiValueDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var MVDict = new MultiValueDictionary<string, string>();

            var UserConsole = new MultiValueDictionaryPrinterService(MVDict);

            var MethodFormatter = new MethodInputFormatter();

            var MethodCaller = new StringMethodCallerService();

            var MethodInputValidator = new MethodInputValidator();

            while(true) {
                try
                {
                    var userInput = UserConsole.GetUserInputFromConsoleAndValidate();

                    var methodToCall = MethodFormatter.GetMethodType(userInput[0]);

                    MethodInputValidator.ValidateMethodArguments(methodToCall, userInput);

                    MethodCaller.CallMethod(methodToCall, userInput, MVDict);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(") Error: " + ex.Message);
                    Console.WriteLine();
                }                             
            }
        }
    }
}
