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
using System.Windows.Threading;

namespace Plasson.MachineTrackingApp
{
    /// <summary>
    /// Interaction logic for NotificationPopup.xaml
    /// </summary>
    public partial class NotificationPopup : UserControl
    {

        public string Message { get; set; }

        public NotificationPopup()
        {
            InitializeComponent();
        }
        public NotificationPopup(string message)
        {
            InitializeComponent();
            DataContext = new { Message = message };
        }

        public void Show()
        {

            // Show notification popup
            Visibility = Visibility.Visible;

            // Hide notification after 2 seconds
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += (sender, e) =>
            {
                Visibility = Visibility.Collapsed;
                timer.Stop();
            };
            timer.Start();
        }

    }
}
