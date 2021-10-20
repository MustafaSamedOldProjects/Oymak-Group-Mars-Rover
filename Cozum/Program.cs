using Cozum.Concrete.Helpers;
using Cozum.Concrete.Models;
using Cozum.Interfaces.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Cozum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                                           .AddScoped<ICordinateHelper, CordinateHelper>()
                                           .AddScoped<IRobotHelper, RobotHelper>()
                                           .BuildServiceProvider();

            ICordinateHelper cordinateHelper = serviceProvider.GetService<ICordinateHelper>();
            Tuple<int, int> cordinates = cordinateHelper.GetValuesFromUserForCordinateSystem();
            List<Cordinate> rectangleCordinate = cordinateHelper.CreateCordinateSystem(cordinates.Item1, cordinates.Item2);
            cordinateHelper.ShowCordinateSystemInConsole(rectangleCordinate);
            IRobotHelper robotHelper = serviceProvider.GetService<IRobotHelper>();
            string exitStatus = "";

            List<Robot> robots = new List<Robot>();
            while (exitStatus != "-1")
            {
                Tuple<int, int, string> robotPosition = robotHelper.GetRobotPosition();
                var createdRobot = robotHelper.CreateRobot(robotPosition.Item1, robotPosition.Item2, robotPosition.Item3);
                robots.Add(createdRobot);
                string commands = robotHelper.RobotPlatoWalk();
                robotHelper.RobotFinalPosition(createdRobot, commands);
                Console.WriteLine("Sonuçları görmek için -1 yazınız, farklı robot girişi yapmak için enter'a basmanız yeterli.");
                exitStatus = Console.ReadLine();
                if (exitStatus == "-1")
                {
                    robotHelper.WriteRobotsToConsole(robots);
                }
            }

        }
    }
}
