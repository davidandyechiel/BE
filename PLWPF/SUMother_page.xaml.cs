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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for SUMother_page.xaml
    /// </summary>
    public partial class SUMother_page : Page
    {
        BL.IBL bl;
        public SUMother_page()
        {
            InitializeComponent();
            bl = BL.BL_Basic.Instance;
            motherListView.ItemsSource = CC.bl.getMotherDS();
        }

        public SUMother_page(int i)
        {
            InitializeComponent();
            bl = BL.BL_Basic.Instance;
        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            MomWindow momWin = new MomWindow();
            momWin.Show();
        }

        private void UPDATE_Click(object sender, RoutedEventArgs e)
        {
           // TODO: make a converter between the combobox item and the BE.Mother
       //     MomWindow momWin = new MomWindow(comboBox.SelectionBoxItem as BE.Mother );
         //   momWin.Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MomWindow momwin;
            momwin = new MomWindow();
            momwin.Show();
        }

        private void DELETE_Click(object sender, RoutedEventArgs e)
        {
            //TODO: update the list
            bl.Remove(sender as BE.Mother);
        }

        private void motherListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
