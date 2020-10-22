using System;
using System.Collections.Generic;

namespace Minesweeper
{
    public class Game
    {
        public static void Main(string[] args)
        {
            var fileReader = new FileStream();
            IOHandler helper = new IOHandler(new ConsoleActions());
            IEnumerable<string> fileContent = helper.ReadFile(fileReader);

            var grid = new Grid();
            if (fileContent != null)
            {
                Coordinate[,] emptyGrid = grid.BuildGrid(fileContent);
                Console.WriteLine("Convert file into 2d array:");
                string[,]  fileInputGrid = grid.ConvertToArray(fileContent);
                Console.WriteLine("\nIndicate number of mines");
                string[,] newGrid = grid.AddNumbers(fileInputGrid);
                Console.WriteLine("\nMatrix:");
                grid.PrintGrid(newGrid);
            }

        }
    }
}