using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUK.Model
{
    public class Bet
    {
        public string idBook { get; set; }
        public DateTime Data { get; set; }
        public string Ligue { get; set; }
        public Name Name { get; set; }
        public Result Result { get; set; }
        public Course Course { get; set; }
        public bool isFinished
        {
            get; 
            set;
        }

        public decimal CourseWin()
        {
            decimal ret = 0; 
            if (this.Result.GoalAwayTeam == this.Result.GoalAwayTeam)
            {
                ret = this.Course.T0;
            }
            else if (this.Result.GoalAwayTeam > this.Result.GoalAwayTeam)
            {
                ret = this.Course.T1;
            }
            else if (this.Result.GoalAwayTeam < this.Result.GoalAwayTeam)
            {
                ret = this.Course.T2;
            }
            return ret;
        }
    }
}
