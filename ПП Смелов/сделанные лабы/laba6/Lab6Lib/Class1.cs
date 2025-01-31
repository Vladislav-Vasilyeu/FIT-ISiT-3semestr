using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6Lib
{
    public interface ISubscriber 
    {
        void update(string eventname);
    }



    public class Publisher 
    {
        private string evenName;
        private List<ISubscriber> subscribers;
        public Publisher(string eventname) 
        {
            this.evenName = eventname;
            this.subscribers = new List<ISubscriber>();
        }
        public void subscribe(ISubscriber subscriber)
        {
            if (!subscribers.Contains(subscriber))
            {
                subscribers.Add(subscriber);
            }
        }
        public bool unsubscribe(ISubscriber subscriber)
        {
            if (subscribers.Contains(subscriber))
            {
                subscribers.Remove(subscriber);
                return true;
            }
            return false;                              
        }
        public int nonify() 
        {
            int notifiedCount = 0;
            foreach (var subscriber in subscribers)
            {
                subscriber.update(evenName);
                notifiedCount++;
            }
            return notifiedCount;                
        }
    }
}
