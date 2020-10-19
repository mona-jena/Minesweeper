using System;
using System.Collections;
using System.Collections.Generic;

namespace Minesweeper
{
    public class Game
    {
        public static void Main(string[] args)
        {
            var sr = new FileUtils();
            Helper helper = new Helper(new ConsoleActions());
            IEnumerable<string> fileContent = helper.ReadFile(sr);
            var grid = new Grid();
            /*if (fileContent != null)
            {
                grid.BuildGrid(fileContent);
            }*/
        }
    }
}