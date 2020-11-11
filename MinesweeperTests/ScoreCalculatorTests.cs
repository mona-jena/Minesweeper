using System.Collections.Generic;
using Minesweeper;
using Xunit;

namespace MinesweeperTests
{
    public class ScoreCalculatorTests
    {
        [Fact]
        public void AllScoreAreZeroWhenThereAreNoMines()
        {
            IEnumerable<string> fileContent = new[]
            {
                "33",
                "...",
                "...",
                "..."
            };
            var ioReader = new TestReader(fileContent);
            var minefieldScorer = new MinefieldScorer(ioReader);
            minefieldScorer.Run();

            var result = minefieldScorer.PrintMinefield();

            var expected = "000\n" + "000\n" + "000";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void NoScoresWhenThereAreAllMines()
        {
            var fileContent = new[]
            {
                "33",
                "***",
                "***",
                "***"
            };

            var ioReader = new TestReader(fileContent);
            var minefieldScorer = new MinefieldScorer(ioReader);
            minefieldScorer.Run();

            var result = minefieldScorer.PrintMinefield();

            var expected = "***\n" + "***\n" + "***";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ScoresAllAroundPerimeterWhenOneMineInTheMiddle()
        {
            var fileContent = new[]
            {
                "33",
                "...",
                ".*.",
                "..."
            };

            var ioReader = new TestReader(fileContent);
            var minefieldScorer = new MinefieldScorer(ioReader);
            minefieldScorer.Run();

            var result = minefieldScorer.PrintMinefield();

            var expected = "111\n" + "1*1\n" + "111";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ScoreOnlyInMiddleWhenMinesAllAroundThePerimeter()
        {
            var fileContent = new[]
            {
                "33",
                "***",
                "*.*",
                "***"
            };

            var ioReader = new TestReader(fileContent);
            var minefieldScorer = new MinefieldScorer(ioReader);
            minefieldScorer.Run();

            var result = minefieldScorer.PrintMinefield();

            var expected = "***\n" + "*8*\n" + "***";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void AllScoreAreZeroWhenThereAreNoMinesFor2X2Minefield()
        {
            var fileContent = new[]
            {
                "22",
                "..",
                ".."
            };

            var ioReader = new TestReader(fileContent);
            var minefieldScorer = new MinefieldScorer(ioReader);
            minefieldScorer.Run();

            var result = minefieldScorer.PrintMinefield();

            var expected = "00\n" + "00";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void NoScoresWhenThereAreAllMinesFor2X2Minefield()
        {
            var fileContent = new[]
            {
                "22",
                "**",
                "**"
            };

            var ioReader = new TestReader(fileContent);
            var minefieldScorer = new MinefieldScorer(ioReader);
            minefieldScorer.Run();

            var result = minefieldScorer.PrintMinefield();

            var expected = "**\n" + "**";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ScoresAllAroundPerimeterWhenOneMineInACornerIn2X2Minefield()
        {
            var fileContent = new[]
            {
                "22",
                ".*",
                ".."
            };

            var ioReader = new TestReader(fileContent);
            var minefieldScorer = new MinefieldScorer(ioReader);
            minefieldScorer.Run();

            var result = minefieldScorer.PrintMinefield();

            var expected = "1*\n" + "11";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ScoreOnlyInOneCornerWhenMinesAllAroundThePerimeterIn2X2Minefield()
        {
            var fileContent = new[]
            {
                "22",
                "**",
                "*."
            };

            var ioReader = new TestReader(fileContent);
            var minefieldScorer = new MinefieldScorer(ioReader);
            minefieldScorer.Run();

            var result = minefieldScorer.PrintMinefield();

            var expected = "**\n" + "*3";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CheckIfCorrectScoreIfAllMinesAreDifferentSizeColumnAndRow()
        {
            var fileContent = new[]
            {
                "35",
                "**...",
                ".....",
                "**..."
            };

            var ioReader = new TestReader(fileContent);
            var minefieldScorer = new MinefieldScorer(ioReader);
            minefieldScorer.Run();

            var result = minefieldScorer.PrintMinefield();

            var expected = "**100\n" + "44200\n" + "**100";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReturnEmptyStringIfRowsAndColumnsAreZero()
        {
            var fileContent = new[]
            {
                "00"
            };

            var ioReader = new TestReader(fileContent);
            var minefieldScorer = new MinefieldScorer(ioReader);
            minefieldScorer.Run();

            var result = minefieldScorer.PrintMinefield();

            var expected = "";
            Assert.Equal(expected, result);
        }


        [Fact]
        public void MultipleMinefieldsWith0X0MinefieldShouldBeHandled()
        {
            IEnumerable<string> fileContent = new[]
            {
                "33",
                "...",
                "...",
                "...",
                "",
                "00"
            };
            var ioReader = new TestReader(fileContent);
            var minefieldScorer = new MinefieldScorer(ioReader);
            minefieldScorer.Run();

            var result = minefieldScorer.PrintMinefield();

            var expected = new[]
            {
                "000", 
                "000", 
                "000",
                "\n"
            };
            Assert.Equal(string.Join("\n",expected), result);
        }

        [Fact]
        public void MultipleMinefieldsShouldBeHandled()
        {
            IEnumerable<string> fileContent = new[]
            {
                "33",
                "...",
                "...",
                "...",
                "",
                "12",
                "*."
            };
            var ioReader = new TestReader(fileContent);
            var minefieldScorer = new MinefieldScorer(ioReader);
            minefieldScorer.Run();

            var result = minefieldScorer.PrintMinefield();

            var expected = new[]
            { 
                "000", 
                "000", 
                "000",
                "",
                "*1"
            };
            Assert.Equal(string.Join("\n",expected), result);
        }

        [Fact]
        public void MultipleMinefields3X3ShouldBeHandled()
        {
            IEnumerable<string> fileContent = new[]
            {
                "33",
                "...",
                "...",
                "...",
                "",
                "12",
                "*.",
                "",
                "33",
                "..*",
                "...",
                "**."
            };
            var ioReader = new TestReader(fileContent);
            var minefieldScorer = new MinefieldScorer(ioReader);
            minefieldScorer.Run();

            var result = minefieldScorer.PrintMinefield();

            var expected = new[]
            {
                "000",
                "000",
                "000",
                "",
                "*1",
                "",
                "01*",
                "232",
                "**1"
            };

            Assert.Equal(string.Join("\n",expected), result);
        }
    }
}