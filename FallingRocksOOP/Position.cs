namespace FallingRocksOOP
{
    public struct Position
    {
        public Position(int x, int y)
            : this()
        {
            this.X = x;
            this.Y = y;
        }

        public int Y { get; set; }

        public int X { get; set; }
    }
}
