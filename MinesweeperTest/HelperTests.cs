using System;
using System.IO;
using System.Linq;
using Minesweeper;
using Xunit;
using Xunit.Sdk;
using Moq;
using FileStream = Minesweeper.FileStream;

namespace TestProject1
{
    public class HelperTests
    {
        [Fact]
        public void TestIfReadFileCanReadFile()
        {
            var file = new IOHandler(new ConsoleActions());
            var actual = file.ReadFile(new FileStream()).First().Trim();
            var expected = "44";
            Assert.Equal(expected, actual);

        } 

        [Fact]
        public void TestIfReadFileCatchesFileNotFoundExceptionWhileReadingFile()
        {
            string fileName = "Mines.csv";
            string fileLocation = Path.Combine(Environment.CurrentDirectory, $"{fileName}");
            var fileMock = new Mock<IFileStream>();
            var consoleActionsMock = new Mock<IConsole>();
            
            var e = new FileNotFoundException();
            fileMock.Setup(s => s.ReadLines(fileLocation))
                .Throws(e);
            
            var file = new IOHandler(consoleActionsMock.Object);
            file.ReadFile(fileMock.Object);

            consoleActionsMock.Verify(s => s.WriteLine($"The file was not found: '{e}'"));
        }

        [Fact]
        public void TestIfReadFileCatchesDirectoryNotFoundExceptionWhileReadingFile()
        {
            string fileName = "Mines.csv";
            string fileLocation = Path.Combine(Environment.CurrentDirectory, $"{fileName}");
            
            var fileMock = new Mock<IFileStream>();
            var consoleActionsMock = new Mock<IConsole>();

            var e = new DirectoryNotFoundException();
            fileMock.Setup(s => s.ReadLines(fileLocation))
                .Throws(e);

            var file = new IOHandler(consoleActionsMock.Object);
            file.ReadFile(fileMock.Object);
            consoleActionsMock.Verify(s => s.WriteLine($"The directory was not found: '{e}'"));
        }
        

        [Fact]
        public void TestIfReadFileCatchesIOExceptionWhileReadingFile()
        {
            string fileName = "Mines.csv";
            string fileLocation = Path.Combine(Environment.CurrentDirectory, $"{fileName}");
            
            var fileMock = new Mock<IFileStream>();
            var consoleActionsMock = new Mock<IConsole>();

            var e = new IOException();
            fileMock.Setup(s => s.ReadLines(fileLocation))
                .Throws(e);

            var file = new IOHandler(consoleActionsMock.Object);
            file.ReadFile(fileMock.Object);

            consoleActionsMock.Verify(s => s.WriteLine($"The file could not be opened: '{e}'"));
        }
    }
    
}