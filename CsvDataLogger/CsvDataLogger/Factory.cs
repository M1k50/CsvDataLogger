using System.IO;
using System.IO.Abstractions;
using CsvHelper;
using FileNameHelper;

namespace CsvDataLogger
{
    internal static class Factory
    {
        internal static ICsvDataWriter GetDataWriter(string fullFileName, string directory ="")
        {
            ICsvDataWriter output = new CsvDataWriter(fullFileName,directory);
            return output;
        }

        internal static IFileNameHelper GetFileNameHeper(string fullFilename, string directory,IFileSystem filesystem)
        {
            IFileNameHelper output = new FileNameHelper.FileNameHelper(fullFilename: fullFilename, directory: directory,fileSystem: filesystem);
            return output;
        }

        internal static CsvWriter GetCswHelperWriter(StreamWriter streamWriter)
        {
            CsvWriter output = new CsvWriter(streamWriter);
            return output;
        }
    }
}
