using System.Collections.Generic;
using System.Linq;
using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class TestIoReader: IIoHandler
    {
        private readonly IEnumerable<string> _gridText;

        public TestIoReader(IEnumerable<string> gridText)
        {
            _gridText = gridText;
        }
        public IList<string> ReadFile(IFileStream fileUtils)
        {
            return _gridText.ToList();
        }
    }
    
    public class ScoreCalculatorTests
    {
        [Fact]
        public void AllScoreAreZeroWhenThereAreNoMines()
        {
            IEnumerable<string> fileContent = new[]
            {
                "33\n",
                "...\n",
                "...\n",
                "...\n"
            };
            var ioReader = new TestIoReader(fileContent);
            var grid = new GridSeparator(ioReader);
            grid.Run();

            var result = grid.PrintGrid(new Grid());

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
            
            var ioReader = new TestIoReader(fileContent);
            var grid = new GridSeparator(ioReader);
            grid.Run();

            var result = grid.PrintGrid(new Grid());

            var expected = "***\n" + "***\n" + "***\n";
            Assert.Equal(expected, result);
        } 
        
        [Fact]
        public void ScoresAllAroundPerimeterWhenOneMineInTheMiddle()
        {
            var fileContent = new[]
            {
                "33\n",
                "...\n",
                ".*.\n",
                "...\n"
            };
            
            var ioReader = new TestIoReader(fileContent);
            var grid = new GridSeparator(ioReader);
            grid.Run();

            var result = grid.PrintGrid(new Grid());

            var expected = "111\n" + "1*1\n" + "111\n";
            Assert.Equal(expected, result);
        } 
        
        [Fact]
        public void ScoreOnlyInMiddleWhenMinesAllAroundThePerimeter()
        {
            var fileContent = new[]
            {
                "33\n",
                "***\n",
                "*.*\n",
                "***\n"
            };
            
            var ioReader = new TestIoReader(fileContent);
            var grid = new GridSeparator(ioReader);
            grid.Run();

            var result = grid.PrintGrid(new Grid());

            var expected = "***\n" + "*8*\n" + "***\n";
            Assert.Equal(expected, result);
        } 
        
        [Fact]
        public void AllScoreAreZeroWhenThereAreNoMinesFor2X2Grid()
        {
            var fileContent = new[]
            {
                "22\n",
                "..\n",
                "..\n"
            };
            
            var ioReader = new TestIoReader(fileContent);
            var grid = new GridSeparator(ioReader);
            grid.Run();
            
            var result = grid.PrintGrid(new Grid());

            var expected = "00\n" + "00\n";
            Assert.Equal(expected, result);

        } 
        
        [Fact]
        public void NoScoresWhenThereAreAllMinesFor2X2Grid()
        {
            var fileContent = new[]
            {
                "22\n",
                "**\n",
                "**\n"
            };
            
            var ioReader = new TestIoReader(fileContent);
            var grid = new GridSeparator(ioReader);
            grid.Run();
            
            var result = grid.PrintGrid(new Grid());

            var expected = "**\n" + "**\n";
            Assert.Equal(expected, result);
        } 
        
        [Fact]
        public void ScoresAllAroundPerimeterWhenOneMineInACornerIn2X2Grid()
        {
            var fileContent = new[]
            {
                "22\n",
                ".*\n",
                "..\n"
            };
            
            var ioReader = new TestIoReader(fileContent);
            var grid = new GridSeparator(ioReader);
            grid.Run();
            
            var result = grid.PrintGrid(new Grid());

            var expected = "1*\n" + "11\n";
            Assert.Equal(expected, result);
        } 
        
        [Fact]
        public void ScoreOnlyInOneCornerWhenMinesAllAroundThePerimeterIn2X2Grid()
        {
            var fileContent = new[]
            {
                "22\n",
                "**\n",
                "*.\n"
            };
            
            var ioReader = new TestIoReader(fileContent);
            var grid = new GridSeparator(ioReader);
            grid.Run();
            
            var result = grid.PrintGrid(new Grid());

            var expected = "**\n" + "*3\n";
            Assert.Equal(expected, result);
        } 
        
        [Fact]
        public void CheckIfCorrectScoreIfAllMinesAreDifferentSizeColumnAndRow()
        {
            var fileContent = new[]
            {
                "35\n",
                "**...\n",
                ".....\n",
                "**...\n"
            };
            
            var ioReader = new TestIoReader(fileContent);
            var grid = new GridSeparator(ioReader);
            grid.Run();
            
            var result = grid.PrintGrid(new Grid());

            var expected = "**100\n" + "44200\n" + "**100\n";
            Assert.Equal(expected, result);
        } 
        
        [Fact]
        public void ReturnEmptyStringIfRowsAndColumnsAreZero()
        {
            var fileContent = new[]
            {
                "00\n"
            };
            
            var ioReader = new TestIoReader(fileContent);
            var grid = new GridSeparator(ioReader);
            grid.Run();
            
            var result = grid.PrintGrid(new Grid());

            var expected = "";
            Assert.Equal(expected, result);
        } 
        
        
        [Fact]
        public void MultipleGridsWith0X0GridShouldBeHandled()
        {
            IEnumerable<string> fileContent = new[]
            {
                "33\n",
                "...\n",
                "...\n",
                "...\n",
                "",
                "00\n"
            };
            var ioReader = new TestIoReader(fileContent);
            var grid = new GridSeparator(ioReader);
            grid.Run();
            
            var result = grid.PrintGrid(new Grid());

            var expected = "000\n" + "000\n" + "000\n" + "\n"
                + "";
            Assert.Equal(expected, result);

        } 
        
        [Fact]
        public void MultipleGridsShouldBeHandled()
        {
            IEnumerable<string> fileContent = new[]
            {
                "33\n",
                "...\n",
                "...\n",
                "...\n",
                "",
                "12\n",
                "*.\n"
            };
            var ioReader = new TestIoReader(fileContent);
            var grid = new GridSeparator(ioReader);
            grid.Run();
            
            var result = grid.PrintGrid(new Grid());

            var expected = "000\n" + "000\n" + "000\n" + "\n" +
                           "*1\n";
            Assert.Equal(expected, result);

        } 
        
        [Fact]
        public void MultipleGrids3X3ShouldBeHandled()
        {
            IEnumerable<string> fileContent = new[]
            {
                "33\n",
                "...\n",
                "...\n",
                "...\n",
                "",
                "12\n",
                "*.\n",
                "",
                "33\n",
                "..*\n",
                "...\n",
                "**.\n"
            };
            var ioReader = new TestIoReader(fileContent);
            var grid = new GridSeparator(ioReader);
            grid.Run();
            
            var result = grid.PrintGrid(new Grid());

            var expected = "000\n" + "000\n" + "000\n" + "\n" + 
                           "*1\n" + "\n" +
                           "01*\n" + "232\n" + "**1\n";
            Assert.Equal(expected, result);

        } 
        
        [Fact]
        public void MultipleGrids3X3ShouldBeHandledWith0X0Case()
        {
            IEnumerable<string> fileContent = new[]
            {
                "33\n",
                "...\n",
                "...\n",
                "...\n",
                "",
                "12\n",
                "*.\n",
                "",
                "00\n"
            };
            var ioReader = new TestIoReader(fileContent);
            var grid = new GridSeparator(ioReader);
            grid.Run();
            
            var result = grid.PrintGrid(new Grid());

            var expected = "000\n" + "000\n" + "000\n" + "\n" + 
                           "*1\n" + "\n" +
                            ""; 
            Assert.Equal(expected, result);

        } 
        
    }
    

}