using Cozum.Concrete.Models;
using Cozum.Interfaces.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cozum.Concrete.Helpers
{
    public class RobotHelper : IRobotHelper
    {
        public Robot CreateRobot(int xPosition, int yPosition, string Direction)
        {
            throw new NotImplementedException();
        }

        public Tuple<int, int, string> GetRobotPosition()
        {
            throw new NotImplementedException();
        }

        public void RobotFinalPosition(Robot robot, string commandToRobot)
        {
            throw new NotImplementedException();
        }

        public string RobotPlatoWalk()
        {
            throw new NotImplementedException();
        }
    }
}
