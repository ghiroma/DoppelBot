using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoppelBot.EZRobot.Services.Interfaces
{
    public interface IConnectionService
    {
        void Connect(string ipAddress);

        void Disconnect();
    }
}
