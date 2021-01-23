using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Weather {
    public class User : Subscriber {
        public string Login;
        
        WeatherBroadcast weatherBroadcast;

        public IStrategy strategy;

        public void SetWeatherBroadcast(WeatherBroadcast w) {
            weatherBroadcast = w;
        }

        public void Subscribe(string city) {
            weatherBroadcast.Subscribe(city, this);
        }

        public void Unsubscribe(string city) {
            weatherBroadcast.Unsubscribe(city, this);
        }

        public void SetStrategy(IStrategy strategy) {
            this.strategy = strategy;
        }

        public void Observe(WeatherInCity weather) {
            if (this.strategy != null && this.strategy.IsOk(weather.WeatherForecast)) {
                Console.WriteLine($"{DateTime.Now}: Hey {Login}, the weather in {weather.City} will be good, have fun!");
            }
        }
    }

    public class UserBuilder {
        private string _login;
        private WeatherBroadcast _broadcast;

        public UserBuilder SetWeatherBroadcast(WeatherBroadcast broadcast) {
            this._broadcast = broadcast;
            return this;
        }

        public UserBuilder SetLogin(string login) {
            this._login = login;
            return this;
        }

        public User Build() {
            if (_login == null) {
                throw new Exception("User needs login");
            }
            if (_broadcast == null) {
                throw new Exception("User needs weather broadcast");
            }

            User u = new User();
            u.Login = _login;
            u.SetWeatherBroadcast(_broadcast);
            return u;
        }
        
        
    }
}