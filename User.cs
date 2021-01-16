using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Weather
{
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
