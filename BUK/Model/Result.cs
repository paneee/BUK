using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUK.Model
{
    public class Result
    {
        public int GoalHomeTeam { get; set; }
        public int GoalAwayTeam { get; set; }

        public Result()
        {
            this.GoalHomeTeam = 0;
            this.GoalAwayTeam = 0;
        }

        public Result(int GoalHomeTeam, int GoalAwayTeam)
        {
            this.GoalHomeTeam = GoalHomeTeam;
            this.GoalAwayTeam = GoalAwayTeam;
        }
    }
}
