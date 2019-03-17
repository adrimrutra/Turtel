using Microsoft.VisualStudio.TestTools.UnitTesting;
using TurtleLibrary;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class TestReader
    {
        [TestMethod]
        public void ReadSetting()
        {
            // Arrange
            Reader reader = Reader.Instance(@"../../test-game-settings");

            // Act
            Settings actual = reader.GetSettings();

            // Assert
            Settings expected = new Settings()
            {
                BoardHeight = 4,
                BoardWidth = 5,
                MineList = new List<Point>() { new Point(1, 1) },
                ExitPoint = new Point(4, 2),
                TurtlePosition = new Point(0, 1),
                TurtleDirection = "N",
                Moves = new string[] { "MRMMMMRMM" }
            };
            Assert.AreEqual(expected.BoardHeight, actual.BoardHeight);
            Assert.AreEqual(expected.BoardWidth, actual.BoardWidth);
            CollectionAssert.AreEquivalent(expected.MineList, actual.MineList);
            Assert.AreEqual(expected.TurtlePosition.X, actual.TurtlePosition.X);
            Assert.AreEqual(expected.TurtlePosition.Y, actual.TurtlePosition.Y);
            Assert.AreEqual(expected.TurtleDirection, actual.TurtleDirection);
            CollectionAssert.AreEquivalent(expected.Moves, actual.Moves);
        }
    }
}
