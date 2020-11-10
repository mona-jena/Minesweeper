using System;
using System.IO;
using System.Linq;
using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class GridTests
    {
        
        [Fact]
        public void FileReaderShouldBeAbleToOpenAndReadFileAndReturnFinalGrids()
        {
            string fileLocation = Path.Combine(Environment.CurrentDirectory, "Mines.csv");
            var fileHandler = new FileReader(fileLocation);

            var gridSeparator = new GridSeparator(fileHandler);
            gridSeparator.Run();
            
            var result = gridSeparator.PrintGrid();

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
        
        
    }
}