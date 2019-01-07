using System;
using System.IO;
using Xunit;
using CsvDataLogger;
using Xunit.Sdk;
using Moq;

namespace CsvDataLogger.Tests
{
    public class CsvDataLoggerTests
    {
        [Fact]
        public void SetFilname_ShouldReturnFilename()
        {
            //Arange
            string expFilename = "TestFilename";
            ICsvDataLogger Logger = new CsvWriter(expFilename);

            //Act
            string actFilename = Logger.FileName;

            //Assert
            Assert.Equal(expFilename, actFilename);
        }

        [Theory]
        [InlineData("Test","./")]
        [InlineData("Test","C:/")]
        public void SetDirectory_ShouldReturnDirectory(string name, string expected )
        {
            //Arange
            ICsvDataLogger Logger = new CsvWriter(name, expected);

            //Act
            string actDirectory = Logger.WorkingDirectory;

            //Assert
            Assert.Equal(expected, actDirectory);

        }

        [Fact]
        public void SetWrongDirectory_ShouldThrowArgumentException()
        {
            //Arange
            string filename = "test";
            string outputDir = "";

            //Assert
            ICsvDataLogger CsvDataLogger;
            Assert.Throws<ArgumentException>(()=> CsvDataLogger = new CsvWriter(filename,outputDir));

        }
    }
}
