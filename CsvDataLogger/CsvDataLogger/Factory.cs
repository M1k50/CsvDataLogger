using System;
using System.IO;
using System.IO.Abstractions;
using CsvHelper;
using FileNameHelper;

namespace CsvDataLogger
{
    public static class Factory
    {
        public static ICsvDataWriter GetDataWriter(string fullFileName, string directory ="",bool createMissingDirectory=false, IFileSystem fileSystem = null)
        {
            ICsvDataWriter output = new CsvDataWriter(fullFileName,directory,createMissingDirectory: createMissingDirectory,filesystem: fileSystem);
            return output;
        }

        public static IFileNameHelper GetFileNameHeper(string fullFilename, string directory,bool createMissingDirectory = false, IFileSystem filesystem=null)
        {
            IFileNameHelper output = new FileNameHelper.FileNameHelper(fullFilename: fullFilename, directory: directory,createMissingDirectory: createMissingDirectory,fileSystem: filesystem);
            return output;
        }

        public static ICsvTable GetCsvDataTable(string indexColumnName="index")
        {
            ICsvTable output = new CsvTable(indexColumnName);
            return output;
        }

        public static CsvWriter GetCswHelperWriter(StreamWriter streamWriter)
        {
            CsvWriter output = new CsvWriter(streamWriter);
            return output;
        }
    }
}
