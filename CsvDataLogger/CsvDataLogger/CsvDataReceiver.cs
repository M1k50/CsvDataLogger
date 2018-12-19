namespace CsvDataLogger
{
    public class CsvDataReceiver : ICsvDataReceiver
    {
        private ICsvDataLogger _csvDataLogger;

        public CsvDataReceiver(CsvDataLogger csvDataLogger)
        {
            _csvDataLogger = csvDataLogger;
        }

        public void LogData(int index, string header, int entry)
        {
            _csvDataLogger.LogData(index,header,entry.ToString());
        }

        public void LogData(int index, string header, double entry)
        {
            _csvDataLogger.LogData(index, header, entry.ToString());
        }

        public void LogData(int index, string header, long entry)
        {
            _csvDataLogger.LogData(index, header, entry.ToString());
        }

        public void LogData(int index, string header, bool entry)
        {
            _csvDataLogger.LogData(index, header, entry.ToString());
        }

        public void LogData(int index, string header, string entry)
        {
            _csvDataLogger.LogData(index, header, entry);
        }
    }
}