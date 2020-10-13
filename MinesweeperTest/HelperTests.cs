using System;
using System.Linq;
using Minesweeper;
using Xunit;
using Xunit.Sdk;

namespace TestProject1
{
    public class HelperTests
    {
        [Fact]
        public void TestIfReadFileCanReadFile()
        {
            var file = new Helper();
            var actual = file.ReadFile("Mines.csv");
            var expected = "44";
            Assert.Equal(expected, actual.First().Trim());

        }
        
        
        
        
    }

    
        
}