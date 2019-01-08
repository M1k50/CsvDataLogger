using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsvDataLogger
{
    internal class CsvFileHandler : ICsvFileHandler
    {
        private ICsvFileHandler _csvFileHandler;
        public CsvFileHandler(ICsvFileHandler fileHandler)
        {
            _csvFileHandler = fileHandler;
        }

        public string FileName { get => _csvFileHandler.FileName; set => _csvFileHandler.FileName = value; }
        public string Directory { get => _csvFileHandler.Directory; set => _csvFileHandler.Directory = value; }

        public void CloseFile()
        {
            throw new NotImplementedException();
        }
    }
}
