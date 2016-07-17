using DoppelBot.EZRobot.Services.Interfaces;
using EZ_B.WiimoteLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoppelBot.EZRobot.Services
{
    public class WiimoteService : IWiimoteService
    {
        private Wiimote _wiimote;
        private IMovementService _movementService;
        private IGripperService _gripperService;

        public WiimoteService(IMovementService movementService, IGripperService gripperService)
        {
            this._movementService = movementService;
            this._gripperService = gripperService;
            this._wiimote = new Wiimote();
            this._wiimote.WiimoteChanged += _wiimote_WiimoteChanged;
        }

        private void _wiimote_WiimoteChanged(object sender, WiimoteChangedEventArgs e)
        {
            var button = e.WiimoteState.ButtonState;
            if (button.A)
            {
                this._movementService.StopMoving();
            }

            if (button.B)
            {
                this._gripperService.CloseGripper(Enums.ServosEnum.LEFTGRIPPER);
                this._gripperService.CloseGripper(Enums.ServosEnum.RIGHTGRIPPER);
            }
            else
            {
                this._gripperService.OpenGripper(Enums.ServosEnum.LEFTGRIPPER);
                this._gripperService.OpenGripper(Enums.ServosEnum.RIGHTGRIPPER);
            }

            if (button.Left)
            {
                this._movementService.MoveLeft();
            }
            else if (button.Right)
            {
                this._movementService.MoveRight();
            }
            else if (button.Up)
            {
                this._movementService.MoveForward();
            }
            else if (button.Down)
            {
                this._movementService.MoveBackward();
            }
        }

        public void Init()
        {
            this._wiimote.Connect();
            this._wiimote.SetReportType(InputReport.Buttons, true);
            this._wiimote.SetLEDs(true, false, false, false);
        }

        public void Stop()
        {
            this._wiimote.Disconnect();
        }
    }
}
