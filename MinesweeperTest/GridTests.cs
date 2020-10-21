using System;
using System.Collections.Generic;
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
            
            var file = new IOHandler(new ConsoleActions());
            var fileContent = file.ReadFile(new FileStream());
            
            var expected = 16;
            var result = grid.BuildGrid(fileContent).Length;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestIfCreateArrayReturnsArrayOfSameSizeAsInputFileGrid()
        {
            var grid = new Grid();
            var file = new IOHandler(new ConsoleActions());
            var fileContent = file.ReadFile(new FileStream());
            var buildGrid = grid.BuildGrid(fileContent);

            var gridArray = grid.CreateArray(fileContent);
            var length = gridArray.Length;

            //int result = lowerBound * upperBound;
            int expected = 16;

            Assert.Equal(expected, length);
        }

    }
}