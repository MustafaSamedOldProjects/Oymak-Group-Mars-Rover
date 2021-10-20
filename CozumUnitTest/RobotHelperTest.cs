using Cozum.Concrete.Helpers;
using Cozum.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CozumUnitTest
{
    public class RobotHelperTest
    {
        private readonly RobotHelper _robotHelper;

        public RobotHelperTest()
        {
            _robotHelper = new RobotHelper();
        }

        [Theory]
        [InlineData(1, 1, "N")]
        [InlineData(2, 2, "S")]
        [InlineData(3, 3, "W")]
        public void Test_For_CreateRobot(int xPosition, int yPosition, string direction)
        {

            Robot robot = _robotHelper.CreateRobot(xPosition, yPosition, direction);

            Assert.Equal(robot.Direction, direction);
            Assert.Equal(robot.xPosition, xPosition);
            Assert.Equal(robot.yPosition, yPosition);
        }

        [Theory]
        [InlineData(1, 2, "N", "LMLMLMLMM")]
        [InlineData(10, 10, "S", "LMRMLMRM")]
        [InlineData(3, 3, "E", "MMRMMRMRRM")]
        public void Test_For_RobotFinalPosition(int xPosition, int yPosition, string direction, string command)
        {
            Robot robot = _robotHelper.RobotFinalPosition(new Robot()
            {
                xPosition = xPosition,
                yPosition = yPosition,
                Direction = direction
            }, command);
            Assert.Equal(robot.Direction, direction);

        }


        [Theory]
        [InlineData("13N")]
        [InlineData("2   4   S")]
        [InlineData(" 3 2 W")]
        [InlineData("45  W")]
        public void Test_For_GetRobotPosition(string position)
        {
            position = position.ToUpper().Replace(" ", "");
            Tuple<int, int, string> robotPosition = _robotHelper.GetRobotPosition(position);
            Assert.Equal(robotPosition.Item1, Convert.ToInt32(position.Substring(0, 1)));
            Assert.Equal(robotPosition.Item2, Convert.ToInt32(position.Substring(1, 1)));
            Assert.Equal(robotPosition.Item3, position.Substring(2, 1));
        }
    }
}
