using BUK.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace BUK.ViewModel
{
    public static class DecimalToColorNameHelper
    {
        public static SolidColorBrush Get(object[] values, SolidColorBrush color1, SolidColorBrush color2, SolidColorBrush color3, SolidColorBrush defaultColor)
        {
            decimal courseCurrent = (decimal)values[0];
            Course courseAll = (Course)values[1];

            if (courseAll.GetHighestCourse() == courseCurrent)
            {
                return color1;
            }

            if (courseAll.GetMediumCourse() == courseCurrent)
            {
                return color2;
            }

            if (courseAll.GetLowerCourse() == courseCurrent)
            {
                return color3;
            }
            return defaultColor;
        }
    }

    public class ResultToColorNameConverterText : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Result result = (Result)values[0];
            bool isFinished = (bool)values[1];
            Course course = (Course)values[2];

            Bet bet = new Bet(); 
            bet.Course = course;
            bet.Result = result;
            bet.isFinished = isFinished;

            //if (isFinished)
            //{
                if (bet.CourseWin() == course.GetHighestCourse())
                {
                    return Brushes.LightGreen;
                }
                else if (bet.CourseWin() == course.GetMediumCourse())
                {
                    return Brushes.Yellow;
                }
                else if (bet.CourseWin() == course.GetLowerCourse())
                {
                    return Brushes.Red;
                }
            //}
            return new SolidColorBrush(Color.FromArgb(255, 209, 209, 209));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DecimalToColorNameConverterForeground : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return DecimalToColorNameHelper.Get(values, Brushes.LightGreen, Brushes.Yellow, Brushes.Red, new SolidColorBrush(Color.FromArgb(255, 209, 209, 209)));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
