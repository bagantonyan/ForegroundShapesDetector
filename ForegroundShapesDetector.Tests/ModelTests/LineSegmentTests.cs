using ForegroundShapesDetector.Library.Models;
using ForegroundShapesDetector.Library.Models.Shapes;

namespace ForegroundShapesDetector.Tests.ModelTests
{
    [TestFixture]
    public class LineSegmentTests
    {
        [Test]
        public void Constructor_ThrowsException_WhenAPointIsNull()
        {
            // Arrange
            Point a = new Point(0, 0);
            Point b = null;

            // Act + Assert
            Assert.Throws<ArgumentNullException>(() => new LineSegment(a, b));
        }

        [Test]
        public void Constructor_ThrowsException_WhenBPointIsNull()
        {
            // Arrange
            Point a = null;
            Point b = new Point(0, 0);

            // Act + Assert
            Assert.Throws<ArgumentNullException>(() => new LineSegment(a, b));
        }

        [Test]
        public void Constructor_ThrowsException_WhenBothPointsAreTheSame()
        {
            // Arrange
            Point a = new Point(0, 0);
            Point b = new Point(0, 0);

            // Act + Assert
            Assert.Throws<ArgumentException>(() => new LineSegment(a, b));
        }
    }
}