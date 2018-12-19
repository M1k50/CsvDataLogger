using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace CsvDataLogger
{
    internal class CsvColumn : ICsvColumn
    {
        public string Header { get; private set; }
        public List<CsvEntry> Entries { get; private set; }

        public CsvColumn(string header)
        {
            Header = header ?? throw new ArgumentNullException(nameof(header));
        }

        public void AddEntry(int index, string data)
        {
            
        }
    }
}
