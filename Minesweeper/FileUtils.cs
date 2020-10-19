using System;
using System.Collections.Generic;
using System.IO;

namespace Minesweeper
{

    public class FileUtils : IFile
    {
        public IEnumerable<string> ReadLines(string filePath)
        {
            return File.ReadLines((filePath));
        }
    }
}