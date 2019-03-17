using Microsoft.VisualStudio.TestTools.UnitTesting;
using TurtleLibrary;

namespace Test
{
    [TestClass]
    public class TestPoint
    {
        [TestMethod]
        public void CreatePoint()
        {
            Point point;
            // Arrange
            point = new Point(3, 3);

            // Assert
            Assert.AreEqual(3, point.Y);
        }
    }
}
