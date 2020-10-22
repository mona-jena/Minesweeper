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

         
         public string[,] ConvertToArray(IEnumerable<string> lines)
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

         public string[,] AddNumbers(string[,] noScoreArray)
         {
             int xUpperBound = noScoreArray.GetUpperBound(0);
             int yUpperBound = noScoreArray.GetUpperBound(1);
             for (int x = 0; x <= xUpperBound; x++) {
                 for (int y = 0; y <= yUpperBound; y++) {
                     string value = noScoreArray[x, y];
                     
                     if (value == "*")
                     {
                         if ((x - 1 >= 0) && (y - 1 >= 0))
                         {
                             int newScore = int.Parse(noScoreArray[x - 1, y - 1]) + 1;
                             noScoreArray[x - 1, y - 1] = newScore.ToString();
                         }
                         if (y - 1 >= 0)
                         {
                             int newScore = int.Parse(noScoreArray[x, y - 1]) + 1;
                             noScoreArray[x, y - 1] = newScore.ToString();
                         }
                         if ((x + 1 <= xUpperBound) && (y - 1 >= 0))
                         {
                             int newScore = int.Parse(noScoreArray[x + 1, y - 1]) + 1;
                             noScoreArray[x + 1, y - 1] = newScore.ToString();
                         }
                         if (x + 1 <= xUpperBound)
                         {
                             int newScore = int.Parse(noScoreArray[x + 1, y]) + 1;
                             noScoreArray[x + 1, y] = newScore.ToString();
                         }

                         if ((x + 1 <= xUpperBound) && (y + 1 <= yUpperBound))
                         {
                             int newScore = int.Parse(noScoreArray[x + 1, y + 1]) + 1;
                             noScoreArray[x + 1, y + 1] = newScore.ToString();
                         }

                         if (y + 1 <= yUpperBound)
                         {
                             int newScore = int.Parse(noScoreArray[x, y + 1]) + 1;
                             noScoreArray[x, y + 1] = newScore.ToString();
                         }

                         if ((x - 1 >= 0) && (y + 1 <= yUpperBound))
                         {
                             int newScore = int.Parse(noScoreArray[x - 1, y + 1]) + 1;
                             noScoreArray[x - 1, y + 1] = newScore.ToString();
                         }

                         if (x - 1 >= 0)
                         {
                             int newScore = int.Parse(noScoreArray[x - 1, y]) + 1;
                             noScoreArray[x - 1, y] = newScore.ToString();
                         }

                     }
                     
                     
                     //Console.WriteLine(value);
                 }
             }

             for (int i = 0; i < Rows; i++)
             {
                 for (int j = 0; j < Columns; j++)
                 {
                     Console.WriteLine("[{0},{1}] = {2}", i, j, noScoreArray[i, j]);
                 }
             }
             
             return noScoreArray;
         }

    }
}