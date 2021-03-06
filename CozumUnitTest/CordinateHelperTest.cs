using Cozum.Concrete.Helpers;
using Cozum.Concrete.Models;
using Cozum.Interfaces.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace CozumUnitTest
{
    public class CordinateHelperTest
    {
        private readonly CordinateHelper _cordinateHelper;

        public CordinateHelperTest()
        {
            _cordinateHelper = new CordinateHelper();
        }

        [Theory]
        [InlineData(1,1)]
        [InlineData(2,2)]
        [InlineData(3,3)]
        public void Test_For_CreateCordinateSystem(int xLength, int yLength)
        {

            List<Cordinate> values =  _cordinateHelper.CreateCordinateSystem(xLength,yLength);

            Assert.Equal((xLength + 1) * (yLength + 1), values.Count);
        }
        

        [Theory]
        [InlineData("5 5")]
        [InlineData("6 6")]
        [InlineData("3 5")]
        public void Test_For_GetValuesFromUserForCordinateSystem(string cordinateInput)
        {
            string[] cordinates = cordinateInput.Trim().Split(" ");
            Tuple<int,int> values = _cordinateHelper.GetValuesFromUserForCordinateSystem(cordinateInput);

            Assert.Equal(Convert.ToInt32(cordinates[0]), values.Item1);
            Assert.Equal(Convert.ToInt32(cordinates[1]), values.Item2);
        }
    }
}
