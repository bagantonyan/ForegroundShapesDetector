using ForegroundShapesDetector.DataGenerator;
using ForegroundShapesDetector.Library.Models.Abstractions;
using ForegroundShapesDetector.Library.Services.Implementations;
using ForegroundShapesDetector.Library.Services.Interfaces;

namespace ForegroundShapesDetector.Tests.ServiceTests
{
    [TestFixture]
    public class ShapesDetectorServiceTests
    {
        private IShapesDetectorService _shapesDetector;
        private IOverlapCheckerService _overlapChecker;

        [SetUp]
        public void SetUp()
        {
            _overlapChecker = new OverlapCheckerService();
            _shapesDetector = new ShapesDetectorService(_overlapChecker);
        }

        [Test]
        public void GetForegroundShapesSync_ThrowsException_WhenShapesIsNull()
        {
            // Arrange
            List<ShapeBase> shapes = null;

            // Act + Assert
            Assert.Throws<ArgumentException>(() => _shapesDetector.GetForegroundShapesSync(shapes));
        }

        [Test]
        public void GetForegroundShapesSync_ThrowsException_WhenShapesIsEmpty()
        {
            // Arrange
            List<ShapeBase> shapes = new List<ShapeBase>();

            // Act + Assert
            Assert.Throws<ArgumentException>(() => _shapesDetector.GetForegroundShapesSync(shapes));
        }

        [Test]
        public void GetForegroundShapesSync_ThrowsException_WhenCountIsNotPositive()
        {
            // Arrange
            List<ShapeBase> shapes = new List<ShapeBase> { };
            int count = 0;

            // Act + Assert
            Assert.Throws<ArgumentException>(() => _shapesDetector.GetForegroundShapesSync(shapes, count));
        }

        [Test]
        public void GetForegroundShapesSync_ShouldReturnLastShape_WhenCountIs1()
        {
            // Arrange
            List<ShapeBase> shapes = ShapesGenerator.GetGeneratedShapes(1).ToList();
            int count = 1;

            // Act
            IEnumerable<int> result = _shapesDetector.GetForegroundShapesSync(shapes, count);

            // Assert
            Assert.That(result.Single(), Is.EqualTo(shapes.Last().Id));
        }
    }
}
