using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Phone.Maps.Services;
using System.Device.Location;
using System.Xml.Linq;
using Windows.Devices.Geolocation;
using System.Windows.Media;


namespace BRA_apk
{
    public partial class Mapa : PhoneApplicationPage
    {
        //public GeoCoordinate ToPkt = null;

        public Mapa()
        {
            InitializeComponent();
            var obj = App.Current as App;
            DaneStacji.ZaznaczNaMapie(Convert.ToString(App.ToJa.Latitude), Convert.ToString(App.ToJa.Longitude), NaszaMapa, new SolidColorBrush(Colors.Red));            
            if (!obj.czySzukacPkt && !obj.czySzukacTrase)
                NaszaMapa.SetView(App.ToJa, 13);
            if (obj.czySzukacPkt)
                GdziPkt();
            if (obj.czySzukacTrase)
                WyznaczTrase();
            LayoutRoot.Background = MainPage.kolorMenu((string)MainPage.globalneUstawienia.Values["kolor"]);
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            NaszaMapa.ZoomLevel++;
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            NaszaMapa.ZoomLevel--;
        }

        private void ApplicationBarIconButton_Click_2(object sender, EventArgs e)
        {
            var ab = sender as ApplicationBarIconButton;
            if (NaszaMapa.CartographicMode == MapCartographicMode.Road)
            {
                NaszaMapa.CartographicMode = MapCartographicMode.Hybrid;
                ab.IconUri = new Uri("/Assets/Icons/R.png", UriKind.Relative);
            }
            else
            {

                NaszaMapa.CartographicMode = MapCartographicMode.Road;
                ab.IconUri = new Uri("/Assets/Icons/A.png", UriKind.Relative);
            }

        }


        private void WyznaczTrase()
        {
            GeoCoordinate srodek = new GeoCoordinate((App.ToJa.Latitude + App.ToPkt.Latitude) / 2, (App.ToPkt.Longitude + App.ToJa.Longitude) / 2);
            NaszaMapa.SetView(App.ToJa, 15);
            RouteQuery zapytanieTrasy = new RouteQuery()
            {
                RouteOptimization = RouteOptimization.MinimizeDistance,
                TravelMode = TravelMode.Driving,
                Waypoints = new GeoCoordinateCollection()
                {
                    App.ToJa, App.ToPkt
                }
            };
            zapytanieTrasy.QueryAsync();
            zapytanieTrasy.QueryCompleted += ZapytanieTrasy_QueryCompleted;
        }
        private void GdziPkt()
        {
            var obj = App.Current as App;
            App.ToPkt = new System.Device.Location.GeoCoordinate(Convert.ToDouble(obj.xszuka), Convert.ToDouble(obj.yszuka));
            NaszaMapa.SetView(App.ToPkt, 15);
        }
        private void ZapytanieTrasy_QueryCompleted(object sender, QueryCompletedEventArgs<Route> e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message, "wyznaczanie trasy", MessageBoxButton.OK);
                return;
            }
            NaszaMapa.AddRoute(new MapRoute(e.Result));
        }
        private void NaszaMapa_Loaded(object sender, RoutedEventArgs e)
        {
            Microsoft.Phone.Maps.MapsSettings.ApplicationContext.ApplicationId = "fb3b0649-7d61-4d6c-9c7c-ccb9325a9164";
            Microsoft.Phone.Maps.MapsSettings.ApplicationContext.AuthenticationToken = "aLs8SK5uvB6eyY6vUaKRxg";
        }

        private void ContentPanel_Loaded(object sender, RoutedEventArgs e)
        {

            foreach (var item in DaneStacji.ListaXML())
            {
                DaneStacji.ZaznaczNaMapie(item.x, item.y, NaszaMapa, new SolidColorBrush(Colors.Blue));
            }

            var obj = App.Current as App;
            if (obj.czySzukacPkt || obj.czySzukacTrase)
            {
                DaneStacji.ZaznaczNaMapie(obj.xszuka, obj.yszuka, NaszaMapa, new SolidColorBrush(Colors.Green));
                obj.czySzukacPkt = false;
                obj.czySzukacTrase = false;
            }
        }
    }
}
