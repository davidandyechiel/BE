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
using PLWPF.GeocodeService;
using PLWPF.ImageryService;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Map_View mapView;
        private SUNanny_page sUNannyPage;
        private SUMother_page sUMotherPage;
        private FNanny_page fNannyPage;
        private SUContract_page contractPage;
        private Setting_page settingPage;
        #region PROPERTY
        public Map_View MapView
        {
            get
            {
                if (mapView == null)
                    mapView = new Map_View(this);
                return mapView;
            }

            set
            {
                mapView = value;
            }
        }

        public SUNanny_page SUNannyPage
        {
            get
            {
                if (sUNannyPage == null)
                    sUNannyPage = new SUNanny_page();
                return sUNannyPage;
            }

            set
            {
                sUNannyPage = value;
            }
        }

        public SUMother_page SUMotherPage
        {
            get
            {
                if (sUMotherPage == null)
                    sUMotherPage = new SUMother_page();
                return sUMotherPage;
            }

            set
            {
                sUMotherPage = value;
            }
        }

        public FNanny_page FNannyPage
        {
            get
            {
                if (fNannyPage == null)
                    fNannyPage = new FNanny_page();
                return fNannyPage;
            }

            set
            {
                fNannyPage = value;
            }
        }

        public SUContract_page ContractPage
        {
            get
            {
                if (contractPage == null)
                    contractPage = new SUContract_page();
                return contractPage;
            }

            set
            {
                contractPage = value;
            }
        }

        public Setting_page SettingPage
        {
            get
            {
                if (settingPage == null)
                    settingPage = new Setting_page();
                return settingPage;
            }

            set
            {
                settingPage = value;
            }
        }
        #endregion
        public MainWindow()
        {

            
            InitializeComponent();
            AddDefaultValues();
            curretPage.Content = MapView;
        }


        private static void AddDefaultValues()
        {
            BE.Mother mom1 = new BE.Mother(1, "Cohen", "Sarah", 026541526, 0527412564, "הועד הלאומי12, ירושלים", "הועד הלאומי12, ירושלים", " ", null, 2);
            BE.Child child11 = new BE.Child(123, 1, "Yossi", "Chohen", BE.EnumClasses.E_gender.BOY, false, "", new DateTime(2017, 1, 1));
            BE.Child child12 = new BE.Child(124, 1, "Moshe", "Chohen", BE.EnumClasses.E_gender.BOY, false, "", new DateTime(2015, 1, 1));

            BE.Mother mom2 = new BE.Mother(2, "Levi", "Ofra", 026584921, 0549853665, "הועד הלאומי13, ירושלים", "הועד הלאומי13, ירושלים", " ", null, 2);
            BE.Child child21 = new BE.Child(125, 2, "Avraham", "Levi", BE.EnumClasses.E_gender.BOY, false, "", new DateTime(2017, 5, 11));
            BE.Child child22 = new BE.Child(126, 2, "Issac", "Levi", BE.EnumClasses.E_gender.BOY, false, "", new DateTime(2015, 12, 23));

            BE.Nanny nan1 = new BE.Nanny(11, "Salem", "Esther", new DateTime(1998 / 1 / 25), 0585802606, true, "הוועד הלאומי 21", 3, 5, 20, 1, 3, true, 30, 500, "yes", true, null, null);
            BE.Nanny nan2 = new BE.Nanny(12, "Dusi", "Grace", new DateTime(1994 / 1 / 25), 0585802608, true, "הוועד הלאומי 21", 2, 5, 20, 1, 3, true, 30, 600, "no", true, null, null);



            BE.Contract con1 = new BE.Contract(11, 123);
            BE.Contract con2 = new BE.Contract(11, 124);
            BE.Contract con3 = new BE.Contract(12, 125);
            BE.Contract con4 = new BE.Contract(12, 126);
            con4.IsSigned = false;


            CC.bl.Add(mom1);
            CC.bl.Add(child11);
            CC.bl.Add(child12);
            CC.bl.Add(mom2);
            CC.bl.Add(child21);
            CC.bl.Add(child22);
            CC.bl.Add(nan1);
            CC.bl.Add(nan2);
            CC.bl.Add(con1);
            CC.bl.Add(con2);
            CC.bl.Add(con3);
            CC.bl.Add(con4);
            con4.IsSigned = true;



        }

        private void mainPage_Click(object sender, RoutedEventArgs e)
        {
            curretPage.Content = MapView;
        }

        private void signNanny_Click(object sender, RoutedEventArgs e)
        {
            curretPage.Content = SUNannyPage;
        }

        private void signMother_Click(object sender, RoutedEventArgs e)
        {
            
            curretPage.Content = SUMotherPage;

        }

        private void findNanny_Click(object sender, RoutedEventArgs e)
        {
            
            curretPage.Content = FNannyPage;

        }

        private void contract_Click(object sender, RoutedEventArgs e)
        {
            
            curretPage.Content = ContractPage;
        }




        private void setting_Click(object sender, RoutedEventArgs e)
        {
            
            curretPage.Content = SettingPage;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            updateNannyWindow nan = new updateNannyWindow();
            nan.Show();
        }

        //public String GeocodeAddress(string address)
        //{
        //    string results = "";
        //    string key = "AouY1xKoo46TxxSZLwxk7P8gUnD9NEHWW20LPEJ8FhOyBKogqLdZbOOquA-qddoq";
        //    GeocodeRequest geocodeRequest = new GeocodeRequest();

        //    // Set the credentials using a valid Bing Maps key
        //    geocodeRequest.Credentials = new GeocodeService.Credentials();
        //    geocodeRequest.Credentials.ApplicationId = key;

        //    // Set the full address query
        //    geocodeRequest.Query = address;

        //    // Set the options to only return high confidence results 
        //    ConfidenceFilter[] filters = new ConfidenceFilter[1];
        //    filters[0] = new ConfidenceFilter();
        //    filters[0].MinimumConfidence = GeocodeService.Confidence.High;

        //    // Add the filters to the options
        //    GeocodeOptions geocodeOptions = new GeocodeOptions();
        //    geocodeOptions.Filters = filters;
        //    geocodeRequest.Options = geocodeOptions;

        //    // Make the geocode request
        //    GeocodeServiceClient geocodeService = new GeocodeServiceClient();
        //    GeocodeResponse geocodeResponse = geocodeService.Geocode(geocodeRequest);

        //    if (geocodeResponse.Results.Length > 0)
        //        results = String.Format(" {0},{1}",
        //          geocodeResponse.Results[0].Locations[0].Latitude,
        //          geocodeResponse.Results[0].Locations[0].Longitude);
        //    else
        //        results = "No Results Found";

        //    return results;
        //}

        //private string GetImagery(string locationString)
        //{
        //    string key = "AouY1xKoo46TxxSZLwxk7P8gUnD9NEHWW20LPEJ8FhOyBKogqLdZbOOquA-qddoq";
        //    MapUriRequest mapUriRequest = new MapUriRequest();

        //    // Set credentials using a valid Bing Maps key
        //    mapUriRequest.Credentials = new ImageryService.Credentials();
        //    mapUriRequest.Credentials.ApplicationId = key;

        //    // Set the location of the requested image
        //    mapUriRequest.Center = new ImageryService.Location();
        //    string[] digits = locationString.Split(',');
        //    mapUriRequest.Center.Latitude = double.Parse(digits[0].Trim());
        //    mapUriRequest.Center.Longitude = double.Parse(digits[1].Trim());

        //    // Set the map style and zoom level
        //    MapUriOptions mapUriOptions = new MapUriOptions();
        //    mapUriOptions.Style = MapStyle.AerialWithLabels;
        //    mapUriOptions.ZoomLevel = 17;

        //    // Set the size of the requested image in pixels
        //    mapUriOptions.ImageSize = new ImageryService.SizeOfint();
        //    mapUriOptions.ImageSize.Height = 200;
        //    mapUriOptions.ImageSize.Width = 300;

        //    mapUriRequest.Options = mapUriOptions;

        //    //Make the request and return the URI
        //    ImageryServiceClient imageryService = new ImageryServiceClient();
        //    MapUriResponse mapUriResponse = imageryService.GetMapUri(mapUriRequest);
        //    return mapUriResponse.Uri;
        //}





    }
}
