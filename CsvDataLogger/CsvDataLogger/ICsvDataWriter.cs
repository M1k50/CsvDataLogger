﻿namespace CsvDataLogger
{
    public interface ICsvDataWriter
    {
        string Directory { get; set; }
        string Filepath { get; set; }
        string FullFileName { get; set; }

        void CloseFile();
        void Dispose();
        void LogData(int index, string header, string entry);
    }
}