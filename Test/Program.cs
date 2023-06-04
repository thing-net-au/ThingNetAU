using System.Data;
using ThingNetAU.Parsers;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Configuration c = new Configuration();
            c.IgnoreRows = 1;
            c.Headers = true;

            ThingNetAU.Parsers.CSVFile p = new ThingNetAU.Parsers.CSVFile("C:\\tmp\\coles.csv",c);
            DataTable g = p.GetDataTable;
            Console.WriteLine("Hello, World!");
        }
    }
}