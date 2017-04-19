using BUK.DataWEB;
using BUK.Helpers;
using BUK.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BUK.ViewModel
{
    public class VMWindow
    {
        #region pola
        public ObservableCollection<VMBet> bets { get; set; } = new ObservableCollection<VMBet>();
        public VMProgressBar progressBar { get; set; } = new VMProgressBar();
        public VMDataGrid dataGrid { get; set; } = new VMDataGrid();

        private List<Bet> all = new List<Bet>();
        #endregion

        #region Konstruktor
        public VMWindow()
        {
            //bets.Add(new BetVM
            //{
            //    Name = new Name { AwayTeam = "Lech", HomeTeam = "Legia" },
            //    Course = new Course { T0 = 1, T02 = 2, T1 = 3, T10 = 4, T12 = 5, T2 = 6 },
            //    Data = DateTime.Now,
            //    idBook = "99",
            //    isFinished = true,
            //    Ligue = "dekstraklasa",
            //    Result = new Result { GoalAwayTeam = 3, GoalHomeTeam = 6 }
            //});

            progressBar.Visibility = System.Windows.Visibility.Hidden;
        }
        #endregion

        private async Task<List<Bet>> GetDataFromWEBAsync()
        {
            return await Task.Run(() =>
            {
                return DataFromWEB.GetDataFromWEB();
            });
        }

        #region funkcje komend
        public async void loadDaneFromWebList()
        {
            dataGrid.IsWin = true;
            progressBar.Visibility = System.Windows.Visibility.Visible;
            progressBar.IsIndeterminate = true;
            all = await GetDataFromWEBAsync();
            foreach (Bet b in all)
            {
                bets.Add(new VMBet
                {
                    Name = b.Name,
                    Course = b.Course,
                    Data = b.Data,
                    idBook = b.idBook,
                    isFinished = b.isFinished,
                    Ligue = b.Ligue,
                    Result = b.Result
                });
            }
            progressBar.IsIndeterminate = false;
            progressBar.Visibility = System.Windows.Visibility.Hidden;

        }

        public void reloadView()
        {
            //bets.Clear();
            //ElementAt(0).Ligue = "eeeeeeeeeeeeeeeee";
            //progressBar.CurrentProgress = 12;
            //progressBar.IsVisible = false;
            ObservableCollection<VMBet> temp = new ObservableCollection<VMBet>();
            temp = bets;
            bets.Clear();
            bets = temp;
        }
        #endregion

        #region Command
        private ICommand _loadCommand;

        public ICommand LoadCommand
        {
            get
            {
                if (_loadCommand == null)
                {
                    _loadCommand = new RelayCommand(
                        param => this.loadDaneFromWebList()
                    );
                }
                return _loadCommand;
            }
        }

        private ICommand _reloadCommand;

        public ICommand ReloadCommand
        {
            get
            {
                if (_reloadCommand == null)
                {
                    _reloadCommand = new RelayCommand(
                        param => this.reloadView()
                    );
                }
                return _reloadCommand;
            }
        }
        #endregion

        #region helpers

        #endregion
    }
}
