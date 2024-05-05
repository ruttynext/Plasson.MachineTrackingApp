using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Plasson.MachineTrackingApp
{
    /// <summary>
    /// Interaction logic for AddEditMachineWindow.xaml
    /// </summary>
    public partial class AddEditMachineWindow : Window
    {
        public MachineStatus[] MachineStatusEnumValues => Enum.GetValues(typeof(MachineStatus)).Cast<MachineStatus>().ToArray();

        public Machine SelectedMachine { get; set; } = new();

        public AddEditMachineWindow()
        {
            InitializeComponent();
            statusComboBox.ItemsSource = MachineStatusEnumValues;
            DataContext = SelectedMachine;
        }

        // Constructor with a specified Machine object
        public AddEditMachineWindow(Machine machine) : this()
        {
            SelectedMachine = machine;
            DataContext = SelectedMachine;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                // Get the selected file path
                string imagePath = openFileDialog.FileName;
                SelectedMachine.ImageSource = imagePath;    
                // Now you can use the imagePath to set the source of your Image control or save it somewhere
                // For example, if you have an Image control named "imageControl":
                // imageControl.Source = new BitmapImage(new Uri(imagePath));
            }
        }
    }
}
