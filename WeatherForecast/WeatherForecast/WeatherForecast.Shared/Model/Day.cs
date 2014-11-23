using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Model
{
    public class Day
    {
        private int dt;

        public int Dt
        {
            get
            {
                return dt;
            }
            set
            { 
                dt = value;
                var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                Time = epoch.AddSeconds(value);
            
            }
        }
        
        public Temp temp { get; set; }
        public double pressure { get; set; }
        public int humidity { get; set; }
        public List<Weather> weather { get; set; }
        public double speed { get; set; }
        public int deg { get; set; }
        public int clouds { get; set; }
        public double rain { get; set; }

        private DateTime time;

        public DateTime Time {
            get { return time; }
            set { time = value; }
        }
    }
}
