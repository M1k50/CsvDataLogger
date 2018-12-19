using System;

namespace CsvDataLogger
{
    class CsvEntry : ICsvEntry
    {
        public int Index { get; }
        public string Data { get;  }

        public CsvEntry(int index, string data)
        {
            Index = index;
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }
    }
}
