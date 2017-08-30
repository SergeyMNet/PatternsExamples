
## Create class SomeSingletonClass

```c#
 public class SomeSingletonClass
    {
        private string Name;

        //the volatile keyword fixed the double lock issue volatile
        private static SomeSingletonClass _instance;
        private static readonly object _syncLock = new object();

        private SomeSingletonClass()
        {
            this.Name = Guid.NewGuid().ToString();
        }

        public static SomeSingletonClass Instance
        {
            get
            {
                if (_instance != null) return _instance;

                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new SomeSingletonClass();
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

## Create Task GetName Singleton

```c#
 public static async Task RunTask()
        {
            SomeSingletonClass.Instance.ShowName();
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

