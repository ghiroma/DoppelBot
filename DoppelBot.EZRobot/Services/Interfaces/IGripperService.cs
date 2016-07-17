using DoppelBot.EZRobot.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoppelBot.EZRobot.Services.Interfaces
{
    public interface IGripperService
    {
        void CloseGripper(ServosEnum gripper);

        void OpenGripper(ServosEnum gripper);
    }
}
