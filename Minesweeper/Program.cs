using System;
using System.IO;

namespace Minesweeper
{
    public static class Program
    {
        public static void Main()
        {
            string fileLocation = Path.Combine(Environment.CurrentDirectory, "Mines.csv");
            var fileReader = new FileReader(fileLocation);

            var minefieldScorer = new MinefieldScorer(fileReader);
            minefieldScorer.Run();
            
            Console.WriteLine(minefieldScorer.PrintMinefield());
            
        }
    }
    
}