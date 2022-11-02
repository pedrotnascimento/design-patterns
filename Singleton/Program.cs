namespace Singleton
{

    //https://refactoring.guru/pt-br/design-patterns/singleton        
    public class MySingleton
    {
        static public MySingleton? Instance { get; set; }
        public int LastNumber { get; set; }
        private MySingleton()
        {

        }

        static public MySingleton GetInstance()
        {
            if (Instance == null)
            {
                Instance = new MySingleton();
            }

            return Instance;
        }
    }


    partial class Program
    {

        static void Main()
        {

            var singleton = MySingleton.GetInstance();
            singleton.LastNumber = 12;
            Console.WriteLine($"first variable of singleton:: Number in singleton {singleton.LastNumber}");
            var sameSingletonInNewVariable = MySingleton.GetInstance();
            Console.WriteLine($"sameSingletonInNewVariable:: Number in singleton {singleton.LastNumber}");
        }
    }

}
