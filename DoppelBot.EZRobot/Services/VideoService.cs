using DoppelBot.EZRobot.Services.Interfaces;
using EZ_B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoppelBot.EZRobot.Services
{
    public class VideoService : IVideoService
    {
        private EZB _robot;
        private Camera _camera;
        private System.IO.MemoryStream stream;

        public VideoService(EZB _robot)
        {
            this._robot = _robot;
            this._camera = new Camera(_robot);
        }

        public void StartVideo()
        {
            this.StartVideo(null);
        }

        public void StartVideo(Control videoControl)
        {
            if (this._robot.IsConnected && !this._camera.IsActive)
            {
                var cameraDevices = Camera.GetVideoCaptureDevices();
                if (videoControl != null)
                {
                    this._camera.StartCamera(cameraDevices[1], videoControl, 640, 480);
                    this.stream = new System.IO.MemoryStream();
                }
                else
                {
                    this._camera.StartCamera(cameraDevices[1], 640, 480);
                    this.stream = new System.IO.MemoryStream();
                }
            }
            else if(!this._camera.IsActive)
            {
                throw new Exception("Camera is not active.");
            }
        }

        public void StartRecording(string fileName)
        {
            if (this._camera.IsActive)
            {
                this._camera.AVIStartRecording(fileName, Camera.VideoCodec.MPEG4, 30);
            }
        }

        public void StopRecording()
        {
            if (this._camera.IsActive)
            {
                this._camera.AVIStopRecording();

            }
        }

        public void StopVideo()
        {
            if (this._robot.IsConnected && this._camera.IsActive)
            {
                this._camera.StopCamera();
                this.stream.Close();
            }
        }

        public void TakePhoto(string fileName)
        {
            if (this._camera.IsActive)
            {
                var image = this._camera.GetCurrentBitmap;
                image.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        public void SetOnNewFrameHandler(Camera.OnNewFrameHandler handler)
        {
            this._camera.OnNewFrame += handler;
        }

        public void SetViewControl(Control control)
        {
            this._camera.SetPreviewControl = control;
        }
    }
}
