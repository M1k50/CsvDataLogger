using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;
using CsvHelper;
using FileNameHelper;

namespace CsvDataLogger
{
    public class CsvWriter : IDisposable, ICsvDataLogger
    {
        //ToDo: Relation DataLogger to Receiver needs to be inverted. DataLogger Interface needs to be Receiver interface.
        private readonly ICsvDataReceiver _csvDataReceiver;

        private CsvHelper.CsvWriter _csvWriter;
        private FileHelper.FileHelper _fileHelper = new FileHelper.FileHelper();
        private StreamWriter _streamWriter;
        private string _workingDirectory = "./";
        private List<ICsvColumn> Columns = new List<ICsvColumn>();
        public CsvWriter(string fileName, string workingDirectory = "./")
        {
            WorkingDirectory = workingDirectory;
            FileName = fileName;
            _csvDataReceiver = CsvFactory.GetNewCsvDataReceiver(this);


            _streamWriter =new StreamWriter();
        }

        public string FileName { get; private set; }

        public int FullFilepath
        {
            get
            {
                string output = string.Format("{0}{1}.csv", _workingDirectory, FileName)
                return myVar;
            }
        }

        public string WorkingDirectory
        {
            get => _workingDirectory;
            set => _workingDirectory = _fileHelper.GetDirectory(value, true);
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

        public void WriteAndClose()
        {
            
        }

        private void AddColumn(string header)
        {
            ICsvColumn newColumn = CsvFactory.GetNewCsvColumn(header);
            Columns.Add(newColumn);
        }


        private string GetFilepath(string filename, string workingDirectory)
        {
            //ToDo: Check Filename. If used, add Counter until free Name is found.
            FileNameHepler helper = new FileNameHepler(filename,workingDirectory);
            string output = helper.GetFilepath;

            return output;
        }

        private string ValidateWorkingDirectory(string workingDirectory)
        {
            //ToDo: Check Working Directory. If not present, create it.

            string output = workingDirectory;
            return output;
        }
    }
}