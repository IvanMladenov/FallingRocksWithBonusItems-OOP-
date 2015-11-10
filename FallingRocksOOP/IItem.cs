namespace FallingRocksOOP
{
    using System;

    public interface IItem
    {
        char Type { get; set; }

        Position Position { get; set; }

        ConsoleColor BackgroundColor { get; set; }

        ConsoleColor ForegroundColor { get; set; }

        void Execute();
    }
}