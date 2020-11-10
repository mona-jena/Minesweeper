using System;
using System.IO;

namespace Minesweeper
{
    public static class Program
    {
        public static void Main()
        {
            string fileLocation = Path.Combine(Environment.CurrentDirectory, "Mines.csv");
            var fileHandler = new FileReader(fileLocation);

            var gridSeparator = new GridSeparator(fileHandler);
            gridSeparator.Run();
            
            Console.WriteLine(gridSeparator.PrintGrid());
            
        }
    }
    
}