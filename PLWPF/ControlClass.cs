using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Globalization;
using System.Windows.Data;
using BE;
namespace PLWPF
{
    /// <summary>
    ///  class that contain genral things, that should be use for all the namespace
    /// </summary>
    public class CC
    {
        public static BL.IBL bl = BL.BL_Basic.Instance;

        public static bool YES_NO_Window(string str)
        {
            return (MessageBox.Show(String.Format("Are you sure you want to {0}?", str),
                                            "Window Saving",
                                            MessageBoxButton.YesNo,
                                            MessageBoxImage.Question) == MessageBoxResult.Yes) ? true : false;
        }

        public static void WindowError(string str)
        {
            MessageBox.Show(String.Format(str),
                                            "Window Error",
                                            MessageBoxButton.OK,
                                            MessageBoxImage.Exclamation);
        }



        static public DateTime[,] setHoursDT(params double[] times)
        {

            DateTime[,] hours = new DateTime[6, 2];
            for (int i = 0; i < times.Length; i += 2)
            {
                hours[i / 2, 0] = DoubleToDateTime(times[i]);
                hours[i / 2, 1] = DoubleToDateTime(times[i + 1]);
            }
            return hours;
        }
        static public double[] setHoursD(DateTime[,] times)
        {

            double[] hours = new double[12];
            for (int i = 0; i < hours.Length; i += 2)
            {
                hours[i] = DateTimeToDouble(times[i, 0]);
                hours[i + 1] = DateTimeToDouble(times[i, 1]);
            }
            return hours;
        }



        public static DateTime DoubleToDateTime(double d)
        {
            int H = (int)d;
            int m = (int)(d - H);
            string str = string.Format("{0}:{1}", (H < 100 ? "0" + (H / 10).ToString() : (H / 10).ToString()), (m < 5 ? "00" : "30")); // set string in format HH:mm
            return DateTime.ParseExact(str, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        }

        public static double DateTimeToDouble(DateTime dt)
        {
            double H = dt.Hour * 10;
            double m = (dt.Minute == 0 ? 0 : 5);
            return H + m;
        }








    } // CC

    public static class ExtentionMethods
    {
        public static IEnumerable<Contract> FilterBy(this IEnumerable<Contract> list, Predicate<Contract> p)
        {
            return CC.bl.FilterBy(list, p);
        }
    }




public class DoubleToTimeViewStringConverter : IValueConverter
    {
        public object Convert(
          object value,
          Type targetType,
          object parameter,
          CultureInfo culture)
        {
            double d = (double)value/10 ;
            int H = (int)d;
            double m = d - H;
            return  string.Format("{0}:{1}", (H < 10 ? "0" + H.ToString() : (H).ToString()), (m < 0.5 ? "00" : "30")); // set string in format HH:mm
        }

        public object ConvertBack(
          object value,
          Type targetType,
          object parameter,
          CultureInfo culture)
        {
            string[] spliter = ((string)value).Split(':');
            double H = double.Parse(spliter[0]) * 10;
            double m = (spliter[1] == "00") ? 0 : 0.5;
            return H + m;
        }

    }

    public class IntToTimeViewStringConverter : IValueConverter
    {
        public object Convert(
          object value,
          Type targetType,
          object parameter,
          CultureInfo culture)
        {
            int H = (int)value / 10;
            int m = (((int)value) - (H * 10));
            return string.Format("{0}:{1}", (H < 10 ? "0" + H.ToString() : H.ToString()), (m < 50 ? "00" : "30")); // set string in format HH:mm
        }

        public object ConvertBack(
          object value,
          Type targetType,
          object parameter,
          CultureInfo culture)
        {
            string[] str = ((string)value).Split(':');
            return int.Parse(str[0]) + int.Parse(str[1]);
        }
    }
    public class EmptyTextToVisabilityConverter : IValueConverter
    {
        public object Convert(
          object value,
          Type targetType,
          object parameter,
          CultureInfo culture)
        {
            string str = (string)value;
            if (str == "")
            {
                return Visibility.Collapsed;
            }
            else
            {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(
          object value,
          Type targetType,
          object parameter,
          CultureInfo culture)
        {
            string[] str = ((string)value).Split(':');
            return int.Parse(str[0]) + int.Parse(str[1]);
        }
    }

    public class ItemCollectionToInt : IValueConverter
    {
        public object Convert(
          object value,
          Type targetType,
          object parameter,
          CultureInfo culture)
        {
            System.Windows.Controls.ItemCollection items = (System.Windows.Controls.ItemCollection)value;
            
                return items.Count;
            
        }

        public object ConvertBack(
          object value,
          Type targetType,
          object parameter,
          CultureInfo culture)
        {
            string[] str = ((string)value).Split(':');
            return int.Parse(str[0]) + int.Parse(str[1]);
        }
    }





}//PLWPF
