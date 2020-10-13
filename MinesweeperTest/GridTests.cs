using System;
using System.Linq;
using Minesweeper;
using Xunit;
using Xunit.Sdk;

namespace TestProject1
{
    public class GridTests
    {
        [Fact]
        public void TestIfBuildGridReturnsCorrectSizedGrid()
        {
            var grid = new Grid();
            
            var file = new Helper();
            var fileContent = file.ReadFile("Mines.csv");
            var expected = 16;
            var result = grid.BuildGrid(fileContent).Length;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestIfGetSurroundingMinesReturnsNumberOfSurroundingMines()
        {
            
        }
    }
}