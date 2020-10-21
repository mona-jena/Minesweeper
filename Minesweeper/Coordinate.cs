using System;

namespace Minesweeper
{
    public class Coordinate
    {
        public override string ToString()
        {
            return $"x:{X}, y:{Y}";
        }

        public int X { get; set; }

        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    
}