namespace WeatherForecast.ViewModel
{
    using GalaSoft.MvvmLight;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using WeatherForecast.Model;
    using System.Net;
    using System.Net.Http;
    using Newtonsoft.Json;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using Windows.Devices.Geolocation;
    using Windows.ApplicationModel.Core;
    using Windows.UI.Core;
    using System.Windows.Input;
    using Windows.UI;
    using Windows.UI.Popups;

    public class MainViewModel : ViewModelBase
    {

        private const string GetInDegrees = "&units=metric";

        public const string DaysCollectionName = "TestString";

        public const string IsSuccessfullyLoadedDataName = "LoadedData";

        public const string CurrentDayName = "CurrentDay";

        private const string locationName = "";

        private string location = string.Empty;

        private string city = string.Empty;

        private Day currentDay;

        private ObservableCollection<Day> days = null;

        private Geolocator geo = null;

        public Geolocation loc = new Geolocation();

        private bool isSuccessfullyLoadedData = false;

        public bool IsSuccessfullyLoadedData
        {
            get
            {
                return isSuccessfullyLoadedData;
            }

            set
            {
                isSuccessfullyLoadedData = value;
                RaisePropertyChanged(IsSuccessfullyLoadedDataName);
            }
        }

        public ICommand commandRun { get; set; }

        public ICommand Run
        {
            get
            {
                if (this.commandRun == null)
                {
                    this.commandRun = new RelayCommandWithParameteres(this.PerformRun);
                }
                return this.commandRun;
            }
            set
            {
            }
        }

        public ICommand commandGetForecast { get; set; }

        public ICommand GetForecast
        {
            get
            {
                if (this.commandGetForecast == null)
                {
                    this.commandGetForecast = new CommandWithParameters(this.PerformGetForecast);
                }
                return this.commandGetForecast;
            }
            set
            {
            }

        }

        private void PerformGetForecast(object obj)
        {
            city = obj as String;
            if (city != string.Empty)
            {

              ReadDataFromWeb(String.Format("http://api.openweathermap.org/data/2.5/forecast/daily?q=" + city + "&mode=json&units=metric&cnt=7"));
            }
            city = String.Empty;
        }


        private async Task GetCurrentLocation()
        {

            if (geo == null)
            {
                geo = new Geolocator();
            }

            Geoposition pos = await geo.GetGeopositionAsync();
            string lon = pos.Coordinate.Point.Position.Longitude.ToString("0.00");
            string lat = pos.Coordinate.Point.Position.Latitude.ToString("0.00");
            loc.Lat = double.Parse(lat);
            loc.Lon = double.Parse(lon);
        }


        public ObservableCollection<Day> Days
        {
            get
            {
                return days;
            }
            set
            {
                if (days == value)
                {
                    days = value;
                    RaisePropertyChanged(DaysCollectionName);
                }

                days = value;
                RaisePropertyChanged(DaysCollectionName);

            }
        }

        private static string tempColorName = "TempColor";
        private Color tempColor;
        public Color TempColor
        {

            get { return tempColor; }
            set
            {
                tempColor = value;
                RaisePropertyChanged(tempColorName);
            }
        }

        public Day CurrentDay
        {
            get { return currentDay; }
            set
            {
                if (currentDay == value)
                {
                    return;
                }

                currentDay = value;
                RaisePropertyChanged(CurrentDayName);
            }
        }


        public string Location
        {
            get { return location; }
            set
            {
                if (location == value)
                {
                    return;
                }

                location = value;
                RaisePropertyChanged(locationName);
            }
        }

        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                this.GetCurrentLocation().ContinueWith(Task =>
                {

                    ReadDataFromWeb(String.Format("http://api.openweathermap.org/data/2.5/forecast/daily?lat=" + loc.Lat + "&lon=" + loc.Lon + "&cnt=10&mode=json" + "{0}", GetInDegrees));
                });

                //ReadDataFromWeb(String.Format("http://api.openweathermap.org/data/2.5/find?lat=" + "{0}" + "&lon=" + "{1}" + "{2}", lon, lat, GetInDegrees));
            }
            else
            {
                this.GetCurrentLocation().ContinueWith(Task =>
                {
                    CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                    () =>
                    {
                        ReadDataFromWeb(String.Format("http://api.openweathermap.org/data/2.5/forecast/daily?lat=" + loc.Lat + "&lon=" + loc.Lon + "&cnt=10&mode=json" + "{0}", GetInDegrees));
                    });

                });

                // ReadDataFromWeb(String.Format("http://api.openweathermap.org/data/2.5/find?lat=" + "{0}" + "&lon=" + "{1}" + "{2}", lon, lat, GetInDegrees));
            }

        }

        private void ReadDataFromWeb(string uri)
        {
            var client = new HttpClient();
            var response = client.GetStringAsync(new Uri(uri));
            string result = string.Empty;
            try
            {
                 result = response.Result;
            }
            catch (AggregateException e)
            {

            }
           

            if (response.IsCanceled || response.IsFaulted)
            {
                IsSuccessfullyLoadedData = false;
            }
            else
            {

                RootObject res = JsonConvert.DeserializeObject<RootObject>(result);
                if (res.list == null || res.city == null)
                {
                    IsSuccessfullyLoadedData = false;
                    CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => {
                                                                                                                  ShowMessageBox();
                                                                                                                 });
                }
                else
                {
                    IsSuccessfullyLoadedData = true;
                    Days = new ObservableCollection<Day>(res.list);
                    CurrentDay = Days[0];
                    Location = res.city.name;
                    if (CurrentDay != null)
                    {
                        TempColor = Color.FromArgb(255, (byte)(255 * (CurrentDay.temp.max / 25)), 255, (byte)(255 * (CurrentDay.temp.min / 25)));
                    }
                }

            }

        }

        async private Task ShowMessageBox()
        {
            MessageDialog msgBox = new MessageDialog("No such destination \"" + city + "\"found. Try again with another destination.");
            await msgBox.ShowAsync();
        }

        private void PerformRun()
        {
            GetCurrentLocation().ContinueWith(Task =>
                {
                    CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
    () =>
    {
        ReadDataFromWeb(String.Format("http://api.openweathermap.org/data/2.5/forecast/daily?lat=" + loc.Lat + "&lon=" + loc.Lon + "&cnt=10&mode=json" + "{0}", GetInDegrees));
    });

                });
        }

    }
}
