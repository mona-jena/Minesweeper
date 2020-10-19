using System;

namespace Minesweeper
{
    public class ConsoleActions : IConsole
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
        
        public void Write(string message)
        {
            Console.Write(message);
        }
    }
}