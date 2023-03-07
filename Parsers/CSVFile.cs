using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace ThingNetAU.Parsers
{
    public class CSVFile : IDisposable
    {
        DataTable std = null;
        private bool disposedValue;

        public CSVFile(string filename, Boolean Headers = true, string TextQualifier = "\"")
        {
            string file = File.ReadAllText(filename);
            std = new DataTable();
            //      std.Tables.Add();
            Boolean HeaderComplete = false;
            Boolean HeaderDone = false;
            string[] data = null;
            foreach (var line in file.SplitToLines())
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    if (HeaderDone) HeaderComplete = true;
                    int datapos = 0;
                    if (!Headers && !HeaderComplete)
                    {
                        for (int i = 1; i <= line.SplitToRows().Count(); i++)
                        {
                            std.Columns.Add("COL" + i);
                        }
                        HeaderComplete = true;
                        HeaderDone = true;

                    }
                    data = new string[std.Columns.Count];

                    foreach (var row in line.SplitToRows())
                    {

                        if (!HeaderComplete)
                        {

                            std.Columns.Add(row);
                            HeaderDone = true;
                        }
                        else
                        {
                            if (datapos < data.Length)
                                data[datapos++] = row;
                        }
                    }

                    if (HeaderComplete)
                        std.Rows.Add(data);
                }
            }
        }
        public DataTable GetDataTable { get { return std; } }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    std.Clear();
                    std.Dispose();
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~CSVFile()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }

}
