using DoppelBot.EZRobot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoppelBot.EZRobot.Services.Interfaces
{
    public interface IEyesService
    {
        void ShutdownEyes();

        void ChangeColor(Color color);
    }
}
