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
    /// Interaction logic for ContractWindow.xaml
    /// </summary>
    public partial class ContractWindow : Window
    {
        private Mother mother;
        private Nanny nanny;
        private Contract contract;
        bool update;

        public ContractWindow()
        {
            InitializeComponent();
        }

        public ContractWindow(Mother mother, Nanny nanny)
        {
            InitializeComponent();
            this.mother = mother;
            this.nanny = nanny;
            nannysName.Text = this.nanny.ToString();
            List<Child> list = new List<Child>();
            foreach (Child child in CC.bl.getChildDS())
            {
                if (child.MothersId == mother.Id)
                    list.Add(child);
            }
            children_combobox.ItemsSource = list;
            contract = new Contract();
            contract.Ishourly = nanny.PerHour;
            contract.Wages = nanny.Wages;
            checkBoxGrid.DataContext = contract;
            update = false;
            delete.Visibility = Visibility.Collapsed;

        }
        //update mode
        public ContractWindow(Contract contract)
        {
            
            InitializeComponent();
            this.contract = contract;
            nannysName.Text = CC.bl.FindNanny(x => x.Id == contract.NannysID).ToString();
            List<Child> list = new List<Child>();
            list.Add(CC.bl.FindChild(x => x.Id == contract.ChildID));
            children_combobox.ItemsSource = list;
            children_combobox.SelectedIndex = 0;
            children_combobox.IsEnabled = false;
            contract.Ishourly = contract.Ishourly;
            contract.Wages = contract.Wages;
            checkBoxGrid.DataContext = contract;
            update = true;
            delete.Visibility = Visibility.Visible;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource contractViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("contractViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // contractViewSource.Source = [generic data source]
        }



        private void save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CC.YES_NO_Window("save"))
                    if (update)
                        CC.bl.Update(contract);
                   else CC.bl.Add(contract);            
            }
             catch (Exception exp)
            { CC.WindowError(exp.Message); }

        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void children_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int childId = (children_combobox.SelectedItem as Child).Id;
                Contract cont = CC.bl.FindContract(x => x.ChildID == childId);
                if (cont != null)
                {
                    if ((MessageBox.Show(string.Format("This child is allready in contract # {0},\n do you want to upload that contract?", cont.ContractNum),
                                            "Window Saving",
                                            MessageBoxButton.YesNo,
                                            MessageBoxImage.Question) == MessageBoxResult.Yes))
                    {
                        update = true;
                        delete.Visibility = Visibility.Visible;
                        children_combobox.IsEnabled = false;
                        nannysName.Text = (CC.bl.FindNanny(x => x.Id == cont.NannysID)).ToString();
                        contract = cont;
                        checkBoxGrid.DataContext = contract;

                    }
                    else
                        children_combobox.SelectedItem = -1;
                }
            }

            catch (Exception exp)
            { CC.WindowError(exp.Message); }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CC.YES_NO_Window("delete"))
                {
                    CC.bl.Remove(new Contract(nanny.Id, (children_combobox.SelectedItem as Child).Id));
                    Close();
                }
            }
            catch (Exception exp)
            {
                CC.WindowError(exp.Message);
            }
        }
    }
}
