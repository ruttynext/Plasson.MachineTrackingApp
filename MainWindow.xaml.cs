using Plasson.MachineTrackingApp.Notification;
using Serilog;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;


namespace Plasson.MachineTrackingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ObservableCollection<Machine> machines = new ObservableCollection<Machine>();

        public MainWindow()
        {
            InitializeComponent();

            // Sample data
            machines.Add(new Machine("בקר ריתוך חשמלי", "בקר ריתוך חשמלי POLYCODE (USB)", MachineStatus.Running, "בקר ריתוך חשמלי להדבקת אביזרי פלסאון", "C:\\Plasson\\Plasson.MachineTrackingApp\\Images\\ElectricWeldingController.png"));
            machines.Add(new Machine("ריתוך פנים", "מכונות ריתוך - BW", MachineStatus.Idle, "נילווים למכונות ריתוך – BW\r\n", "C:\\Plasson\\Plasson.MachineTrackingApp\\Images\\BW-מכונת-ריתוך.jpg"));
            machines.Add(new Machine("זוויות", "זווית 45° מעבר – הברגה פנימית פליז", MachineStatus.Offline, "זווית 90° מעבר – הברגה פנימית פליז\r\n", "C:\\Plasson\\Plasson.MachineTrackingApp\\Images\\493504063020_Med.jpg"));
            machineListBox.ItemsSource = machines;

            // Populate filter options
            filterComboBox.ItemsSource = new string[] { "All", MachineStatus.Running.ToString(), MachineStatus.Idle.ToString(), MachineStatus.Offline.ToString() };
            filterComboBox.SelectedIndex = 0;
        }

        private void AddMachine_Click(object sender, RoutedEventArgs e)
        {
            // Open a dialog to add a new machine
            AddEditMachineWindow addEditWindow = new AddEditMachineWindow();
            if (addEditWindow.ShowDialog() == true)
            {
                machines.Add(addEditWindow.SelectedMachine);
                NotificationHelper.ShowNotification(notificationPopup, "New machine added successfully.");

            }
        }


        private void FilterComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string selectedStatus = filterComboBox.SelectedItem as string;
            if (selectedStatus == "All")
            {
                foreach (Machine machine in machines)
                {
                    machine.IsVisible = true;
                }
            }
            else
            {
                foreach (Machine machine in machines)
                {
                    machine.IsVisible = (machine.Status.ToString() == selectedStatus);
                }
            }

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = ((Button)sender).DataContext as Machine; // Replace YourItemType with the actual type of your items

                if (item != null)
                {
                    // Open a dialog to edit the selected machine
                    AddEditMachineWindow addEditWindow = new AddEditMachineWindow(item);
                    if (addEditWindow.ShowDialog() == true)
                    {
                        int index = machines.IndexOf(item);
                        if (index != -1)
                        {
                            machines[index] = addEditWindow.SelectedMachine;
                            NotificationHelper.ShowNotification(notificationPopup, "Machine details updated successfully.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Notify the user that an error has occurred
                NotificationHelper.ShowNotification(notificationPopup, "An error occurred while editing the machine. Please try again later.");
                // Log the error
                Log.Error(ex, "An error occurred while editing the machine.");
            }
        }

        private void BtnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = ((Button)sender).DataContext as Machine;
                // Ensure a machine is selected
                if (item != null)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this Machine?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        machines.Remove(item);
                        NotificationHelper.ShowNotification(notificationPopup, "Machine removed successfully.");
                    }
                }
            }
            catch (Exception ex)
            {

                NotificationHelper.ShowNotification(notificationPopup, "An error occurred while deleting the machine. Please try again later.");
                Log.Information(ex.Message);
            }

        }

    }
}