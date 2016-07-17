using EZ_B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoppelBot.EZRobot.Services
{
    public class CameraService
    {
        private Camera _camera;

        public CameraService(EZB _robot)
        {
            this._camera = new Camera(_robot);
        }

        public void TakePhoto(string fileName)
        {
            this._camera.SaveImageAsJPEG(fileName);
        }
    }
}
