namespace CsvDataLogger
{
    public interface ICsvDataLogger
    {
        /// <summary>
        /// The output directory for the .csv file.
        /// </summary>
        string Directory { get; set; }
        /// <summary>
        /// The absolute filepath to the .csv file.
        /// </summary>
        string Filepath { get; set; }
        /// <summary>
        /// The .csv. filename including the extension.
        /// </summary>
        string FullFileName { get; set; }
        /// <summary>
        /// Closes the filestream to the logfile and disposes the datalogger including helper classes.
        /// </summary>
        void Dispose();
        /// <summary>
        /// Write data to the databuffer.
        /// </summary>
        /// <param name="index">The csv tables index, or row to write to</param>
        /// <param name="column">The column name to write to</param>
        /// <param name="entry">The data to be writen to the cell</param>
        void LogData(int index, string column, bool entry);
        /// <summary>
        /// Write data to the databuffer.
        /// </summary>
        /// <param name="index">The csv tables index, or row to write to</param>
        /// <param name="column">The column name to write to</param>
        /// <param name="entry">The data to be writen to the cell</param>
        void LogData(int index, string column, double entry);
        /// <summary>
        /// Write data to the databuffer.
        /// </summary>
        /// <param name="index">The csv tables index, or row to write to</param>
        /// <param name="column">The column name to write to</param>
        /// <param name="entry">The data to be writen to the cell</param>
        void LogData(int index, string column, float entry);
        /// <summary>
        /// Write data to the databuffer.
        /// </summary>
        /// <param name="index">The csv tables index, or row to write to</param>
        /// <param name="column">The column name to write to</param>
        /// <param name="entry">The data to be writen to the cell</param>
        void LogData(int index, string column, int entry);
        /// <summary>
        /// Write data to the databuffer.
        /// </summary>
        /// <param name="index">The csv tables index, or row to write to</param>
        /// <param name="column">The column name to write to</param>
        /// <param name="entry">The data to be writen to the cell</param>
        void LogData(int index, string column, long entry);
        /// <summary>
        /// Write data to the databuffer.
        /// </summary>
        /// <param name="index">The csv tables index, or row to write to</param>
        /// <param name="column">The column name to write to</param>
        /// <param name="entry">The data to be writen to the cell</param>
        void LogData(int index, string column, string entry);
        /// <summary>
        /// Write the accumulated data to the .csv file.
        /// </summary>
        void FlushBuffer();
    }
}