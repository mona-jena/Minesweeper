using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    public class Grid
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
   
        
         public Coordinate[,] BuildGrid(IEnumerable<string> fileContent)
         {
             string line1 = fileContent.First().Trim();
             
             Rows = int.Parse(line1.Substring(0,1));
             Columns = int.Parse(line1.Substring(1,1));
             
             Coordinate[,] gridArray = new Coordinate[Rows,Columns];

             return gridArray;
         }

         
         public string[,] CreateArray(IEnumerable<string> lines)
         {
             string[,] newArray = new string[Rows, Columns];
             //List<Coordinate> mineLocations = new List<Coordinate>();
             
             /*var y = 0;
             for (int line = 0; line < Rows; line++)
             {
                 var x = 0;
                 for (int character = 0; character < Columns; character++)
                 {
                     newArray[x, y] = character.ToString();
                     x++;
                 }
                 y++;
             }*/

             var y = 0;
             foreach (var line in lines.Skip(1))
             {
                 var x = 0;
                 foreach (var character in line.Trim())
                 {
                     newArray[x, y] = character.ToString();
                     // if (character.ToString() == "*")
                     // {
                     //     //mineLocations.Add(new Coordinate(x,y));
                     // }
                     x++;
                 }
                 y++;
             }

             for (int i = 0; i < Rows; i++)
             {
                 for (int j = 0; j < Columns; j++)
                 {
                     Console.WriteLine("[{0},{1}] = {2}", i, j, newArray[i, j]);
                 }
             }

             /*for (int i = 0; i < mineLocations.Count; i++)
             {
                 Console.WriteLine(mineLocations[i]);
             }*/

             return newArray;
         }

    }
}