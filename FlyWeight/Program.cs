namespace Flyweight
{

    public  class TreeType // HEAVY WEIGHT OBJECT, CREATION CONTROLLED BY FACTORY, HOLDS INTRINSIC PROPERTY
    {
        public string IntrisicPropertyTexture { get; set; }
        public TreeType(string intrisicPropertyTexture)
        {
            IntrisicPropertyTexture = intrisicPropertyTexture;
        }   
    }

    public static class TreeFactory
    {
        public static List<TreeType> TreeTypeList { get; set; } = new List<TreeType>();
        public static TreeType GetTree(string texture)
        {
            if(TreeTypeList.Any(x=> x.IntrisicPropertyTexture == texture)){

                return TreeTypeList.FirstOrDefault(x => x.IntrisicPropertyTexture == texture);
            }
            else
            {
                var tree = new TreeType(texture);
                TreeTypeList.Add(tree);
                return tree;
            }
        }
    }

    public class Tree // LIGHT WEIGHT OBJECT, EXTRINSIC PROPERTY, HOLDS A REFERENCE OVER HEAVY OBJECT
    {
        public int x, y;

        public TreeType Type { get; }

        public Tree(int x, int y, TreeType treeType)
        {
            this.x = x;
            this.y = y;
            this.Type = treeType;
        }
    }

    public class Forest
    {
        public List<Tree> Trees = new List<Tree>();
        public void PlantTree(int x, int y, string texture)
        {
            var treeType = TreeFactory.GetTree(texture);// GET OR CREATE A HEAVY OBJECT
            var tree = new Tree(x,y, treeType); // INITIALIZA LIGHT OBJECT WITH REFERENCE TO HEAVY OBJECT
            Trees.Add(tree);
        }
    }


}