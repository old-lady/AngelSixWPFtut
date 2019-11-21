using System.ComponentModel;

namespace Video03
{
    /// <summary>
    /// This base view model fires property changed events as needed!
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// the event that is fired everytime a child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
