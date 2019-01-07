namespace CsvDataLogger
{
    internal static class CsvFactory
    {
        public static ICsvColumn GetNewCsvColumn(string header)
        {
            ICsvColumn newColumn = new CsvColumn(header);
            return newColumn;
        }

        public static ICsvDataReceiver GetNewCsvDataReceiver(CsvWriter csvWriter)
        {
            ICsvDataReceiver newReceiver = new CsvDataReceiver(csvWriter);
            return newReceiver;
        }
    }
}
