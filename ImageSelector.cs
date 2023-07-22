using System;
using System.Windows.Media.Imaging;

namespace Weather_Checker
{
    public class ImageSelector
    {
        public BitmapImage Select(string descriptionText)
        {
            switch (descriptionText)
            {
                case "Clear sky": //(чисте небо)
                    return new BitmapImage(new Uri("/Images/Weather_clearSky.png", UriKind.Relative));
                case "Overcast clouds": //(похмура хмарність)
                    return new BitmapImage(new Uri("/Images/Weather_ocClouds.png", UriKind.Relative));
                case "Few clouds": //(невелика хмарність)
                case "Scattered clouds": //(розсіяна хмарність)
                case "Broken clouds": //(розірвана хмарність)
                    return new BitmapImage(new Uri("/Images/Weather_fewClouds.png", UriKind.Relative));
                case "Rain": //(дощ)
                    return new BitmapImage(new Uri("/Images/Weather_rain.png", UriKind.Relative));
                case "Light rain": //(легкий дощ)
                case "Moderate rain": //(помірний дощ)
                case "Drizzle": //(мряка)
                    return new BitmapImage(new Uri("/Images/Weather_lightRain.png", UriKind.Relative));
                case "Heavy rain": //(сильний дощ)
                case "Rain showers": //(зливові дощі)
                    return new BitmapImage(new Uri("/Images/Weather_heavyRain.png", UriKind.Relative));
                case "Thunderstorm with light rain": //(гроза з легким дощем)
                case "Thunderstorm": //(гроза)
                    return new BitmapImage(new Uri("/Images/Weather_thunderstorm.png", UriKind.Relative));
                case "Tornado": //(торнадо)
                case "Squalls": //(шквали)
                case "Dust whirls": //(пилові вихори)
                    return new BitmapImage(new Uri("/Images/Weather_tornado.png", UriKind.Relative));
                case "Mist": //(туман)
                case "Fog": //(туман)
                    return new BitmapImage(new Uri("/Images/Weather_mist.png", UriKind.Relative));
                case "Snow": //(сніг)
                case "Light snow": //(легкий сніг)
                case "Moderate snow": //(помірний сніг)
                    return new BitmapImage(new Uri("/Images/Weahter_snow.png", UriKind.Relative));
                case "Freezing rain": //(ожеледиця)
                    return new BitmapImage(new Uri("/Images/Weather_freezingRain.png", UriKind.Relative));
                case "Heavy snow": //(сильний сніг)
                case "Hail": //(град)
                case "Ice storm": //(град)
                    return new BitmapImage(new Uri("/Images/Weather_heavySnow.png", UriKind.Relative));
                default: //(якийсь інший варіант)
                    return new BitmapImage(new Uri("/Images/Map.png", UriKind.Relative));
            }
        }
    }
}