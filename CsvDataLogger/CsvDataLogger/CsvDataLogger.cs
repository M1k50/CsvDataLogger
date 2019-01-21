﻿using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvDataLogger
{
    public class CsvDataLogger : ICsvDataLogger
    {
        private ICsvDataWriter _csvDataWriter;
        private ICsvTable _csvTable;

        public CsvDataLogger(string fullFilename, string directory = null,bool createMissingDirectory = false ,IFileSystem fileSystem=null,string indexColumnName = "index")
        {
            _csvDataWriter = Factory.GetDataWriter(fullFilename,directory,createMissingDirectory,fileSystem);
            _csvTable = Factory.GetCsvDataTable(indexColumnName);
        }
                
        public string Directory { get => _csvDataWriter.Directory; set => _csvDataWriter.Directory=value; }
        public string Filepath { get => _csvDataWriter.Filepath; set => _csvDataWriter.Filepath=value; }
        public string FullFileName { get => _csvDataWriter.FullFileName; set => _csvDataWriter.FullFileName=value; }

        public void CloseFile()
        {
            //_csvDataWriter.CloseFile();
        }

        public void Dispose()
        {
            _csvDataWriter.FlushFilestream();
            _csvDataWriter.Dispose();
        }

        public void FlushBuffer()
        {
            _csvDataWriter.WriteDataTable(_csvTable.Table);
            _csvDataWriter.FlushFilestream();
        }

        public void LogData(int index, string column, int entry)
        {
            LogData(index, column, entry.ToString());
        }

        public void LogData(int index, string column, double entry)
        {
            LogData(index, column, entry.ToString());
        }
        public void LogData(int index, string column, float entry)
        {
            LogData(index, column, entry.ToString());
        }

        public void LogData(int index, string column, long entry)
        {
            LogData(index, column, entry.ToString());
        }

        public void LogData(int index, string column, bool entry)
        {
            LogData(index, column, entry.ToString());
        }

        public void LogData(int index, string column, string entry)
        {
            _csvTable.WriteCell(index, column, entry);
        }
    }
}
