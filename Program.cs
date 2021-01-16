using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

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
        Dictionary<string, string> UserSubscriptions = new Dictionary<string, string>(); // (city, Subscription)

        WeatherBroadcast weatherBroadcast;

        public Strategy strategy;


        public void Subscribe(string city)
        {
            IObservator observator = new UserWeatherObserver(this, city);

            weatherBroadcast.Subscribe(city, observator);
        }

        public void Unsubscribe(string city)
        {
            //TODO
        }

        public void SetStrategy(Strategy strategy)
        {
            //TODO
        }

    }

    class UserWeatherObserver : IObservator
    {
        private readonly User user;
        private readonly string city;



        public UserWeatherObserver(User userArg, string cityArg)
        {
            user = userArg;
            city = cityArg;
        }

        public void Observe(Weather weather)
        {
            if (user.strategy.IsOk(weather))
            {
                Console.WriteLine($"The weather in ${city} will be good, have fun!");
            }

        }
    }


}
