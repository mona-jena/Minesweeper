using System;
using System.Collections.Generic;
using System.IO;

namespace Minesweeper
{
    public class IOHandler
    {
        private IConsole _newConsole;
        
        public IOHandler(IConsole console)
        {
            _newConsole = console;
        }

        public IEnumerable<string> ReadFile(IFileStream fileUtils)
        {
            string fileLocation = Path.Combine(Environment.CurrentDirectory, $"Mines.csv");
            IEnumerable<string> fileContent = null;
            fileContent = fileUtils.ReadLines(fileLocation);
            _newConsole.WriteLine($"The file has been opened");

            return fileContent;
        }
        
    }
}