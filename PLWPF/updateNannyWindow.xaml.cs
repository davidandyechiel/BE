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
using System.ComponentModel;
using System.Collections.ObjectModel;
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for updateNannyWindow.xaml
    /// </summary>
    public partial class updateNannyWindow : Window ,INotifyPropertyChanged
    {
        private ObservableCollection<BE.Nanny> nannys = new ObservableCollection<Nanny>(); 
       public static BE.Nanny nanny;

        private ObservableCollection<BE.Nanny> Nannys
        {
            get
            {
                return nannys;
            }

            set
            {
                nannys = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public  Nanny Nanny
        {
            get
            {
                return nanny;
            }

            set
            {
                nanny = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Nanny"));
            }
        }

        public updateNannyWindow()
        {
            InitializeComponent();
             
            //this.updateNannyByIdcomboBox.ItemsSource = CC.bl.getNannyDS();
            //this.updateNannyByIdcomboBox.DisplayMemberPath = "Id";
            //this.updateNannyByIdcomboBox.SelectedValuePath = "Id";
            grid1.DataContext = Nanny;
            hourRateTextBox.IsEnabled = false;
            //updateNannyByIdcomboBox.DataContext = Nannys;
        }
        /// <summary>
        /// Nanny update mode
        /// </summary>
        /// <param name="_nanny"> existing nanny </param>
        public updateNannyWindow(SUNanny_page fromSUnanny, Nanny _nanny)
        {
            InitializeComponent();
            nanny = new BE.Nanny(_nanny);
            grid1.DataContext = nanny;
            //TODO:reverse datetime to timepicker
            DateTime[][] hourArray = _nanny.DThoursTable;
            // int i = 0;
            //foreach (RoyT.TimePicker.TimePicker item in tpGrid.Children)
            //{

            //    item.Time.Hour = hourArray[i][0].Hour;
            //    item.Time.Minute= hourArray[i][0].Minute;
            //    i++;
            //}
        }


        private void updatebutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //foreach (Nanny nanny in updateNannyByIdcomboBox.Items)
                //    if(!CC.bl.Exists(nanny))
                //    {
                //        nanny.Id = int.Parse(updateNannyByIdcomboBox.Text);
                //        CC.bl.Add(nanny);
                //    }
                CC.bl.Update(nanny);
                //this.updateNannyByIdcomboBox.ItemsSource = CC.bl.getNannyDS();
                //  Nanny = new BE.Nanny();
                // grid1.DataContext = Nanny;
                //  CC.bl.Update(Nanny);
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
                //Nanny = (BE.Nanny)updateNannyByIdcomboBox.SelectedItem;
                grid1.DataContext = Nanny;
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
