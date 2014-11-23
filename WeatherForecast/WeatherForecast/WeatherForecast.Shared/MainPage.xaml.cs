using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Geolocation;

using WeatherForecast.ViewModel;
using System.Threading.Tasks;
using System.Net.Http;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.Streams;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WeatherForecast
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }


        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            CheckConnectionViewModel checker = new CheckConnectionViewModel();

            checker.CheckNetworkConnection();


            ShowLoadingAnimation();
#if WINDOWS_APP
            this.MainGrid.Width = 480;
            this.ClockEllipse.Width = 250;
            this.ClockEllipse.Height = 250;
            Canvas.SetLeft(ClockEllipse, 110);
            Canvas.SetTop(ClockEllipse, 60);
#endif


        }

        private void FadeInEffectAnimation(DependencyObject obj)
        {

            DoubleAnimation fadeOut = new DoubleAnimation();

            Storyboard.SetTarget(fadeOut, obj);
            Storyboard.SetTargetProperty(fadeOut, "Opacity");
            fadeOut.From = 0;
            fadeOut.To = 1;
            fadeOut.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 6000));

            Storyboard stb = new Storyboard();
            stb.Children.Add(fadeOut);
            stb.Begin();
        }


        private void ShowLoadingAnimation()
        {
            //      this.Drop.Visibility = Visibility;
            //      DoubleAnimation fadeOut = new DoubleAnimation();


            //  Storyboard.SetTarget(fadeOut, Drop);
            //  Storyboard.SetTargetProperty(fadeOut, "Opacity");


            //  fadeOut.From = 1;
            //  fadeOut.To = 0;
            //  fadeOut.Duration = new TimeSpan(0, 0, 2);

            //  Storyboard stb = new Storyboard();
            //  stb.Children.Add(fadeOut);

            // // stb.RepeatBehavior = new RepeatBehavior(5);
            //  stb.Begin();

        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {

            DoubleAnimation anim = new DoubleAnimation();
            this.Temperature.FontSize = 130;
            Storyboard.SetTarget(anim, Temperature);
            Storyboard.SetTargetProperty(anim, "FontSize");
            anim.From = 130;
            anim.To = 180;
            anim.Duration = new TimeSpan(0, 0, 6);
            anim.RepeatBehavior = new RepeatBehavior(5);
            anim.EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut };
            Storyboard stb = new Storyboard();
            stb.Children.Add(anim);
            stb.Begin();

        }

        private void Temp_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            TextBlock t = sender as TextBlock;
            Storyboard stb = new Storyboard();
            DoubleAnimationUsingKeyFrames shake = new DoubleAnimationUsingKeyFrames();
            shake.BeginTime = new TimeSpan(0, 0, 0);
            stb.RepeatBehavior = new RepeatBehavior(5.0);
            stb.AutoReverse = false;
            stb.SpeedRatio = 5;
            shake.Duration = new Duration(new TimeSpan(0, 0, 6));
            EasingDoubleKeyFrame one = new EasingDoubleKeyFrame();

            one.KeyTime = new TimeSpan(0, 0, 0, 0);
            one.Value = 80;
            EasingDoubleKeyFrame two = new EasingDoubleKeyFrame();
            two.KeyTime = new TimeSpan(0, 0, 0, 3);
            two.Value = 100;
            EasingDoubleKeyFrame tree = new EasingDoubleKeyFrame();
            tree.KeyTime = new TimeSpan(0, 0, 0, 4);
            tree.Value = 80;
            EasingDoubleKeyFrame four = new EasingDoubleKeyFrame();
            four.KeyTime = new TimeSpan(0, 0, 0, 5);
            four.Value = 100;
            shake.KeyFrames.Add(one);
            shake.KeyFrames.Add(two);
            shake.KeyFrames.Add(tree);
            shake.KeyFrames.Add(four);

            Storyboard.SetTargetName(shake, "Temperature");
            Storyboard.SetTargetProperty(shake, "FontSize");
            stb.Children.Add(shake);
            // stb.Begin();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox b = sender as ListBox;
            if (b == null)
            {
                return;
            }
            string weather = WeatherMain.Text;
            string src = "ms-appx:///Assets/clouds.jpg";

            switch (weather)
            {
                case "Rain": src = "ms-appx:///Assets/phone-480-586.png"; break;
                case "Clear": src = "ms-appx:///Assets/sunny2.jpg"; break;
                case "Snow": src = "ms-appx:///Assets/snow.jpg"; break;
                case "Cloudy": src = "ms-appx:///Assets/clouds.jpg"; break;
            }

            RunChangingImageAnimation(src);
            soundPlayer.Play();
        }

        private void RunChangingImageAnimation(string src)
        {

            DoubleAnimation fadeOut = new DoubleAnimation();
            DoubleAnimation fadeIn = new DoubleAnimation();

            Storyboard fadeOutStb = new Storyboard();
            Storyboard fadeInStb = new Storyboard();

            fadeOut.From = 1;
            fadeOut.To = 0;
            fadeOut.Duration = new TimeSpan(0, 0, 0, 0, 500);
            fadeIn.From = 0;
            fadeIn.To = 1;
            fadeIn.Duration = new TimeSpan(0, 0, 0, 0, 500);

            fadeOutStb.Children.Add(fadeOut);
            fadeInStb.Children.Add(fadeIn);

            if (this.UpImage.Opacity == 1)
            {
                this.DownImage.Source = new BitmapImage(new Uri(src));
                Storyboard.SetTarget(fadeOut, this.UpImage);
                Storyboard.SetTargetProperty(fadeOut, "Opacity");
                Storyboard.SetTarget(fadeIn, this.DownImage);
                Storyboard.SetTargetProperty(fadeIn, "Opacity");
                fadeOutStb.Begin();
                fadeInStb.Begin();

            }
            if (this.DownImage.Opacity == 1)
            {

                this.UpImage.Source = new BitmapImage(new Uri(src));
                Storyboard.SetTarget(fadeIn, this.UpImage);
                Storyboard.SetTargetProperty(fadeIn, "Opacity");
                Storyboard.SetTarget(fadeOut, this.DownImage);
                Storyboard.SetTargetProperty(fadeOut, "Opacity");
                fadeOutStb.Begin();
                fadeInStb.Begin();
            }
        }

        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void progressIndicator_Unloaded(object sender, RoutedEventArgs e)
        {

            // FadeInEffectAnimation(LocationTextBlock);
        }

        private void LocationTextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            DependencyObject obj = sender as DependencyObject;
            FadeInEffectAnimation(obj);
            FadeInEffectAnimation(WeatherMain);
            FadeInEffectAnimation(WeatherSub);
            FadeInEffectAnimation(Temperature);
        }


    }
}
