﻿using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using Lab6Lib;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Publisher event1 = new Publisher("EVENT-1");
            Publisher event2 = new Publisher("EVENT-2");
            Publisher event3 = new Publisher("EVENT-3");

            SubscriberA subscriberA = new SubscriberA();
            SubscriberB subscriberB = new SubscriberB();
            SubscriberC subscriberC = new SubscriberC();

            Console.WriteLine("--------------------Тест 1 ------------------");
            event1.subscribe(subscriberA);
            event2.subscribe(subscriberA);
            event3.subscribe(subscriberA);
            event1.nonify(); event2.nonify(); event3.nonify();

            Console.WriteLine("--------------------Тест 2 ------------------");
            event1.subscribe(subscriberB);
            event2.unsubscribe(subscriberA);
            event1.nonify(); event2.nonify(); event3.nonify();

            Console.WriteLine("--------------------Тест 3 ------------------");
            event2.subscribe(subscriberB);
            event3.subscribe(subscriberC);
            event1.nonify(); event2.nonify(); event3.nonify();

            Console.WriteLine("--------------------Тест 4 ------------------");
            event2.subscribe(subscriberB);
            event3.subscribe(subscriberC);
            event1.nonify(); 
            event2.nonify(); 
            event3.nonify();

            Console.WriteLine("--------------------Тест 5 ------------------");
            event1.unsubscribe(subscriberA);
            event1.unsubscribe(subscriberB);
            event2.unsubscribe(subscriberB);
            event3.unsubscribe(subscriberA);
            event3.unsubscribe(subscriberC);
            event1.nonify(); 
            event2.nonify(); 
            event3.nonify();

        }
    }

    public class SubscriberA : ISubscriber
    {
        public void update(string eventname)
        {
            Console.WriteLine(string.Format("Subscriber:{0}, Event:{1}", "A", eventname));
        }
    }
    public class SubscriberB : ISubscriber
    {
        public void update(string eventname)
        {
            Console.WriteLine(string.Format("Subscriber:{0}, Event:{1}", "B", eventname));
        }
    }
    public class SubscriberC : ISubscriber
    {
        public void update(string eventname)
        {
            Console.WriteLine(string.Format("Subscriber:{0}, Event:{1}", "C", eventname));
        }
    }



}

