namespace Weather
{
    public interface IStrategy
    {
         string Name();
         bool IsOk(WeatherForecast weather);
    }

    public class RainStrategy:IStrategy
    {
        public string Name() => "Rain strategy.";
        public bool IsOk(WeatherForecast weather) => weather.weather[0].main.Equals("Rain");
    }
    public class SnowStrategy:IStrategy
    {
        public string Name() => "Snow strategy.";
        public bool IsOk(WeatherForecast weather) => weather.weather[0].main.Equals("Snow");
    }
    public class ThunderstormStrategy:IStrategy
    {
        public string Name() => "Thunderstorm strategy.";
        public bool IsOk(WeatherForecast weather) => weather.weather[0].main.Equals("Thunderstorm");
    }
    public class ClearStrategy:IStrategy
    {
        public string Name() => "Clear strategy.";
        public bool IsOk(WeatherForecast weather) => weather.weather[0].main.Equals("Clear");
    }
    public class CloudsStrategy:IStrategy
    {
        public string Name() => "Clouds strategy.";
        public bool IsOk(WeatherForecast weather) => weather.weather[0].main.Equals("Clouds");
    }
    public class AshStrategy:IStrategy
    {
        public string Name() => "Ash strategy.";
        public bool IsOk(WeatherForecast weather) => weather.weather[0].main.Equals("Ash");
    }
    public class HazeStrategy:IStrategy
    {
        public string Name() => "Haze strategy.";
        public bool IsOk(WeatherForecast weather) => weather.weather[0].main.Equals("Haze");
    }
    public class SmokeStrategy:IStrategy
    {
        public string Name() => "Smoke strategy.";
        public bool IsOk(WeatherForecast weather) => weather.weather[0].main.Equals("Smoke");
    }
    
    public class FogStrategy:IStrategy
    {
        public string Name() => "Fog strategy.";
        public bool IsOk(WeatherForecast weather) => weather.weather[0].main.Equals("Fog");
    }
    public class DustStrategy:IStrategy
    {
        public string Name() => "Dust strategy.";
        public bool IsOk(WeatherForecast weather) => weather.weather[0].main.Equals("Dust");
    }
    public class SandStrategy:IStrategy
    {
        public string Name() => "Sand strategy.";
        public bool IsOk(WeatherForecast weather) => weather.weather[0].main.Equals("Sand");
    }
    public class TornadoStrategy:IStrategy
    {
        public string Name() => "Tornado strategy.";
        public bool IsOk(WeatherForecast weather) => weather.weather[0].main.Equals("Tornado");
    }
    public class SquallStrategy:IStrategy
    {
        public string Name() => "Squall strategy.";
        public bool IsOk(WeatherForecast weather) => weather.weather[0].main.Equals("Squall");
    }
    public class DrizzleStrategy:IStrategy
    {
        public string Name() => "Drizzle strategy.";
        public bool IsOk(WeatherForecast weather) => weather.weather[0].main.Equals("Drizzle");
    }
    public class MistStrategy:IStrategy
    {
        public string Name() => "Mist strategy.";
        public bool IsOk(WeatherForecast weather) => weather.weather[0].main.Equals("Mist");
    }
}
