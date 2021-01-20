using System;

namespace Weather
{
    public class Builder
    {

        public interface IBuilder
        {
            void CreateUser();
            void CreateWeatherBroadcastForUser();
            User GetUser();
            WeatherBroadcast GetWeatherBroadcast();
        }

        public class ProgramBuilder : IBuilder
        {
            private User _user;
            private WeatherBroadcast _weatherBroadcast;
            private WeatherBroadcastFeeder _weatherBroadcastFeeder;
            private string city;
            private IStrategy _strategy;

            public ProgramBuilder( )
            {
                Console.WriteLine("Enter city name: ");
                city = Console.ReadLine();
                Console.WriteLine("Enter strategy: ");
                string strategyString = Console.ReadLine();
                switch (strategyString)
                {
                    case "Mist":
                        _strategy = new MistStrategy();
                        break;
                    case "Rain":
                        _strategy = new RainStrategy();
                        break;
                    case "Snow":
                        _strategy = new SnowStrategy();
                        break;
                    case "Thunderstorm":
                        _strategy = new ThunderstormStrategy();
                        break;
                    case "Clear":
                        _strategy = new ClearStrategy();
                        break;
                    case "Clouds":
                        _strategy = new CloudsStrategy();
                        break;
                    case "Ash":
                        _strategy = new AshStrategy();
                        break;
                    case "Haze":
                        _strategy = new HazeStrategy();
                        break;
                    case "Smoke":
                        _strategy = new SmokeStrategy();
                        break;
                    case "Fog":
                        _strategy = new FogStrategy();
                        break;
                    case "Dust":
                        _strategy = new DustStrategy();
                        break;
                    case "Sand":
                        _strategy = new SandStrategy();
                        break;
                    case "Tornado":
                        _strategy = new TornadoStrategy();
                        break;
                    case "Squall":
                        _strategy = new SquallStrategy();
                        break;
                    case "Drizzle":
                        _strategy = new DrizzleStrategy();
                        break;
                    default:
                        throw new Exception();
                        break;
                }
                
                CreateUser();
                CreateWeatherBroadcastForUser();
                _user.SetWeatherBroadcast(_weatherBroadcast);
            }
            public void CreateUser()
            {
                _user = new User();
                _user.Subscribe(city);
                _user.SetStrategy(_strategy);
            }
            

            public void CreateWeatherBroadcastForUser()
            {
                _weatherBroadcast = new WeatherBroadcast();
            }


            public User GetUser()
            {
                return _user;
            }

            public WeatherBroadcast GetWeatherBroadcast()
            {
                return _weatherBroadcast;
            }
        }

       

    }
}