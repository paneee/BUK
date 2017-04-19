using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BUK.ViewModel
{
    public class VMProgressBar : INotifyPropertyChanged
    {
        private bool _isIndeterminate { get; set; }
        private Visibility _visibility  { get; set; }
        private double _currentProgress;

        public bool IsIndeterminate
        {
            get { return this._isIndeterminate; }
            set { if (value != this._isIndeterminate) { this._isIndeterminate = value; OnPropertyChanged("IsIndeterminate"); } }
        }

        public Visibility Visibility
        {
            get { return this._visibility; }
            set { if (value != this._visibility) { this._visibility = value; OnPropertyChanged("Visibility"); } }
        }

        public double CurrentProgress
        {
            get { return this._currentProgress; }
            set { if (value != this._currentProgress) { this._currentProgress = value; OnPropertyChanged("CurrentProgress"); } }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string nazwaWłasnosci)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nazwaWłasnosci));
        }
    }
}
