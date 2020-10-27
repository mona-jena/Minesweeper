using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Minesweeper
{
    public class Grid
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        private string[,] GridArray;


        public void StoreGridSize(IEnumerable<string> fileContent)
         {
             string line1 = fileContent.First().Trim();
             
             Rows = int.Parse(line1.Substring(0,1));
             Columns = int.Parse(line1.Substring(1,1));
             GridArray = new string[Rows, Columns];
             ConvertToArray(fileContent);
             AddNumbers();
         }
         
         public void ConvertToArray(IEnumerable<string> lines)
         {
             var y = 0;
             foreach (var line in lines.Skip(1))
             {
                 var x = 0;
                 foreach (var character in line.Trim())
                 {
                     if (character.ToString() == "*")
                     {
                         GridArray[x, y] = character.ToString();
                     }
                     else if (character.ToString() == ".")
                     {
                         GridArray[x, y] = "0";
                     }
                     x++;
                 }
                 y++;
             }

             for (int i = 0; i < Rows; i++)
             {
                 for (int j = 0; j < Columns; j++)
                 {
                     Debug.WriteLine("[{0},{1}] = {2}", i, j, GridArray[i, j]);
                 }
             }
             
         }

         private void AddNumbers()
         {
             int xUpperBound = GridArray.GetUpperBound(0);
             int yUpperBound = GridArray.GetUpperBound(1);
             for (int x = 0; x <= xUpperBound; x++) {
                 for (int y = 0; y <= yUpperBound; y++) {
                     string value = GridArray[x, y];

                     if (value == "*")
                     {
                         if ((x - 1 >= 0) && (y - 1 >= 0))
                         {
                             int coordinateScore;
                             bool success = Int32.TryParse(GridArray[x - 1, y - 1], out coordinateScore);
                             if (success)
                             {
                                 GridArray[x - 1, y - 1] = (coordinateScore + 1).ToString();
                             }
                         }

                         if (y - 1 >= 0)
                         {
                             int coordinateScore;
                             bool success = Int32.TryParse(GridArray[x, y - 1], out coordinateScore);
                             if (success)
                             {
                                 GridArray[x, y - 1] = (coordinateScore + 1).ToString();
                             }
                         }

                         if ((x + 1 <= xUpperBound) && (y - 1 >= 0))
                         {
                             int coordinateScore;
                             bool success = Int32.TryParse(GridArray[x + 1, y - 1], out coordinateScore);
                             if (success)
                             {
                                 GridArray[x + 1, y - 1] = (coordinateScore + 1).ToString();
                             }
                         }

                         if (x + 1 <= xUpperBound)
                         {
                             int coordinateScore;
                             bool success = Int32.TryParse(GridArray[x + 1, y], out coordinateScore);
                             if (success)
                             {
                                 GridArray[x + 1, y] = (coordinateScore + 1).ToString();
                             }
                         }

                         if ((x + 1 <= xUpperBound) && (y + 1 <= yUpperBound))
                         {
                             int coordinateScore;
                             bool success = Int32.TryParse(GridArray[x + 1, y + 1], out coordinateScore);
                             if (success)
                             {
                                 GridArray[x + 1, y + 1] = (coordinateScore + 1).ToString();
                             }
                         }

                         if (y + 1 <= yUpperBound)
                         {
                             int coordinateScore;
                             bool success = Int32.TryParse(GridArray[x, y + 1], out coordinateScore);
                             if (success)
                             {
                                 GridArray[x, y + 1] = (coordinateScore + 1).ToString();
                             }
                         }

                         if ((x - 1 >= 0) && (y + 1 <= yUpperBound))
                         {
                             int coordinateScore;
                             bool success = Int32.TryParse(GridArray[x - 1, y + 1], out coordinateScore);
                             if (success)
                             {
                                 GridArray[x - 1, y + 1] = (coordinateScore + 1).ToString();
                             }
                         }

                         if (x - 1 >= 0)
                         {
                             int coordinateScore;
                             bool success = Int32.TryParse(GridArray[x - 1, y], out coordinateScore);
                             if (success)
                             {
                                 GridArray[x - 1, y] = (coordinateScore + 1).ToString();
                             }
                         }
                     }
                 }
             }

             for (int i = 0; i < Rows; i++)
             {
                 for (int j = 0; j < Columns; j++)
                 {
                     Debug.WriteLine("[{0},{1}] = {2}", i, j, GridArray[i, j]);
                 }
             }
             
         }
         
         
         public string PrintGrid()
         {
             string matrixGrid = "";
             for (int y = 0; y < GridArray.GetLength(1); y++)
             {
                 for (int x = 0; x < GridArray.GetLength(0); x++)
                 {
                     matrixGrid += GridArray[x, y];
                 }

                 matrixGrid += "\n";
             }

             return matrixGrid;
         }

    }
}