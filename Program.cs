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

    class User
    {
        public void Subscribe()
        {
            //TODO
        }

        public void Unsubscribe()
        {
            //TODO
        }

        public void SetStrategy(Strategy strategy)
        {
            //TODO
        }
    }

    class Strategy
    {
        public string name;
        public bool isOk;
    }

    interface IObservator
    {
        public void Observe(Weather weather);

    }

    class UserWeatherObserver
    {
        private readonly User user;

        public UserWeatherObserver(User userArg)
        {
            user = userArg;
        }
    }
}
