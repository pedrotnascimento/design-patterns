namespace Adapter
{
    public interface IBusinessWithGuid
    {
        string GetGUID();
    }

    public static class GUIDGeneratorService
    {
        public static Guid GetGUID()
        {
            return Guid.NewGuid();
        }
    }

    public class AdapterGUIDToString : IBusinessWithGuid
    {
        public string GetGUID()
        {
            Guid myGuid = GUIDGeneratorService.GetGUID();
            string myString = myGuid.ToString();
            return myString;
        }
    }


    public class WorkWithStringsClass
    {
        public void BussinessLogicWithString(string myString)
        {
            AdapterGUIDToString? adapter = new AdapterGUIDToString();

            string myGuid = adapter.GetGUID();
            Console.WriteLine($"This string:: {myString} has that GUID {myGuid}");
        }
    }

    public class Program
    {
        static void Main()
        {
            var stringWork = new WorkWithStringsClass();
            stringWork.BussinessLogicWithString("What up!!");
        }
    }
}