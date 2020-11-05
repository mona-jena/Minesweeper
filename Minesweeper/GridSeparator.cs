using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    public class GridSeparator
    {
        private IList<string> _fileContent;
        
        public GridSeparator(IList<string> file)
        {
            _fileContent = file;
        }

        public void SeperateEachGrid()
        {
            foreach(var line in _fileContent.Skip(1))
            {
                var isNumber = int.TryParse(line.Substring(0), out int result);
                if (isNumber)
                {
                    var grid = new Grid(null);
                    grid.Run();
                }
            }
        }
        
        
    }
}