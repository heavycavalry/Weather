using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Weather
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var url = "https://api.openweathermap.org/data/2.5/weather?q=Krakow&appid=db73877da80bcf86ce14d0db9c8b06a3";
            using var client = new HttpClient();

            var content = await client.GetStringAsync(url);
            var weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(content);
            float xd = weatherForecast.coord.lon;
        }
    }
}
