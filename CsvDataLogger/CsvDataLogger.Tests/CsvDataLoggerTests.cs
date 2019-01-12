using System;
using System.IO;
using Xunit;
using CsvDataLogger;
using Xunit.Sdk;
using System.IO;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;


namespace CsvDataLogger.Tests
{
    public class CsvDataLoggerTests
    {
        [Fact]
        public void LogData_ValidData_ShouldCreateFile()
        {
            //Arrange
            string fullFilename = "test.csv";
            string directory = @"C:\temp\";
            MockFileSystem fileSystem = new MockFileSystem();
            CsvDataLogger logger = new CsvDataLogger(fullFilename,directory,true,fileSystem);

            string header1 = "1";
            int row1 = 1;
            string entry1 = $"Cell_{header1}{row1}";
            string expectedFileText = $"Cell_{header1}{entry1}{Environment.NewLine}";

            //Act
            logger.LogData(row1, header1, entry1);
            MockFileData mockFile = fileSystem.GetFile(logger.Filepath);
            string actualFileText = mockFile.TextContents;

            //Assert
            Assert.Equal(expectedFileText, actualFileText);
            logger.Dispose();

        }

        //[Fact]
        //public void SetFilname_ShouldReturnFilename()
        //{
        //    //Arange
        //    string expFilename = "TestFilename";
        //    ICsvDataLogger logger = new CsvDataLogger();

        //    //Act
        //    string actFilename = logger.FullFileName;

        //    //Assert
        //    Assert.Equal(expFilename, actFilename);
        //}

        //[Theory]
        //[InlineData("Test", "./")]
        //[InlineData("Test", "C:/")]
        //public void SetDirectory_ShouldReturnDirectory(string name, string expected)
        //{
        //    //Arange
        //    ICsvDataLogger logger = new CsvDataLogger();

        //    //Act
        //    string actDirectory = logger.Directory;

        //    //Assert
        //    Assert.Equal(expected, actDirectory);

        //}

        //[Fact]
        //public void SetWrongDirectory_ShouldThrowArgumentException()
        //{
        //    //Arange
        //    string filename = "test";
        //    string outputDir = "";

        //    //Assert
        //    ICsvDataLogger logger;
        //    Assert.Throws<ArgumentException>(() => logger = new CsvDataLogger());

        //}
    }
}
