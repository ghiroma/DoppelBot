using DoppelBot.EZRobot.Services.Interfaces;
using EZ_B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoppelBot.EZRobot.Services
{
    public class TCPServerService : ITCPServerService
    {
        private EZB _robot;

        public TCPServerService(EZB _robot)
        {
            this._robot = _robot;
        }

        public TCPServer Start(int port)
        {
            if (this._robot.IsConnected)
            {
                this._robot.TCPServer.Start(port);
                return this._robot.TCPServer;
            }

            return null;
        }

        public void Stop()
        {
            if (this._robot.IsConnected)
            {
                this._robot.TCPServer.Stop();
            }
        }
    }
}
