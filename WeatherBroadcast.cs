using System;
using System.Collections.Generic;
using System.Threading;

namespace Weather
{
    public class WeatherBroadcast //PUBLISHER
    {
        internal Dictionary<string, Subscriptions> CitySubscriptions = new Dictionary<string, Subscriptions>();

        public WeatherBroadcast()
        {
            new WeatherBroadcastFeeder(this).start();
        }


        //TWORZY SUBSKRYPCJE DLA DANEGO CITY I OBSERWATORA, DODAJE JĄ 
        //DO REJESTRU SUBSKRYPCJI I ZWRACA ID TEJ SUBSKRYPCJI ZEBY POTEM
        //MOZNA BYLO SIE DO NIEGO DOSTAC I GO USUNAC, NIE MA ZA CO
        public string Subscribe(string city, IObservator observator)
        {
            Subscription subscription = new Subscription();
            subscription.ID = Guid.NewGuid().ToString();
            subscription.Observator = observator;
            EnsureSubscriptionForCity(city);
            CitySubscriptions[city].Add(subscription);

            return subscription.ID;
        }

        public void Unsubscribe(string ID, string city)
        {
            if (CitySubscriptions.ContainsKey(city))
            {
                CitySubscriptions[city].Remove(ID);

                if (CitySubscriptions[city].IsEmpty())
                {
                    CitySubscriptions.Remove(city);
                }
            }
        }

        public void EnsureSubscriptionForCity(string city)
        {
            if (!CitySubscriptions.ContainsKey(city))
            {
                Subscriptions subscriptions = new Subscriptions();
                CitySubscriptions.Add(city, subscriptions);
            }
        }

        public void NotifySubscribers(string city, WeatherForecast weather)
        {
            if (CitySubscriptions.ContainsKey(city))
            {
                CitySubscriptions[city].Notify(weather);
            }
        }
    }

    class WeatherBroadcastFeeder
    {
        private WeatherBroadcast weatherBroadcast;
        public WeatherBroadcastFeeder(WeatherBroadcast broadcast)
        {
            this.weatherBroadcast = broadcast;
        }

        void feedingProcess()
        {
            while (true)
            {
                foreach (var city in weatherBroadcast.CitySubscriptions.Keys)
                {
                    var weather = WeatherClient.GetWeather(city);
                    weatherBroadcast.NotifySubscribers(city, weather);
                }
                Thread.Sleep(2000); // usypia/zawiesza watek na 2 sekundy
            }
        }

        public void start()
        {
            var thread = new Thread(this.feedingProcess);
            thread.Start(); //włączamy nowy wątek
        }
        
        
    }

}




