using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BRA_apk.Resources;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Media;
using Windows.Storage;
using Microsoft.Phone.Maps.Services;
using System.Device.Location;
using System.Xml.Linq;
using Windows.Devices.Geolocation;

namespace BRA_apk
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        

        public MainPage()
        {
            InitializeComponent();
            GdzieJa();
            var obj = App.Current as App;
            obj.czySzukacPkt = false;
            obj.czySzukacTrase = false;
            LayoutRoot.Background = kolorMenu((string)globalneUstawienia.Values["kolor"]);
        }
        private async void GdzieJa()
        {
            //ustala położenie z GPS; pokazuje w GPS

            Geolocator mojGPS = new Geolocator();
            Geoposition daneGPS = await mojGPS.GetGeopositionAsync();
            double dlg = daneGPS.Coordinate.Longitude;
            double szer = daneGPS.Coordinate.Latitude;
            App.ToJa = new System.Device.Location.GeoCoordinate(szer, dlg);


        }
        private void Mapa_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Mapa.xaml", UriKind.Relative));
        }

        private void Stacje_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Stacje.xaml", UriKind.Relative));
        }

        private void wPobliżu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/wPobliżu.xaml", UriKind.Relative));
        }

        private void Opcje_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/zmieńKolor.xaml", UriKind.Relative));
        }

        private void oProgramie_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/oProgramie.xaml", UriKind.Relative));
        }
        private void Koniec_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Terminate();
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
        public static ApplicationDataContainer globalneUstawienia = ApplicationData.Current.RoamingSettings;
        public static SolidColorBrush kolorMenu(string kolor)
        {
            if (kolor == "fioletowy")
                return new SolidColorBrush(Colors.Purple);
            if (kolor == "szary")
                return new SolidColorBrush(Colors.Gray); 
            if (kolor == "czerwony")
                return new SolidColorBrush(Colors.Red); 
            if (kolor == "niebieski")
                return new SolidColorBrush(Colors.Blue); 
            if (kolor == "zielony")
                return new SolidColorBrush(Colors.Green);
            
            else return new SolidColorBrush(Colors.Green);

        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            LayoutRoot.Background = kolorMenu((string)globalneUstawienia.Values["kolor"]);
        }
    }

}