using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Minesweeper
{
    
    public class FileReader : IReader
    {
        private readonly string _filepath;
        
        public FileReader(string filePath)
        {
            _filepath = filePath;
        }

        public IList<string> Read()
        {
            IEnumerable<string> fileContent = File.ReadLines(_filepath).ToList();

            return fileContent.ToList();
        }
        
    }
}