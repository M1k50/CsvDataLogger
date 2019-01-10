namespace CsvDataLogger
{
    public interface ICsvDataLogger
    {
        string Directory { get; set; }
        string Filepath { get; set; }
        string FullFileName { get; set; }

        void CloseFile();
        void Dispose();
        void LogData(int index, string header, bool entry);
        void LogData(int index, string header, double entry);
        void LogData(int index, string header, int entry);
        void LogData(int index, string header, long entry);
        void LogData(int index, string header, string entry);
    }
}