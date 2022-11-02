namespace Decorator
{
    //public abstract class Component
    //{
    //    public abstract string Operation();
    //}

    public interface Component
    {
        public string Operation();
    }

    public class Decorator : Component
    {
        protected Component component;

        public Decorator(Component component)
        {
            this.component = component;
        }

        public void SetComponent(Component component)
        {
            this.component = component;

        }

        public string Operation()
        {
            if (component != null)
            {
                return component.Operation();
            }
            return "";
        }
    }

    public class ComponentA : Decorator, Component
    {
        public ComponentA(Component component) : base(component)
        {
        }

        public string Operation()
        {
            return $"ComponentA({base.Operation()})";
        }
    }

    public class ComponentB : Decorator, Component
    {
        public ComponentB(Component component) : base(component)
        {
        }

        public string Operation()
        {
            return $"ComponentB({base.Operation()})";
        }
    }

    public class ConcreteComponent : Component
    {

        public string Operation()
        {
            return "Simple Component";
        }
    }

    public class Program
    {
        static void Main()
        {
            var component = new ConcreteComponent();
            Console.WriteLine("Writing just a SImple Component below");
            Console.WriteLine(component.Operation());


            var cA = new ComponentA(component);
            var cb = new ComponentB(cA);
            Console.WriteLine(cb.Operation());

        }
    }

}