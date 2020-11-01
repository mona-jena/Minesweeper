using System.IO;
using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class GridTests
    {
        
        [Fact]
        public void TestIfPrintGridReturnsArrayWithCorrectScoreAndCorrectMatrixFormat()
        {
            var fileContent = File.ReadAllLines("Mines.csv");
            var grid = new Grid(fileContent);
            
            var result = grid.PrintGrid();

            var expected =
                "*100\n" +
                "2210\n" +
                "1*10\n" +
                "1110\n";

            Assert.Equal(expected, result);

        }
        
    }
}