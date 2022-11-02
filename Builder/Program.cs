namespace Builder
{
    //https://refactoring.guru/pt-br/design-patterns/builder
    public interface BuilderProduct
    {
        void Reset();
        void Stage1();
        void Stage2();
        // Product GetResult();
    }

    public class ProductA
    {
    }
    public class ProductB
    {
    }


    public class BuilderProductA : BuilderProduct
    {
        private ProductA Product { get; set; }

        public void Stage1()
        {
            Console.WriteLine("First step of product A");
        }

        public void Stage2()
        {
            Console.WriteLine("Second step of product A");
        }

        public void Reset()
        {
            Product = new ProductA();
            Console.WriteLine("Reseting the product A");
        }

        public ProductA GetResult()
        {
            return Product;
        }
    }

    public class BuilderProductB : BuilderProduct
    {
        private ProductB Product;
        public void Stage1()
        {
            Console.WriteLine("First step of product B");
        }

        public void Stage2()
        {
            Console.WriteLine("Second step of product B");
        }

        public void Reset()
        {
            Product = new ProductB();
            Console.WriteLine("Reseting the product B");
        }

        public ProductB GetResult()
        {
            return Product;
        }
    }

    public class Director
    {
        public ProductA Make(BuilderProductA builderA)
        {
            builderA.Reset();
            builderA.Stage1();
            builderA.Stage2();
            ProductA product= builderA.GetResult();
            return product;
        }
        
        public ProductB Make(BuilderProductB builderB)
        {
            builderB.Reset();
            builderB.Stage1();
            builderB.Stage2();
            ProductB product= builderB.GetResult();
            return product;
        }
    }

}