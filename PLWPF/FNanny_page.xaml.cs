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
using System.Collections.ObjectModel;


namespace PLWPF
{
    /// <summary>
    /// Interaction logic for FNanny_page.xaml
    /// </summary>
    public partial class FNanny_page : Page
    {
        private ObservableCollection<BE.Mother> momCollection = new ObservableCollection<BE.Mother>();
        private ObservableCollection<BE.Nanny> nannyCollection = new ObservableCollection<BE.Nanny>();


        public FNanny_page()
        {
            InitializeComponent();
            foreach (var mom in CC.bl.getMotherDS())
                momCollection.Add(mom);
            foreach (var nanny in CC.bl.getNannyDS())
                if (CC.bl.CheckCapacity(nanny))  // filtering only alailable nannies
                    nannyCollection.Add(nanny);
            comboboxMom.ItemsSource = momCollection;
            nannyDataGrid.ItemsSource = nannyCollection;

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {   
                if (!CC.bl.CheckCapacity(nannyDataGrid.SelectedItem as BE.Nanny))
                    throw new Exception("nanny is full");
                ContractWindow cont = new ContractWindow(comboboxMom.SelectedItem as BE.Mother, nannyDataGrid.SelectedItem as BE.Nanny);
                cont.Show();
            }
            catch (Exception exp)
            {
                CC.WindowError(exp.Message);
            }
        }

        private void comboboxMom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex == -1)
                lower_than_splitter.IsEnabled = false;
            else lower_than_splitter.IsEnabled = true;

           nannyDataGrid.ItemsSource = CC.bl.nannysThatCanWorkForMe((sender as ComboBox).SelectedItem as BE.Mother);
        }



        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int id = -1;
            if (textBox.Text != "")
                id = int.Parse(textBox.Text);
            foreach (var item in comboboxMom.Items)
            {
                if ((item as BE.Mother).Id == id)
                {
                    comboboxMom.SelectedItem = item;
                    return;
                }
                else comboboxMom.SelectedIndex = -1;
            }
        }

        private void filter_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //radio button condition:

               

                IEnumerable<BE.Nanny> filteredList = CC.bl.getNannyDS();
                Predicate<BE.Nanny> filters = new Predicate<BE.Nanny>( CC.bl.CheckCapacity);

                if (textBox.Text == "")
                    throw new Exception("Enter id value");
                if (dependedDaysOffCheckBox.IsChecked.Value)  //depended days off filter
                    filters += delegate(BE.Nanny arg) { return arg.DependedDaysOff; };
                if (perHourCheckBox.IsChecked.Value)  // perhour filter
                    filters += delegate (BE.Nanny arg) { return arg.PerHour; };
                if (elevatorCheckBox.IsChecked.Value) //need elevator filter
                    filters += delegate (BE.Nanny arg) { return arg.Elevator; };
            /*    else if ()
                

                //isSigned ComboBox condition:

                if (comboBoxSign.SelectedIndex == 1)
                    filteredList = filteredList.FilterBy(x => x.IsSigned == true);
                else if (comboBoxSign.SelectedIndex == 2)
                    filteredList = filteredList.FilterBy(x => x.IsSigned == false);

                contractDataGrid.ItemsSource = filteredList;

    */


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void elevatorCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            floorTextBox.Visibility = Visibility.Collapsed;
        }

        private void elevatorCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            floorTextBox.Visibility = Visibility.Visible;
        }



        private void floorTextBox_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!floorTextBox.IsEnabled)
                floorTextBox.Text = "";
        }

        
    }//FNanny_page
}//PLWPF
