using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Minesweeper
{
    public class Grid
    {
        public int YMax { get; set; }
        public int XMax { get; set; }

        private string[,] _gridArray;

        // MAKE IEnumerable AN ARRAY!

        public void StoreGridSize(IEnumerable<string> fileContent)
        {
            string line1 = fileContent.First().Trim();

            YMax = int.Parse(line1.Substring(0, 1));
            XMax = int.Parse(line1.Substring(1, 1));
            _gridArray = new string[YMax, XMax];
            ConvertToArray(fileContent);
            AddNumbers();
        }

        public void ConvertToArray(IEnumerable<string> lines)
        {
            var y = 0;
            while (y < YMax)
            {
                foreach (var line in lines.Skip(1))
                {
                    var x = 0;
                    while (x < XMax)
                    {
                        var eachLine = line.Trim();
                        foreach (var character in eachLine)
                        {
                            if (character.ToString() == "*")
                            {
                                _gridArray[y, x] = character.ToString();
                            }
                            else if (character.ToString() == ".")
                            {
                                _gridArray[y, x] = "0";
                            }

                            x++;
                        }
                    }

                    y++;
                }
            }
        }

        private void AddNumbers()
        {
            for (int i = 0; i < YMax; i++)
            {
                for (int j = 0; j < XMax; j++)
                {
                    if (_gridArray[j, i] == "*")
                    {
                        CalculateScore(j, i);
                    }
                }
            }
        }

        private void CalculateScore(int y, int x)
        {
            foreach (var n in GetNeighbours(x, y))
            {
                if (int.TryParse(_gridArray[n.x, n.y], out var number))
                {
                    _gridArray[n.x, n.y] = (number + 1).ToString();
                }
            }
        }

        private List<(int x, int y)> GetNeighbours(int x, int y)
        {
            List<(int x, int y)> neighbours = new List<(int, int)>();
            var xValues = new List<int> {x - 1, x, x + 1}.Where(x => x >= 0 && x < XMax);
            var yValues = new List<int> {y - 1, y, y + 1}.Where(y => y >= 0 && y < YMax);

            foreach (var i in xValues)
            foreach (var j in yValues)
                neighbours.Add((i, j));

            neighbours.Remove((x, y));

            return neighbours;
        }


        public string PrintGrid()
        {
            string matrixGrid = "";
            for (int y = 0; y < _gridArray.GetLength(1); y++)
            {
                for (int x = 0; x < _gridArray.GetLength(0); x++)
                {
                    matrixGrid += _gridArray[x, y];
                }

                matrixGrid += "\n";
            }

            return matrixGrid;
        }
    }
}