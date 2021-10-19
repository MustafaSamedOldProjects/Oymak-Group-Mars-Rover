using Cozum.Interfaces.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cozum.Concrete.Models
{
    public class Robot : IRobot
    {
        public int xPosition { get; set; }
        public int yPosition { get; set; }
        public string Direction { get; set; }

    }
}
