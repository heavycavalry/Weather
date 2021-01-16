using System.Collections.Generic;

namespace Weather
{
    interface IObservator
    {
        public void Observe(Weather weather);

    }

    class Subsription
    {
        public int ID;
        public IObservator Observator;
    }
    class Subscriptions
    {
        public void Accept(Weather weather)
        {
            //TODO
        }

        List<Subsription> subsriptions = new List<Subsription>();
    }


    class WeatherBroadcast
    {

    }


}
