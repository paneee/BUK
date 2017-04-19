using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUK.ViewModel
{
    public class VMDataGrid
    {
        private bool _isWin;

        public bool IsWin
        {
            get { return this._isWin; }
            set { if (value != this._isWin) { this._isWin = value; OnPropertyChanged("IsWin"); } }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string nazwaWłasnosci)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nazwaWłasnosci));
        }
    }
}
