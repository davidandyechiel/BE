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
        bool update;

        public Boolean State
        {
            get { return (Boolean)this.GetValue(StateProperty); }
            set { this.SetValue(StateProperty, value); }
        }
        public static readonly DependencyProperty StateProperty = DependencyProperty.Register(
          "State", typeof(Boolean), typeof(MomWindow), new PropertyMetadata(false));

        List<Child> brothers;
        public List<Child> Brothers
        {
            get { return brothers; }
            set
            {
                brothers = value;
            }
        }

          public Double Brothers1
          {
              get { return (Boolean)GetValue(BrothersProperty); }
              set
              {
                  this.SetValue(BrothersProperty, value);
              }
          }
          public static  DependencyProperty BrothersProperty = DependencyProperty.Register(
              "Brothers1",typeof(Boolean), typeof(MomWindow), new PropertyMetadata(false));


          /// <summary>
          /// Add new mom mode
          /// </summary>
          public  MomWindow() // add new mom
          {
              InitializeComponent();
              this.DataContext = new BE.Mother();
              update = false; // new mom
              children_combo_box.ItemsSource = Brothers;
          }

          /// <summary>
          /// Mom update mode
          /// </summary>
          /// <param name="_mom"> existing mom </param>
          public  MomWindow(FrameworkElement _mom) // 
          {
              InitializeComponent();
             // mom = new BE.Mother(_mom.DataContext as Mother);
              this.DataContext = (_mom.DataContext as Mother);
              idTextBox.IsEnabled = false; // lock the id, id is inchangeable
              refreshBrotherList();
              children_combo_box.ItemsSource = Brothers;
              update = true;
          }

          public void refreshBrotherList()
          {
                Brothers = ((CC.bl as BL.BL_Basic).collectBrothers((this.DataContext as Mother).Id).ToList());
              foreach (ComboBoxItem item in children_combo_box.Items)
                  item.Content = (item.DataContext as Child).FName;
              if (children_combo_box.Items.Count == -1)
                  children_combo_box.IsEnabled = false;
              else children_combo_box.IsEnabled = true;
          }

          /*
           * TODO: see if needed maybe delete
          private void setComboBox()
          {
              children_combo_box.Items.Clear();
              foreach (Child child in Brothers)
              {
                  ComboBoxItem newItem = new ComboBoxItem();
                  newItem.Content = child.FName;
                  children_combo_box.Items.Add(newItem);
              }
          }
          */



        private void Save_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {

                
                // If the user sure that he wants so save ...
                if (CC.WindowSaving("save") == MessageBoxResult.Yes)
                {
                 /*   Mother mom = new Mother(this.DataContext as Mother);
                    foreach (item in daysSliders.)

                    var hoursVal = from item in daysSliders where (item is Slider)
                    mom.DThoursTable = 
                    

                    if (update)
                        CC.bl.Update(this.DataContext as Mother);
                    else // need only to add
                        CC.bl.Add(this.DataContext as Mother);
                    (sender as SUMother_page).refreshList();
                    Close();*/
                }



                //  course.CourseId = int.Parse(this.idTextBox.Text);
                //  course.CourseName = this.nameTextBox.Text;

                //TODO:  bl.AddStudent(student); + update the window list
                //  mom = new BE.Mother();
                //  this.DataContext = mom;
                

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
            //TODO: insert to thread
           
            if (!update && CC.bl.Exists(this.DataContext as Mother)) // if its new mom and she ready exist in DS so change to update mode
            {
                update = true;
                idTextBox.IsEnabled = false;
                this.DataContext = CC.bl.FindMother(x=> x.Id == int.Parse(idTextBox.Text));
                refreshBrotherList();
            }
        }



        private void AddChild_Click(object sender, RoutedEventArgs e)
        {

            ChildWindow childwin = new ChildWindow();
            childwin.Show(); // if there will be change, so Brother will be refreshing.
        }

        private void UpdateChild_Click(object sender, RoutedEventArgs e)
        {
            ChildWindow childwin = new ChildWindow(children_combo_box.SelectedValue as BE.Child);
            childwin.Show(); childwin.Show(); // if there will be change, so Brother will be refreshing.
        }

        private void DeleteChild_Click(object sender, RoutedEventArgs e)
        { // TODO: update the contract , send a masseage if there is a contract with that child
            CC.bl.Remove(children_combo_box.SelectedValue as Child);
            refreshBrotherList();
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            if (CC.WindowSaving("clear") == MessageBoxResult.Yes)
            {
                this.DataContext = new Mother();
                Brothers.Clear();
                update = false;
                idTextBox.IsEnabled = false;
            }
        }

        private void Slider_ValueChanged_start(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if ((sender as Slider).Value > sunday_end_slider.Value)
                (sender as Slider).Value = sunday_end_slider.Value;
            (sender as Slider).ToolTip = CC.DoubleToDateTime(e.NewValue).ToString("from HH:mm");
        }
        private void Slider_ValueChanged_end(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if ((sender as Slider).Value < sunday_start_slider.Value)
                (sender as Slider).Value = sunday_start_slider.Value;
            (sender as Slider).ToolTip = CC.DoubleToDateTime(e.NewValue).ToString("to HH:mm");
        }

        private void start_slider_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            (sender as Slider).ToolTip = CC.DoubleToDateTime((sender as Slider).Value).ToString("from HH:mm");
        }
        private void end_slider_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            (sender as Slider).ToolTip = CC.DoubleToDateTime((sender as Slider).Value).ToString("to HH:mm");
        }

        



        // TODO: EXeptions handler include BInDING Errors
        // TODO: threads!
    }
}
