using Cozum.Interfaces.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cozum.Concrete.Helpers
{
    public class ConsoleHelper : IConsoleHelper
    {
        public string ReadFromConsole()
        {
            string input = Console.ReadLine();

            string inputRemovedSpaces = RemoveSpaces(input);

            return inputRemovedSpaces.ToUpper();

        }
        public string RemoveSpaces(string input)
        {
            return input.Replace(" ", ""); ;
        }
        public string ReadFromConsoleForPlato()
        {
            string input = Console.ReadLine();

            return input.ToUpper();

        }


        public void WriteMessageToConsole(string message)
        {
            Console.WriteLine(message);
        }
    }
}
