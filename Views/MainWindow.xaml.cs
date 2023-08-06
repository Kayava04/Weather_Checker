using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Weather_Checker.Data;

namespace Weather_Checker.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string CityName;
        private const string WIFI_ERROR = "Error connecting to the weather service!";
        private ErrorWindow errorWindow;
        private CancellationTokenSource clockCancellationTokenSource;

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Close_ButtonClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Minimize_ButtonClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void City_TextChanged(object sender, TextChangedEventArgs e)
        {
            CityName = CityTextBox.Text;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            GetInfoAsync();
        }

        private void Clock_TextBox()
        {
            clockCancellationTokenSource = new CancellationTokenSource();
            Task.Run(() =>
            {
                while (true)
                {
                    if (clockCancellationTokenSource.Token.IsCancellationRequested)
                        break;
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Clock.Text = DateTime.Now.ToString("HH:mm:ss");
                    });
                    Thread.Sleep(1000);
                }
            });
        }

        private async void GetInfoAsync()
        {
            WeatherDataFetcher weatherInfoFetcher = new WeatherDataFetcher();
            WeatherData WD = await weatherInfoFetcher.GetWeatherDataAsync(CityName);
            if (WD != null)
            {
                Clock_TextBox();
                
                double tempInCelsius = TempConverter.CelsiusConverter(WD.Temperature.TemperatureInfo);
                double feelsLikeInCelsius = TempConverter.CelsiusConverter(WD.Temperature.FeelsLike);
                double tempFarengate = TempConverter.FarengateConverter(WD.Temperature.TemperatureInfo);
                double feelsLikeInFarengate = TempConverter.FarengateConverter(WD.Temperature.FeelsLike);

                Location.Text = $"Country | {WD.Data.Country}\nCity | {WD.City}\nDateTime | {DateTime.Today.DayOfWeek}";
                Weather.Text = $"{tempInCelsius} °C | {tempFarengate} °F\n{new string('–', 9)}\n{feelsLikeInCelsius} °C | {feelsLikeInFarengate} °F";
                wInfo.Text = WD.Description[0].Description[..1].ToUpper() + WD.Description[0].Description[1..];
                DescriptionData.Text = $"\n\nHumidity | {WD.Temperature.Humidity}%" +
                                       $"\nWind speed | {Math.Round(WD.Wind.WindSpeed, 1)} km/h";
                StartupIcon.Visibility = Visibility.Collapsed;
                WeatherIcon.Visibility = Visibility.Visible;
                WeatherIcon.Source = ImageSelector.Select(wInfo.Text);
            }
            else
            {
                clockCancellationTokenSource?.Cancel();
                Location.Text = Weather.Text = wInfo.Text = DescriptionData.Text = Clock.Text = "";
                WeatherIcon.Visibility = Visibility.Collapsed;
                StartupIcon.Visibility = Visibility.Visible;
                StartupIcon.Source = ImageSelector.Select(null);
                errorWindow = new ErrorWindow();
                errorWindow.ErrorMessage.Text = WIFI_ERROR;
                errorWindow.Show();
                Keyboard.ClearFocus();
            }
        }

        private void Submit(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                GetInfoAsync();
                CityTextBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                Keyboard.ClearFocus();
            }
        }
    }
}