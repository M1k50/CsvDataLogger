namespace CsvDataLogger
{
    internal static class CsvFactory
    {
        public static ICsvColumn GetNewCsvColumn(string header)
        {
            ICsvColumn newColumn = new CsvColumn(header);
            return newColumn;
        }

        public static ICsvDataReceiver GetNewCsvDataReceiver(CsvDataLogger csvDataLogger)
        {
            ICsvDataReceiver newReceiver = new CsvDataReceiver(csvDataLogger);
            return newReceiver;
        }
    }
}
