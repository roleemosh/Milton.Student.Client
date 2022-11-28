using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Milton.Blazor.Shared.ViewModels.Base
{
    public class NotifiedObject : INotifyPropertyChanging, INotifyPropertyChanged
    {
        //
        // Summary:
        //     event handler to propagate the INotifyPropertyChanging.PropertyChanging event
        public event PropertyChangingEventHandler PropertyChanging;

        //
        // Summary:
        //     event handler to propagate the INotifyPropertyChanged.PropertyChanged event
        public event PropertyChangedEventHandler PropertyChanged;

        //
        // Summary:
        //     Set the value of the property, and call the corresponding event handlers
        //
        // Parameters:
        //   backingStore:
        //     The reference of the backing store field, this filed contains the concrete value
        //     of the property
        //
        //   value:
        //     the new value
        //
        //   propertyName:
        //     The name of the property which is setted. This parameter is filled automatically
        //     from calling context
        //
        // Type parameters:
        //   T:
        //     type of the value, filed automativcally from calling context
        //
        // Returns:
        //     If the value is set, then it returns true. When the new value and the current
        //     value is same, then it returns false, and the event handlers are not called
        protected virtual bool SetPropertyValue<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }

            this.PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
            backingStore = value;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }

        //
        // Summary:
        //     calling the PropertyChangedEventHandler
        //
        // Parameters:
        //   propertyName:
        //     The name of the property which is changed.
        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
