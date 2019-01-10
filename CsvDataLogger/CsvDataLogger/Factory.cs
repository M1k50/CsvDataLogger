using System.IO;
using System.IO.Abstractions;
using CsvHelper;
using FileNameHelper;

namespace CsvDataLogger
{
    internal static class Factory
    {
        internal static ICsvDataWriter GetDataWriter(string fullFileName, string directory ="",bool createMissingDirectory=false, IFileSystem fileSystem = null)
        {
            ICsvDataWriter output = new CsvDataWriter(fullFileName,directory,createMissingDirectory: createMissingDirectory,filesystem: fileSystem);
            return output;
        }

        internal static IFileNameHelper GetFileNameHeper(string fullFilename, string directory,bool createMissingDirectory = false, IFileSystem filesystem=null)
        {
            IFileNameHelper output = new FileNameHelper.FileNameHelper(fullFilename: fullFilename, directory: directory,createMissingDirectory: createMissingDirectory,fileSystem: filesystem);
            return output;
        }

        internal static CsvWriter GetCswHelperWriter(StreamWriter streamWriter)
        {
            CsvWriter output = new CsvWriter(streamWriter);
            return output;
        }
    }
}
