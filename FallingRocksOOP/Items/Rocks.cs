namespace FallingRocksOOP.Items
{
    using System;

    public class Rocks : Item
    {
        private readonly ConsoleColor[] colors =
            {
                ConsoleColor.Yellow,
                ConsoleColor.DarkGreen,
                ConsoleColor.Cyan,
                ConsoleColor.Green,
                ConsoleColor.Blue,
                ConsoleColor.Magenta,
                ConsoleColor.White,
                ConsoleColor.Red,
                ConsoleColor.Gray
            };

        private readonly char[] rocks = { '!', '@', '#', '&', '$', '%', '*', '-', ']', '/' };

        private readonly Random rnd = new Random(DateTime.Now.Millisecond);

        public Rocks()
        {
            this.Type = this.rocks[this.rnd.Next(0, this.rocks.Length)];
            this.ForegroundColor = this.colors[this.rnd.Next(0, this.colors.Length)];
            this.BackgroundColor = ConsoleColor.Black;
        }

        public override void Execute()
        {
            throw new CrashExeption();
        }
    }
}
