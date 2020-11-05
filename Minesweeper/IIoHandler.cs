using System.Collections.Generic;

namespace Minesweeper
{
    public interface IIoHandler
    {
        IList<string> ReadFile(IFileStream fileUtils);
    }
}