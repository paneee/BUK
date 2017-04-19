using BUK.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUK.ViewModel
{
    public class VMBet : INotifyPropertyChanged
    {
        private string _idBook { get; set; }
        private DateTime _Data { get; set; }
        private string _Ligue { get; set; }
        private Name _Name { get; set; }
        private Result _Result { get; set; }
        private Course _Course { get; set; }
        private bool _isFinished { get; set; }

        public string idBook
        {
            get { return this._idBook; }
            set { if (value != this._idBook) { this._idBook = value; OnPropertyChanged("idBook"); } }
        }

        public DateTime Data
        {
            get { return this._Data; }
            set { if (value != this._Data) { this._Data = value; OnPropertyChanged("Data"); } }
        }

        public string Ligue
        {
            get { return this._Ligue; }
            set { if (value != this._Ligue) { this._Ligue = value; OnPropertyChanged("Ligue"); } }
        }

        public Name Name
        {
            get { return this._Name; }
            set { if (value != this._Name) { this._Name = value; OnPropertyChanged("Name"); } }
        }

        public Result Result
        {
            get { return this._Result; }
            set { if (value != this._Result) { this._Result = value; OnPropertyChanged("Result"); } }
        }

        public Course Course
        {
            get { return this._Course; }
            set { if (value != this._Course) { this._Course = value; OnPropertyChanged("Course"); } }
        }

        public bool isFinished
        {
            get { return this._isFinished; }
            set { if (value != this._isFinished) { this._isFinished = value; OnPropertyChanged("isFinished");} }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string nazwaWłasnosci)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nazwaWłasnosci));
        }
    }
}
