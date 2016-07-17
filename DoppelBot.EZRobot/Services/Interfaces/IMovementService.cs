using DoppelBot.EZRobot.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoppelBot.EZRobot.Services.Interfaces
{
    public interface IMovementService
    {
        bool MoveServo(ServosEnum servo, int position, int speed = -1);

        bool MoveServo(ServosEnum servo, int x, int y, int z, int speed = -1);

        void MoveForward();

        void MoveBackward();

        void MoveLeft();

        void MoveRight();

        void StopMoving();

        void GetUp();

        void ReleaseServos();

        int GetServoPosition(ServosEnum servo);
    }
}
