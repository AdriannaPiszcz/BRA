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
using System.Xml.Linq;

namespace BRA_apk
{
    public partial class wPobliżu : PhoneApplicationPage
    {
       
        public wPobliżu()
        {
            InitializeComponent();
            LayoutRoot.Background = MainPage.kolorMenu((string)MainPage.globalneUstawienia.Values["kolor"]);
            
        }
      

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            blisko.ItemsSource = DaneStacji.ListaXML();
        }
    }
}