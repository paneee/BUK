using System.Collections.Generic;
using System.ComponentModel;

namespace BUK.Model
{
    public class Course
    {
        public decimal T0 { get; set; }
        public decimal T1 { get; set; }
        public decimal T2 { get; set; }
        public decimal T10 { get; set; }
        public decimal T02 { get; set; }
        public decimal T12 { get; set; }

        private List<decimal> courseToList()
        {
            List<decimal> ret = new List<decimal>();
            ret.Add(this.T0);
            ret.Add(this.T1);
            ret.Add(this.T2);
            //ret.Add(this.T10);
            //ret.Add(this.T02);
            //ret.Add(this.T12);
            return ret;
        }

        private decimal getMaxValue(List<decimal> list)
        {
            list = courseToList();
            list.Sort();
            return list[list.Count - 1];
        }

        private decimal getMinValue(List<decimal> list)
        {
            list = courseToList();
            list.Sort();
            return list[0];
        }

        private decimal getMediumValue(List<decimal> list)
        {
            list = courseToList();
            list.Sort();
            return list[1];
        }

        public decimal GetHighestCourse()
        { 
            return getMaxValue(courseToList());
        }

        public decimal GetLowerCourse()
        {
            return getMinValue(courseToList());
        }

        public decimal GetMediumCourse()
        {
            return getMediumValue(courseToList());
        }
    }
}