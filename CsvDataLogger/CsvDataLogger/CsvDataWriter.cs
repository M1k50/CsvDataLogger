using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;
using CsvHelper;
using FileNameHelper;

namespace CsvDataLogger
{
    public class CsvDataWriter : IDisposable, ICsvFileHandler
    {
        //ToDo: Relation DataLogger to Receiver needs to be inverted. DataLogger Interface needs to be Receiver interface.
        private readonly ICsvDataReceiver _csvDataReceiver;

        private IFileNameHelper _fileNameHelper;
        private StreamWriter _streamWriter;
        private CsvWriter _csvWriter;

        public CsvDataWriter(string fileName, string workingDirectory = "./")
        {
            Directory = workingDirectory;
            FileName = fileName;
            _csvDataReceiver = CsvFactory.GetNewCsvDataReceiver(this);


            //_streamWriter =new StreamWriter();
        }

        public string FileName { get; set; }

        public string Directory
        {
            get => _cs;
            set => _workingDirectory = _fileNameHelper.GetDirectory(value, true);
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void LogData(int index, string header, string entry)
        {
            // Find Column or Create new
            // Add Data to Column
        }

        public void CloseFile()
        {
            
        }

    }
}