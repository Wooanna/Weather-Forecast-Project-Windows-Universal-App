using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace WeatherForecast.ValueConverter
{
    public class WithDegreeSignValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string degree = value.ToString();
             string s = string.Empty;
            if (degree.Length >= 3)
            {
               s = degree.Substring(0, 2).Replace(".", "");
            }
            else {
                s = degree;
            }
           return String.Format("{0}{1}", s, "°");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
