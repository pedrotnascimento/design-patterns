namespace AbstractFactory
{

    public interface ProductX
    {
        void DoXThing();
    }

    public interface ProductY
    {
        void DoYThing();
    }

    public interface IAbstractFactory
    {
        ProductX CreateProductX();
        ProductY CreateProductY();
    }

    public class ProductXTypeA : ProductX
    {
        public void DoXThing()
        {
            Console.WriteLine("Do X Thing from family A");
        }
    }
    
    public class ProductYTypeA : ProductY
    {
        public void DoYThing()
        {
            Console.WriteLine("Do Y Thing from family A");
        }
    }
    
    public class ProductXTypeB: ProductX
    {
        public void DoXThing()
        {
            Console.WriteLine("Do X Thing from family B");
        }
    }
    
    public class ProductYTypeB : ProductY
    {
        public void DoYThing()
        {
            Console.WriteLine("Do Y Thing from family B");
        }
    }


    public class FactoryA : IAbstractFactory
    {
        public ProductX CreateProductX()
        {
            return new ProductXTypeA();
        }

        public ProductY CreateProductY()
        {
            return new ProductYTypeA();
        }
    }
    
    public class FactoryB : IAbstractFactory
    {
        public ProductX CreateProductX()
        {
            return new ProductXTypeB();
        }

        public ProductY CreateProductY()
        {
            return new ProductYTypeB();
        }
    }

    public class Program
    {
        static void Main()
        {
            IAbstractFactory factoryA = new FactoryA();
            factoryA.CreateProductX().DoXThing();
            factoryA.CreateProductY().DoYThing();

            IAbstractFactory abstractFactoryB = new FactoryB();
            abstractFactoryB.CreateProductX().DoXThing();
            abstractFactoryB.CreateProductY().DoYThing();

        }
    }


}

