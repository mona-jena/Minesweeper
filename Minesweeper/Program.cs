using System;
using System.Collections.Generic;

namespace Minesweeper
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var fileHandler = new FileHandler(new ConsoleActions());
            var fileContent = fileHandler.ReadFile(new FileStream());
            // var gridSeparator = new GridSeparator(fileContent);
            // gridSeparator.SeperateEachGrid();
            
            var grid = new Grid(null);
            grid.Run();
            
            //grid.StoreGridSize(fileContent);
            Console.WriteLine("\nConvert file into 2d array:");
            //grid.ConvertToArray(fileContent);
            Console.WriteLine("\nIndicate number of mines:");
            // string[,] newGrid = grid.AddNumbers();
            Console.WriteLine("\nField #1:");
           // Console.WriteLine(grid.PrintGrid());
        }
    }
    
}