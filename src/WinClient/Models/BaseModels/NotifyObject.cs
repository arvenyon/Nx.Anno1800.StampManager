using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WinClient.Models.BaseModels
{
    /// <summary>
    /// Base class for objects that inform about changes 
    /// </summary>
    public abstract class NotifyObject : INotifyPropertyChanged
    {
        /// <summary>
        /// Is called every time some property changes, see PropertyChanged.Fody package
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// If changed, updates value and informs about changes
        /// </summary>
        /// <typeparam name="T">Type of the value</typeparam>
        /// <param name="oldValue">The old value</param>
        /// <param name="newValue">The value to set</param>
        /// <param name="propName">The name of the respecting property</param>
        internal void SetProperty<T>(ref T oldValue, T newValue, [CallerMemberName] string propName = "")
        {
            if (!EqualityComparer<T>.Default.Equals(oldValue, newValue))
            {
                oldValue = newValue;
                OnPropChanged(propName);
            }
        }

        /// <summary>
        /// Informs about change of given member
        /// </summary>
        /// <param name="propName">Member name that has changed</param>
        internal void OnPropChanged([CallerMemberName] string propName = "")
        {
            if (!string.IsNullOrWhiteSpace(propName))
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}