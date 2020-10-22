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

            var gridArray = grid.ConvertToArray(fileContent);
            var length = gridArray.Length;
            
            int expected = 16;
            Assert.Equal(expected, length);
        }

        [Fact]
        public void TestIfAddNumbersReturnsArrayWithCorrectScore()
        {
            var grid = new Grid();
            var file = new IOHandler(new ConsoleActions());
            var fileContent = file.ReadFile(new FileStream());
            grid.BuildGrid(fileContent);
            var gridArray = grid.ConvertToArray(fileContent);

            var result = grid.AddNumbers(gridArray);
            
            string[,] expectedArray = new string[4, 4];
            expectedArray[0, 0] = "*";
            expectedArray[0, 1] = "2";
            expectedArray[0, 2] = "1";
            expectedArray[0, 3] = "1";
            expectedArray[1, 0] = "1";
            expectedArray[1, 1] = "2";
            expectedArray[1, 2] = "*";
            expectedArray[1, 3] = "1";
            expectedArray[2, 0] = "0";
            expectedArray[2, 1] = "1";
            expectedArray[2, 2] = "1";
            expectedArray[2, 3] = "1";
            expectedArray[3, 0] = "0";
            expectedArray[3, 1] = "0";
            expectedArray[3, 2] = "0";
            expectedArray[3, 3] = "0";

            Assert.Equal(expectedArray, result);

        }
    }
}