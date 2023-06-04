using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingNetAU.Parsers
{
    public class Configuration
    {
        /// <summary>
        /// File contains headers
        /// </summary>
        public bool Headers { get;  set; }
        /// <summary>
        /// Number of rows to ignore before the first row or header.
        /// </summary>
        public int IgnoreRows { get;  set; }
        public char Delimeter { get; set; }
        public char TextQualifier { get; set; }
        public Configuration()
        {
            IgnoreRows = 0;
            Delimeter = ',';
            TextQualifier = '"';
        }
        
    }
}
