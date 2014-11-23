using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Model
{
    public class Main
    {
        public double temp { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double pressure { get; set; }
        public double sea_level { get; set; }
        public double grnd_level { get; set; }
        public int humidity { get; set; }
        public int temp_kf { get; set; }
    }
}
