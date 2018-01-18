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
        public Map_View mapView;
        public SUNanny_page SUNannyPage;
        public SUMother_page SUMotherPage;
        public FNanny_page FNannyPage;
        public Setting_page SettingPage;

        public MainWindow()
        {
            mapView = new Map_View();
            AddDefaultValues();
            InitializeComponent();
        }

        private static void AddDefaultValues()
        {
           BE.Mother mom = new 








        }

        private void mainPage_Click(object sender, RoutedEventArgs e)
        {
            curretPage.Content = mapView;
        }

        private void signNanny_Click(object sender, RoutedEventArgs e)
        {
            if (SUNannyPage == null)
                SUNannyPage = new SUNanny_page();
            curretPage.Content = SUNannyPage;
        }

        private void signMother_Click(object sender, RoutedEventArgs e)
        {
            if (SUMotherPage == null)
                SUMotherPage = new SUMother_page();
            curretPage.Content = SUMotherPage;

        }

        private void findNanny_Click(object sender, RoutedEventArgs e)
        {
            if (FNannyPage == null)
                FNannyPage = new FNanny_page();
            curretPage.Content = FNannyPage;

        }

        private void setting_Click(object sender, RoutedEventArgs e)
        {
            if (SettingPage == null)
                SettingPage = new Setting_page();
            curretPage.Content = SettingPage;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            updateNannyWindow nan = new updateNannyWindow();
            nan.Show();
        }
    }
}
