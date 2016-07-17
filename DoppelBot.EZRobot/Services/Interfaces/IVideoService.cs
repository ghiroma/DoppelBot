using EZ_B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoppelBot.EZRobot.Services.Interfaces
{
    public interface IVideoService
    {
        void StartVideo();

        void StartVideo(Control videoControl);

        void StartRecording(string fileName);

        void SetOnNewFrameHandler(Camera.OnNewFrameHandler handler);

        void StopRecording();

        void StopVideo();

        void TakePhoto(string fileName);

        void SetViewControl(Control control);
    }
}
