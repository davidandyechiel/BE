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
        static MainPageMap mainPageMap;
        #region dependency property

        public static DependencyProperty CurrentPage =
            DependencyProperty.Register("MyCurrentPage"
                                            , typeof(MainPageMap)
                                              , typeof(MainWindow)
                                                 , new PropertyMetadata(mainPageMap));


        public MainPageMap MyCurrentPage
        {
            get
            {
                return (MainPageMap)GetValue(CurrentPage);
            }

            set
            {
                SetValue(CurrentPage, value);
            }
        }
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            mainPageMap = new MainPageMap();

            
                 //set the new map view
        }
        /*
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
        }*/

        private void button_Copy2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = mainPageMap;
        }
    }
}
