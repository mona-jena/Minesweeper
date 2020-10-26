using System.Threading.Tasks.Dataflow;
using Minesweeper;
using NuGet.Frameworks;
using Xunit;

namespace MinesweeperTests
{
    public class GridTests
    {
        [Fact]
        public void TestIfStoreGridSizeStoresRowsAndColumnsValue()
        {
            var grid = new Grid();
            var file = new IOHandler(new ConsoleActions());
            var fileContent = file.ReadFile(new FileStream());
            grid.StoreGridSize(fileContent);
            
            var rowsExpected = 4;
            var rowsResult = grid.Rows;
            Assert.Equal(rowsExpected, rowsResult);
            
            var columnExpected = 4;
            var columnResult = grid.Columns;
            Assert.Equal(columnExpected, columnResult);
        }

        [Fact]
        public void TestIfCreateArrayReturnsArrayOfSameSizeGridAsInputFileGrid()
        {
            var grid = new Grid();
            var file = new IOHandler(new ConsoleActions());
            var fileContent = file.ReadFile(new FileStream());
            grid.StoreGridSize(fileContent);

            var gridArray = grid.ConvertToArray(fileContent);
            var length = gridArray.Length;
            
            int expected = 16;
            Assert.Equal(expected, length);
        }

        [Fact]
        public void TestIfPrintGridReturnsArrayWithCorrectScoreAndCorrectMatrixFormat()
        {
            var grid = new Grid();
            var file = new IOHandler(new ConsoleActions());
            var fileContent = file.ReadFile(new FileStream());
            grid.StoreGridSize(fileContent);
            var gridArray = grid.ConvertToArray(fileContent);

            var arrayWithHints = grid.AddNumbers(gridArray);
            var result = grid.PrintGrid(arrayWithHints);

            var expected =
                "*100\n" +
                "2210\n" +
                "1*10\n" +
                "1110\n";

            Assert.Equal(expected, result);

        }
        
    }
}