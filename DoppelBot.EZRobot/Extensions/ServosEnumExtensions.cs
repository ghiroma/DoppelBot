using DoppelBot.EZRobot.Enums;
using EZ_B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoppelBot.EZRobot.Extensions
{
    public static class ServosEnumExtensions
    {
        public static Servo.ServoPortEnum ToServoPortEnum(this ServosEnum servo)
        {
            switch (servo)
            {
                case ServosEnum.LEFTSHOULDER:
                    return Servo.ServoPortEnum.D3;
                case ServosEnum.RIGHTSHOULDER:
                    return Servo.ServoPortEnum.D2;
                case ServosEnum.HORIZONTALHEAD:
                    return Servo.ServoPortEnum.D0;
                case ServosEnum.VERTICALHEAD:
                    return Servo.ServoPortEnum.D1;
                case ServosEnum.LEFTUPPERARM:
                    return Servo.ServoPortEnum.D4;
                case ServosEnum.LEFTFOREARM:
                    return Servo.ServoPortEnum.D5;
                case ServosEnum.LEFTGRIPPER:
                    return Servo.ServoPortEnum.D6;
                case ServosEnum.RIGHTUPPERARM:
                    return Servo.ServoPortEnum.D7;
                case ServosEnum.RIGHTFOREARM:
                    return Servo.ServoPortEnum.D8;
                case ServosEnum.RIGHTGRIPPER:
                    return Servo.ServoPortEnum.D9;
                case ServosEnum.LEFTUPPERLEG:
                    return Servo.ServoPortEnum.D12;
                case ServosEnum.LEFTKNEE:
                    return Servo.ServoPortEnum.D13;
                case ServosEnum.LEFTANKLE:
                    return Servo.ServoPortEnum.D14;
                case ServosEnum.RIGHTUPPERLEG:
                    return Servo.ServoPortEnum.D16;
                case ServosEnum.RIGHTKNEE:
                    return Servo.ServoPortEnum.D17;
                case ServosEnum.RIGHTANKLE:
                    return Servo.ServoPortEnum.D18;
                default: throw new Exception("Servo value not recognized: " + servo);
            }
        }
    }
}
