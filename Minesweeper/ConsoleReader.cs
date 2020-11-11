using System;
using System.Collections.Generic;

namespace Minesweeper
{
    
    public class ConsoleReader : IReader
    {
        public IList<string> Read()
        {
            List<string> aList = new List<string>();
            aList.Add(Console.ReadLine());
            return aList;
        }
        
    }
}