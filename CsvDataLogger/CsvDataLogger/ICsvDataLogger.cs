namespace CsvDataLogger
{
    public interface ICsvDataLogger
    {
        string FileName { get; }
        string WorkingDirectory { get; set; }

        void Dispose();
        void LogData(int index, string header, string entry);
        void WriteAndClose();
    }
}