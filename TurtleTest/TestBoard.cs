using Microsoft.VisualStudio.TestTools.UnitTesting;
using TurtleLibrary;

namespace Test
{
    [TestClass]
    public class TestBoard
    {
        [TestMethod]
        public void CreateBoard()
        {
            // Arrange
            Board board;

            // Act
            board = new Board(4, 5);

            // Assert
            const int width = 5, height = 4;
            Assert.AreEqual(width, board.Width);
            Assert.AreEqual(height,  board.Height);
        }
        [TestMethod]
        public void SetTileOnBoard()
        {
            // Arrange
            Board board = new Board(4, 5);
            Point pos = new Point(2, 2);
            Tile tile = new Tile() { Position = pos };

            // Act
            board[pos] = tile;

            // Assert
            Assert.AreEqual(tile, board[pos] as Tile);
        }
    }
}
