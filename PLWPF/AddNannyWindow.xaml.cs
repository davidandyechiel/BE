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
        BL.IBL bl;


        public AddNannyWindow()
        {
            InitializeComponent();
            nanny = new BE.Nanny();
            this.grid1.DataContext = nanny;
            this.grid2.DataContext = nanny;

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
                nanny.Id = int.Parse(this.idTextBox.Text);
                CC.bl.Add(nanny);
                nanny = new BE.Nanny();
                this.grid1.DataContext = nanny;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        private void idTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
