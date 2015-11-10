namespace FallingRocksOOP.Items
{
    using System;

    using FallingRocksOOP.Exeptions;

    public class Speed:Item
    {
        private const char S = 'S';

        public Speed()
        {
            this.Type = S;
            this.BackgroundColor = ConsoleColor.Green;
        }

        public override void Execute()
        {
            throw new SpeedExeption();
        }
    }
}