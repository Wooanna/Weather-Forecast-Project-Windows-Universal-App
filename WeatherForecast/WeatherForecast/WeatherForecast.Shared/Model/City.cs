﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Model
{
    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
        public int population { get; set; }
    }
}
