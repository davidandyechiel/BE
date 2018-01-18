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
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for updateNannyWindow.xaml
    /// </summary>
    public partial class updateNannyWindow : Window
    {
       public static BE.Nanny nanny;

        public static Nanny Nanny
        {
            get
            {
                return nanny;
            }

            set
            {
                nanny = value;
            }
        }

        public updateNannyWindow()
        {
            InitializeComponent();
            this.updateNannyByIdcomboBox.ItemsSource = CC.bl.getNannyDS();
            this.updateNannyByIdcomboBox.DisplayMemberPath = "Id";
            this.updateNannyByIdcomboBox.SelectedValuePath = "Id";
            this.DataContext = Nanny;
            hourRateTextBox.IsEnabled = false;
        }

      

        private void updatebutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CC.bl.Update(Nanny);
                Nanny = new BE.Nanny();
                this.DataContext = Nanny;
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
                Nanny = (BE.Nanny)updateNannyByIdcomboBox.SelectedItem;
                this.DataContext = Nanny;
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

                CC.bl.Remove(Nanny);
                Nanny = new BE.Nanny();
                this.DataContext = Nanny;
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

        private void perHourCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            hourRateTextBox.IsEnabled = true;
        }

        private void perHourCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            hourRateTextBox.IsEnabled = false;
        }

        private void Window_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

    }
    
}
