using System;
using Xunit;
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

            string column = "1";
            int row = 1;
            string entry1 = $"Cell_{row}{column}";
            string expectedFileText = $"{column}{Environment.NewLine}Cell_{row}{column}{Environment.NewLine}";

            //Act
            logger.LogData(row, column, entry1);
            MockFileData mockFile = fileSystem.GetFile(logger.Filepath);
            string actualFileText = mockFile.TextContents;

            //Assert
            Assert.Equal(expectedFileText, actualFileText);
            logger.Dispose();

        }

        [Theory]
        [InlineData(1, "1", "Cell1Row1")]
        [InlineData(3, "3", "Cell3Row3")]
        [InlineData(1000, "10", "Cell10Row1000")]


        public void CsvTable_ShouldReturnWrittenValue(int row, string column, string data)
        {
            //Arange
            ICsvTable table = new CsvTable();

            //Act
            table.WriteCell(row,column, data);
            string expectedValue = data;
            string actualValue = table.ReadCell( row,column);

            //Assert
            Assert.Equal(expectedValue, actualValue);
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
