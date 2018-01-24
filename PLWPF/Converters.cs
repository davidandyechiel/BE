using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace PLWPF
{


    public class DoubleToTimeViewStringConverter : IValueConverter
    {
        public object Convert(
          object value,
          Type targetType,
          object parameter,
          CultureInfo culture)
        {
            double d = (double)value / 10;
            int H = (int)d;
            double m = d - H;
            return string.Format("{0}:{1}", (H < 10 ? "0" + H.ToString() : (H).ToString()), (m < 0.5 ? "00" : "30")); // set string in format HH:mm
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

    public class OpositeCheckConverter : IValueConverter
    {
        public object Convert(
          object value,
          Type targetType,
          object parameter,
          CultureInfo culture)
        {
            if (((bool?)value).Value )
                return false;
            else return true;
        }

        public object ConvertBack(
          object value,
          Type targetType,
          object parameter,
          CultureInfo culture)
        {
            if ((bool)value)
                return false;
            else return true;
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

    public class SelectedIndexToVisible : IValueConverter
    {
        public object Convert(
          object value,
          Type targetType,
          object parameter,
          CultureInfo culture)
        {
            if ((string)value == "-1")
                return false;
            else return true;
        }

        public object ConvertBack(
          object value,
          Type targetType,
          object parameter,
          CultureInfo culture)
        {
            throw new Exception("not impliented!");
        }
    }


    
}
