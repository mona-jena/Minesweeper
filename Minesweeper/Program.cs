using System;

namespace Minesweeper
{
    public static class Program
    {
        public static void Main()
        {
            var fileHandler = new FileHandler(new ConsoleActions());

            var gridSeparator = new GridSeparator(fileHandler);
            gridSeparator.Run();
            
            Console.WriteLine(gridSeparator.PrintGrid());
            
        }
    }
    
}