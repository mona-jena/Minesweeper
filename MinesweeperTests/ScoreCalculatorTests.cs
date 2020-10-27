using System;
using System.IO;
using System.Linq;
using Minesweeper;
using Xunit;
using Moq;
using FileStream = Minesweeper.FileStream;

namespace MinesweeperTests
{
    public class ScoreCalculatorTests
    {
        [Fact]
        public void AllScoreAreZeroWhenThereAreNoMines()
        {
            var fileContent = new[]
            {
                "33\n",
                "...\n",
                "...\n",
                "...\n"
            };
            
            var grid = new Grid();
            grid.StoreGridSize(fileContent);

            var result = grid.PrintGrid();

            var expected = "000\n" + "000\n" + "000\n";
            Assert.Equal(expected, result);

        } 
        
        [Fact]
        public void NoScoresWhenThereAreAllMines()
        {
            var fileContent = new[]
            {
                "33\n",
                "***\n",
                "***\n",
                "***\n"
            };
            
            var grid = new Grid();
            grid.StoreGridSize(fileContent);

            var result = grid.PrintGrid();

            var expected = "***\n" + "***\n" + "***\n";
            Assert.Equal(expected, result);
        } 
        
        [Fact]
        public void CheckIfThereIsCorrectScoreWithOneMineInTheMiddle()
        {
            var fileContent = new[]
            {
                "33\n",
                "...\n",
                ".*.\n",
                "...\n"
            };
            
            var grid = new Grid();
            grid.StoreGridSize(fileContent);

            var result = grid.PrintGrid();

            var expected = "111\n" + "1*1\n" + "111\n";
            Assert.Equal(expected, result);
        } 
        
        [Fact]
        public void CheckIfThereIsCorrectScoreWithMinesAllOnThePerimeter()
        {
            var fileContent = new[]
            {
                "33\n",
                "***\n",
                "*.*\n",
                "***\n"
            };
            
            var grid = new Grid();
            grid.StoreGridSize(fileContent);

            var result = grid.PrintGrid();

            var expected = "***\n" + "*8*\n" + "***\n";
            Assert.Equal(expected, result);
        } 
        
    }
    
}