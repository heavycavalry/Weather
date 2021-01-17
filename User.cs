using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Weather
{
    class User
    {
        Dictionary<string, string> UserSubscriptions = new Dictionary<string, string>(); // (city -> ID)

        WeatherBroadcast weatherBroadcast;

        public Strategy strategy;


        public void Subscribe(string city)
        {
            if (UserSubscriptions.ContainsKey(city)) {
            IObservator observator = new UserWeatherObserver(this, city);
            var id = weatherBroadcast.Subscribe(city, observator);
            UserSubscriptions.Add(city, id);
            }
        }

        public void Unsubscribe(string city)
        {
            if (UserSubscriptions.ContainsKey(city)) {
                
               var subscriptionId = UserSubscriptions[city];
                weatherBroadcast.Unsubscribe(subscriptionId, city);
                UserSubscriptions.Remove(city);
            }
        }

        public void SetStrategy(Strategy strategy)
        {
            this.strategy = strategy;
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

        public void Observe(WeatherForecast weather)
        {
            if (user.strategy.IsOk(weather))
            {
                Console.WriteLine($"The weather in ${city} will be good, have fun!");
            }

        }
    }
}
