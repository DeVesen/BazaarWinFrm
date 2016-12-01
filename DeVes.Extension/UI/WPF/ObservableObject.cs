using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DeVes.Extension.UI.WPF
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChangedEvent([CallerMemberName]string propertyName = null)
        {
            var _handler = PropertyChanged;
            if (_handler != null)
                _handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
