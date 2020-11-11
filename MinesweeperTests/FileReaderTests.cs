using System;
using System.IO;
using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class MinefieldTests
    {
        
        [Fact]
        public void FileReaderShouldBeAbleToOpenAndReadFileAndReturnFinalMinefields()
        {
            string fileLocation = Path.Combine(Environment.CurrentDirectory, "Mines.csv");
            var fileHandler = new FileReader(fileLocation);

            var minefieldScorer = new MinefieldScorer(fileHandler);
            minefieldScorer.Run();
            
            var result = minefieldScorer.PrintMinefield();

            var expected =
                "*100\n" +
                "2210\n" +
                "1*10\n" +
                "1110\n" +
                "\n" +
                "**100\n" +
                "33200\n" +
                "1*100\n"+
                "\n";

            Assert.Equal(expected, result);
        }
        
        
        [Fact]
        public void FileReaderShouldBeAbleToOpenAndReadFileAndReturnFinalMinefieldsWithMines2()
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, "Mines2.csv");
            var fileHandler = new FileReader(filePath);

            var minefieldScorer = new MinefieldScorer(fileHandler);
            minefieldScorer.Run();
            
            var result = minefieldScorer.PrintMinefield();

            var expected = "\n" +
                           "\n" +
                           "**\n" +
                           "33\n" +
                           "2*\n" +
                           "*2\n" +
                           "11\n" +
                           "11\n" +
                           "*1\n" +
                           "\n" +
                           "\n" +
                           "\n"
            ;

            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void FileReaderShouldBeAbleToOpenAndReadFileAndReturnFinalMinefieldsWithSingleMinefield()
        {
            string fileLocation = Path.Combine(Environment.CurrentDirectory, "SingleMinefield.csv");
            var fileHandler = new FileReader(fileLocation);

            var minefieldScorer = new MinefieldScorer(fileHandler);
            minefieldScorer.Run();
            
            var result = minefieldScorer.PrintMinefield();

            var expected =
                "*100\n" +     
                "2210\n" +
                "1*10\n" +
                "1110";

            Assert.Equal(expected, result);
        }
        
    }
}                  

                                                