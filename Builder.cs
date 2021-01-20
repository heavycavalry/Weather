using System;

namespace Weather
{
    public class Builder
    {

        public interface IBuilder
        {
            void CreateUser();
            void CreateUserObserverForUser();
            void CreateWeatherBroadcastForUser();
            void CreateWeatherBroadcastFeeder();
            void StartWeatherBroadcastFeeder();
            WeatherBroadcastFeeder GetWeatherBroadcastFeeder();
            IObservator GetUserWeatherObserver();
            User GetUser();
            WeatherBroadcast GetWeatherBroadcast();
        }

        public class ProgramBuilder : IBuilder
        {
            private User _user;
            private UserWeatherObserver _userWeatherObserver;
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
                CreateUserObserverForUser();
                CreateWeatherBroadcastForUser();
                CreateWeatherBroadcastFeeder();
                StartWeatherBroadcastFeeder();
            }
            public void CreateUser()
            {
                _user = new User();
                _user.Subscribe(city);
                _user.SetStrategy(_strategy);
            }

            public void CreateUserObserverForUser()
            {
                _userWeatherObserver = new UserWeatherObserver(_user, city);
            }

            public void CreateWeatherBroadcastForUser()
            {
                _weatherBroadcast = new WeatherBroadcast();
                _weatherBroadcast.Subscribe(city, _userWeatherObserver);
            }

            public void CreateWeatherBroadcastFeeder()
            {
                _weatherBroadcastFeeder = new WeatherBroadcastFeeder(_weatherBroadcast);
            }

            public void StartWeatherBroadcastFeeder()
            {
                _weatherBroadcastFeeder.start();
            }

            public WeatherBroadcastFeeder GetWeatherBroadcastFeeder()
            {
                return _weatherBroadcastFeeder;
            }

            public IObservator GetUserWeatherObserver()
            {
                return _userWeatherObserver;
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