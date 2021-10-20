using Cozum.Concrete.Models;
using Cozum.Interfaces.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cozum.Applications
{
    public class Application
    {
        protected readonly IConsoleHelper _consoleHelper;
        protected readonly IRobotHelper _robotHelper;
        protected readonly ICordinateHelper _cordinateHelper;

        public Application(IConsoleHelper consoleHelper, IRobotHelper robotHelper, ICordinateHelper cordinateHelper)
        {
            _consoleHelper = consoleHelper; 
            _robotHelper = robotHelper; 
            _cordinateHelper = cordinateHelper; 
        }

        public void Run()
        {
            
            _consoleHelper.WriteMessageToConsole("Lütfen Bir Dikdörtgen Giriniz");
            string inputCordinate = _consoleHelper.ReadFromConsoleForPlato();
            Tuple<int, int> cordinates = _cordinateHelper.GetValuesFromUserForCordinateSystem(inputCordinate);
            _consoleHelper.WriteMessageToConsole("Plato aşağıdaki gibidir.");
            List<Cordinate> rectangleCordinate = _cordinateHelper.CreateCordinateSystem(cordinates.Item1, cordinates.Item2);
            _cordinateHelper.ShowCordinateSystemInConsole(rectangleCordinate);

            string exitStatus = "";

            List<Robot> robots = new List<Robot>();

            while (exitStatus != "-1")
            {
                _consoleHelper.WriteMessageToConsole("Robot'un x,y ve yönünü(E,W,N,S) girin. Örneğin : 1 2 N");
                string inputRobotPosition = _consoleHelper.ReadFromConsole();
                Tuple<int, int, string> robotPosition = _robotHelper.GetRobotPosition(inputRobotPosition);
                var createdRobot = _robotHelper.CreateRobot(robotPosition.Item1, robotPosition.Item2, robotPosition.Item3);
                robots.Add(createdRobot);
                Console.WriteLine("Robot'un gideceği yönü R,L,M şeklinde belirtiniz.");
                string inputForPlatoWalk = _consoleHelper.ReadFromConsole();
                string commands = _robotHelper.RobotPlatoWalk(inputForPlatoWalk);
                _robotHelper.RobotFinalPosition(createdRobot, commands);
                Console.WriteLine("Sonuçları görmek için -1 yazınız, farklı robot girişi yapmak için enter'a basmanız yeterli.");
                exitStatus = Console.ReadLine();
                if (exitStatus == "-1")
                {
                    _robotHelper.WriteRobotsToConsole(robots);
                }
            }
        }
    }
}
