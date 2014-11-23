using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace WeatherForecast.ValueConverter
{
    public class WeatherToImageStringValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            String weather = value as string;
            String imageString = "";
            switch (weather) 
            {
                case "Rain": imageString = "Assets/drops.png"; break;
                case "Clouds": imageString = "Assets/clouds.png"; break;
                case "Clear": imageString = "Assets/sun.png"; break;
                case "Snow": imageString = "Assets/drops.png"; break;
                default: imageString = "Assets/drops.png"; break;
            }

            return imageString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
