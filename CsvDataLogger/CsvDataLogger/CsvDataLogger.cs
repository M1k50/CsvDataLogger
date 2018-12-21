using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;

namespace CsvDataLogger
{
    public class CsvDataLogger : IDisposable, ICsvDataLogger
    {
        private string _workingDirectory = "./";
        public string WorkingDirectory
        {
            get { return _workingDirectory; }
            set {
                bool dirExists = Directory.Exists(value);
                if (dirExists)
                {
                    _workingDirectory = value;
                }
                else
                {
                    throw new ArgumentException("Specified Workingdirectory does not exist");
                }
            }
        }


        public string FileName { get; private set; }

        private List<ICsvColumn> Columns=new List<ICsvColumn>();
        //ToDo: Relation DataLogger to Receiver needs to be inverted. DataLogger Interface needs to be Receiver interface.
        private readonly ICsvDataReceiver _csvDataReceiver;

        public CsvDataLogger(string fileName,string workingDirectory = "./")
        {
            bool dirExists = Directory.Exists(workingDirectory);
            if (dirExists)
            {
                WorkingDirectory = workingDirectory;
            }
            else
            {
                throw new ArgumentException("Specified Workingdirectory does not exist");
            }

            FileName = fileName;
            _csvDataReceiver = CsvFactory.GetNewCsvDataReceiver(this);
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


        private string ValidateFileName(string filename, string workingDirectory)
        {
            //ToDo: Check Filename. If used, add Counter until free Name is found.

            string output = filename;
            return output;
        }

        private string ValidateWorkingDirectory(string workingDirectory)
        {
            //ToDo: Check Working Directory. If not present, create it.

            string output = workingDirectory;
            return output;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}