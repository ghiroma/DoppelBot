using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoppelBot.EZRobot.Services.Interfaces
{
    public interface ISoundService
    {
        //Important! audio must be raw 8bit 18khz sample rate.
        void PlayData(System.IO.Stream stream, decimal volume);

        void PlayData(Byte[] sound, decimal volume);

        void StartListening();

        void StopListening();

        void StopPlaying();
    }
}
