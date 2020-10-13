using System;
using System.Collections;
using System.Collections.Generic;

namespace Minesweeper
{
    public class Game
    {
        //get user input for grid size 

        public static void Main(string[] args)
        {
            Helper helper = new Helper();
            IEnumerable<string> fileContent = helper.ReadFile("Mines.csv");
            var grid = new Grid();
            grid.BuildGrid(fileContent);
        }

        
    }
    
    
}