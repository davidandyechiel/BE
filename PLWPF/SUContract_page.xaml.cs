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
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for SUContract_page.xaml
    /// </summary>
    public partial class SUContract_page : Page
    {
        private ObservableCollection<Contract> contractCollection;
     //   private currentCont;
        #region PROPERTY
        public ObservableCollection<Contract> MotherCollection
        {
            get
            {
                return contractCollection;
            }

            set
            {
                contractCollection = value;
            }
        }
        #endregion

        public SUContract_page()
        {
            InitializeComponent();


        }

        private void contractDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void filterButton_Click(object sender, RoutedEventArgs e)
        { 
               if (textBox.Text == "")
               {
                //list = all the grup

               }
               else if ()
            
        }
}
