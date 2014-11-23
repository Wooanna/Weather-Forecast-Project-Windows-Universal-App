using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Model
{
   public struct Geolocation
    {
        private double lon;

        public double Lon
        {
            get { return lon; }
            set { lon = value; }
        }
        private double lat;

        public double Lat
        {
            get { return lat; }
            set { lat = value; }
        }
    }
}
