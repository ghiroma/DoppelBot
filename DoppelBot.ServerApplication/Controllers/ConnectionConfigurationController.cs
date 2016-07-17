using DoppelBot.EZRobot.Enums;
using DoppelBot.ServerApplication.Constants;
using DoppelBot.ServerApplication.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoppelBot.ServerApplication.Controllers
{
    public class ConnectionConfigurationController
    {
        private EZRobot.DoppelBot _robot;
        private LoggerHelper _logger;

        public ConnectionConfigurationController()
        {
            this._robot = new EZRobot.DoppelBot();
            this._logger = new LoggerHelper(LoggerConstants.LOG_FILE_PATH);
        }

        public void Connect(string ipAddress)
        {
            try
            {
                this._robot.Init(ipAddress);
                this._robot.SetInitialStance();

                this._robot.StartListeningSound();
            }
            catch (Exception ex)
            {
                this._logger.LogCritical(ex.Message);
            }
        }

        public void Disconnect()
        {
            try
            {
                this._robot.Stop();
            }
            catch (Exception ex)
            {
                this._logger.LogCritical(ex.Message);
            }
        }

        public void MoveServo(ServosEnum servo, int position)
        {
            this._robot.MoveServo(servo, position);
        }

        public int GetServoPosition(ServosEnum servo)
        {
            return this._robot.GetServoPosition(servo);
        }

        public void AttachVideo(System.Windows.Forms.Control control)
        {
            try
            {
                var handler = new EZ_B.Camera.OnNewFrameHandler(this.VideoHandler);
                this._robot.SetVideoControl(control, handler);
            }
            catch (Exception ex)
            {

            }
        }

        private void VideoHandler()
        {

        }
    }
}
