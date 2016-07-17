using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZ_B;
using DoppelBot.EZRobot.Services.Interfaces;

namespace DoppelBot.EZRobot.Services
{
    public class ConnectionService : IConnectionService
    {
        private EZB _robot;

        public ConnectionService(EZB _robot)
        {
            this._robot = _robot;
        }

        public void Connect(string ipAddress)
        {
            this._robot.Connect(ipAddress);
            if (this._robot.IsConnected == false)
            {
                throw new Exception("Could not connect to doppelbot ip: " + ipAddress);
            }
        }

        public void Disconnect()
        {

        }
    }
}
