using DoppelBot.ServerApplication.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DoppelBot.ServerApplication.Pages
{
    /// <summary>
    /// Interaction logic for ConnectionConfiguration.xaml
    /// </summary>
    public partial class ConnectionConfiguration : Page
    {
        private ConnectionConfigurationController _controller;

        public ConnectionConfiguration()
        {
            InitializeComponent();
            this._controller = new ConnectionConfigurationController();
        }

        private void chkDoppelbotConnection_Checked(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox.IsChecked == true)
            {
                System.Net.IPAddress address;
                if (System.Net.IPAddress.TryParse(this.txtDoppelBotIP.Text, out address))
                {
                    this._controller.Connect(this.txtDoppelBotIP.Text);
                    var panel = new System.Windows.Forms.Panel();
                    panel.Height = 480;
                    panel.Width = 640;
                    windowsFormsHost.Child = panel;
                    this._controller.AttachVideo(panel);
                    this.txtDoppelBotIP.IsEnabled = false;
                }
                else
                {
                    //Show incorrect message and log.
                }
            }
            else
            {
                this._controller.Disconnect();
                this.txtDoppelBotIP.IsEnabled = true;
            }
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            int position = 0;

            switch (e.Key)
            {
                case Key.A:
                    position = this._controller.GetServoPosition(EZRobot.Enums.ServosEnum.LEFTFOREARM);
                    this._controller.MoveServo(EZRobot.Enums.ServosEnum.LEFTFOREARM, position + 3);
                    break;
                case Key.D:
                    position = this._controller.GetServoPosition(EZRobot.Enums.ServosEnum.LEFTFOREARM);
                    this._controller.MoveServo(EZRobot.Enums.ServosEnum.LEFTFOREARM, position - 3);
                    break;
                case Key.W:
                    position = this._controller.GetServoPosition(EZRobot.Enums.ServosEnum.LEFTSHOULDER);
                    this._controller.MoveServo(EZRobot.Enums.ServosEnum.LEFTSHOULDER, position + 3);
                    break;
                case Key.S:
                    position = this._controller.GetServoPosition(EZRobot.Enums.ServosEnum.LEFTSHOULDER);
                    this._controller.MoveServo(EZRobot.Enums.ServosEnum.LEFTSHOULDER, position - 3);
                    break;
                case Key.J:
                    position = this._controller.GetServoPosition(EZRobot.Enums.ServosEnum.RIGHTFOREARM);
                    this._controller.MoveServo(EZRobot.Enums.ServosEnum.RIGHTUPPERARM, position + 3);
                    break;
                case Key.L:
                    position = this._controller.GetServoPosition(EZRobot.Enums.ServosEnum.RIGHTFOREARM);
                    this._controller.MoveServo(EZRobot.Enums.ServosEnum.RIGHTUPPERARM, position - 3);
                    break;
                case Key.I:
                    position = this._controller.GetServoPosition(EZRobot.Enums.ServosEnum.RIGHTSHOULDER);
                    this._controller.MoveServo(EZRobot.Enums.ServosEnum.RIGHTSHOULDER, position + 3);
                    break;
                case Key.K:
                    position = this._controller.GetServoPosition(EZRobot.Enums.ServosEnum.RIGHTSHOULDER);
                    this._controller.MoveServo(EZRobot.Enums.ServosEnum.RIGHTSHOULDER, position - 3);
                    break;
                case Key.Left:
                    position = this._controller.GetServoPosition(EZRobot.Enums.ServosEnum.HORIZONTALHEAD);
                    this._controller.MoveServo(EZRobot.Enums.ServosEnum.HORIZONTALHEAD, position - 3);
                    break;
                case Key.Right:
                    position = this._controller.GetServoPosition(EZRobot.Enums.ServosEnum.HORIZONTALHEAD);
                    this._controller.MoveServo(EZRobot.Enums.ServosEnum.HORIZONTALHEAD, position + 3);
                    break;
                case Key.Up:
                    position = this._controller.GetServoPosition(EZRobot.Enums.ServosEnum.VERTICALHEAD);
                    this._controller.MoveServo(EZRobot.Enums.ServosEnum.VERTICALHEAD, position + 3);
                    break;
                case Key.Down:
                    position = this._controller.GetServoPosition(EZRobot.Enums.ServosEnum.VERTICALHEAD);
                    this._controller.MoveServo(EZRobot.Enums.ServosEnum.VERTICALHEAD, position - 3);
                    break;
            }
        }
    }
}
