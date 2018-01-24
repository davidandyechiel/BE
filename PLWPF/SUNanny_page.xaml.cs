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
    /// Interaction logic for SUNanny_page.xaml
    /// </summary>
    public partial class SUNanny_page : Page
    {
        private ObservableCollection<Nanny> nannyCollection;
        private Nanny currentnanny;
        #region PROPERTY
        public ObservableCollection<Nanny> NannyCollection
        {
            get
            {
                return nannyCollection;
            }

            set
            {
                nannyCollection = value;
            }
        }
        #endregion
        public BL.IBL bl;
        public SUNanny_page()
        {
            InitializeComponent();
            nannyCollection = new ObservableCollection<Nanny>(CC.bl.getNannyDS());
            nannyDataGrid.ItemsSource = nannyCollection;
            DataContext = nannyCollection;
            currentnanny = new Nanny();
            idComboBox.ItemsSource = CC.bl.getNannyDS();
            nannyDataGrid.ItemsSource = CC.bl.getNannyDS();
            
        }

        private void AddNanny_Click(object sender, RoutedEventArgs e)
        {
            AddNannyWindow nannyWin = new AddNannyWindow();
            nannyWin.Show();
          //  new AddNannyWindow().Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            updateNannyWindow updNan = new updateNannyWindow(this,idComboBox.SelectedItem as Nanny);
            updNan.Show();
        }

        private void nannyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void idComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
