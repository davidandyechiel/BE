using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PLWPF
{
    /// <summary>
    ///  class that contain genral things, that should be use for all the namespace
    /// </summary>
    public class CC 
    {
        public static BL.IBL bl = BL.BL_Basic.Instance;

        public static MessageBoxResult WindowSaving(string str)
        {
            return MessageBox.Show( String.Format("Are you sure you want to {0}?" , str),
                                             "Window Saving",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Question);
        }

        public static void WindowError(string str)
        {
             MessageBox.Show(String.Format( str),
                                             "Window Error",
                                             MessageBoxButton.OK,
                                             MessageBoxImage.Exclamation);
        }



        static public DateTime[][] setHoursDT(params double[] times)
        {
            
            DateTime[][] hours = new DateTime[6][];
            for (int i = 0; i < times.Length; i += 2)
            {
                hours[i / 2][0] = DoubleToDateTime(times[i]);
                hours[i / 2][1] = DoubleToDateTime(times[i + 1]);
            }
            return hours;
        }
        static public double[] setHoursD(DateTime[][] times)
        {

            double[] hours = new double[12];
            for (int i = 0; i < hours.Length; i += 2)
            {
                hours[i] = DateTimeToDouble(times[i][0]);
                hours[i + 1] = DateTimeToDouble(times[i][1]);
            }
            return hours;
        }

               

        public static DateTime DoubleToDateTime(double d)
        {
            int H = (int)d;
            int m = (int)((d - H) * 10);
            string str = string.Format("{0}:{1}", (H < 10 ? "0" + H.ToString() : H.ToString()), (m == 0 ? "00" : "30")); // set string in format HH:mm
            return DateTime.ParseExact(str, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        }

        public static double DateTimeToDouble(DateTime dt)
        {
            double H = dt.Hour;
            double m = (dt.Minute == 0 ? 0 : 0.5);
            return H + m;
        }
        

    
      
       



    } // CC
}//PLWPF
