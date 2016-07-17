using DoppelBot.EZRobot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoppelBot.EZRobot.Constants
{
    public class ColorsConstants
    {
        public static Color Red = new Color { Red = 255, Green = 0, Blue = 0 };
        public static Color Blue = new Color() { Red = 0, Green = 0, Blue = 255 };
        public static Color Green = new Color() { Red = 0, Green = 255, Blue = 0 };
        public static Color White = new Color() { Red = 255, Green = 255, Blue = 255 };
    }
}
