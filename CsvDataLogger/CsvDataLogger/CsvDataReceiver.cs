namespace CsvDataLogger
{
    public class CsvDataReceiver : ICsvDataReceiver
    {
        private ICsvDataReceiver _csvTable;

        public CsvDataReceiver(ICsvDataReceiver CsvTable)
        {
            _csvTable = CsvTable;
        }

        public void LogData(int index, string header, int entry)
        {
            _csvTable.LogData(index,header, entry.ToString());
        }

        public void LogData(int index, string header, double entry)
        {
            _csvTable.LogData(index, header, entry.ToString());
        }

        public void LogData(int index, string header, long entry)
        {
            _csvTable.LogData(index, header, entry.ToString());
        }

        public void LogData(int index, string header, bool entry)
        {
            _csvTable.LogData(index, header, entry.ToString());
        }

        public void LogData(int index, string header, string entry)
        {
            _csvTable.LogData(index, header, entry);
        }
    }
}