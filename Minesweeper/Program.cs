using System;
using System.Collections.Generic;

namespace Minesweeper
{
    
    public static class Program
    {
        public static void Main(string[] args)
        {
            var fileHandler = new IOHandler(new ConsoleActions());
            IEnumerable<string> fileContent = fileHandler.ReadFile(new FileStream());

            var grid = new Grid(fileContent);
            if (fileContent != null)
            {
                //grid.StoreGridSize(fileContent);
                Console.WriteLine("\nConvert file into 2d array:");
                //grid.ConvertToArray(fileContent);
                Console.WriteLine("\nIndicate number of mines:");
               // string[,] newGrid = grid.AddNumbers();
                Console.WriteLine("\nField #1:");
                Console.WriteLine(grid.PrintGrid());
            }

        }
    }
}