using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TurtleLibrary;

namespace TurtleTest
{
    [TestClass]
    public class TestTurtle
    {
        [TestMethod]
        public void CreateTurtleInstance()
        {
            // Arrange
            Turtle turtle;

            // Act
            turtle = Turtle.Instance(new Point(0, 0));

            // Assert
            const int X = 0, Y = 0;
            Assert.AreEqual(X, turtle.Position.X);
            Assert.AreEqual(Y, turtle.Position.Y);
        }
        [TestMethod]
        public void MoveTurtleForward()
        {
            // Arrange
            Turtle turtle = Turtle.Instance(new Point(0, 0));
            turtle.TurtleDirection = Direction.E;

            // Act
            turtle.Move(Move.M);

            // Assert
            const int X = 1, Y = 0;
            Assert.AreEqual(X, turtle.Position.X);
            Assert.AreEqual(Y, turtle.Position.Y);
        }
        [TestMethod]
        public void TurnTurtleLeftFromNordToWest()
        {
            // Arrange
            Turtle turtle = Turtle.Instance(new Point(0, 0));
            turtle.TurtleDirection = Direction.N;

            // Act
            turtle.Move(Move.L);

            // Assert
            Assert.AreEqual(Direction.W, turtle.TurtleDirection);
        }
        [TestMethod]
        public void TurnTurtleRightFromNordToEast()
        {
            // Arrange
            Turtle turtle = Turtle.Instance(new Point(0, 0));
            turtle.TurtleDirection = Direction.N;

            // Act
            turtle.Move(Move.R);

            // Assert
            Assert.AreEqual(Direction.E, turtle.TurtleDirection);
        }
        [TestMethod]
        public void TurnTurtleLeftFromEastToNord()
        {
            // Arrange
            Turtle turtle = Turtle.Instance(new Point(0, 0));
            turtle.TurtleDirection = Direction.E;

            // Act
            turtle.Move(Move.L);

            // Assert
            Assert.AreEqual(Direction.N, turtle.TurtleDirection);
        }
        [TestMethod]
        public void TurnTurtleRightFromEastToSouth()
        {
            // Arrange
            Turtle turtle = Turtle.Instance(new Point(0, 0));
            turtle.TurtleDirection = Direction.E;

            // Act
            turtle.Move(Move.R);

            // Assert
            Assert.AreEqual(Direction.S, turtle.TurtleDirection);
        }
        [TestMethod]
        public void TurnTurtleLeftFromSouthToEast()
        {
            // Arrange
            Turtle turtle = Turtle.Instance(new Point(0, 0));
            turtle.TurtleDirection = Direction.S;

            // Act
            turtle.Move(Move.L);

            // Assert
            Assert.AreEqual(Direction.E, turtle.TurtleDirection);
        }
        [TestMethod]
        public void TurnTurtleRightFromSouthToWest()
        {
            // Arrange
            Turtle turtle = Turtle.Instance(new Point(0, 0));
            turtle.TurtleDirection = Direction.S;

            // Act
            turtle.Move(Move.R);

            // Assert
            Assert.AreEqual(Direction.W, turtle.TurtleDirection);
        }
        [TestMethod]
        public void TurnTurtleLeftFromWestToSouth()
        {
            // Arrange
            Turtle turtle = Turtle.Instance(new Point(0, 0));
            turtle.TurtleDirection = Direction.W;

            // Act
            turtle.Move(Move.L);

            // Assert
            Assert.AreEqual(Direction.S, turtle.TurtleDirection);
        }
        [TestMethod]
        public void TurnTurtleRightFromWestToNord()
        {
            // Arrange
            Turtle turtle = Turtle.Instance(new Point(0, 0));
            turtle.TurtleDirection = Direction.W;

            // Act
            turtle.Move(Move.R);

            // Assert
            Assert.AreEqual(Direction.N, turtle.TurtleDirection);
        }
    }
}
