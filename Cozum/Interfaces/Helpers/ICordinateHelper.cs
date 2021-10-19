using Cozum.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cozum.Interfaces.Helpers
{
    public interface ICordinateHelper
    {
        Tuple<int, int> GetValuesFromUserForCordinateSystem();
        List<Cordinate> CreateCordinateSystem(int xLength, int yLength);
        void ShowCordinateSystemInConsole(List<Cordinate> rectangleCordinate);
    }
}
