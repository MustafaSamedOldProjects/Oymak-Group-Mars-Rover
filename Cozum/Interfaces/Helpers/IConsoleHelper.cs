using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cozum.Interfaces.Helpers
{
    public interface IConsoleHelper
    {
        string ReadFromConsole();
        string RemoveSpaces(string input);
        public string ReadFromConsoleForPlato();
        void WriteMessageToConsole(string message);
    }
}
