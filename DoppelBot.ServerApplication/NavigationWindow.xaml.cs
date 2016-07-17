using DoppelBot.ServerApplication.Pages;
using DoppelBot.ServerApplication.Windows;
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

namespace DoppelBot.ServerApplication
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : NavigationWindow
    {
        public Window1()
        {
            InitializeComponent();
            appContent.Navigate(new HomePage());
        }

        private void LogAndConnectMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //appContent.Navigate(new LogAndConnect());
            var logWindow = new LogViewer();
            logWindow.Show();
            
        }

        private void ConnectionConfigMenuItem_Click(object sender, RoutedEventArgs e)
        {
            appContent.Navigate(new ConnectionConfiguration());
        }

        private void HelpMenuItem_Click(object sender, RoutedEventArgs e)
        {
            appContent.Navigate(new Help());
        }
    }
}
