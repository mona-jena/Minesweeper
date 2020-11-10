using System.Collections.Generic;
using System.Linq;
using Minesweeper;

namespace MinesweeperTests
{
    public class TestReader : IReader
    {
        private readonly IEnumerable<string> _gridText;

        public TestReader(IEnumerable<string> gridText)
        {
            _gridText = gridText;
        }

        public IList<string> Read()
        {
            return _gridText.ToList();
        }
    }
}