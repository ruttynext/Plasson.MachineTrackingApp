using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plasson.MachineTrackingApp
{
    public enum MachineStatus
    {
        Running,
        Idle,
        Offline
    }
    public class Machine: INotifyPropertyChanged
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            { 
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set 
            { 
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private MachineStatus status;

        public MachineStatus Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        private string notes;

        public string Notes
        {
            get { return notes; }
            set
            {
                notes = value;
                OnPropertyChanged(nameof(Notes));
            }
        }

        private bool _isVisible = true; // Default to true

        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                if (_isVisible != value)
                {
                    _isVisible = value;
                    OnPropertyChanged(nameof(IsVisible));
                }
            }
        }
        private string imageSource;

        public string ImageSource
        {
            get { return imageSource; }
            set 
            { 
                imageSource = value;
                OnPropertyChanged(nameof(ImageSource));
            }
        }


        public Machine()
        {

        }
        public Machine(string name, string description, MachineStatus status, string notes, string imageSource)
        {
            Name = name;
            Description = description;
            Status = status;
            Notes = notes;
            ImageSource = imageSource;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
