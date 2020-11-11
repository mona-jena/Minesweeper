using System.Collections.Generic;
using System.Linq;
using Minesweeper;

namespace MinesweeperTests
{
    public class TestReader : IReader
    {
        private readonly IEnumerable<string> _minefieldText;

        public TestReader(IEnumerable<string> minefieldText)
        {
            _minefieldText = minefieldText;
        }

        public IList<string> Read()
        {
            return _minefieldText.ToList();
        }
    }
}