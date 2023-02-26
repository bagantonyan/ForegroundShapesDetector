using ForegroundShapesDetector.Library.Models;
using ForegroundShapesDetector.Library.Models.Shapes;

namespace ForegroundShapesDetector.Tests.ModelTests
{
    [TestFixture]
    public class CircleTests
    {
        [Test]
        public void Constructor_ThrowsException_WhenCenterPointIsNull()
        {
            // Arrange
            Point center = null;
            double radius = 1;

            // Act + Assert
            Assert.Throws<ArgumentNullException>(() => new Circle(center, radius));
        }

        [Test]
        public void Constructor_ThrowsException_WhenRadiusIsNegativePointIsNull()
        {
            // Arrange
            Point center = new Point(0, 0);
            double radius = -1;

            // Act + Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(center, radius));
        }

        [Test]
        public void GetSquare_ReturnsCorrectValue()
        {
            // Arrange
            Point center = new Point(0, 0);
            double radius = 1;
            Circle circle = new Circle(center, radius);

            // Act
            double square = circle.GetSquare();

            // Assert
            Assert.That(square, Is.EqualTo(Math.PI));
        }
    }
}
