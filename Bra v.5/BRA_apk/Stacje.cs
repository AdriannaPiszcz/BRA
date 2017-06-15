using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Phone.Maps.Services;
using System.Xml.Linq;
using System.Device.Location;
using Windows.Devices.Geolocation;
using System.Windows.Media;

namespace BRA_apk
{
    class DaneWPobliżu
    {
        public string nazwa { get; set; }
        public string x { get; set; }
        public string y { get; set; }
    }
    class DaneStacji
    {
        public string nazwaStacji { get; set; }
        public string x { get; set; }
        public string y { get; set; }
        public double kilometry { get; set; }
        public List<DaneWPobliżu> listaWPobliżu { get; set; }
        

        public static List<DaneStacji> ListaXML ()
        {
            List<DaneStacji> listaStacji = new List<DaneStacji>();
            var obj = App.Current as App;
            XDocument stacjeXML = XDocument.Load("./StacjeXML.xml");
            listaStacji = stacjeXML.Descendants("stacja").Select(item => new DaneStacji()
            {
                nazwaStacji = item.Element("nazwaStacji").Value,
                x = item.Element("x").Value,
                y = item.Element("y").Value,
                kilometry = 0,
                
                listaWPobliżu = item.Descendants("obiekt").Select(stac => new DaneWPobliżu()
                {
                    nazwa = stac.Element("nazwa").Value,
                    x = stac.Element("x").Value,
                    y = stac.Element("y").Value
                }).ToList()
            }).ToList();
            return listaStacji;
        }
        public static void ZaznaczNaMapie(string stacjaX, string stacjaY, Map mapa, SolidColorBrush kolor)
        {
            MapOverlay punkt = new MapOverlay()
            {
                GeoCoordinate = new GeoCoordinate(Convert.ToDouble(stacjaX), Convert.ToDouble(stacjaY)),
                Content = new System.Windows.Shapes.Ellipse()
                {
                    Height = 20,
                    Width = 20,
                    Fill = kolor
                },
                PositionOrigin = new System.Windows.Point(0.75, 0.75)

            };
            MapLayer warstwaMapy = new MapLayer();
            warstwaMapy.Add(punkt);
            mapa.Layers.Add(warstwaMapy);
        }

    }
}
