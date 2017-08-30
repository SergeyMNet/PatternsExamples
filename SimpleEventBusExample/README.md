
## Create class EventBus

```c#
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
```

## Subscribe to Events

```c#
 EventBus.Subscribe(e => {

      if (e is Day)
        Console.WriteLine("> What a nice day!");

      else if (e is Night)
        Console.WriteLine("> GoodNight!");
  });

            EventBus.Publish(new Day());
```

## Publish Event

```c#
    EventBus.Publish(new Day());
```
