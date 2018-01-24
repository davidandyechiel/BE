using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Globalization;
using System.Windows.Data;
using BE;

using System.Collections.ObjectModel;

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
        
    } // CC

    public static class ExtentionMethods
    {
        public static IEnumerable<Contract>  FilterBy(this IEnumerable<Contract> list, Predicate<Contract> p)
        {
           return CC.bl.FilterBy(list, p);
        }
        public static IEnumerable<Nanny> FilterBy(this IEnumerable<Nanny> list, Predicate<Nanny> p)
        {
            return CC.bl.FilterBy(list, p);
        }

        public static void Clone(this ObservableCollection<Contract> list, IEnumerable<Contract> cloneFrom)
        {
            list.Clear();
            foreach (var item in cloneFrom)
            {
                list.Add(item);
            }
         }

        


    }






    





}//PLWPF
