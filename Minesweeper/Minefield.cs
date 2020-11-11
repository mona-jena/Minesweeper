using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    internal class Minefield
    {
        private string[,] _minefieldArray;

        private int YMax { get; set; }
        private int XMax { get; set; }
        
        private readonly List<string> _stringMinefield = new List<string>();

        public void AddLine(string line)
        {
            _stringMinefield.Add(line);
        }
        

        private void StoreMinefieldSize(IEnumerable<string> fileContent)
        {
            string line1 = fileContent.First().Trim();
            YMax = int.Parse(line1.Substring(0, 1));
            XMax = int.Parse(line1.Substring(1, 1));
            _minefieldArray = new string[XMax, YMax];
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

                        _minefieldArray[x++, y] = newCharacter;
                    }
                    y++;
                }
            }
        }

        private void UpdateMinefieldWithScore()
        {
            for (int y = 0; y < YMax; y++)
            {
                for (int x = 0; x < XMax; x++)
                {
                    if (_minefieldArray[x, y] == "*")
                    {
                        CalculateScore(x, y);
                    }
                }
            }
        }

        private void CalculateScore(int x, int y)
        {
            foreach (var (i, i1) in GetNeighbours(x, y))
            {
                if (int.TryParse(_minefieldArray[i, i1], out var number))
                {
                    _minefieldArray[i, i1] = (number + 1).ToString();
                }
            }
        }

        private List<(int x, int y)> GetNeighbours(int xAxis, int yAxis)
        {
            List<(int x, int y)> neighbours = new List<(int, int)>();
            var validXs = new List<int> {xAxis - 1, xAxis, xAxis + 1}.Where(x => x >= 0 && x < XMax).ToList();
            var validYs = new List<int> {yAxis - 1, yAxis, yAxis + 1}.Where(y => y >= 0 && y < YMax).ToList();

            foreach (var y in validYs)
            foreach (var x in validXs)
                neighbours.Add((x, y));

            neighbours.Remove((xAxis, yAxis));
            return neighbours;
        }
        
        public string MinefieldArrayToString()
        {
            Build();
            string matrixMinefield = "";
            for (int y = 0; y < _minefieldArray.GetLength(1); y++)
            {
                for (int x = 0; x < _minefieldArray.GetLength(0); x++)
                {
                    matrixMinefield += _minefieldArray[x, y];
                }

                matrixMinefield += "\n";
            }
            
            return matrixMinefield.Trim();
        }
        
        private void Build()
        {
            StoreMinefieldSize(_stringMinefield);
            ConvertToArray(_stringMinefield);
            UpdateMinefieldWithScore();
        }
        
        
    }
}