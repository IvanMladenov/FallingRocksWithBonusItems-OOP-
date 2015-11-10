namespace FallingRocksOOP.Items
{
    using System;

    public class Freeze : Item
    {
        private const char F = 'F';

        public Freeze()
        {
            this.Type = F;
            this.BackgroundColor = ConsoleColor.Blue;
        }

        public override void Execute()
        {
            
        }
    }
}