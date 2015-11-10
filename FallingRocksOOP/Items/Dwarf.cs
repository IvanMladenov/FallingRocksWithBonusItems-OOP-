namespace FallingRocksOOP.Items
{
    using System;

    class Dwarf
    {
        private static string dwarf = "<0>";

        public Dwarf()
        {
            this.Position = new Position(Console.WindowWidth/2-2, Console.WindowHeight-1);
            this.Color = ConsoleColor.Gray;
        }

        public Position Position { get; set; }

        public ConsoleColor Color { get; private set; }

        public override string ToString()
        {
            return dwarf;
        }
    }
}
