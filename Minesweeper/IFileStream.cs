using System.Collections.Generic;
using System.IO;

namespace Minesweeper
{
    public interface IFileStream
    {
        IEnumerable<string> ReadLines(string filePath);
    }

    
        


}