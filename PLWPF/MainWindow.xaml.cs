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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NannyButton_Click(object sender, RoutedEventArgs e)
        {
            Window nannyWindow = new NannyWindow();
            nannyWindow.Show();
        }

        private void MomButton_Click(object sender, RoutedEventArgs e)
        {
            Window momWindow = new MomWindow();
            momWindow.Show();
        }

        private void ContractButton_Click(object sender, RoutedEventArgs e)
        {
            Window contractWindow = new ContractWindow();
            contractWindow.Show();
        }

        private void ChildButton_Click(object sender, RoutedEventArgs e)
        {
            Window childWindow = new ChildWindow();
            childWindow.Show();
        }
    }
}
