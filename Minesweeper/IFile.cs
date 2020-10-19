using System.Collections.Generic;
using System.IO;

namespace Minesweeper
{
    public interface IFile
    {
        IEnumerable<string> ReadLines(string filePath);
    }

    
        


}