namespace CsvDataLogger
{
    interface ICsvEntry
    {
        /// <summary>
        /// Data to be stored in the final CSV Cell.
        /// </summary>
        string Data { get; }

        /// <summary>
        /// Line Index 
        /// </summary>
        int Index { get; }
    }
}