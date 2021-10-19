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
        public Tuple<int, int> GetValuesFromUserForCordinateSystem()
        {
            Console.WriteLine("Lütfen Bir Dikdörtgen Giriniz");

            string input = Console.ReadLine();

            string inputReadable = input.Replace(" ", "");


            int xLength = Convert.ToInt32(inputReadable.Substring(0, 1));
            int yLength = Convert.ToInt32(inputReadable.Substring(1, 1));

            return Tuple.Create(xLength, yLength);
        }

        public List<Cordinate> CreateCordinateSystem(int xLength, int yLength)
        {
            List<Cordinate> rectangleCordinate = new List<Cordinate>();

            for (int x = xLength; x >= 0; x--)
            {
                for (int y = 0; y <= yLength; y++)
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
            throw new NotImplementedException();
        }
    }
}
