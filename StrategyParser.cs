using System;

namespace Weather {
    public class StrategyParser {
        public static IStrategy ParseStrategy(string strategyString) {
            IStrategy strategy;
            switch (strategyString) {
                case "Mist":
                    strategy = new MistStrategy();
                    break;
                case "Rain":
                    strategy = new RainStrategy();
                    break;
                case "Snow":
                    strategy = new SnowStrategy();
                    break;
                case "Thunderstorm":
                    strategy = new ThunderstormStrategy();
                    break;
                case "Clear":
                    strategy = new ClearStrategy();
                    break;
                case "Clouds":
                    strategy = new CloudsStrategy();
                    break;
                case "Ash":
                    strategy = new AshStrategy();
                    break;
                case "Haze":
                    strategy = new HazeStrategy();
                    break;
                case "Smoke":
                    strategy = new SmokeStrategy();
                    break;
                case "Fog":
                    strategy = new FogStrategy();
                    break;
                case "Dust":
                    strategy = new DustStrategy();
                    break;
                case "Sand":
                    strategy = new SandStrategy();
                    break;
                case "Tornado":
                    strategy = new TornadoStrategy();
                    break;
                case "Squall":
                    strategy = new SquallStrategy();
                    break;
                case "Drizzle":
                    strategy = new DrizzleStrategy();
                    break;
                default:
                    throw new Exception("Wrong strategy name. Please try again.");
            }

            return strategy;
        }
    }
}