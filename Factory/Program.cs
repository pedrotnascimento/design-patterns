namespace FactoryMethod
{
    // https://refactoring.guru/pt-br/design-patterns/factory-method
    public interface Product
    {
        void DoThing();
    }
    public class ProductA : Product
    {
        public string Name { get; set; }
        public void DoThing()
        {
            Console.WriteLine("Product A do his thing");
        }
    }

    public class ProductB : Product
    {
        public string Name { get; set; }
        public Guid SerialNumberAboutB { get; set; } = Guid.NewGuid();
        public void DoThing()
        {
            Console.WriteLine($"Product B do his thing:: B Serial Number {SerialNumberAboutB}");
        }
    }

    abstract public class Factory
    {
        /// <summary>
        /// Factory METHOD
        /// </summary>
        /// <returns></returns>
        public abstract Product CreateProduct(); ///

        public void WhatEverLogics()
        {
            Console.WriteLine("Renderize object");
        }
    }

    public class FactoryA : Factory
    {
        public override Product CreateProduct()
        {
            return new ProductA();
        }
    }

    public class FactoryB : Factory
    {
        public override Product CreateProduct()
        {
            return new ProductB();
        }
    }

    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Implementing Factory pattern");
            string typeProduct;
            typeProduct = "Need ProductA";
            ExecuteProduct(typeProduct);

            typeProduct = "Need ProductB";
            ExecuteProduct(typeProduct);

        }

        private static void ExecuteProduct(string typeProduct)
        {
            Factory factory;
            Product product;
            if (typeProduct == "Need ProductA")
            {
                factory = new FactoryA();
                product = factory.CreateProduct();
                product.DoThing();
            }
            else if (typeProduct == "Need ProductB")
            {
                factory = new FactoryB();
                product = factory.CreateProduct();
                product.DoThing();
            }
        }
    }

}