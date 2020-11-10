using System.Collections.Generic;

namespace Minesweeper
{
    public interface IReader
    {
        IList<string> Read();
    }
}