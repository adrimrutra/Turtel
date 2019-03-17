using Microsoft.VisualStudio.TestTools.UnitTesting;
using TurtleLibrary;
using TurtleLibrary.BusinessLogic;

namespace Test
{
    
    [TestClass]
    public class TestObserver
    {
        [TestMethod]
        public void ObsorveIfMine()
        {
            // Arrange
            Board board = new Board(4, 5);
            Point pos = new Point(2, 2);
            Mine mine = new Mine() { Position = pos };
            board[pos] = mine;
            Observer observer = new Observer(board);

            // Act
            IsMine actual = observer.Observe(pos) as IsMine;

            // Assert
            Assert.IsInstanceOfType(actual, typeof(IsMine));
        }

        [TestMethod]
        public void ObsorveIfExit()
        {
            // Arrange
            Board board = new Board(4, 5);
            Point pos = new Point(2, 2);
            Exit exit = new Exit() { Position = pos };
            board[pos] = exit;
            Observer observer = new Observer(board);

            // Act
            IsExit actual = observer.Observe(pos) as IsExit;

            // Assert
            Assert.IsInstanceOfType(actual, typeof(IsExit));
        }
        [TestMethod]
        public void ObsorveIfDanger()
        {
            // Arrange
            Board board = new Board(4, 5);
            Point pos = new Point(2, 2);
            Turtle turtle = Turtle.Instance(pos);
            board[pos] = turtle;
            Observer observer = new Observer(board);

            // Act
            IsDanger actual = observer.Observe(pos) as IsDanger;

            // Assert
            Assert.IsInstanceOfType(actual,typeof(IsDanger));
        }
        [TestMethod]
        public void ObsorveIfOutOfRange()
        {
            // Arrange
            Board board = new Board(4, 5);
            Point pos = new Point(9, 9);
            Observer observer = new Observer(board);

            // Act
            IsOutOfRange actual = observer.Observe(pos) as IsOutOfRange;

            // Assert
            Assert.IsInstanceOfType(actual, typeof(IsOutOfRange));
        }
    }
}
