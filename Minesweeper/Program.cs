using System;
using System.Collections.Generic;

namespace Minesweeper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IOHandler fileHandler = new IOHandler(new ConsoleActions());
            IEnumerable<string> fileContent = fileHandler.ReadFile(new FileStream());

            var grid = new Grid();
            if (fileContent != null)
            {
                //Coordinate[,] emptyGrid = grid.BuildGrid(fileContent);
                grid.StoreGridSize(fileContent);
                Console.WriteLine("\nConvert file into 2d array:");
                string[,]  fileInputGrid = grid.ConvertToArray(fileContent);
                Console.WriteLine("\nIndicate number of mines:");
                string[,] newGrid = grid.AddNumbers(fileInputGrid);
                Console.WriteLine("\nField #1:");
                Console.WriteLine(grid.PrintGrid(newGrid));
            }

        }
    }
}