using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using Windows.Devices.Geolocation;
using System.Xml.Linq;

namespace BRA_apk
{
    public partial class Stacje : PhoneApplicationPage
    {
        //public List<DaneStacji> tempList { get; set; }
        public Stacje()
        {
            InitializeComponent();
            LayoutRoot.Background = MainPage.kolorMenu((string)MainPage.globalneUstawienia.Values["kolor"]);
         
            sort();
            
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Ulubione.xaml", UriKind.Relative));
        }

        private void DoMapy_Click(object sender, RoutedEventArgs e)
        {
            var send = sender as Button;
            var obj = App.Current as App;
            foreach (var item in DaneStacji.ListaXML())
            {
                if (item.nazwaStacji == send.Tag.ToString())
                {
                    obj.xszuka =item.x;
                    obj.yszuka = item.y;
                }
            }
            obj.czySzukacPkt = true;
            NavigationService.Navigate(new Uri("/Mapa.xaml", UriKind.Relative));           
        }

        private void DoTrasy_Click(object sender, RoutedEventArgs e)
        {
            var send = sender as Button;
            var obj = App.Current as App;
            foreach (var item in DaneStacji.ListaXML())
            {
                if (item.nazwaStacji == send.Tag.ToString())
                {
                    obj.xszuka = item.x;
                    obj.yszuka = item.y;
                }
            }
            obj.czySzukacTrase = true;
            NavigationService.Navigate(new Uri("/Mapa.xaml", UriKind.Relative));
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            App.sortKM = true;
            sort();
        }
        private void sort()
        {
            List<DaneStacji> tempList;
            tempList = new List<DaneStacji>();
            tempList = DaneStacji.ListaXML();
            var obj = App.Current as App;
            foreach (var item in tempList)
            {

                obj.xszuka = item.x;
                obj.yszuka = item.y;
                App.ToPkt = new System.Device.Location.GeoCoordinate(Convert.ToDouble(obj.xszuka), Convert.ToDouble(obj.yszuka));
                item.kilometry = Math.Round((App.ToJa.GetDistanceTo(App.ToPkt)) / 1000, 2);
            }
            if (App.sortKM)
                tempList = tempList.OrderBy(i => i.kilometry).ToList();
            else
                tempList = tempList.OrderBy(i => i.nazwaStacji).ToList();
            formatki.ItemsSource = tempList;
        }
        //private void LayoutRoot_Loaded_1(object sender, RoutedEventArgs e)
        //{
        //   // App.sortKM = true;
        //    List<DaneStacji> tempList;
        //    tempList = new List<DaneStacji>();
        //    tempList = DaneStacji.ListaXML();
        //    var obj = App.Current as App;
        //    foreach (var item in tempList)
        //    {

        //        obj.xszuka = item.x;
        //        obj.yszuka = item.y;
        //        App.ToPkt = new System.Device.Location.GeoCoordinate(Convert.ToDouble(obj.xszuka), Convert.ToDouble(obj.yszuka));
        //        item.kilometry = Math.Round((App.ToJa.GetDistanceTo(App.ToPkt)) / 1000, 2);
        //    }
        //    if (App.sortKM)
        //        tempList = tempList.OrderBy(i => i.kilometry).ToList();
        //    else
        //    tempList = tempList.OrderBy(i => i.nazwaStacji).ToList();
        //    formatki.ItemsSource = tempList;

        //}

        private void ApplicationBarIconButton_Click_2(object sender, EventArgs e)
        {
            App.sortKM = false;
            sort();
        }
    }
}