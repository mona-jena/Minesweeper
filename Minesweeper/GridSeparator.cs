using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    public class GridSeparator
    {
        private readonly IReader _fileHandler;

        private readonly List<Grid> _listOfGrids = new List<Grid>();

        public GridSeparator(IReader fileHandler)
        {
            _fileHandler = fileHandler ?? throw new ArgumentException(nameof(fileHandler));
        }

        public void Run()
        {
            var fileContent = _fileHandler.Read();
            var grid = new Grid();
            _listOfGrids.Add(grid);
            
            foreach(var line in fileContent)
            {
                if ( line == "")
                {
                    grid = new Grid();
                    _listOfGrids.Add(grid);
                    continue;
                }
                grid.AddLine(line);
            }

            PrintGrid();
        }


        public string PrintGrid()
        {
            return string.Join("\n\n",_listOfGrids.Select(g => g.GridToString()));
        }
    }
}