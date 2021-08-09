using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaApplication3
{
    class VK : INotifyPropertyChanged
    {
        private string _groupName;
        private string _groupAva;

        public string GroupName
        {

            get => _groupName;
            set
            {
                _groupName = value;
                OnPropertyChanged(nameof(GroupName));
            }

        }

        public string GroupAva
        {

            get => _groupAva;
            set
            {
                _groupAva = value;
                OnPropertyChanged(nameof(GroupAva));
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

