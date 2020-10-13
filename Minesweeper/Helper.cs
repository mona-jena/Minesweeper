using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Minesweeper
{
    public class Helper
    {
        public IEnumerable<string> ReadFile(string fileName)
        {
            string fileLocation = Path.Combine(Environment.CurrentDirectory, $"{fileName}");
            IEnumerable<string> fileContent = null;
            
            try
            {
                fileContent = File.ReadLines(fileLocation);
                Console.WriteLine($"The file has been opened");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"The file was not found: '{e}'");
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine($"The directory was not found: '{e}'");
            }
            catch (IOException e)
            {
                Console.WriteLine($"The file could not be opened: '{e}'");
            }

            return fileContent;
        }
    }
}