using ForegroundShapesDetector.Library.Models;
using ForegroundShapesDetector.Library.Models.Shapes;

namespace ForegroundShapesDetector.Tests.ModelTests
{
    [TestFixture]
    public class TriangleTests
    {
        [Test]
        public void Constructor_ThrowsException_WhenPointIsNull()
        {
            // Arrange
            var a = new Point(0, 0);
            var b = new Point(0, 1);
            Point c = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Triangle(a, b, c));
        }

        [Test]
        public void Constructor_ThrowsException_WhenPointsAreInvalid()
        {
            // Arrange
            Point a = new Point(0, 0);
            Point b = new Point(0, 1);
            Point c = new Point(0, 2);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
        }

        [Test]
        public void GetSquare_ReturnsCorrectValue()
        {
            // Arrange
            Point a = new Point(0, 0);
            Point b = new Point(3, 0);
            Point c = new Point(0, 4);
            Triangle triangle = new Triangle(a, b, c);

            // Act
            double square = triangle.GetSquare();

            // Assert
            Assert.AreEqual(6, square);
        }
    }
}
