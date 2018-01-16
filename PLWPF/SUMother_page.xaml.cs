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
        public SUMother_page()
        {
            InitializeComponent();
        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            MomWindow momWin = new MomWindow();
            momWin.Show();
        }

        private void UPDATE_Click(object sender, RoutedEventArgs e)
        {
            MomWindow momWin = new MomWindow();
            momWin.Show();
        }
    }
}
