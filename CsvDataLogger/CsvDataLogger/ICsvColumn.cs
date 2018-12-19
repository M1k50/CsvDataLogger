using System.Collections.Generic;

namespace CsvDataLogger
{
    interface ICsvColumn
    {
        List<CsvEntry> Entries { get; }
        string Header { get; }

        void AddEntry(int index, string data);
    }
}