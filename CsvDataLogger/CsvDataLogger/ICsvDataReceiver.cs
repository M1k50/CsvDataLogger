namespace CsvDataLogger
{
    public interface ICsvDataReceiver
    {
        void LogData(int index, string header, string entry);
        void LogData(int index, string header, bool entry);
        void LogData(int index, string header, double entry);
        void LogData(int index, string header, int entry);
        void LogData(int index, string header, long entry);

    }
}