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
using System.ComponentModel;
using BE;

namespace PLWPF 
{
    /// <summary>
    /// Interaction logic for SUMother_page.xaml
    /// </summary>
    public partial class SUMother_page : Page  
    {
        private ObservableCollection<Mother> motherCollection;
        private Mother currentMom;
        #region PROPERTY
        public ObservableCollection<Mother> MotherCollection
        {
            get
            {
                return motherCollection;
            }

            set
            {
                motherCollection = value;
            }
        }
        #endregion




        public SUMother_page()
        {
            InitializeComponent();
            motherCollection = new ObservableCollection<Mother>(CC.bl.getMotherDS());
            motherDataGrid.ItemsSource = motherCollection;
            DataContext = motherCollection;
            currentMom = new Mother();
        }
         


        

        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            MomWindow momWin = new MomWindow(this);
            momWin.Show();
        }

        private void UPDATE_Click(object sender, RoutedEventArgs e)
        { //TODO:  build this window
          
        MomWindow momWin = new MomWindow(this, motherDataGrid.SelectedItem as Mother);
          momWin.Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MomWindow momwin;
            momwin = new MomWindow(this);
            momwin.Show();
        }

        private void DELETE_Click(object sender, RoutedEventArgs e)
        {
            //TODO: update the list
            CC.bl.Remove(sender as BE.Mother);
        }

        private void motherListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentMom = (motherDataGrid.SelectedItem as Mother);
        }

        internal void hadChange(Mother mom, bool update)
        {
            if (update)
                motherCollection.Remove(mom);
            motherCollection.Add(mom);
        }

        private void motherDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
