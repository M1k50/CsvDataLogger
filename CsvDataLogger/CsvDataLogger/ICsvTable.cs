using System.Data;

namespace CsvDataLogger
{
    public interface ICsvTable
    {
        DataTable Table { get; }

        void WriteCell(int row, string column, string entry);
        string ReadCell(int row, string column);
    }
}