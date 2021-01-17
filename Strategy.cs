namespace Weather
{
    public enum StrategyType
    {
        Rain,
        Snow,
        Thunderstorm,
        Clear,
        Clouds,
        Ash,
        Haze,
        Smoke,
        Fog,
        Dust,
        Sand,
        Tornado,
        Squall,
        Drizzle,
        Mist
    }
    interface Strategy
    {
        public string Name();
        public bool IsOk(WeatherForecast weather);
    }

    public class RainStrategy : Strategy
    {
        public StrategyType Type;
        public RainStrategy() => Type = StrategyType.Rain;
        public string Name() => "Rain strategy.";

        public bool IsOk(WeatherForecast weather) => weather.weather[0].main == "Rain";
    }
    public class SnowStrategy : Strategy
    {
        public StrategyType Type;
        public SnowStrategy() => Type = StrategyType.Snow;
        public string Name() => "Snow strategy.";

        public bool IsOk(WeatherForecast weather) => weather.weather[0].main == "Snow";
    }
    public class ThunderstormStrategy : Strategy
    {
        public StrategyType Type;
        public ThunderstormStrategy() => Type = StrategyType.Thunderstorm;
        public string Name() => "Thunderstorm strategy.";

        public bool IsOk(WeatherForecast weather) => weather.weather[0].main == "Thunderstorm";
    }
    public class ClearStrategy : Strategy
    {
        public StrategyType Type;
        public ClearStrategy() => Type = StrategyType.Clear;
        public string Name() => "Clear strategy.";

        public bool IsOk(WeatherForecast weather) => weather.weather[0].main == "Clear";
    }
    public class CloudsStrategy : Strategy
    {
        public StrategyType Type;
        public CloudsStrategy() => Type = StrategyType.Clouds;
        public string Name() => "Clouds strategy.";

        public bool IsOk(WeatherForecast weather) => weather.weather[0].main == "Clouds";
    }
    public class AshStrategy : Strategy
    {
        public StrategyType Type;
        public AshStrategy() => Type = StrategyType.Ash;
        public string Name() => "Ash strategy.";

        public bool IsOk(WeatherForecast weather) => weather.weather[0].main == "Ash";
    }
    public class HazeStrategy : Strategy
    {
        public StrategyType Type;
        public HazeStrategy() => Type = StrategyType.Haze;
        public string Name() => "Haze strategy.";

        public bool IsOk(WeatherForecast weather) => weather.weather[0].main == "Haze";
    }
    public class SmokeStrategy : Strategy
    {
        public StrategyType Type;
        public SmokeStrategy() => Type = StrategyType.Smoke;
        public string Name() => "Smoke strategy.";

        public bool IsOk(WeatherForecast weather) => weather.weather[0].main == "Smoke";
    }
    public class FogStrategy : Strategy
    {
        public StrategyType Type;
        public FogStrategy() => Type = StrategyType.Fog;
        public string Name() => "Fog strategy.";

        public bool IsOk(WeatherForecast weather) => weather.weather[0].main == "Fog";
    }
    public class DustStrategy : Strategy
    {
        public StrategyType Type;
        public DustStrategy() => Type = StrategyType.Dust;
        public string Name() => "Dust strategy.";

        public bool IsOk(WeatherForecast weather) => weather.weather[0].main == "Dust";
    }
    public class SandStrategy : Strategy
    {
        public StrategyType Type;
        public SandStrategy() => Type = StrategyType.Sand;
        public string Name() => "Sand strategy.";

        public bool IsOk(WeatherForecast weather) => weather.weather[0].main == "Sand";
    }
    public class TornadoStrategy : Strategy
    {
        public StrategyType Type;
        public TornadoStrategy() => Type = StrategyType.Tornado;
        public string Name() => "Tornado strategy.";

        public bool IsOk(WeatherForecast weather) => weather.weather[0].main == "Tornado";
    }
    public class SquallStrategy : Strategy
    {
        public StrategyType Type;
        public SquallStrategy() => Type = StrategyType.Squall;
        public string Name() => "Squall strategy.";

        public bool IsOk(WeatherForecast weather) => weather.weather[0].main == "Squall";
    }
    public class DrizzleStrategy : Strategy
    {
        public StrategyType Type;
        public DrizzleStrategy() => Type = StrategyType.Drizzle;
        public string Name() => "Drizzle strategy.";

        public bool IsOk(WeatherForecast weather) => weather.weather[0].main == "Drizzle";
    }
    public class MistStrategy : Strategy
    {
        public StrategyType Type;
        public MistStrategy() => Type = StrategyType.Mist;
        public string Name() => "Mist strategy.";

        public bool IsOk(WeatherForecast weather) => weather.weather[0].main == "Mist";
    }
}
