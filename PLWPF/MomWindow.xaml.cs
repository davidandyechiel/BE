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
using System.Collections.ObjectModel;
using BE;

namespace PLWPF
{
    //TODO: set datacontext and!!! the open child window
    /// <summary>
    /// Interaction logic for MomWindow.xaml
    /// </summary>
    public partial class MomWindow : Window
    {
        bool update;
        private BE.Mother mom;
        private SUMother_page SUmom;
        private ObservableCollection<BE.Child> brothers = new ObservableCollection<Child>();

        public ObservableCollection<Child> Brothers
        {
            get
            {
                return brothers;
            }

            set
            {
                brothers = value;
            }
        }

        // TODO: 


        /// <summary>
        /// Add new mom mode
        /// </summary>
        public MomWindow(SUMother_page fromSUmom) // add new mom
        {
            InitializeComponent();
            mom = new BE.Mother();
            grid1.DataContext = mom;
            update = false; // new mom
            foreach (BE.Child child in CC.bl.collectBrothers(mom.Id))
                Brothers.Add(child);
            SUmom = fromSUmom;
            children_combo_box.DataContext = Brothers;
        }

        /// <summary>
        /// Mom update mode
        /// </summary>
        /// <param name="_mom"> existing mom </param>
        public MomWindow(SUMother_page fromSUmom, Mother _mom)  
        {
            InitializeComponent();
            mom = new BE.Mother(_mom);
            grid1.DataContext = mom;
            idTextBox.IsEnabled = false; // lock the id, id is inchangeable
            update = true;
            SUmom = fromSUmom;
            foreach (BE.Child brother in CC.bl.collectBrothers(mom.Id))
                Brothers.Add(brother);
            children_combo_box.DataContext = Brothers;
            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                // If the user sure that he wants so save ...
                if (CC.YES_NO_Window("save"))
                {
                    //set new mother
        //            mom = new Mother(mom);
                    //set houtsTable
                    List<double> hoursList = new List<double>();
                    foreach (MahApps.Metro.Controls.RangeSlider item in daysSliders.Children)
                    {
                        hoursList.Add(item.LowerValue);
                        hoursList.Add(item.UpperValue);
                    }
                    mom.DThoursTable = CC.setHoursDT(hoursList.ToArray());
                    //update the the mother id of the children before delete

                    foreach (Child child in children_combo_box.Items)
                        if (!CC.bl.Exists(child))
                        {
                            child.MothersId = int.Parse(idTextBox.Text);
                            CC.bl.Add(child);
                        }
                    // add new brothers to DS

                    if (update)
                        CC.bl.Update(mom);
                    else // need only to add
                        CC.bl.Add(mom);
                    SUmom.hadChange(mom, update);
                    Close();
                }

                             
                
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

        internal void hadChange(Child child, bool needUpdate)
        {
            if (needUpdate)
            {
                brothers.Remove(child);
                CC.bl.Update(child);
            }
            brothers.Add(child);
        }






        private void AddChild_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var s = children_combo_box.Items;
                ChildWindow childwin = new ChildWindow(this);
                childwin.Show();

            } // if there will be change, so Brother will be refreshing.
            catch (Exception exp)
            {
                CC.WindowError(exp.Message);
            }
        }

        private void UpdateChild_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                ChildWindow childwin = new ChildWindow(this, children_combo_box.SelectedValue as BE.Child);
                childwin.Show(); // if there will be change, so Brother will be refreshing.
            }

            catch (Exception exp)
            {
                CC.WindowError(exp.Message);
            }


        }

        private void DeleteChild_Click(object sender, RoutedEventArgs e)
        { // TODO: update the contract , send a masseage if there is a contract with that child

            try
            {
                //if there is a contract whith that chils so ask the user if he realy want to delete the child
                if (CC.bl.FindContract(x => x.ChildID == (children_combo_box.SelectedValue as Child).Id) != null)
                    //if yes, do delete the contract too.
                    if (CC.YES_NO_Window("Delete this child?\n this child is aready in contract,\n deleting this child will lead to delete the contract"))
                    {
                        CC.bl.Remove(CC.bl.FindContract(x => x.ChildID == (children_combo_box.SelectedValue as Child).Id));
                        CC.bl.Remove(children_combo_box.SelectedValue as Child);
                        brothers.Remove(children_combo_box.SelectedValue as Child);
                    }
                    //if no, return.
                    else return;
                else if (CC.YES_NO_Window("Delete" + (children_combo_box.SelectedValue as Child).ToString()))
                {
                    if (update)
                        CC.bl.Remove(children_combo_box.SelectedValue as Child);
                    brothers.Remove(children_combo_box.SelectedValue as Child);
                }
            }
            catch (Exception exp)
            {
                CC.WindowError(exp.Message);
            }

        }


        private void start_slider_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            (sender as Slider).ToolTip = CC.DoubleToDateTime((sender as Slider).Value).ToString("from HH:mm");
        }
        private void end_slider_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            (sender as Slider).ToolTip = CC.DoubleToDateTime((sender as Slider).Value).ToString("to HH:mm");
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CC.YES_NO_Window("Clear"))
                {
                    mom = new Mother();
                    grid1.DataContext = mom;
                    update = false;
                    idTextBox.IsEnabled = true;

                }

            }
            catch (Exception exp)
            {
                CC.WindowError(exp.Message);
            }



        }


        /*    private void Clear_Click(object sender, RoutedEventArgs e)
             {
                 if (CC.YES_NO_Window("clear"))
                 {
                 mom = new Mother();
                 grid1.DataContext = mom;

                     update = false;
                     idTextBox.IsEnabled = true;
                 }
             }*/

        private void Slider_ValueChanged_start(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            /*  if (sunday_end_slider == null)
              {
                  sunday_end_slider = new Slider();
                  sunday_end_slider = new Slider();
              }
         //     if (sunday_start_slider.Value > sunday_end_slider.Value)
         //         sunday_start_slider.Value = sunday_end_slider.Value;
              (sender as Slider).ToolTip = CC.DoubleToDateTime(e.NewValue).ToString("from HH:mm");
              */
        }
        private void Slider_ValueChanged_end(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            /*  if (sender is Slider)
              {
        //          if ((sender as Slider).Value < sunday_start_slider.Value)
         //             (sender as Slider).Value = sunday_start_slider.Value;
                  (sender as Slider).ToolTip = CC.DoubleToDateTime(e.NewValue).ToString("to HH:mm");
              }*/
        }







        // TODO: EXeptions handler include BInDING Errors
        // TODO: threads!
    }
}// PLWPL
