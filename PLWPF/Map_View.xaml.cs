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
using Microsoft.Maps.MapControl.WPF;
using Microsoft.Maps.MapControl.WPF.Design;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Map_View.xaml
    /// </summary>
    public partial class Map_View : Page
    {
        public Map_View(MainWindow main)
        {
            InitializeComponent();
            Pushpin a = new Pushpin();

            //Create REST Services geocode request using Locations API
            string geocodeRequest = "http://dev.virtualearth.net/REST/v1/Locations/" + main.SettingPage.TextAddress.Text + "?o=xml&key=" + "AouY1xKoo46TxxSZLwxk7P8gUnD9NEHWW20LPEJ8FhOyBKogqLdZbOOquA - qddoq";
         //   XmlDocument geocodeResponse = GetXmlResponse(geocodeRequest);

            main.SettingPage.TextAddressToLocation.Text = geocodeRequest;


            //   string address = main.GeocodeAddress(main.SettingPage.TextAddress.Text);
        }
    }
}
