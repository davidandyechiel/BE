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
    /* public class AddChildCommand : ICommand
     {
         public event EventHandler CanExecuteChanged;

         public BE.Child ChildProperty { get; set; }

         //public AddCourseCommand(ref BE.Course c)
         //{

         //}

         public bool CanExecute(object parameter)
         {
             if (ChildProperty != null)
             {
                 if (ChildProperty.Id != 0 && ChildProperty.FName != "")
                     return true;
             }
             return false;
         }

         public void Execute(object parameter)
         {
             CC.bl.Add(ChildProperty); 
         }
     }*/









    /// <summary>
    /// Interaction logic for ChildWindow.xaml
    /// </summary>
    public partial class ChildWindow : Window
    {
        //TODO: change size event
        //TODO: Inotipfy for child
        bool update; // need an update or just add
        BE.Child child;
        MomWindow mom;
       

        public ChildWindow(MomWindow _mom)
        {
            InitializeComponent();
            mom = _mom;
            child = new BE.Child();
            grid1.DataContext = child;
            update = false;
            genderComboBox.ItemsSource = Enum.GetValues(typeof(BE.EnumClasses.E_gender)).Cast<BE.EnumClasses.E_gender>();
        }

        public ChildWindow(MomWindow _mom, BE.Child _child)
        {
            InitializeComponent();
            child = new BE.Child(_child);
            grid1.DataContext = child;
            update = true;
            idTextBox.IsEnabled = false;
            mom = _mom;
            genderComboBox.ItemsSource = Enum.GetValues(typeof(BE.EnumClasses.E_gender)).Cast<BE.EnumClasses.E_gender>();
        }



        private void save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (update)
                    CC.bl.Update(child);
                mom.hadChange(child, update);
                Close();
            }
            catch (Exception exp)
            {
                CC.WindowError(exp.Message);
            }

        }


    }
}