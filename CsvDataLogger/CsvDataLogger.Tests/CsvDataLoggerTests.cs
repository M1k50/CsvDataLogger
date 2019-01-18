using System;
using Xunit;
using System.IO.Abstractions.TestingHelpers;
using System.Data;
using System.Collections.Generic;

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


        public void CsvTable_ShouldReturnSingleWrittenValue(int row, string column, string data)
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

        [Fact]
        public void CsvTable_ShouldReturnWrittenTableValues()
        {
            //Arange
            int maxIndex = 10;
            int maxColumns = 20;
            ICsvTable table = new CsvTable();

            int r1 = 1;
            string c1 = "1";
            string expected1 = "1";
            table.WriteCell(r1, c1, expected1);

            int r2 = 24308;
            string c2 = "Header";
            string expected2 = "TestEntry";
            table.WriteCell(r2, c2, expected2);


            //Act
            string actual1 = table.ReadCell(r1, c1);
            string actual2 = table.ReadCell(r2, c2);

            //Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);

        }

        [Fact]
        public void CsvTable_OverwrittenCellShouldReturnLastValue()
        {
            //Arange
            int maxIndex = 10;
            int maxColumns = 20;
            ICsvTable table = new CsvTable();

            int r1 = 24308;
            string c1 = "Header";
            string e1 = "1";
            string expected = "TestEntry";
            table.WriteCell(r1, c1, e1);
            table.WriteCell(r1, c1, expected);

            //Act
            string actual = table.ReadCell(r1, c1);

            //Assert
            Assert.Equal(expected, actual);

        }
    }
}
