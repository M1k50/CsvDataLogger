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
        private CsvWriter _csvHelperWriter;
        private string _delimiter;
        private string _directory;
        private IFileNameHelper _fileNameHelper;
        private string _filepath;
        private IFileSystem _fileSystem;
        private string _fullFileName;
        private StreamWriter _streamWriter;

        public CsvDataWriter(string fullFilename, string directory = "./", string delimiter=",", bool createMissingDirectory = false, IFileSystem filesystem = null)
        {
            SetupFileNameHelper(fullFilename, directory, createMissingDirectory, filesystem);

            //_fullFileName = _fileNameHelper.FullFilename;
            //_directory = _fileNameHelper.Directory;
            _filepath = _fileNameHelper.Filepath;

            SetupCsvHelperWriter();

        }

        public string Directory
        {
            get => _directory;
            set
            {
                _fileNameHelper.Directory = value;
                _directory = _fileNameHelper.Directory;
            }
        }

        public string Filepath
        {
            get => _filepath;
            set
            {
                _fileNameHelper.Filepath = value;
                _filepath = _fileNameHelper.Filepath;
            }
        }

        public string FullFileName
        {
            get => _fullFileName;
            set
            {
                _fileNameHelper.FullFilename = value;
                _fullFileName = _fileNameHelper.FullFilename;
            }
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

        private void SetupCsvHelperWriter()
        {
            _streamWriter = _fileSystem.File.CreateText(Filepath);
            _csvHelperWriter = Factory.GetCswHelperWriter(_streamWriter);
            _csvHelperWriter.Configuration.Delimiter = _delimiter;

        }

        private void SetupFileNameHelper(string fullFilename, string directory, bool createMissingDirectory, IFileSystem filesystem)
        {
            SetFileSystem(filesystem);
            _fileNameHelper = Factory.GetFileNameHeper(fullFilename, directory, createMissingDirectory, _fileSystem);
        }
    }
}