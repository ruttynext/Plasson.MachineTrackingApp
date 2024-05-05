using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;

namespace Plasson.MachineTrackingApp.Notification
{
    public static class NotificationHelper
    {
        public static void ShowNotification(NotificationPopup notificationPopup, string message)
        {
            notificationPopup.DataContext = new { Message = message };

            // Show notification popup
            notificationPopup.Visibility = Visibility.Visible;

            // Hide notification after 2 seconds
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += (sender, e) =>
            {
                notificationPopup.Visibility = Visibility.Collapsed;
                timer.Stop();
            };
            timer.Start();
        }
    }
}
