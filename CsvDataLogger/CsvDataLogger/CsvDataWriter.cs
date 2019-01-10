using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Runtime.InteropServices;
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
        private CsvWriter _csvHelperWriter;
        private string _directory;
        private string _filepath;
        private string _fullFileName;
        private IFileNameHelper _fileNameHelper;
        public CsvDataWriter(string fullFilename, string directory = "./", IFileSystem filesystem = null)
        {
            _fileNameHelper = Factory.GetFileNameHeper(fullFilename, directory, filesystem);
            
            StreamWriter streamWriter = new StreamWriter(_fileNameHelper.Filepath,true);
            _csvHelperWriter = Factory.GetCswHelperWriter(streamWriter);
        }
        public string Directory
        {
            get => _directory;
            //set
            //{
            //    _fileNameHelper.Directory = value;
            //    _directory = _fileNameHelper.Directory;
            //}
        }

        public string Filepath
        {
            get => _filepath;
            //set
            //{
            //    _fileNameHelper.Filepath = value;
            //    _filepath = _fileNameHelper.Filepath;
            //}
        }

        public string FullFileName
        {
            get => _fullFileName;
            //set
            //{
            //    _fileNameHelper.FullFilename = value;
            //    _fullFileName = _fileNameHelper.FullFilename;
            //}
        }
        public void CloseFile()
        {

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void LogData(int index, string header, string entry)
        {

        }
    }
}