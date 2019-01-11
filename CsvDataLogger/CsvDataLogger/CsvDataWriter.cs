using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Abstractions;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using CsvHelper;
using FileNameHelper;

namespace CsvDataLogger
{
    /// <summary>
    /// Sorts and stores received data until writen to output file.
    /// </summary>
    internal class CsvDataWriter : IDisposable, ICsvDataWriter
    {
        private StreamWriter _streamWriter;

        private CsvWriter _csvHelperWriter;
        private IFileSystem _fileSystem;
        private string _directory;
        private string _filepath;
        private string _fullFileName;
        private string _delimiter;
        private IFileNameHelper _fileNameHelper;
        public CsvDataWriter(string fullFilename, string directory = "./", string delimiter=",", bool createMissingDirectory = false, IFileSystem filesystem = null)
        {
            SetupFileNameHelper(fullFilename, directory, createMissingDirectory, filesystem);

            SetupCsvHelperWriter();

        }

        private void SetupFileNameHelper(string fullFilename, string directory, bool createMissingDirectory, IFileSystem filesystem)
        {
            SetFileSystem(filesystem);
            _fileNameHelper = Factory.GetFileNameHeper(fullFilename, directory, createMissingDirectory, _fileSystem);
        }

        private void SetupCsvHelperWriter()
        {
            _streamWriter = new StreamWriter(Filepath);
                
            _csvHelperWriter = Factory.GetCswHelperWriter(_streamWriter);
            _csvHelperWriter.Configuration.Delimiter = _delimiter;

        }

        private void SetFileSystem(IFileSystem fileSystem)
        {
            if (fileSystem == null)
            {
                _fileSystem = new FileSystem();
            }
            else
            {
                _fileSystem = fileSystem;
            }
        }

        public string Directory
        {
            get => _fileNameHelper.Directory;
            set => _fileNameHelper.Directory = value;

        }

        public string Filepath
        {
            get => _fileNameHelper.Filepath;
            set => _fileNameHelper.Filepath = value;
        }

        public string FullFileName
        {
            get => _fileNameHelper.FullFilename;
            set => _fileNameHelper.FullFilename = value;
        }
        public void CloseFile()
        {

        }

        public void Dispose()
        {
            _streamWriter.Dispose();
            _csvHelperWriter.Dispose();
            _fileSystem = null;
        }

        public void LogData(int index, string header, string entry)
        {
            string line = $"Header1{Environment.NewLine}Col1Row1";
            _streamWriter.WriteLine(line);
            _streamWriter.Flush();
            //_csvHelperWriter.WriteField<string>(line);
            //_csvHelperWriter.NextRecord();

            
        }
    }
}