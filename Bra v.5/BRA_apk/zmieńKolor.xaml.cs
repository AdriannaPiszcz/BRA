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
using Windows.Storage;

namespace BRA_apk
{
    public partial class zmieńKolor : PhoneApplicationPage
    {
        string kolor;
        public zmieńKolor()
        {
            InitializeComponent();
            LayoutRoot.Background = MainPage.kolorMenu((string)MainPage.globalneUstawienia.Values["kolor"]);

        }

        //private void button_Click(object sender, RoutedEventArgs e)
        //{
        //     LayoutRoot.Background = new SolidColorBrush(Colors.Yellow);



        //PhoneApplicationFrame RootFrame = new PhoneApplicationFrame();
        //RootFrame.SetValue(new SolidColorBrush(Colors.Yellow));
   
        //    //RootFrame.Background = new SolidColorBrush(Colors.Yellow);

        //    //System.Windows.Style style = new System.Windows.Style(typeof(Grid));
        //    //style.Setters.Add(new Setter(Grid.BackgroundProperty, new SolidColorBrush(Colors.Green)));
        //    //Application.Current.Resources.Add("LayoutGridStyle", style);
        //    //(Application.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/MainMenu.xaml", UriKind.Relative));
        //}

        private void Fiolotowy_Click(object sender, RoutedEventArgs e)
        {
            LayoutRoot.Background = new SolidColorBrush(Colors.Purple);
            kolor = "fioletowy";
        }

        private void Niebieski_Click(object sender, RoutedEventArgs e)
        {
            LayoutRoot.Background = new SolidColorBrush(Colors.Blue);
            kolor = "niebieski";
        }

        private void Czerwony_Click(object sender, RoutedEventArgs e)
        {
            LayoutRoot.Background = new SolidColorBrush(Colors.Red);
            kolor = "czerwony";
        }

        private void Zielony_Click(object sender, RoutedEventArgs e)
        {
            LayoutRoot.Background = new SolidColorBrush(Colors.Green);
            kolor = "zielony";
        }

        private void Szary_Click(object sender, RoutedEventArgs e)
        {
            LayoutRoot.Background = new SolidColorBrush(Colors.Gray);
            kolor = "szary";
        }

        private void Zapisz_Click(object sender, RoutedEventArgs e)
        {
            MainPage.globalneUstawienia.Values["kolor"]= kolor;
        }

        //public ApplicationDataContainer roamingSettingsKolor = ApplicationData.Current.RoamingSettings;
    }
}