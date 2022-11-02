public interface Mediator
{
    void Nofity(object obj, string ev);
}


public class ConcreteMediator : Mediator
{
    public Sum sum;
    public Sub sub;
    public void Nofity(object obj, string ev)
    {
        if (ev == "Sum")
        {
            Console.WriteLine("For Every Sum subtract -1");
            var resSub = this.sub.GetSub((int)obj, 1);
            Console.WriteLine($"Reaction Sub: {resSub}");
        }
        else if (ev == "Sub")
        {
            Console.WriteLine("For Every Sub sum +1");
            var resSum = this.sum.GetSum((int)obj, 1);
            Console.WriteLine($"Reaction Sum: {resSum}");
        }
    }
}

public class BaseComponent
{
    protected Mediator Mediator { get; set; }// imutable
    public BaseComponent(Mediator mediator)
    {
        this.Mediator = mediator;
    }
}

public class Sum : BaseComponent
{
    public Sum(Mediator mediator) : base(mediator)
    {
    }
    public void NotifySum(int a, int b)
    {
        string message = $"Sum";
        int sum = GetSum(a, b);
        Console.WriteLine($"Sum and notifiy: {a}+{b}");
        this.Mediator.Nofity(sum, message);
    }

    public int GetSum(int a, int b)
    {
        return a + b;
    }
}

public class Sub : BaseComponent
{
    public Sub(Mediator mediator) : base(mediator)
    {
    }

    public void DoSub(int a, int b)
    {
        string message = $"Sub";
        int sub = GetSub(a, b);
        Console.WriteLine($"Sub and notifiy: {a}-{b}");
        this.Mediator.Nofity(sub, message);
    }

    public int GetSub(int a, int b)
    {
        return a - b;
    }
}

public class Program
{
    static public void Main()
    {
        var mediator = new ConcreteMediator();
        var sumComponent = new Sum(mediator);
        var subComponent = new Sub(mediator);
        mediator.sum = sumComponent;
        mediator.sub = subComponent;
        sumComponent.NotifySum(3, 2);
        subComponent.DoSub(3, 2);
    }
}