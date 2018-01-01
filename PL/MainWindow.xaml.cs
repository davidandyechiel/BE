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
using System.ComponentModel;
using BL;
using BE;

namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Members
        private ;
        private BindingList<Nanny> NannysList;
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            bl = MyBL.Instance;
            CreateDemoEntites();
            LoadNannyListOnWindow();
           

        }

        private void CreateDemoEntites()
        {
            int[] idArray = new int[] { 1, 2, 3, 4,5 };
            foreach (int i in idArray)
            {
                bl.addNanny (new Nanny(idArray[i], "a","b"));
            }
          
        }

        private void LoadNannyListOnWindow()
        {
            NannysList = bl.getNannysList();
            lvNanny.DataContext = NannysList;
        }

        private void addNannyButton_Click(object sender, RoutedEventArgs e)
        {
            string id = bl.getLastNannyID();
            int newID;
            Int32.TryParse(id, out newID);
            bl.addNanny(new Nanny((++newID).ToString(), 21));
        }
    }
}
