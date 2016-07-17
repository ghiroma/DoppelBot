using DoppelBot.EZRobot.Constants;
using DoppelBot.EZRobot.Enums;
using DoppelBot.EZRobot.Services.Interfaces;
using EZ_B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoppelBot.EZRobot.Services
{
    public class GripperService : IGripperService
    {
        private EZB _robot;
        private IMovementService _manager;

        public GripperService(EZB _robot, IMovementService _manager)
        {
            this._robot = _robot;
            this._manager = _manager;
        }

        public void CloseGripper(ServosEnum gripper)
        {
            if (this._robot.IsConnected)
            {
                this._manager.MoveServo(gripper, 85);
            }
        }

        public void OpenGripper(ServosEnum gripper)
        {
            if (this._robot.IsConnected)
            {
                this._manager.MoveServo(gripper, 10);
            }
        }

        private async void ReleaseGripper(ServosEnum gripper, int angle)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            var currentPosition = this._manager.GetServoPosition(gripper);
            if (currentPosition != angle)
            {
                this._manager.MoveServo(gripper, angle - 5);
            }
        }
    }
}
