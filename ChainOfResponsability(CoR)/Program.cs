public interface IHandler
{
    void DoWork(string str);
}


public class ComponentBase : IHandler
{
    protected IHandler? NextHandler { get; set; } // OR NEXT
    public virtual void DoWork(string str)
    {

        Console.WriteLine($"BASE do work: {str}");
        if (NextHandler != null)
        {
            NextHandler.DoWork(str);
        }
    }

    public ComponentBase AddChild(IHandler component)
    {
        NextHandler = component;
        return (ComponentBase)NextHandler;
    }
}

public class ComponentAAA : ComponentBase
{

    public override void DoWork(string str)
    {
        Console.WriteLine($"AAA do work: {str}");
        if (NextHandler != null)
        {
            NextHandler.DoWork(str);
        }

    }
}

public class ComponentBBB : ComponentBase
{

    public override void DoWork(string str)
    {
        Console.WriteLine($"BBB do work: {str}");
        if (NextHandler != null)
        {
            NextHandler.DoWork(str);
        }
    }
}


public static class Program
{
    static public void Main()
    {
        /// BUILDING CHAIN OF RESPONSABILITY
        ComponentBase baseComp = new ComponentBase();
        ComponentAAA AAAComp = new ComponentAAA();
        ComponentBBB BBBComp = new ComponentBBB();
        baseComp
            .AddChild(AAAComp)
            .AddChild(BBBComp);

        /// CLIENT RECEIVED REQUEST, 
        /// RUN CHAIN OF RESPONSABILITY
        baseComp.DoWork("HI THERE!!!");
        Console.WriteLine();

    }
}