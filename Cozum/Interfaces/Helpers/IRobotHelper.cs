using Cozum.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cozum.Interfaces.Helpers
{
    public interface IRobotHelper
    {
        Tuple<int, int, string> GetRobotPosition();
        Robot CreateRobot(int xPosition, int yPosition, string Direction);
        string RobotPlatoWalk();
        Robot RobotFinalPosition(Robot robot, string commandToRobot);
        void WriteRobotsToConsole(List<Robot> robots);
    }
}
