using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Setting_page.xaml
    /// </summary>
    public partial class Setting_page : Page
    {/*TODO:
        1. set langugh
        2. set DS
        3. ser ADDRESS
        */
        public Setting_page()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void slider_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Slider s = e.Source as Slider;
            if (s.Value == 0)
                s.Value = 1;
            else
                s.Value = 0;


        }

        private void LANGslider_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        

        private void DSslider_TouchDown(object sender, TouchEventArgs e)
        {

        }

       

        private void DSslider_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
        }

        private void DSslider_GotMouseCapture(object sender, MouseEventArgs e)
        {
            Slider s = e.Source as Slider;
           
            if (s.Value < 0.5)
                s.Value = 1;
            else
                s.Value = 0;

        }

        private void DSslider_ValueChanged_2(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DSslider.Value == 0 && CC.bl.getInstanceType() == BE.EnumClasses.E_InstanceType.LIST)
                    CC.bl.setInstanceType(BE.EnumClasses.E_InstanceType.XML);
                if (DSslider.Value == 1 && CC.bl.getInstanceType() == BE.EnumClasses.E_InstanceType.XML)
                    CC.bl.setInstanceType(BE.EnumClasses.E_InstanceType.LIST);
            }
            catch (Exception exp)
            {
                CC.WindowError("Data Surce Had Been Cahnged");
            }
        }
    }
}
