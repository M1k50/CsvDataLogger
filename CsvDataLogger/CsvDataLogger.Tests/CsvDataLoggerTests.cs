//using System;
//using System.IO;
//using Xunit;
//using CsvDataLogger;
//using Xunit.Sdk;
//using Moq;

//namespace CsvDataLogger.Tests
//{
//    public class CsvDataLoggerTests
//    {
//        [Fact]
//        public void SetFilname_ShouldReturnFilename()
//        {
//            //Arange
//            string expFilename = "TestFilename";
//            ICsvDataLogger logger = new CsvDataLogger();

//            //Act
//            string actFilename = logger.FullFileName;

//            //Assert
//            Assert.Equal(expFilename, actFilename);
//        }

//        [Theory]
//        [InlineData("Test","./")]
//        [InlineData("Test","C:/")]
//        public void SetDirectory_ShouldReturnDirectory(string name, string expected )
//        {
//            //Arange
//            ICsvDataLogger logger = new CsvDataLogger();

//            //Act
//            string actDirectory = logger.Directory;

//            //Assert
//            Assert.Equal(expected, actDirectory);

//        }

//        [Fact]
//        public void SetWrongDirectory_ShouldThrowArgumentException()
//        {
//            //Arange
//            string filename = "test";
//            string outputDir = "";

//            //Assert
//            ICsvDataLogger logger;
//            Assert.Throws<ArgumentException>(()=> logger = new CsvDataLogger());

//        }
//    }
//}
