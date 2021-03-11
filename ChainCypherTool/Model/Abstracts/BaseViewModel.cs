using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ChainCypherTool.Model.Abstracts
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool isEnabled;
        public bool IsEnabled { get { return isEnabled; } set { SetValue(ref isEnabled, value); } }

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return;
            field = value;
            NotifyPropertyChanged(propertyName);
        }
    }
}
