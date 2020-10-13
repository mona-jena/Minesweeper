using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    public class Grid
    {
        public Coordinate[,] BuildGrid(IEnumerable<string> fileContent)
        {
            string line1 = fileContent.First().Trim();
            
            var rows = int.Parse(line1.Substring(0,1));
            var columns = int.Parse(line1.Substring(1,1));
            
            Coordinate[,] gridArray = new Coordinate[rows,columns];

            return gridArray;
        }

        /*public Coordinate[,] GetSurroundingMines(Coordinate[,] gridArray)
        {
            foreach (var grid in gridArray)
            {
                if (grid.ToString() == ".")
                {
                    // grid.x = grid.c
                }
                else if (grid.ToString() == "*")
                {
                    
                }
            }
            
        }*/
        
        
    }
}