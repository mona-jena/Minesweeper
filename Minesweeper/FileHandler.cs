using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Minesweeper
{
    
    public class FileHandler : IIoHandler
    {
        private readonly IConsole _newConsole;
        
        public FileHandler(IConsole console)
        {
            _newConsole = console;
        }

        public IList<string> ReadFile(IFileStream fileUtils)
        {
            string fileLocation = Path.Combine(Environment.CurrentDirectory, $"Mines.csv");
            IEnumerable<string> fileContent = fileUtils.ReadLines(fileLocation).ToList();
            _newConsole.WriteLine($"The file has been opened");

            return fileContent.ToList();
        }
        
    }
}