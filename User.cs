using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Weather {
    class User : Subscriber {
        WeatherBroadcast weatherBroadcast;

        public Strategy strategy;


        public void Subscribe(string city) {
            weatherBroadcast.Subscribe(city, this);
        }

        public void Unsubscribe(string city) {
            weatherBroadcast.Unsubscribe(city, this);
        }

        public void SetStrategy(Strategy strategy) {
            this.strategy = strategy;
        }

        public void Observe(WeatherInCity weather) {
            if (this.strategy.IsOk(weather.WeatherForecast)) {
                Console.WriteLine($"The weather in ${weather.City} will be good, have fun!");
            }
        }
    }
}