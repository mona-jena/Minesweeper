using System;
using System.Collections.Generic;

namespace Minesweeper
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var fileHandler = new FileHandler(new ConsoleActions());

            var allGrids = new GridSeparator(fileHandler);
            
            allGrids.Run();
            
            Console.WriteLine(allGrids.PrintGrid());
            
        }
    }
    
}