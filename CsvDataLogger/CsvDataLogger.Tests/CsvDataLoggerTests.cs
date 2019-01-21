using System;
using System.IO;
using Xunit;
using System.IO.Abstractions.TestingHelpers;
using System.Data;
using System.Collections.Generic;
using CsvDataLogger;
using System.IO.Abstractions;

namespace CsvDataLogger.Tests
{
    public class CsvDataLoggerTests
    {
        [Fact]
        public void CsvDataLogger_ValidData_ShouldCreateFile()
        {
            //Arrange
            string fullFilename = "test.csv";
            string directory = @"C:\temp\";
            string indexColumnName = "Index";
            MockFileSystem fileSystem = new MockFileSystem();
            ICsvDataLogger logger = new CsvDataLogger(fullFilename,directory,true,fileSystem,indexColumnName);

            string column = "TestColumn";
            int index = int.MaxValue;
            string entry1 = $"TestEntry";
            string expectedFileText = $"{indexColumnName},{column}{Environment.NewLine}{index},{entry1}{Environment.NewLine}";

            //Act
            logger.LogData(index, column, entry1);
            logger.FlushBuffer();
            MockFileData mockFile = fileSystem.GetFile(logger.Filepath);
            string actualFileText = mockFile.TextContents;

            //Assert
            Assert.Equal(expectedFileText, actualFileText);

            logger.Dispose();

        }

        //[Fact]
        //public void CsvDataLogger_ValidData_ShouldCreateRealFile()
        //{
        //    //Arrange
        //    string fullFilename = "test.csv";
        //    string directory = @"C:\temp\";
        //    IFileSystem fileSystem = new FileSystem();
        //    ICsvDataLogger logger = new CsvDataLogger(fullFilename, directory, true, fileSystem);

        //    string column = "TestColumn1";
        //    int index = 13;
        //    string entry1 = $"Entry:Index:{index}, Column:{column}";
        //    string expectedFileText = $"{column}{Environment.NewLine}Cell_{index}{column}{Environment.NewLine}";

        //    //Act
        //    logger.LogData(index, column, entry1);
        //    logger.WriteLogBuffer();
        //    logger.Dispose();
        //    string actualFileText = System.IO.File.ReadAllText(logger.Filepath);

        //    //Assert
        //    Assert.Equal(expectedFileText, actualFileText);
        //}

        [Theory]
        [InlineData(1, "1", "Cell1Row1")]
        [InlineData(3, "3", "Cell3Row3")]
        [InlineData(1000, "10", "Cell10Row1000")]


        public void CsvTable_ShouldReturnSingleWrittenValue(int row, string column, string data)
        {
            //Arange
            ICsvTable table = Factory.GetCsvDataTable();

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
            ICsvTable table = Factory.GetCsvDataTable();

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
            ICsvTable table = Factory.GetCsvDataTable();

            int r1 = 24308;
            string c1 = "Header";
            string expected1 = "TestEntry1";

            string expected2 = "TestEntry2";
            //Act
            table.WriteCell(r1, c1, expected1);
            string actual1 = table.ReadCell(r1, c1);

            table.WriteCell(r1, c1, expected2);
            string actual2 = table.ReadCell(r1, c1);

            //Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
        }

        [Fact]
        public void Logger_SortColumns_DataIsConsistent()
        {
            //Arrange
            string fullFilename = "test.csv";
            string directory = @"C:\temp\";
            string indexColumnName = "Index";
            bool sortColumns = true;
            //MockFileSystem fileSystem = new MockFileSystem();
            IFileSystem fileSystem= new FileSystem();
            ICsvDataLogger logger = new CsvDataLogger(fullFilename, directory, true, fileSystem, indexColumnName, sortColumns);

            //Act
            DataTable referenceTable = new DataTable();

            int expectedColumns = 10;
            List<int> expectedColumnNames = GenerateDiscretePointsList(expectedColumns, 1000);
            int expectedRows = 10;

            foreach (int col in expectedColumnNames)
            {
                string colName = col.ToString();
                referenceTable.Columns.Add(colName);

            }

            for (int index = 0; index < expectedRows; index++)
            {
                foreach (int col in expectedColumnNames)
                {
                    string entry = CellEntry(index, col);
                    logger.LogData(index, col.ToString(), entry);
                }
            }
            logger.FlushBuffer();

            //Assert
            int actualRows = logger.CsvTable.Table.Rows.Count;
            int actualColumns = logger.CsvTable.Table.Columns.Count;
            for (int index = 0; index < expectedRows; index++)
            {
                for (int column = 0; column < expectedColumns; column++)
                {
                    string columnName = referenceTable.Columns[column].ColumnName;
                    string expectedEntry = referenceTable.Rows[index][columnName].ToString();
                    string actualEntry = logger.CsvTable.ReadCell(index, columnName);
                    Assert.Equal(expectedEntry, actualEntry);
                }
            }
            logger.Dispose();
        }

        private static string CellEntry(int index, int column)
        {
            string output= $"ind:{index} col:{column}";
            return output;
        }

        private List<int> GenerateDiscretePointsList(int elements, int range)
        {
            List<int> output = new List<int>();
            while (output.Count<elements)
            {
                Random rndNum = new Random();
                int element = rndNum.Next(range);
                bool numberContained = output.Contains(element);
                if (!numberContained)
                {
                    output.Add(element);
                }

            }
            return output;
        }

        [Fact]
        public void CsvTable_SortColumns_Multiple_DataIsConsistent()
        {

        }
    }
}
