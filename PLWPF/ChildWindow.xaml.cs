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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for ChildWindow.xaml
    /// </summary>
    public partial class ChildWindow : Window
    {
        BE.Child child;
        public ChildWindow()
        {
            InitializeComponent();
            child = new BE.Child();
            DataContext = child;
        }
        public ChildWindow(BE.Child _child)
        {
            InitializeComponent();
            child = new BE.Child(_child);
            DataContext = child;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource childViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("childViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // childViewSource.Source = [generic data source]
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {   
            //TODO: bl add child + take care of the update the combobox;

        }
    }
}
