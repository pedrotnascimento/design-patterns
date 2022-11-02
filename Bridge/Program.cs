namespace Bridge
{

    //https://refactoring.guru/pt-br/design-patterns/bridge
    public class Abstraction
    {
        public IColorImplementation colorImplementation;
        public Abstraction(IColorImplementation colorImplementation)
        {
            this.colorImplementation = colorImplementation;
        }

        public void ApplyColor()
        {

            Console.WriteLine($"Color Being user: {colorImplementation.GetColor()}");
            this.colorImplementation.Paint();
        }
    }

    public interface IColorImplementation
    {
        void Paint();
        string GetColor();
    }

    public class Red : IColorImplementation
    {
        public string GetColor()
        {
            return "Red";
        }

        public void Paint()
        {
            Console.WriteLine("Painting stuff");
        }
    }
    
    public class Blue: IColorImplementation
    {
        public string GetColor()
        {
            return "Blue";
        }

        public void Paint()
        {
            Console.WriteLine("Painting stuff");
        }
    }


    public class Program
    {
        static void Main()
        {
            Red red = new Red();
            var abstractionThatUsesAColor = new Abstraction(red);
            abstractionThatUsesAColor.ApplyColor();
            
            Blue blue= new Blue();
            abstractionThatUsesAColor.colorImplementation = blue;
            abstractionThatUsesAColor.ApplyColor();
        }
    }
}