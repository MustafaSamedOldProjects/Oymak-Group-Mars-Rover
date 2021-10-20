using Autofac;
using Cozum.Applications;
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
        private static IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>();
            builder.RegisterType<ConsoleHelper>().As<IConsoleHelper>() ;
            builder.RegisterType<RobotHelper>().As<IRobotHelper>() ;
            builder.RegisterType<CordinateHelper>().As<ICordinateHelper>() ;
            return builder.Build();
        }
        public static void Main(string[] args)
        {

            var runable = CompositionRoot().Resolve<Application>();
            runable.Run();
        }
    }
}
