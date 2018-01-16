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
    /// Interaction logic for MomWindow.xaml
    /// </summary>
    public partial class MomWindow : Window
    {
        BE.Mother mom;
        // TODO: BL.IBL bl;
        public MomWindow()
        {
            
            InitializeComponent();
            mom = new BE.Mother();
            this.DataContext = mom;


            // TODO: this.studentCampusComboBox.ItemsSource = Enum.GetValues(typeof(BE.Campus));
            //TODO: bl = BL.FactoryBL.GetBL();
        }

        public MomWindow(BE.Mother _mom)
        {
            InitializeComponent();
            mom = new BE.Mother(_mom);
            this.DataContext = mom;
            //TODO: bl = BL.FactoryBL.GetBL();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource motherViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("motherViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // motherViewSource.Source = [generic data source]
        }

       

        

        

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //BE.Mother mom = new BE.Mother(
            //    int.Parse(idTextBox.Text),
            //    lastNameTextBox.Text,
            //    firstNameTextBox.Text,
            //    int.Parse(homePhoneNumTextBox.Text),
            //    int.Parse(cellPhoneNumTextBox.Text),
            //    addressTextBox.Text,
            //    addressNearHereTextBox.Text,
            //    notesTextBox.Text,
            //    BE.Mother.setHours(sunday_start_slider.Value,
            //                       sunday_end_slider.Value,
            //                       monday_start_slider.Value,
            //                       monday_end_slider.Value,
            //                       tuesday_start_slider.Value,
            //                       tuesday_end_slider.Value,
            //                       wednesday_start_slider.Value,
            //                       wednesday_end_slider.Value,
            //                       thursday_start_slider.Value,
            //                       thursday_end_slider.Value,
            //                       friday_start_slider.Value,
            //                       friday_end_slider.Value
            //                      ),
            //    int.Parse(numOfKidsTextBox.Text));


            try
            {
                //  course.CourseId = int.Parse(this.idTextBox.Text);
                //  course.CourseName = this.nameTextBox.Text;

              //TODO:  bl.AddStudent(student); + update the window list
              //  mom = new BE.Mother();
              //  this.DataContext = mom;
                Close();

                //  this.idTextBox.ClearValue(TextBox.TextProperty);   // this.idTextBox.Text = ""
                //  this.nameTextBox.ClearValue(TextBox.TextProperty);// this.nameTextBox.Text = ""
            }
            catch (FormatException)
            {
                MessageBox.Show("check your input and try again");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }





        }


                
                
                
                
        

        private void idTextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            //TODO: check id in mother list
        }

        private void children_combo_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: bind the with collection tat take all the kids with the same mom, add "observer"
        }

        private void AddChild_Click(object sender, RoutedEventArgs e)
        {





            ChildWindow childwin = new ChildWindow();
            childwin.Show();
               
        }

        private void UpdateChild_Click(object sender, RoutedEventArgs e)
        {
            //TODO: take the child from the combobox to build new child and then update it
            ChildWindow childwin = new ChildWindow();
            childwin.Show();
        }
    }
}
