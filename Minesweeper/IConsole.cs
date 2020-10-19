namespace Minesweeper
{
    public interface IConsole
    {
        public string ReadLine();

        public void WriteLine(string message);

        public void Write(string message);
    }

}