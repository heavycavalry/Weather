using System;
using System.Collections.Generic;
using System.ComponentModel;

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

        List<Subscription> subscriptions = new List<Subscription>();

        public void Feed(Weather weather)
        {
            foreach (Subscription subscription in subscriptions)
            {
                subscription.Observator.Observe(weather);
            }
        }

        public void Add(Subscription subscription)
        {
            subscriptions.Add(subscription);
        }

        public void Remove(string ID)
        {
            Subscription removedItem = null;

            foreach (Subscription s in subscriptions)
            {
                if (s.ID == ID)
                {
                    removedItem = s;
                }
            }

            subscriptions.Remove(removedItem);
        }

        public bool IsEmpty() => subscriptions.Count == 0;

    }


    public class WeatherBroadcast
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

        public void Feed(string city, Weather weather)
        {
            if (CitySubscriptions.ContainsKey(city))
            {
                CitySubscriptions[city].Feed(weather);
            }
        }
    }

}




