using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Weather {
    public interface Subscriber {
        public void Observe(WeatherInCity weather);
    }

    class Subscriptions {
        List<Subscriber> subscriptions = new List<Subscriber>();

        public void Notify(WeatherInCity weather) {
            foreach (Subscriber subscriber in subscriptions) {
                subscriber.Observe(weather);
            }
        }

        public void Add(Subscriber subscription) {
            subscriptions.Add(subscription);
        }

        public void Remove(Subscriber subscriber) {
            subscriptions.Remove(subscriber);
        }
        public bool IsEmpty() => subscriptions.Count == 0;
    }
}