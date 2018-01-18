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
            BE.Mother mom1 = new BE.Mother(1, "Cohen", "Sarah", 026541526, 0527412564, "הועד הלאומי12, ירושלים", "הועד הלאומי12, ירושלים", " ", null, 2);
            BE.Child child11 = new BE.Child(123, 1, "Yossi", "Chohen", BE.E_gender.BOY, false, "", new DateTime(2017, 1, 1));
            BE.Child child12 = new BE.Child(124, 1, "Moshe", "Chohen", BE.E_gender.BOY, false, "", new DateTime(2015, 1, 1));

            BE.Mother mom2 = new BE.Mother(2, "Levi", "Ofra", 026584921, 0549853665, "הועד הלאומי13, ירושלים", "הועד הלאומי13, ירושלים", " ", null, 2);
            BE.Child child21 = new BE.Child(125, 1, "Avraham", "Levi", BE.E_gender.BOY, false, "", new DateTime(2017, 5, 11));
            BE.Child child22 = new BE.Child(126, 1, "Issac", "Levi", BE.E_gender.BOY, false, "", new DateTime(2015, 12, 23));


            BE.Contract con1 = new BE.Contract(11, 123);
            BE.Contract con2 = new BE.Contract(11, 124);
            BE.Contract con3 = new BE.Contract(12, 125);
            BE.Contract con4 = new BE.Contract(12, 126);




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
