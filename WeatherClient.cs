using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Weather {
    class WeatherClient {
        public static WeatherForecast GetWeather(String city) {
            var url =
                $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=db73877da80bcf86ce14d0db9c8b06a3";
            using var client = new HttpClient();

            string content = client.GetStringAsync(url).Result;
            WeatherForecast weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(content);
            return weatherForecast;
        }
    }
}