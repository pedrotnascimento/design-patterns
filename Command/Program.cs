public interface ICommand
{
    void Execute();
}


public class Rice : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Rice");
    }
}

public class Beam : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Beam");
    }
}

public class Cookie : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Cookie");
    }
}

public class Meat : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Meat");
    }
}

public class KitchenInvoker
{
    public List<ICommand> Meal { get; set; } = new List<ICommand>();

    public KitchenInvoker AddMeal(ICommand meal)
    {
        Meal.Add(meal);
        return this;
    }

    public void PrepareMeal()
    {
        Console.WriteLine("Preparing Meal");
        foreach (var m in Meal)
        {
            m.Execute();
        }
    }

    public void Bake(ICommand command)
    {
        Console.WriteLine("Bakering->>>");
        command.Execute();
    }

    public void Boil(ICommand command)
    {
        Console.WriteLine("Boiling->>>");
        command.Execute();
    }
}

public static class Program
{
    static public void Main()
    {
        KitchenInvoker kitchen = new KitchenInvoker();
        kitchen.AddMeal(new Beam());
        kitchen.AddMeal(new Rice());
        kitchen.PrepareMeal();

        kitchen.Bake(new Cookie());
        kitchen.Boil(new Meat());
    }
}
