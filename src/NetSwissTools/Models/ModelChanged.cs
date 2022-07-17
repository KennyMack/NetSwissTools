using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace NetSwissTools.Models
{
    public class ModelChanged : INotifyPropertyChanged
    {
        /// <summary>
        /// Fires the event when the property value change
        /// example of use:
        ///   bool isBusy = false;
        ///   public bool IsBusy
        ///   {
        ///       get { return isBusy; }
        ///       set { SetProperty(ref isBusy, value); }
        ///   }
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="backingStore">Backup value</param>
        /// <param name="value">Value</param>
        /// <param name="propertyName">Name of property</param>
        /// <param name="onChanged">Action called when the value change</param>
        /// <returns>System.Boolean</returns>
        protected bool SetProperty<T>(ref T backingStore, T value,
               [CallerMemberName] string propertyName = "",
               Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            if (onChanged != null)
                onChanged.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
