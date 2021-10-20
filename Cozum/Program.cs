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
                                           .AddScoped<IConsoleHelper, ConsoleHelper>()
                                           .BuildServiceProvider();

            IConsoleHelper consoleHelper = serviceProvider.GetService<IConsoleHelper>();
           
            ICordinateHelper cordinateHelper = serviceProvider.GetService<ICordinateHelper>();
            consoleHelper.WriteMessageToConsole("Lütfen Bir Dikdörtgen Giriniz");
            string inputCordinate = consoleHelper.ReadFromConsoleForPlato();
            Tuple<int, int> cordinates = cordinateHelper.GetValuesFromUserForCordinateSystem(inputCordinate);
            List<Cordinate> rectangleCordinate = cordinateHelper.CreateCordinateSystem(cordinates.Item1, cordinates.Item2);
            cordinateHelper.ShowCordinateSystemInConsole(rectangleCordinate);
            

            IRobotHelper robotHelper = serviceProvider.GetService<IRobotHelper>();
            string exitStatus = "";

            List<Robot> robots = new List<Robot>();
            while (exitStatus != "-1")
            {
                consoleHelper.WriteMessageToConsole("Robot'un x,y ve yönünü(E,W,N,S) girin.");
                string inputRobotPosition = consoleHelper.ReadFromConsole();
                Tuple<int, int, string> robotPosition = robotHelper.GetRobotPosition(inputRobotPosition);
                var createdRobot = robotHelper.CreateRobot(robotPosition.Item1, robotPosition.Item2, robotPosition.Item3);
                robots.Add(createdRobot);
                Console.WriteLine("Robot'un gideceği yönü R,L,M şeklinde belirtiniz.");
                string inputForPlatoWalk =  consoleHelper.ReadFromConsole();
                string commands = robotHelper.RobotPlatoWalk(inputForPlatoWalk);
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
