using System;

namespace Minesweeper
{
    public class ConsoleActions : IConsole
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
        
    }
}