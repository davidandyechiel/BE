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
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MomWindow.xaml
    /// </summary>
    public partial class MomWindow : Window
    {
        BE.Mother mom;
        BL.IBL bl;

        public DependencyProperty BrothersProperty = DependencyProperty.Register("Brothers",typeof( List<Child>),typeof (MomWindow), new UIPropertyMetadata(""));
        public List<Child> Brothers
        {
            get { return (List<Child>)GetValue(BrothersProperty); }
            set { SetValue(BrothersProperty, value); }
        }

       
        bool update;
        public MomWindow()
        {
            InitializeComponent();
            mom = new BE.Mother();
            this.DataContext = mom;
            children_combo_box.IsEnabled = false;
            update = false;
            // TODO: this.studentCampusComboBox.ItemsSource = Enum.GetValues(typeof(BE.Campus));
            bl = BL.BL_Basic.Instance;
            children_combo_box.DataContext = Brothers;
        }

        public MomWindow(FrameworkElement _mom)
        {
            InitializeComponent();
            mom = new BE.Mother(_mom.DataContext as Mother);
            this.DataContext = mom;
            bl = BL.BL_Basic.Instance;
            Brothers = (BL.BL_Basic.Instance.collectBrothers(mom.Id).ToList());
            idTextBox.IsEnabled = false; // lock the id
            update = true;
          
        }

        private void setComboBox()
        {//TODO: see if needed
            children_combo_box.Items.Clear();
            foreach (Child child in Brothers)
            {
                ComboBoxItem newItem = new ComboBoxItem();
                newItem.Content = child.FName;
                children_combo_box.Items.Add(newItem);
            }
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
            //TODO: thread
            if (CC.bl.Exist(E_type.MOTHER, int.Parse(idTextBox.Text))
                {



            }
            else (hiddenTextBox.Text = "")

        }

        

        private void AddChild_Click(object sender, RoutedEventArgs e)
        {
            
            ChildWindow childwin = new ChildWindow();
           /*TODO: add this in the update combobox
            * 
            *  if (!children_combo_box.IsEnabled)
               children_combo_box.IsEnabled = true;*/
            childwin.Show();
               
        }

        private void UpdateChild_Click(object sender, RoutedEventArgs e)
        {
            //TODO: take the child from the combobox to build new child and then update it
            ChildWindow childwin = new ChildWindow(children_combo_box.SelectedValue as BE.Child);
            childwin.Show();
        }

        private void DeleteChild_Click(object sender, RoutedEventArgs e)
        { // TODO: update the contract , send a masseage if ther is acontract with that child
            CC.bl.Remove(children_combo_box.SelectedValue as Child);
            brothers.RemoveAt(brothers.FindIndex(x => x.Id == (children_combo_box.SelectedValue as Child).Id));
        }

        // TODO: EXeptions handler include BInDING
    }
}
