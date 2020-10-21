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
             
             Coordinate[,] gridArray = new Coordinate[Rows,Columns];  //DELETE??

             return gridArray;
         }

         
         public string[,] CreateArray(IEnumerable<string> lines)
         {
             string[,] newArray = new string[Rows, Columns];
             //List<Coordinate> mineLocations = new List<Coordinate>();
             
             var y = 0;
             foreach (var line in lines.Skip(1))
             {
                 var x = 0;
                 foreach (var character in line.Trim())
                 {
                     
                     if (character.ToString() == "*")
                     {
                         //mineLocations.Add(new Coordinate(x,y));
                         newArray[x, y] = character.ToString();
                     }
                     else if (character.ToString() == ".")
                     {
                         newArray[x, y] = "0";
                     }
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