namespace CsvDataLogger
{
    public interface ICsvDataLogger
    {
        string Directory { get; set; }
        string Filepath { get; set; }
        string FullFileName { get; set; }

        void CloseFile();
        void Dispose();
        void LogData(int row, string column, bool entry);
        void LogData(int row, string column, double entry);
        void LogData(int row, string column, int entry);
        void LogData(int row, string column, long entry);
        void LogData(int row, string column, string entry);
    }
}