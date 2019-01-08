namespace CsvDataLogger
{
    public interface ICsvFileHandler
    {
        string FileName { get; set; }
        string Directory { get; set; }

        void CloseFile();

    }
}