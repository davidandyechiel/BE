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
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddNannyWindow.xaml
    /// </summary>
    public partial class AddNannyWindow : Window
    {
        BE.Nanny nanny;
       // BL.IBL bl;


        public AddNannyWindow()
        {
            InitializeComponent();
            nanny = new BE.Nanny();
            this.DataContext = nanny;
            this.grid1.DataContext = nanny;
           

          //  bl = BL.blfactory.getbl();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource nannyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("nannyViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // nannyViewSource.Source = [generic data source]
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
               
                DateTime[][]hourList= new DateTime[6][];
                int i = 0;
                foreach (RoyT.TimePicker.TimePicker tp in tpGrid.Children)
                {
                    if (hourList[i / 2] == null)
                        hourList[i / 2] = new DateTime[2];
                    hourList[i / 2][ i % 2] = CC.bl.DoubleToDateTime(tp.Time.Hour, tp.Time.Minute);
                    i++;
                }
                nanny.DThoursTable = hourList;
                nanny.Id = int.Parse(this.idTextBox.Text);
                CC.bl.Add(nanny);
                nanny = new BE.Nanny();
                grid1.DataContext = nanny;
                grid2.DataContext = nanny;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            var v = tpFridayEnd.Time;
            
            
        }

        private void idTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
