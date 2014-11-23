using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;
using Windows.UI.Popups;

namespace WeatherForecast.ViewModel
{
    public class CheckConnectionViewModel : ViewModelBase
    {
        private bool isConnected;
        public CheckConnectionViewModel()
        {
            this.isConnected = true;
        }


       
        private static string isConnectedName = "isConnected";

        public bool IsConnected
        {
            get 
            {
                return isConnected;
            }
            set
            { 
                isConnected = value;
                RaisePropertyChanged(isConnectedName);
            }
        }

         public void CheckNetworkConnection()
        {
            IsConnected = NetworkInterface.GetIsNetworkAvailable();

            ConnectionProfile InternetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();
            NetworkConnectivityLevel connection = InternetConnectionProfile.GetNetworkConnectivityLevel();
            if (connection == NetworkConnectivityLevel.None || connection == NetworkConnectivityLevel.LocalAccess)
            {
                IsConnected = false;
            }
         
        }

        

    }
}
