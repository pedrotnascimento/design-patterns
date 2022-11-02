public class Context
{
    private State state;

    public void ChangeState(State state)
    {
        this.state = state;
        Console.WriteLine($"State changed to {state.GetType().Name}");
        
    }
    public void Task1()
    {
        this.state.Task1();
    }
}

public abstract class State
{
    private Context context;

    void SetContext(Context context)
    {
        this.context = context;
    }

    abstract public void Task1();
}


public class StateA : State
{
    public override void Task1()
    {
        Console.WriteLine("Hi NOW its STATE A doing TASK 1 as it changed");
    }
}

public class StateB : State
{
    public override void Task1()
    {
        Console.WriteLine("Hi NOW its STATE B doing TASK 1 as it changed");
    }

}

public static class Program
{
    public static void Main()
    {
        var context = new Context();
        
        var stateA = new StateA();
        context.ChangeState(stateA);
        context.Task1();

        var stateB = new StateB();
        context.ChangeState(stateB);
        context.Task1();
    }
}