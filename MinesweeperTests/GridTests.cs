using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class GridTests
    {
        [Fact]
        public void TestIfBuildGridReturnsCorrectSizedGrid()
        {
            var grid = new Grid();
            
            var file = new IOHandler(new ConsoleActions());
            var fileContent = file.ReadFile(new FileStream());
            
            var expected = 16;
            var result = grid.BuildGrid(fileContent).Length;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestIfCreateArrayReturnsArrayOfSameSizeGridAsInputFileGrid()
        {
            var grid = new Grid();
            var file = new IOHandler(new ConsoleActions());
            var fileContent = file.ReadFile(new FileStream());
            grid.BuildGrid(fileContent);

            var gridArray = grid.CreateArray(fileContent);
            var length = gridArray.Length;
            
            int expected = 16;
            Assert.Equal(expected, length);
        }

    }
}