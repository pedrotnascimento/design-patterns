namespace Composite
{

    public interface IGraphic // childs or leaf
    {
        void Move(int x, int y);
        void Draw();
    }

    public class CompoundGraphic : IGraphic
    {
        #region container methods
        public List<IGraphic> children { get; set; }
        public void Add(IGraphic child)
        {
            children.Add(child);
        }

        public void Delete(IGraphic child)
        {
            children.Remove(child);
        }

        #endregion

        #region interface/business rules Methods

        public void Draw()
        {
            foreach(var child in children)
            {
                child.Draw();
            }
        }

        public void Move(int x, int y)
        {
            foreach (var child in children)
            {
                child.Move(x, y);
            }
        }

        #endregion
    }

    public class Dot : IGraphic
    {
        public int x;
        public int y;
        public Dot(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        virtual public void Draw()
        {
            Console.WriteLine("Drawing DOT");
        }

        public void Move(int x, int y)
        {
            this.x = x;
            this.y = y;
            Console.WriteLine("Moving DOT");
        }
    }

    public class Circle : Dot
    {
        public int radius;
        public Circle(int x, int y, int radius) : base(x, y)
        {
            this.radius = radius;
        }

        public sealed override void Draw()
        {
            Console.WriteLine($"Draw circles in X: {x}, Y: {y}, and radius {radius}");
        }
    }

}