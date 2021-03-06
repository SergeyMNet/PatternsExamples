
## Singleton without Locks
The static constructor is only executed when the instance property is called the first time.

```c#
 public sealed class SingletonWithoutLocks
    {
        private string Name;

        private static readonly SingletonWithoutLocks instance;

        private SingletonWithoutLocks() {
            this.Name = Guid.NewGuid().ToString();
        }

        static SingletonWithoutLocks()
        {
            instance = new SingletonWithoutLocks();
        }

        public static SingletonWithoutLocks Instance
        {
            get
            {
                return instance;
            }
        }

        public void ShowName()
        {
            Console.WriteLine(Name);
        }
    }
```

## Singleton with using locks
Using lazy load.

```c#
 public class SingletonUseLock
    {
        private string Name;

        //the volatile keyword fixed the double lock issue volatile
        private static SingletonUseLock _instance;
        private static readonly object _syncLock = new object();

        private SingletonUseLock()
        {
            this.Name = Guid.NewGuid().ToString();
        }

        public static SingletonUseLock Instance
        {
            get
            {
                if (_instance != null) return _instance;

                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonUseLock();
                    }
                }
                return _instance;
            }
        }

        public void ShowName()
        {
            Console.WriteLine(Name);
        }
    }
```

## Check Name from different threads

```c#
  static void Main(string[] args)
        {
            Console.WriteLine("Start");

            var all = new List<Task>();
            for (int i = 0; i < 1000; i++)
                all.Add(RunTask());

            Task.WaitAll(all.ToArray());

            Console.WriteLine("Finish");
            Console.ReadKey();
        }
```

