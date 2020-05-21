using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Chitin.Models
{
    public class NotifyPropertyChangedBase: INotifyPropertyChanged
    {
        [field: NonSerialized()]
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
