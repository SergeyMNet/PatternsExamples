using System;
using System.Collections.Generic;
using System.Threading;

namespace SimpleEventBusExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start!");


            Console.WriteLine("Subscribe to Events Day/Night");
            EventBus.Subscribe(e => {

                if (e is Day)
                    Console.WriteLine("> What a nice day!");

                else if (e is Night)
                    Console.WriteLine("> GoodNight!");

            });

            Thread.Sleep(5000);

            Console.WriteLine("===========");
            Console.WriteLine("Publish Day");
            EventBus.Publish(new Day());
            Console.WriteLine("===========");

            Thread.Sleep(5000);

            Console.WriteLine("===========");
            Console.WriteLine("Publish Night");
            EventBus.Publish(new Night());
            Console.WriteLine("===========");

            Console.WriteLine("End");
            Console.ReadKey();
        }
    }

    public static class EventBus
    {
        // list of all Subscribes
        private static List<Action<object>> handlers = new List<Action<object>>();

        // add new Subscribes
        public static void Subscribe(Action<object> handler)
        {
            handlers.Add(handler);
        }

        // Search for subscribers and notify them
        public static void Publish(object e)
        {
            handlers.ForEach(handler => handler(e));
        }
    }

    class Day
    {
    }

    class Night
    {
    }
}
