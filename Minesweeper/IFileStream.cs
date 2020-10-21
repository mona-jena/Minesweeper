using System.Collections.Generic;

namespace Minesweeper
{
    public interface IFileStream
    {
        IEnumerable<string> ReadLines(string filePath);
    }

    
        


}