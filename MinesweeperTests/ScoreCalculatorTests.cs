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
            var grid = new Grid(ioReader);
            grid.Run();

            var result = grid.PrintGrid();

            var expectedString = "000\n" + "000\n" + "000\n";
            var expected = new List<string>() {expectedString};
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
            var grid = new Grid(ioReader);
            grid.Run();

            var result = grid.PrintGrid();
            var expectedString = "***\n" + "***\n" + "***\n";
            var expected = new List<string>() { expectedString};
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
            var grid = new Grid(ioReader);
            grid.Run();

            var result = grid.PrintGrid();

            var expectedString = "111\n" + "1*1\n" + "111\n";
            var expected = new List<string>() { expectedString};
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
            var grid = new Grid(ioReader);
            grid.Run();

            var result = grid.PrintGrid();

            var expectedString = "***\n" + "*8*\n" + "***\n";
            var expected = new List<string>() { expectedString};
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
            var grid = new Grid(ioReader);
            grid.Run();
            
            var result = grid.PrintGrid();

            var expectedString = "00\n" + "00\n";
            var expected = new List<string>() { expectedString};
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
            var grid = new Grid(ioReader);
            grid.Run();
            
            var result = grid.PrintGrid();

            var expectedString = "**\n" + "**\n";
            var expected = new List<string>() { expectedString};
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
            var grid = new Grid(ioReader);
            grid.Run();
            
            var result = grid.PrintGrid();

            var expectedString = "1*\n" + "11\n";
            var expected = new List<string>() { expectedString};
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
            var grid = new Grid(ioReader);
            grid.Run();
            
            var result = grid.PrintGrid();

            var expectedString = "**\n" + "*3\n";
            var expected = new List<string>() { expectedString};
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
            var grid = new Grid(ioReader);
            grid.Run();
            
            var result = grid.PrintGrid();

            var expectedString = "**100\n" + "44200\n" + "**100\n";
            var expected = new List<string>() { expectedString};
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
            var grid = new Grid(ioReader);
            grid.Run();
            
            var result = grid.PrintGrid();

            var expectedString = "";
            var expected = new List<string>() { expectedString};
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
                "\n",
                "00\n"
                
            };
            var ioReader = new TestIoReader(fileContent);
            var grid = new Grid(ioReader);
            grid.Run();
            
            var result = grid.PrintGrid();

            var expectedString1 = "000\n" + "000\n" + "000\n";
            var expectedString2 = "";
            var expected = new List<string>() { expectedString1, expectedString2};
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
                "\n",
                "12\n",
                "*.\n"

            };
            var ioReader = new TestIoReader(fileContent);
            var grid = new Grid(ioReader);
            grid.Run();
            
            var result = grid.PrintGrid();

            var expectedString1 = "000\n" + "000\n" + "000\n";
            var expectedString2 = "*1\n";
            var expected = new List<string>() { expectedString1, expectedString2};
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
                "\n",
                "12\n",
                "*.\n",
                "\n",
                "33\n",
                "..*\n",
                "...\n",
                "**.\n"
            };
            var ioReader = new TestIoReader(fileContent);
            var grid = new Grid(ioReader);
            grid.Run();
            
            var result = grid.PrintGrid();

            var expectedString1 = "000\n" + "000\n" + "000\n";
            var expectedString2 = "*1\n";
            var expectedString3 = "01*\n" + "232\n" + "**1\n";
            var expected = new List<string>() { expectedString1, expectedString2, expectedString3};
            Assert.Equal(expected, result);

        } 
        
    }
    

}