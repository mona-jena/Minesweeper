using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Minesweeper
{
    public class FileReader
    {
        private IConsole _newConsole;
        
        public FileReader(IConsole console)
        {
            _newConsole = console;
        }

        public IEnumerable<string> ReadFile(IFile fileUtils)
        {
            string fileLocation = Path.Combine(Environment.CurrentDirectory, $"Mines.csv");
            IEnumerable<string> fileContent = null;
            try
            {
                //fileContent = _streamReader.ReadLine(fileLocation)
                fileContent = fileUtils.ReadLines(fileLocation);
                
                //fileContent = File.ReadLines(fileLocation);
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