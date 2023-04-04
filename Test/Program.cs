using System.Data;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ThingNetAU.Parsers.CSVFile p = new ThingNetAU.Parsers.CSVFile("C:\\tmp\\Query Output.xls",3,'\t', true);
            DataTable g = p.GetDataTable;
            Console.WriteLine("Hello, World!");
        }
    }
}