using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvDataLogger
{
    class CsvTable
    {

        public int Row { get; set; }
        public int Column { get; set; }
        public List<CsvEntry> Entries { get; set; }
    }
}
