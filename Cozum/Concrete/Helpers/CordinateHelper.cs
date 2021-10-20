using Cozum.Concrete.Models;
using Cozum.Interfaces.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cozum.Concrete.Helpers
{
    public class CordinateHelper : ICordinateHelper
    {        
        public Tuple<int, int> GetValuesFromUserForCordinateSystem(string cordinateSystem)
        {
            string[] cordinates = cordinateSystem.Trim().Split(" ");
            int xLength = Convert.ToInt32(cordinates[0]);
            int yLength = Convert.ToInt32(cordinates[1]);

            return Tuple.Create(xLength, yLength);
        }

        public List<Cordinate> CreateCordinateSystem(int xLength, int yLength)
        {
            List<Cordinate> rectangleCordinate = new List<Cordinate>();


            for (int y = yLength; y >= 0; y--)
            {
                for (int x = 0; x <= xLength; x++)
                {
                    rectangleCordinate.Add(new Cordinate()
                    {
                        cordinateX = x,
                        cordinateY = y
                    });
                }
            }

            return rectangleCordinate;
        }

        public void ShowCordinateSystemInConsole(List<Cordinate> rectangleCordinate)
        {
            int temp = rectangleCordinate.FirstOrDefault().cordinateX;

            foreach (var item in rectangleCordinate)
            {
                if (temp != item.cordinateX)
                {
                    Console.Write("(" + item.cordinateX + "," + item.cordinateY + ") ");
                }
                else
                {
                    Console.WriteLine();
                    Console.Write("(" + item.cordinateX + "," + item.cordinateY + ") ");
                    temp = item.cordinateX;
                }
            }
            Console.WriteLine();
        }
    }
}
