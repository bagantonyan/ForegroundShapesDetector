using ForegroundShapesDetector.Library.Models;
using ForegroundShapesDetector.Library.Models.Abstractions;
using ForegroundShapesDetector.Library.Models.Shapes;

namespace ForegroundShapesDetector.DataGenerator
{
    public class ShapesGenerator
    {
        private static double _panelWidth;
        private static double _panelHeight;
        private static double _minShapeSize;
        private static double _maxShapeSize;
        private static Random _random = new Random();

        public static IEnumerable<ShapeBase> GetGeneratedShapes(
            int count, double panelWidth, double panelHeight, double minShapeSize, double maxShapeSize)
        {
            _panelWidth = panelWidth;
            _panelHeight = panelHeight;
            _minShapeSize = minShapeSize;
            _maxShapeSize = maxShapeSize;

            List<ShapeBase> shapes = new List<ShapeBase>();

            for (int i = 0; i < count; i++)
            {
                ShapeBase newShape = null;

                ShapeTypes shapeType = GetRandomShapeType();

                switch (shapeType)
                {
                    case ShapeTypes.LineSegment:
                        {
                            newShape = GetRandomLineSegment();
                            break;
                        }
                    case ShapeTypes.Triangle:
                        {
                            newShape = GetRandomTriangle();
                            break;
                        }
                    case ShapeTypes.Rectangle:
                        {
                            newShape = GetRandomRectangle();
                            break;
                        }
                    case ShapeTypes.Circle:
                        {
                            newShape = GetRandomCircle();
                            break;
                        }
                    default:
                        break;
                }

                if (newShape is not null)
                    shapes.Add(newShape);
            }

            return shapes;
        }

        private static ShapeTypes GetRandomShapeType()
        {
            var values = Enum.GetValues(typeof(ShapeTypes));
            return (ShapeTypes)values.GetValue(_random.Next(values.Length));
        }

        private static LineSegment GetRandomLineSegment()
        {
            double x1 = GetRandomDoubleInRange(0, _panelWidth);
            double y1 = GetRandomDoubleInRange(0, _panelHeight);

            double lineLength = GetRandomDoubleInRange(_minShapeSize, _maxShapeSize);
            double lineAngle = GetRandomDoubleInRange(0, 2 * Math.PI);

            double x2 = x1 + (lineLength * Math.Cos(lineAngle));
            double y2 = y1 + (lineLength * Math.Sin(lineAngle));

            Point p1 = new Point(x1, y1);
            Point p2 = new Point(x2, y2);

            LineSegment lineSegment = null;

            try
            {
                lineSegment = new LineSegment(p1, p2);
            }
            catch (Exception) { }

            return lineSegment;
        }

        private static Triangle GetRandomTriangle()
        {
            double x1 = GetRandomDoubleInRange(0, _panelWidth);
            double y1 = GetRandomDoubleInRange(0, _panelHeight);

            double x2 = GetRandomDoubleInRange(x1 - _maxShapeSize, x1 + _maxShapeSize);
            double y2 = GetRandomDoubleInRange(y1 - _maxShapeSize, y1 + _maxShapeSize);

            double x3 = GetRandomDoubleInRange(x2 - _maxShapeSize, x2 + _maxShapeSize);
            double y3 = GetRandomDoubleInRange(y2 - _maxShapeSize, y2 + _maxShapeSize);

            Point p1 = new Point(x1, y1);
            Point p2 = new Point(x2, y2);
            Point p3 = new Point(x3, y3);

            Triangle triangle = null;

            try
            {
                triangle = new Triangle(p1, p2, p3);
            }
            catch (Exception) { }

            return triangle;
        }

        private static Rectangle GetRandomRectangle()
        {
            double x = GetRandomDoubleInRange(0, _panelWidth);
            double y = GetRandomDoubleInRange(0, _panelHeight);

            Point p1 = new Point(x, y);

            double width = GetRandomDoubleInRange(_minShapeSize, _maxShapeSize);
            double height = GetRandomDoubleInRange(_minShapeSize, _maxShapeSize);

            Rectangle rectangle = null;

            try
            {
                rectangle = new Rectangle(p1, width, height);
            }
            catch (Exception) { }

            return rectangle;
        }

        private static Circle GetRandomCircle()
        {
            double x = GetRandomDoubleInRange(0, _panelWidth);
            double y = GetRandomDoubleInRange(0, _panelHeight);

            Point p1 = new Point(x, y);
            double radius = GetRandomDoubleInRange(_minShapeSize, _maxShapeSize);

            Circle circle = null;

            try
            {
                circle = new Circle(p1, radius);
            }
            catch (Exception) { }

            return circle;
        }

        private static double GetRandomDoubleInRange(double min, double max)
        {
            var next = _random.NextDouble();
            return min + (next * (max - min));
        }
    }
}
