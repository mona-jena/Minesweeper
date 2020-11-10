using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    public class Grid
    {
        private string[,] _gridArray;

        private int YMax { get; set; }
        private int XMax { get; set; }
        
        private readonly List<string> _listOfStrings = new List<string>();

        public void AddLine(string line)
        {
            _listOfStrings.Add(line);
        }

        private void Build()
        {
            StoreGridSize(_listOfStrings);
            ConvertToArray(_listOfStrings);
            UpdateGridWithScore();
        }

        private void StoreGridSize(IEnumerable<string> fileContent)
        {
            string line1 = fileContent.First().Trim();
            YMax = int.Parse(line1.Substring(0, 1));
            XMax = int.Parse(line1.Substring(1, 1));
            _gridArray = new string[YMax, XMax];
        }

        private void ConvertToArray(IEnumerable<string> lines)
        {
            var y = 0;
            foreach (var line in lines)
            {
                var isNumber = int.TryParse(line.Substring(0), out var _);
                if (!isNumber)
                {
                    var x = 0;
                    foreach (var character in line.Trim())
                    {
                        var newCharacter = "0";
                        if (character.ToString() == "*")
                        {
                            newCharacter = character.ToString();
                        }

                        _gridArray[y, x++] = newCharacter;
                    }
                    y++;
                }
            }
        }

        private void UpdateGridWithScore()
        {
            for (int y = 0; y < YMax; y++)
            {
                for (int x = 0; x < XMax; x++)
                {
                    if (_gridArray[y, x] == "*")
                    {
                        CalculateScore(y, x);
                    }
                }
            }
        }

        private void CalculateScore(int y, int x)
        {
            foreach (var (i, i1) in GetNeighbours(y, x))
            {
                if (int.TryParse(_gridArray[i, i1], out var number))
                {
                    _gridArray[i, i1] = (number + 1).ToString();
                }
            }
        }

        private List<(int y, int x)> GetNeighbours(int yAxis, int xAxis)
        {
            List<(int y, int x)> neighbours = new List<(int, int)>();
            var validXs = new List<int> {xAxis - 1, xAxis, xAxis + 1}.Where(x => x >= 0 && x < XMax).ToList();
            var validYs = new List<int> {yAxis - 1, yAxis, yAxis + 1}.Where(y => y >= 0 && y < YMax).ToList();

            foreach (var y in validYs)
            foreach (var x in validXs)
                neighbours.Add((y, x));

            neighbours.Remove((yAxis, xAxis));
            return neighbours;
        }
        
        public string GridToString()
        {
            Build();
            string matrixGrid = "";
            for (int y = 0; y < _gridArray.GetLength(0); y++)
            {
                for (int x = 0; x < _gridArray.GetLength(1); x++)
                {
                    matrixGrid += _gridArray[y, x];
                }

                matrixGrid += "\n";
            }
            
            return matrixGrid.Trim();
        }
        
        
    }
}