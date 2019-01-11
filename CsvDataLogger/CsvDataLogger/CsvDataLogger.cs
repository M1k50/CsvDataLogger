using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvDataLogger
{
    public class CsvDataLogger : ICsvDataWriter, ICsvDataLogger
    {
        private ICsvDataWriter _csvDataWriter;

        public CsvDataLogger(string fullFilename, string directory = null,bool createMissingDirectory = false ,IFileSystem fileSystem=null)
        {
            _csvDataWriter = Factory.GetDataWriter(fullFilename,directory,createMissingDirectory,fileSystem);
            //Filepath = _csvDataWriter.Filepath;
                
        }
                
        public string Directory { get => _csvDataWriter.Directory; set => _csvDataWriter.Directory=value; }
        public string Filepath { get => _csvDataWriter.Filepath; set => _csvDataWriter.Filepath=value; }
        public string FullFileName { get => _csvDataWriter.FullFileName; set => _csvDataWriter.FullFileName=value; }

        public void CloseFile()
        {
            _csvDataWriter.CloseFile();
        }

        public void Dispose()
        {
            _csvDataWriter.Dispose();
        }

        public void LogData(int index, string header, int entry)
        {
            _csvDataWriter.LogData(index, header, entry.ToString());
        }

        public void LogData(int index, string header, double entry)
        {
            _csvDataWriter.LogData(index, header, entry.ToString());
        }

        public void LogData(int index, string header, long entry)
        {
            _csvDataWriter.LogData(index, header, entry.ToString());
        }

        public void LogData(int index, string header, bool entry)
        {
            _csvDataWriter.LogData(index, header, entry.ToString());
        }

        public void LogData(int index, string header, string entry)
        {
            _csvDataWriter.LogData(index, header, entry);
        }
    }
}
