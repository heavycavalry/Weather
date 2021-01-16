using System;
using System.Collections.Generic;

namespace Weather
{
    interface IObservator
    {
        public void Observe(Weather weather);

    }

    class Subscription
    {
        public string ID;
        public IObservator Observator;
    }
    class Subscriptions
    {
        public void Accept(Weather weather)
        {
            //TODO
        }

        public void Add(Subscription subscription)
        {
            subscriptions.Add(subscription);
        }

        List<Subscription> subscriptions = new List<Subscription>();
    }


    class WeatherBroadcast
    {
        Dictionary<string, Subscriptions> CitySubscriptions = new Dictionary<string, Subscriptions>();


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

        public void EnsureSubscriptionForCity(string city)
        {
            if (!CitySubscriptions.ContainsKey(city))
            {
                Subscriptions subscriptions = new Subscriptions();
                CitySubscriptions.Add(city, subscriptions);
            }
        }
    }

}




