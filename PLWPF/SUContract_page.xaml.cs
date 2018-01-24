﻿using System;
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
    public partial class SUContract_page : Page, INotifyPropertyChanged
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ContractCollection"));
            }
        }
        #endregion

        public SUContract_page()
        {
            InitializeComponent();
            ContractCollection = new ObservableCollection<Contract>(CC.bl.getContractDS());
            contractDataGrid.ItemsSource = ContractCollection;
            DataContext = ContractCollection;

        }

        private void contractDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void filterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //radio button condition:

                IEnumerable<Contract> filteredList = CC.bl.getContractDS();

                if (radioButtonAll.IsChecked.Value)
                    filteredList = CC.bl.getContractDS();
                else if (textBox.Text == "")
                    throw new Exception("Enter id value");
                else if (radioButtoChildnum.IsChecked.Value)
                    filteredList = CC.bl.FilterBy(x => x.ChildID == int.Parse(textBox.Text));
                else if (radioButtonContnum.IsChecked.Value)
                    filteredList = CC.bl.FilterBy(x => x.ContractNum == int.Parse(textBox.Text));
                else if (radioButtonNannynum.IsChecked.Value)
                    filteredList = CC.bl.FilterBy(x => x.NannysID == int.Parse(textBox.Text));

                //isSigned ComboBox condition:

                if (comboBoxSign.SelectedIndex == 1)
                    filteredList = filteredList.FilterBy(x => x.IsSigned == true);
                else if (comboBoxSign.SelectedIndex == 2)
                    filteredList = filteredList.FilterBy(x => x.IsSigned == false);

                contractDataGrid.ItemsSource = filteredList;




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void radioButtonAll_Checked(object sender, RoutedEventArgs e)
        {
            ContractCollection = new ObservableCollection<Contract>(CC.bl.getContractDS());
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CC.YES_NO_Window("delete?"))
                    CC.bl.Remove(contractDataGrid.SelectedItem as Contract);
            }
            catch (Exception exp)
            {
                CC.WindowError(exp.Message);
            }
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            ContractWindow cont = new ContractWindow(contractDataGrid.SelectedItem as Contract);
            cont.Show();
        }
    }
}
