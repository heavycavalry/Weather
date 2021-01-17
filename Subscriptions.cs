using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Weather
{
    public interface IObservator
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

        public void Notify(Weather weather)
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

}




