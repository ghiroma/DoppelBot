using DoppelBot.EZRobot.Constants;
using DoppelBot.EZRobot.Enums;
using DoppelBot.EZRobot.Services;
using DoppelBot.EZRobot.Services.Interfaces;
using EZ_B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoppelBot.EZRobot
{
    public class DoppelBot : IDisposable
    {
        private EZB robot;
        private IConnectionService _connectionService;
        private IMovementService _movementService;
        private IGripperService _gripperService;
        private IVideoService _videoService;
        private ITCPServerService _tcpServerService;
        private ISpeechRecognitionService _speechRecognitionService;
        private IEyesService _eyesService;
        private IWiimoteService _wiimoteService;
        private ISoundService _soundService;

        public DoppelBot()
        {
            this.robot = new EZB();
            this._connectionService = new ConnectionService(this.robot);
            this._movementService = new MovementService(this.robot);
            this._gripperService = new GripperService(this.robot, this._movementService);
            this._videoService = new VideoService(this.robot);
            this._tcpServerService = new TCPServerService(this.robot);
            this._eyesService = new EyesService(this.robot);
            this._speechRecognitionService = new SpeechRecognitionService(this._eyesService, this._movementService);
            this._wiimoteService = new WiimoteService(this._movementService, this._gripperService);
            this._soundService = new SoundService(this.robot);
        }

        public void Init(string ipAddress)
        {
            this._connectionService.Connect(ipAddress);
            this._speechRecognitionService.StartListening();
            this._videoService.StartVideo();
            this._wiimoteService.Init();
        }

        public void Stop()
        {
            this._speechRecognitionService.StopListening();
            this._eyesService.ShutdownEyes();
            //this._videoService.StopVideo();
            this._connectionService.Disconnect();
            this._wiimoteService.Stop();
        }

        public void MoveServo(ServosEnum servo, int position, int speed)
        {

            this._movementService.MoveServo(servo, position, speed);
        }

        public void MoveServo(ServosEnum servo, int position)
        {
            this.MoveServo(servo, position, -1);
        }

        public int GetServoPosition(ServosEnum servo)
        {
            return this._movementService.GetServoPosition(servo);
        }

        public void GoForward()
        {
            this._movementService.MoveForward();
        }

        public void GoBackward()
        {
            this._movementService.MoveBackward();
        }

        public void GoLeft()
        {
            this._movementService.MoveLeft();
        }

        public void GoRight()
        {
            this._movementService.MoveRight();
        }

        public void StopMoving()
        {
            this._movementService.StopMoving();
        }

        public void SetInitialStance()
        {
            this._movementService.MoveServo(ServosEnum.LEFTUPPERARM, 90);
            this._movementService.MoveServo(ServosEnum.LEFTFOREARM, 90);
            this._movementService.MoveServo(ServosEnum.RIGHTUPPERARM, 90);
            this._movementService.MoveServo(ServosEnum.RIGHTFOREARM, 90);
            this._movementService.MoveServo(ServosEnum.LEFTGRIPPER, 85);
            this._movementService.MoveServo(ServosEnum.RIGHTGRIPPER, 85);
            this._movementService.MoveServo(ServosEnum.LEFTUPPERLEG, 90);
            this._movementService.MoveServo(ServosEnum.RIGHTUPPERLEG, 90);
            this._movementService.MoveServo(ServosEnum.LEFTKNEE, 90);
            this._movementService.MoveServo(ServosEnum.RIGHTKNEE, 90);
            this._movementService.MoveServo(ServosEnum.LEFTSHOULDER, 90);
            this._movementService.MoveServo(ServosEnum.RIGHTSHOULDER, 90);
            //this._movementService.ReleaseServos();
        }

        public void Dispose()
        {

        }

        public void SetVideoFrameHandler(Camera.OnNewFrameHandler handler)
        {
            this._videoService.SetOnNewFrameHandler(handler);
        }

        public void SetVideoControl(System.Windows.Forms.Control control, Camera.OnNewFrameHandler handler)
        {
            this._videoService.SetViewControl(control);
            this._videoService.SetOnNewFrameHandler(handler);
        }

        public void StartListeningSound()
        {
            this._soundService.StartListening();
        }

        public void StopListeningSound()
        {
            this._soundService.StopListening();
        }
    }
}
