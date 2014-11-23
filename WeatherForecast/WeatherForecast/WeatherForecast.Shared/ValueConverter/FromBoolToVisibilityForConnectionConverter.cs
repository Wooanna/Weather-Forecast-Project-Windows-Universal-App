using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace WeatherForecast.ValueConverter
{
   public class FromBoolToVisibilityForConnectionConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool isConnected = (bool)value;

            if (isConnected)
            {
                return "Collapsed";
            }
            else
            {
                return "Visible";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
