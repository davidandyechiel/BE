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
    /// Interaction logic for updateNannyWindow.xaml
    /// </summary>
    public partial class updateNannyWindow : Window
    {
        BE.Nanny nanny;
        BL.IBL bl;

        public updateNannyWindow()
        {
            InitializeComponent();
            this.updateNannyByIdcomboBox.ItemsSource = bl.getNannyDS();
            this.updateNannyByIdcomboBox.DisplayMemberPath = "Id";
            this.updateNannyByIdcomboBox.SelectedValuePath = "Id";
            this.DataContext = nanny;
        }

      

        private void updatebutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                bl.Update(nanny);
                nanny = new BE.Nanny();
                this.DataContext = nanny;
                MessageBox.Show("successfully updated nanny");
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Check your input and try again");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updateNannyByIdcomboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender is ComboBox && ((ComboBox)sender).SelectedIndex > -1))
                try
                {
                nanny = (BE.Nanny)updateNannyByIdcomboBox.SelectedItem;
                this.DataContext = nanny;
                }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                bl.Remove(nanny);
                nanny = new BE.Nanny();
                this.DataContext = nanny;
                MessageBox.Show("successfully DELETED nanny");
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Check your input and try again");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    
}
