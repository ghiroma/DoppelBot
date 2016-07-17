using DoppelBot.EZRobot.Entities;
using DoppelBot.EZRobot.Services.Interfaces;
using EZ_B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoppelBot.EZRobot.Services
{
    public class EyesService : IEyesService
    {
        private EZB _robot;

        public EyesService(EZB _robot)
        {
            this._robot = _robot;
        }

        public void ShutdownEyes()
        {
            this._robot.RGBEyes.SetAllColor(0, 0, 0);
        }

        public void ChangeColor(Color color)
        {
            this._robot.RGBEyes.SetAllColor(color.Red, color.Green, color.Blue);
        }

    }
}
