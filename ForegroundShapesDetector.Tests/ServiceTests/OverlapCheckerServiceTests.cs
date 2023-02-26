using ForegroundShapesDetector.Library.Models;
using ForegroundShapesDetector.Library.Models.Shapes;
using ForegroundShapesDetector.Library.Services.Implementations;
using ForegroundShapesDetector.Library.Services.Interfaces;

namespace ForegroundShapesDetector.Tests.ServiceTests
{
    [TestFixture]
    public class OverlapCheckerServiceTests
    {
        private IOverlapCheckerService _overlapCheckerService;

        [SetUp]
        public void SetUp()
        {
            _overlapCheckerService = new OverlapCheckerService();
        }

        [Test]
        public void CheckOverlap_ShouldReturnTrue_WhenTwoLineSegmentsOverlap()
        {
            // Arrange
            var line1 = new LineSegment(new Point(0, 0), new Point(10, 10));
            var line2 = new LineSegment(new Point(0, 10), new Point(10, 0));

            // Act
            var result = _overlapCheckerService.CheckOverlap(line1, line2);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnFalse_WhenTwoLineSegmentsDoNotOverlap()
        {
            // Arrange
            var line1 = new LineSegment(new Point(0, 0), new Point(10, 10));
            var line2 = new LineSegment(new Point(0, 10), new Point(15, 17));

            // Act
            var result = _overlapCheckerService.CheckOverlap(line1, line2);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnTrue_WhenLineSegmentAndTriangleOverlap_Intersection()
        {
            // Arrange
            var line = new LineSegment(new Point(0, 0), new Point(10, 0));
            var triangle = new Triangle(new Point(5, 0), new Point(15, 0), new Point(10, 10));

            // Act
            var result = _overlapCheckerService.CheckOverlap(line, triangle);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnTrue_WhenLineSegmentAndTriangleOverlap_Inside()
        {
            // Arrange
            var line = new LineSegment(new Point(2, 2), new Point(4, 1));
            var triangle = new Triangle(new Point(0, 0), new Point(3, 5), new Point(7, 0));

            // Act
            var result = _overlapCheckerService.CheckOverlap(line, triangle);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnFalse_WhenLineSegmentAndTriangleDoNotOverlap()
        {
            // Arrange
            var line = new LineSegment(new Point(0, 0), new Point(10, 0));
            var triangle = new Triangle(new Point(5, 5), new Point(15, 6), new Point(11, 11));

            // Act
            var result = _overlapCheckerService.CheckOverlap(line, triangle);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnTrue_WhenLineSegmentAndRectangleOverlap_Intersection()
        {
            // Arrange
            var line = new LineSegment(new Point(2, 2), new Point(4, 5));
            var rectangle = new Rectangle(new Point(0, 4), 6, 4);

            // Act
            var result = _overlapCheckerService.CheckOverlap(line, rectangle);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnTrue_WhenLineSegmentAndRectangleOverlap_Inside()
        {
            // Arrange
            var line = new LineSegment(new Point(2, 2), new Point(5, 2));
            var rectangle = new Rectangle(new Point(0, 4), 6, 4);

            // Act
            var result = _overlapCheckerService.CheckOverlap(line, rectangle);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnFalse_WhenLineSegmentAndRectangleDoNotOverlap()
        {
            // Arrange
            var line = new LineSegment(new Point(8, 3), new Point(9, 5));
            var rectangle = new Rectangle(new Point(0, 4), 6, 4);

            // Act
            var result = _overlapCheckerService.CheckOverlap(line, rectangle);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnTrue_WhenLineSegmentAndCircleOverlap_Intersection()
        {
            // Arrange
            var line = new LineSegment(new Point(4, 4), new Point(7, 7));
            var circle = new Circle(new Point(3, 3), 3);

            // Act
            var result = _overlapCheckerService.CheckOverlap(line, circle);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnTrue_WhenLineSegmentAndCircleOverlap_Touch()
        {
            // Arrange
            var line = new LineSegment(new Point(0, 6), new Point(6, 6));
            var circle = new Circle(new Point(3, 3), 3);

            // Act
            var result = _overlapCheckerService.CheckOverlap(line, circle);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnTrue_WhenLineSegmentAndCircleOverlap_Inside()
        {
            // Arrange
            var line = new LineSegment(new Point(4, 4), new Point(2, 2));
            var circle = new Circle(new Point(3, 3), 3);

            // Act
            var result = _overlapCheckerService.CheckOverlap(line, circle);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnTrue_WhenLineSegmentAndCircleOverlap_IntersectsInTwoPoints()
        {
            // Arrange
            var line = new LineSegment(new Point(2, 7), new Point(7, 2));
            var circle = new Circle(new Point(3, 3), 3);

            // Act
            var result = _overlapCheckerService.CheckOverlap(line, circle);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnFalse_WhenLineSegmentAndCircleDoNotOverlap()
        {
            // Arrange
            var line = new LineSegment(new Point(6, 6), new Point(7, 7));
            var circle = new Circle(new Point(3, 3), 3);

            // Act
            var result = _overlapCheckerService.CheckOverlap(line, circle);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnTrue_WhenTwoTrianglesOverlap_Intersection()
        {
            // Arrange
            var triangle1 = new Triangle(new Point(0, 0), new Point(3, 5), new Point(7, 0));
            var triangle2 = new Triangle(new Point(3, 3), new Point(6, 6), new Point(8, 3));

            // Act
            var result = _overlapCheckerService.CheckOverlap(triangle1, triangle2);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnTrue_WhenTwoTrianglesOverlap_Inside()
        {
            // Arrange
            var triangle1 = new Triangle(new Point(0, 0), new Point(3, 5), new Point(7, 0));
            var triangle2 = new Triangle(new Point(2, 2), new Point(3, 3), new Point(5, 1));

            // Act
            var result = _overlapCheckerService.CheckOverlap(triangle1, triangle2);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnFalse_WhenTwoTrianglesDoNotOverlap()
        {
            // Arrange
            var triangle1 = new Triangle(new Point(0, 0), new Point(3, 5), new Point(7, 0));
            var triangle2 = new Triangle(new Point(6, 4), new Point(7, 7), new Point(9, 5));

            // Act
            var result = _overlapCheckerService.CheckOverlap(triangle1, triangle2);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnTrue_WhenTriangleAndRectangleOverlap_Intersection()
        {
            // Arrange
            var triangle = new Triangle(new Point(2, 2), new Point(5, 3), new Point(3, 5));
            var rectangle = new Rectangle(new Point(0, 4), 6, 4);

            // Act
            var result = _overlapCheckerService.CheckOverlap(triangle, rectangle);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnTrue_WhenTriangleAndRectangleOverlap_TriangleIsInside()
        {
            // Arrange
            var triangle = new Triangle(new Point(2, 2), new Point(5, 3), new Point(4, 1));
            var rectangle = new Rectangle(new Point(0, 4), 6, 4);

            // Act
            var result = _overlapCheckerService.CheckOverlap(triangle, rectangle);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnTrue_WhenTriangleAndRectangleOverlap_RectangleIsIsInside()
        {
            // Arrange
            var triangle = new Triangle(new Point(0, 0), new Point(3, 6), new Point(7, 0));
            var rectangle = new Rectangle(new Point(2, 2), 2, 1);

            // Act
            var result = _overlapCheckerService.CheckOverlap(triangle, rectangle);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnFalse_WhenTriangleAndRectangleDoNotOverlap()
        {
            // Arrange
            var triangle = new Triangle(new Point(8, 3), new Point(6, 6), new Point(9, 5));
            var rectangle = new Rectangle(new Point(0, 4), 6, 4);

            // Act
            var result = _overlapCheckerService.CheckOverlap(triangle, rectangle);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnTrue_WhenTriangleAndCircleOverlap_Intersection()
        {
            // Arrange
            var triangle = new Triangle(new Point(3, 3), new Point(6, 6), new Point(9, 5));
            var circle = new Circle(new Point(3, 3), 3);

            // Act
            var result = _overlapCheckerService.CheckOverlap(triangle, circle);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnTrue_WhenTriangleAndCircleOverlap_TriangleIsInside()
        {
            // Arrange
            var triangle = new Triangle(new Point(2, 2), new Point(4, 1), new Point(5, 3));
            var circle = new Circle(new Point(3, 3), 3);

            // Act
            var result = _overlapCheckerService.CheckOverlap(triangle, circle);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnTrue_WhenTriangleAndCircleOverlap_CircleIsInside()
        {
            // Arrange
            var triangle = new Triangle(new Point(0, 0), new Point(3, 6), new Point(7, 0));
            var circle = new Circle(new Point(3, 2), 1);

            // Act
            var result = _overlapCheckerService.CheckOverlap(triangle, circle);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnFalse_WhenTriangleAndCircleDoNotOverlap()
        {
            // Arrange
            var triangle = new Triangle(new Point(9, 5), new Point(6, 6), new Point(7, 7));
            var circle = new Circle(new Point(3, 3), 3);

            // Act
            var result = _overlapCheckerService.CheckOverlap(triangle, circle);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnTrue_WhenTwoRectanglesOverlap_Intersection()
        {
            // Arrange
            var rectangle1 = new Rectangle(new Point(0, 4), 6, 4);
            var rectangle2 = new Rectangle(new Point(3, 6), 4, 3);

            // Act
            var result = _overlapCheckerService.CheckOverlap(rectangle1, rectangle2);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnTrue_WhenTwoRectanglesOverlap_Inside()
        {
            // Arrange
            var rectangle1 = new Rectangle(new Point(2, 3), 3, 2);
            var rectangle2 = new Rectangle(new Point(0, 4), 6, 4);

            // Act
            var result = _overlapCheckerService.CheckOverlap(rectangle1, rectangle2);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnFalse_WhenTwoRectanglesDoNotOverlap()
        {
            // Arrange
            var rectangle1 = new Rectangle(new Point(0, 4), 6, 4);
            var rectangle2 = new Rectangle(new Point(8, 3), 2, 1);

            // Act
            var result = _overlapCheckerService.CheckOverlap(rectangle1, rectangle2);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnTrue_WhenRectangleAndCircleOverlap_Intersection()
        {
            // Arrange
            var rectangle = new Rectangle(new Point(5, 7), 5, 4);
            var circle = new Circle(new Point(3, 3), 3);

            // Act
            var result = _overlapCheckerService.CheckOverlap(rectangle, circle);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnTrue_WhenRectangleAndCircleOverlap_RectangleIsInside()
        {
            // Arrange
            var rectangle = new Rectangle(new Point(2, 4), 2, 1);
            var circle = new Circle(new Point(3, 3), 3);

            // Act
            var result = _overlapCheckerService.CheckOverlap(rectangle, circle);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnTrue_WhenRectangleAndCircleOverlap_CircleIsInside()
        {
            // Arrange
            var rectangle = new Rectangle(new Point(0, 4), 6, 4);
            var circle = new Circle(new Point(3, 2), 1);

            // Act
            var result = _overlapCheckerService.CheckOverlap(rectangle, circle);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnFalse_WhenRectangleAndCircleDoNotOverlap()
        {
            // Arrange
            var rectangle = new Rectangle(new Point(0, 4), 6, 4);
            var circle = new Circle(new Point(7, 7), 1);

            // Act
            var result = _overlapCheckerService.CheckOverlap(rectangle, circle);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnTrue_WhenTwoCirclesOverlap_Intersection()
        {
            // Arrange
            var circle1 = new Circle(new Point(3, 3), 3);
            var circle2 = new Circle(new Point(5, 7), 4);

            // Act
            var result = _overlapCheckerService.CheckOverlap(circle1, circle2);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnTrue_WhenTwoCirclesOverlap_Inside()
        {
            // Arrange
            var circle1 = new Circle(new Point(3, 3), 3);
            var circle2 = new Circle(new Point(4, 3), 1);

            // Act
            var result = _overlapCheckerService.CheckOverlap(circle1, circle2);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckOverlap_ShouldReturnFalse_WhenTwoCirclesDoNotOverlap()
        {
            // Arrange
            var circle1 = new Circle(new Point(3, 3), 3);
            var circle2 = new Circle(new Point(9, 5), 1);

            // Act
            var result = _overlapCheckerService.CheckOverlap(circle1, circle2);

            // Assert
            Assert.IsFalse(result);
        }
    }
}