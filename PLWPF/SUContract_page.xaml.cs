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
using System.ComponentModel;

using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for SUContract_page.xaml
    /// </summary>
    /// 
    //TODO: chage the  child and the nanny in the visual table
    public partial class SUContract_page : Page , INotifyPropertyChanged
    {
        private ObservableCollection<Contract> contractCollection;

        public event PropertyChangedEventHandler PropertyChanged;

        //   private currentCont;
        #region PROPERTY
        public ObservableCollection<Contract> ContractCollection
        {
            get
            {
                return contractCollection;
            }

            set
            {
                contractCollection = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ContractCollection"));
            }
        }
        #endregion

        public SUContract_page()
        {
            InitializeComponent();
            ContractCollection = new ObservableCollection<Contract>(CC.bl.getContractDS());
            contractDataGrid.ItemsSource = ContractCollection;
            DataContext = ContractCollection;
           // comboBoxSign.SelectedItem;
           // currentMom = new Mother();

        }

        private void contractDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void filterButton_Click(object sender, RoutedEventArgs e)
        {
            //radio button condition
            IEnumerable<Contract> filteredList = null;

            if (radioButtoChildnum.IsChecked.Value)
            {
                filteredList = CC.bl.FilterBy(x => x.ChildID == int.Parse(textBox.Text));
            }
            if (radioButtonContnum.IsChecked.Value)
            {
                filteredList = CC.bl.FilterBy(x => x.ContractNum == int.Parse(textBox.Text));
            }
            if (radioButtonNannynum.IsChecked.Value)
            {
                filteredList = CC.bl.FilterBy(x => x.NannysID == int.Parse(textBox.Text));
            }
            else
            {
                filteredList = CC.bl.getContractDS();
            }

            //is signed condition

       /*     if (comboBoxSign.SelectedItem )
            {
                filteredList = filteredList.FilterBy(x => (x.IsSigned));
            }
            if (comboBoxSign.SelectedItem.ToString() == "NO")
            {
                filteredList = filteredList.FilterBy( x => !(x.IsSigned));
            }
            */
            ContractCollection = new ObservableCollection<Contract>(filteredList);
            
        }

           

        private void radioButtonAll_Checked(object sender, RoutedEventArgs e)
        {
            ContractCollection = new  ObservableCollection<Contract>(CC.bl.getContractDS());             
        }
    }
}
