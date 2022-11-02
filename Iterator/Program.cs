public interface Iterator<T>
{
    T Next();
    T Current();
    bool HasMore();
    void Reset();
}

public class ZigZag : Iterator<int>
{
    private List<int> list;
    private bool goReverse = false;
    private int index = 0;

    public ZigZag(List<int> ints)
    {
        this.list = ints;
    }

    public int Current()
    {
        return !goReverse ? list[index] : list[list.Count - index - 1]; ;
    }

    public bool HasMore()
    {
        if(index > list.Count - index-1)
        {
            return false;   
        }

        if(index >= list.Count - index -1 && goReverse)
        {
            return false;
        }
        return true;
    }

    public int Next()
    {
        var elem = Current();
        goReverse = !goReverse;
        if (goReverse == false)
        {
            index++;
        }
        return elem;
    }

    public void Reset()
    {
        index=0;
        goReverse = false;  
    }

}

static public class Program
{
    static public void Main()
    {
        Console.WriteLine("Zig zag till 9 (odd)");
        ZigZag zigZag = new ZigZag(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        while (zigZag.HasMore())
        {
            var elem = zigZag.Next();
            Console.WriteLine(elem);

        }
        Console.WriteLine("Zig zag till 10(even)");
        ZigZag zigZag2 = new ZigZag(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9,10 });
        while (zigZag2.HasMore())
        {
            var elem = zigZag2.Next();
            Console.WriteLine(elem);

        }
    }
}

