namespace FallingRocksOOP.Items
{
    using System;

    public abstract class Item:IItem
    {
        private Random rnd = new Random();

        protected Item()
        {
            this.Position = new Position(this.rnd.Next(0, Console.WindowWidth), 0);
        }

        public Position Position { get; set; }

        public char Type { get; set; }

        public ConsoleColor BackgroundColor { get; set; }

        public ConsoleColor ForegroundColor { get; set; }

        public abstract void Execute();

        public override string ToString()
        {
            return this.Type.ToString();
        }
    }
}
