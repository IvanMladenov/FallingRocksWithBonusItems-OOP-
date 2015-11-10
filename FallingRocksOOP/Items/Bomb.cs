namespace FallingRocksOOP.Items
{
    using System;

    using FallingRocksOOP.Exeptions;

    public class Bomb:Item
    {
        private const char B = 'B';

        public Bomb()
        {
            this.Type = B;
            this.BackgroundColor = ConsoleColor.Red;
        }

        public override void Execute()
        {
            throw new BombExeption();
        }
    }
}