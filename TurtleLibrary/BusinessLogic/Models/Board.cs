namespace TurtleLibrary
{
    public class Board
    {
        private Tile[][] tiles;
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Board(int x, int y)
        {
            Width = y;
            Height = x;
            tiles = new Tile[x][];
            for (int i = 0; i < x; i++)
            {
                tiles[i] = new Tile[y];
                for (int j = 0; j < y; j++)
                {
                    tiles[i][j] = new Tile() { Position = new Point { X = i, Y = j } };
                }
            }   
        }

        public Tile this[Point point]
        {
            get { return tiles[point.X][point.Y]; }
            set { tiles[point.X][point.Y] = value; }
        }
    }
}
