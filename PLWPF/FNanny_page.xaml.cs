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
                nannyCollection.Add(nanny);
            
            
            comboboxMom.ItemsSource = momCollection;
            nannyDataGrid.ItemsSource = nannyCollection;
        }
    }
}
