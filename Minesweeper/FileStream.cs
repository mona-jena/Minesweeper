using System;
using System.Collections.Generic;
using System.IO;

namespace Minesweeper
{

    public class FileStream : IFileStream
    {
        public IEnumerable<string> ReadLines(string filePath)
        {
            return File.ReadLines((filePath));
        }
    }
}