using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace WeatherForecast.ValueConverter
{
   public class DayOfWeekToTreeLettersStringConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string dayOfWeek = value.ToString();
            string result = "EMPTY";
            switch (dayOfWeek) {
                case "Monday": result = "MON"; break;

                case "Tuesday": result = "TUE"; break;

                case "Wednesday": result = "WED"; break;

                case "Thursday": result = "THU"; break;

                case "Friday": result = "FRI"; break;

                case "Saturday": result = "SAT"; break;

                case "Sunday": result = "SUN"; break;

                default: result = "MON"; break;

            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
