namespace CsvDataLogger
{
    public class CsvDataReceiver : ICsvDataReceiver
    {
        private ICsvDataLogger _csvWriter;

        public CsvDataReceiver(CsvWriter csvWriter)
        {
            _csvWriter = csvWriter;
        }

        public void LogData(int index, string header, int entry)
        {
            _csvWriter.LogData(index,header,entry.ToString());
        }

        public void LogData(int index, string header, double entry)
        {
            _csvWriter.LogData(index, header, entry.ToString());
        }

        public void LogData(int index, string header, long entry)
        {
            _csvWriter.LogData(index, header, entry.ToString());
        }

        public void LogData(int index, string header, bool entry)
        {
            _csvWriter.LogData(index, header, entry.ToString());
        }

        public void LogData(int index, string header, string entry)
        {
            _csvWriter.LogData(index, header, entry);
        }
    }
}