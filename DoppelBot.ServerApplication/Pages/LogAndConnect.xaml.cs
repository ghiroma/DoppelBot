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
    /// Interaction logic for LogAndConnect.xaml
    /// </summary>
    public partial class LogAndConnect : Page
    {
        private LogAndConnectController _controller;

        public LogAndConnect()
        {
            InitializeComponent();
            this._controller = new LogAndConnectController();
            this.txtLog.Text = this._controller.ReadLog();
        }
    }
}
