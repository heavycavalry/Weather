using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Weather
{
    class WeatherClient
    {
        static WeatherForecast GetWeather(String city)
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=db73877da80bcf86ce14d0db9c8b06a3";
            using var client = new HttpClient();

            var content = client.GetStringAsync(url).Result;
            var weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(content);
            return weatherForecast;
        }

    }
}
