using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    class Publisher
    {

        private List<UserSubscriber> subscribers = new List<UserSubscriber>();

        public void subscribe(UserSubscriber s)
        {
            Console.WriteLine("Subscriber {0} was added to subscribers list", s.ToString());
            this.subscribers.Add(s);

        }


        public void unsubscribe(UserSubscriber s)
        {
            Console.WriteLine("Subscriber {0} was remove from subscribers list", s.ToString());
            this.subscribers.Remove(s);

        }


        public void notifySubscribers(string message)
        {
            Console.WriteLine("Subject: Notifying subscribers...");
            foreach (var user in subscribers)
            {
                user.update(message);
            }


        }


        public List<UserSubscriber> getSubscribers()
        {

            return subscribers;
        }


        public void printSubscribers()
        {
            foreach (var user in subscribers)
            {
                Console.WriteLine(user.ToString());
            }

        }


    }
}
