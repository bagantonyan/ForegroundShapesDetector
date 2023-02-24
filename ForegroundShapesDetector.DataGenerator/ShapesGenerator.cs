using ForegroundShapesDetector.Library.Models;
using ForegroundShapesDetector.Library.Models.Abstractions;
using ForegroundShapesDetector.Library.Models.Shapes;

namespace ForegroundShapesDetector.DataGenerator
{
    public class ShapesGenerator
    {
        public static IEnumerable<ShapeBase> GetGeneratedShapes(int count) 
        {
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
            var random = new Random();
            return (ShapeTypes)values.GetValue(random.Next(values.Length));
        }

        private static LineSegment GetRandomLineSegment()
        {
            double x1 = GetRandomDoubleInRange(0, 1000);
            double y1 = GetRandomDoubleInRange(0, 1000);
            double x2 = GetRandomDoubleInRange(0, 1000);
            double y2 = GetRandomDoubleInRange(0, 1000);

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
            double x1 = GetRandomDoubleInRange(0, 1000);
            double y1 = GetRandomDoubleInRange(0, 1000);
            double x2 = GetRandomDoubleInRange(0, 1000);
            double y2 = GetRandomDoubleInRange(0, 1000);
            double x3 = GetRandomDoubleInRange(0, 1000);
            double y3 = GetRandomDoubleInRange(0, 1000);

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
            double x = GetRandomDoubleInRange(0, 950);
            double y = GetRandomDoubleInRange(50, 1000);

            Point p1 = new Point(x, y);

            double width = GetRandomDoubleInRange(0, 1000 - x);
            double height = GetRandomDoubleInRange(0, y);

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
            double x = GetRandomDoubleInRange(50, 950);
            double y = GetRandomDoubleInRange(50, 950);

            Point p1 = new Point(x, y);

            double minDistanceByX = Math.Min(x, 1000 - x);
            double minDistanceByY = Math.Min(y, 1000 - y);
            double minDistanceOfCenterFromAxis = Math.Min(minDistanceByX, minDistanceByY);

            double radius = GetRandomDoubleInRange(50, minDistanceOfCenterFromAxis);

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
            Random random = new Random();
            var next = random.NextDouble();
            return min + (next * (max - min));
        }
    }
}
