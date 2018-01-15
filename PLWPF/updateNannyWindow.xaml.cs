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
    /// Interaction logic for updateNannyWindow.xaml
    /// </summary>
    public partial class updateNannyWindow : Window
    {
        BE.Nanny nanny;
        BL.IBL bl;

        public updateNannyWindow()
        {
            InitializeComponent();
            this.updateNannyByIdcomboBox.ItemsSource = bl.getNannyDS();
            this.updateNannyByIdcomboBox.DisplayMemberPath = "NannyName";
            this.updateNannyByIdcomboBox.SelectedValuePath = "NannyId";
        }

        private void deleteNannycomboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void updateNannyByIdcomboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        /*
            if (this.updateNannyByIdcomboBox.SelectedItem is Nanny)
            { this.nannyToUpdate = ((Nanny)this.updateNannyByIdcomboBox.SelectedItem).GetCopy();
                this.DataContext = nannyToUpdate;
            }*/
        
    }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
