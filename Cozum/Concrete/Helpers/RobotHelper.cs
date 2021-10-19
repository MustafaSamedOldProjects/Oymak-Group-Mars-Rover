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
        public Tuple<int, int, string> GetRobotPosition()
        {

            Console.WriteLine("Robot'un x,y ve yönünü(E,W,N,S) girin.");
            string robotInformation = Console.ReadLine();
            if (robotInformation == "-1")
            {
                return Tuple.Create(-1, -1, "-1");
            }
            string inputReadable = robotInformation.Replace(" ", "");

            int xPosition = Convert.ToInt32(inputReadable.Substring(0, 1));
            int yPosition = Convert.ToInt32(inputReadable.Substring(1, 1));
            string Direction = inputReadable.ToUpper().Substring(2, 1);
            return Tuple.Create(xPosition, yPosition, Direction);
        }

        public Robot CreateRobot(int xPosition, int yPosition, string Direction)
        {
            Robot robot = new Robot();

            robot.xPosition = Convert.ToInt32(xPosition);
            robot.yPosition = Convert.ToInt32(yPosition);
            robot.Direction = Direction.ToUpper();

            return robot;
        }

        public string RobotPlatoWalk()
        {
            Console.WriteLine("Robot'un gideceği yönü R,L,M şeklinde belirtiniz.");
            string commandToRobot = Console.ReadLine().ToUpper();
            return commandToRobot;
        }

        public void RobotFinalPosition(Robot robot, string commandToRobot)
        {
            char[] commands = commandToRobot.ToCharArray();
            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i] == 'L')
                {
                    if (robot.Direction == "E")
                    {
                        robot.Direction = "N";
                    }
                    else if (robot.Direction == "N")
                    {
                        robot.Direction = "W";
                    }
                    else if (robot.Direction == "W")
                    {
                        robot.Direction = "S";
                    }
                    else if (robot.Direction == "S")
                    {
                        robot.Direction = "E";
                    }
                }
                if (commands[i] == 'R')
                {
                    if (robot.Direction == "E")
                    {
                        robot.Direction = "S";
                    }
                    else if (robot.Direction == "S")
                    {
                        robot.Direction = "W";
                    }
                    else if (robot.Direction == "W")
                    {
                        robot.Direction = "N";
                    }
                    else if (robot.Direction == "N")
                    {
                        robot.Direction = "E";
                    }
                }
                if (commands[i] == 'M')
                {
                    if (robot.Direction == "E")
                    {
                        ++robot.xPosition;
                    }
                    if (robot.Direction == "W")
                    {
                        --robot.xPosition;
                    }
                    if (robot.Direction == "N")
                    {
                        ++robot.yPosition;
                    }
                    if (robot.Direction == "S")
                    {
                        --robot.yPosition;
                    }
                }
            }
        }

        public void WriteRobotsToConsole(List<Robot> robots)
        {
            foreach (var item in robots)
            {
                Console.WriteLine(item.xPosition + " " + item.yPosition + " " + item.Direction);              
            }
        }
    }
}
