
namespace Minesweeper
{
    public class Coordinate
    {
        private int X { get; set; }

        private int Y { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public override string ToString()
        {
            return $"x:{X}, y:{Y}";
        }
    }
    
}