using System.Data;

namespace CsvDataLogger
{
    public interface ICsvTable
    {
        DataTable Table { get; }

        void WriteCell(int index, string column, string entry);
        string ReadCell(int index, string column);
    }
}