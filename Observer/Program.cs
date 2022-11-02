public interface Subscriber
{
    void Update(string response);
}

public class ComponentA : Subscriber
{
    public void Update(string response)
    {
        Console.WriteLine("I'm component A, I received " + response);


    }
}

public class ComponentB : Subscriber
{
    public void Update(string response)
    {
        Console.WriteLine("I'm component B, I received " + response);


    }
}


public class Publisher
{
    List<Subscriber> subscribers = new List<Subscriber>();
    public Publisher AddSubscriber(Subscriber subscriber)
    {
        this.subscribers.Add(subscriber);
        return this;
    }

    public void Notify(string state)
    {
        foreach (var s in subscribers)
        {
            s.Update(state);
        }
    }
}

public class Program
{
    static public void Main()
    {
        var a = new ComponentA();
        var b = new ComponentB();
        var pub = new Publisher();
        pub.AddSubscriber(a)
            .AddSubscriber(b);
        pub.Notify("Hey I'm pub: chaging my state ");
        pub.Notify("Hey I'm pub: chaging my state AGAIN!, SORRY!!!");

    }
}