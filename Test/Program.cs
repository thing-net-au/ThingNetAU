using System.Data;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ThingNetAU.Parsers.CSVFile p = new ThingNetAU.Parsers.CSVFile("C:\\tmp\\222820.07M.csv", false);
            DataTable g = p.GetDataTable;
            Console.WriteLine("Hello, World!");
        }
    }
}