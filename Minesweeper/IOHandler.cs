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
            try
            {
                fileContent = fileUtils.ReadLines(fileLocation);
                
                _newConsole.WriteLine($"The file has been opened");
            }
            catch (FileNotFoundException e)
            {
                _newConsole.WriteLine($"The file was not found: '{e}'");
            }
            catch (DirectoryNotFoundException e)
            {
                _newConsole.WriteLine($"The directory was not found: '{e}'");
            }
            catch (IOException e)
            {
                _newConsole.WriteLine($"The file could not be opened: '{e}'");
            }

            return fileContent;
        }
        
    }
}