using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    public class MinefieldScorer
    {
        private readonly IReader _reader;

        private readonly List<Minefield> _listOfMinefields = new List<Minefield>();

        public MinefieldScorer(IReader reader)
        {
            _reader = reader ?? throw new ArgumentException(nameof(reader));
        }

        public void Run()
        {
            var content = _reader.Read();
            var minefield = new Minefield();
            _listOfMinefields.Add(minefield);
            
            foreach(var line in content)
            {
                if ( line == "")
                {
                    minefield = new Minefield();
                    _listOfMinefields.Add(minefield);
                    continue;
                }
                minefield.AddLine(line);
            }

            PrintMinefield();
        }


        public string PrintMinefield()
        {
            return string.Join("\n\n",_listOfMinefields.Select(m => m.MinefieldArrayToString()));
        }
    }
}