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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BE.Nanny nanny;
        BL.IBL bl;
        public MainWindow()
        {

            InitializeComponent();
            this.deleteNannycomboBox.ItemsSource = bl.getNannyDS();
            this.deleteNannycomboBox.DisplayMemberPath = "lastName";
            this.deleteNannycomboBox.SelectedValuePath = "id";
        }
        //nanny
        //private void NannyButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Window nannyWindow = new NannyWindow();
        //    nannyWindow.Show();
        //}
        private void addNannybutton_Click(object sender, RoutedEventArgs e)
        {
            Window addNannyWindow = new AddNannyWindow();
            addNannyWindow.Show();
        }

        private void updateNanny_Click(object sender, RoutedEventArgs e)
        {

            Window updateNannyWindow = new updateNannyWindow();
            updateNannyWindow.Show();
        }


        private void deleteNanntbutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.Remove(nanny);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

       





//mom

       
        
    }
}
