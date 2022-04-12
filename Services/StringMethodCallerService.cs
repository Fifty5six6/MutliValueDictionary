using MultiValueDictionary.Enums;
using MultiValueDictionary.Interfaces;
using System;
using System.Linq;

namespace MultiValueDictionary.Services
{
    public class StringMethodCallerService
    {
        public StringMethodCallerService() { }

        /// <summary>
        /// Executes the specified method
        /// </summary>
        /// <param name="methodToCall"> Enum of method type to call </param>
        /// <param name="userInput"> Arguments passed </param>
        /// <param name="mvDict"> MultiValueDictionary to update </param>
        public void CallMethod(MethodType methodToCall, string[] userInput, IMultiValueDictionary<string, string> mvDict)
        {
            switch (methodToCall)
            {

                case MethodType.ADD:
                    mvDict.Add(userInput[1], userInput[2]);
                    Console.WriteLine(") Added");
                    break;

                case MethodType.MEMBERS:
                    var members = mvDict.Members(userInput[1]);
                    var index = 0;

                    foreach (var member in members)
                    {
                        index++;
                        Console.WriteLine(index + ") " + member);
                    }

                    Console.WriteLine();
                    break;

                case MethodType.KEYS:
                    var keys = mvDict.Keys();
                    index = 0;

                    if (keys.Count() <= 0)
                        Console.WriteLine("(Empty set)");

                    foreach (var key in keys)
                    {
                        index++;
                        Console.WriteLine(index + ")" + key);
                    }

                    Console.WriteLine();
                    break;

                case MethodType.REMOVE:
                    mvDict.Remove(userInput[1], userInput[2]);
                    Console.WriteLine(") Removed");
                    break;

                case MethodType.REMOVEALL:
                    mvDict.RemoveAll(userInput[1]);
                    Console.WriteLine(") Removed");
                    Console.WriteLine();
                    break;

                case MethodType.CLEAR:
                    mvDict.Clear();
                    Console.WriteLine(") Cleared");
                    Console.WriteLine();
                    break;

                case MethodType.KEYEXISTS:
                    Console.WriteLine(mvDict.KeyExists(userInput[1]).ToString());
                    break;

                case MethodType.MEMBEREXISTS:
                    Console.WriteLine(mvDict.MemberExists(userInput[1], userInput[2]).ToString());
                    break;

                case MethodType.ALLMEMBERS:
                    var allMembers = mvDict.AllMembers();
                    index = 0;

                    if (allMembers.Count() <= 0)
                        Console.WriteLine("(Empty set)");

                    foreach (var member in allMembers)
                    {
                        index++;
                        Console.WriteLine(index + ")" + member);
                    }
                    break;

                case MethodType.ITEMS:
                    var items = mvDict.Items();

                    if (items.Count() <= 0)
                        Console.WriteLine("(Empty set)");

                    foreach (var item in items)
                    {
                        Console.WriteLine(item.Key + " : " + item.Value);
                    }

                    break;

                case MethodType.BADMETHOD:
                    Console.WriteLine("Invalid method name passed");

                    break;

            }
        }
    }
}
