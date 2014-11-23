using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Model
{
    public class RootObject
    {
        public string message { get; set; }
        public string cod { get; set; }

        public City city { get; set; }
        public int count { get; set; }
        public List<Day> list { get; set; }
    }
}
