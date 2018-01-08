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
    /// Interaction logic for NannyWindow.xaml
    /// </summary>
    public partial class NannyWindow : Window
    {
        BL.IBL bl;
        BE.Nanny nanny;
        public NannyWindow()
        {
            InitializeComponent();
           // this.deleteNannycomboBox.ItemsSource = BL.BL_Basic.Instance.getNannyDS();


            this.deleteNannycomboBox.ItemsSource = bl.getNannyDS();
            this.deleteNannycomboBox.DisplayMemberPath = "lastName,firstName";
            this.deleteNannycomboBox.SelectedValuePath = "id";
        }

        private void addNannybutton_Click(object sender, RoutedEventArgs e)
        {
            Window addNannyWindow = new AddNannyWindow();
            addNannyWindow.Show();
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

        private void updateNanny_Click(object sender, RoutedEventArgs e)
        {

            Window updateNannyWindow = new updateNannyWindow();
            updateNannyWindow.Show();
        }
    }
}
