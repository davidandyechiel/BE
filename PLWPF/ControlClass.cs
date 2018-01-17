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
    } // CC
}//PLWPF
