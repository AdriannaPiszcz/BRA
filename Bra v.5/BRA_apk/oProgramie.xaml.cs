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

namespace BRA_apk
{
    public partial class oProgramie : PhoneApplicationPage
    {
        public oProgramie()
        {
            InitializeComponent();
            LayoutRoot.Background = MainPage.kolorMenu((string)MainPage.globalneUstawienia.Values["kolor"]);
        }
    }
}