using DoppelBot.ServerApplication.Controllers;
using Xceed.Wpf.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DoppelBot.ServerApplication.Windows
{
    /// <summary>
    /// Interaction logic for LogViewer.xaml
    /// </summary>
    public partial class LogViewer : Window
    {
        private LogAndConnectController _controller;
        private DispatcherTimer _timer;

        public LogViewer()
        {
            InitializeComponent();
            this._controller = new LogAndConnectController();
            this.txtLog.Text = this._controller.ReadLog();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            this.txtLog.Text = this._controller.ReadLog();
        }

        private void InitTimer()
        {
            this._timer = new DispatcherTimer();
            this._timer.Interval = TimeSpan.FromSeconds(2);
            this._timer.Tick += _timer_Tick;
            this._timer.Start();
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(dpFrom.Text) || !string.IsNullOrEmpty(dpTo.Text))
            {
                DateTime? dateFrom = null;
                DateTime? dateTo = null;
                if (!string.IsNullOrEmpty(dpFrom.Text))
                {
                    dateFrom = Convert.ToDateTime(dpFrom.Text);
                }

                if (!string.IsNullOrEmpty(dpTo.Text))
                {
                    dateTo = Convert.ToDateTime(dpTo.Text);
                }

                this.txtLog.Text = this._controller.ReadFilteredLog(dateFrom, dateTo);
            }
        }
    }
}
