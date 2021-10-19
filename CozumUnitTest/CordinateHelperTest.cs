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

            Assert.Equal(values.Count,(xLength+1)*(yLength+1));
        }
    }
}
