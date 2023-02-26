using ForegroundShapesDetector.Library.Models;
using ForegroundShapesDetector.Library.Models.Shapes;

namespace ForegroundShapesDetector.Tests.ModelTests
{
    [TestFixture]
    public class RectangleTests
    {
        [Test]
        public void Constructor_ThrowsException_WhenTopLeftPointIsNull()
        {
            // Arrange
            Point topLeftPoint = null;
            double width = 10;
            double height = 20;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Rectangle(topLeftPoint, width, height));
        }

        [Test]
        public void Constructor_ThrowsException_WhenWidthIsLessThanOrEqualToZero()
        {
            // Arrange
            Point topLeftPoint = new Point(0, 0);
            double width = 0;
            double height = 20;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Rectangle(topLeftPoint, width, height));
        }

        [Test]
        public void Constructor_ThrowsException_WhenHeightIsLessThanOrEqualToZero()
        {
            // Arrange
            Point topLeftPoint = new Point(0, 0);
            double width = 10;
            double height = 0;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Rectangle(topLeftPoint, width, height));
        }

        [Test]
        public void GetSquare_ReturnsCorrectValue()
        {
            // Arrange
            Point topLeftPoint = new Point(0, 0);
            double width = 10;
            double height = 20;
            Rectangle rectangle = new Rectangle(topLeftPoint, width, height);

            // Act
            double square = rectangle.GetSquare();

            // Assert
            Assert.AreEqual(width * height, square);
        }
    }
}
