using System;
using System.Collections;
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
                grid.BuildGrid(fileContent);
                grid.CreateArray(fileContent);
            }
            
            
        }
    }
}