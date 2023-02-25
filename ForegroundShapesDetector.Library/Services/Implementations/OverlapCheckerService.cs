using ForegroundShapesDetector.Library.Constants;
using ForegroundShapesDetector.Library.Models;
using ForegroundShapesDetector.Library.Models.Abstractions;
using ForegroundShapesDetector.Library.Models.Shapes;
using ForegroundShapesDetector.Library.Services.Interfaces;

namespace ForegroundShapesDetector.Library.Services.Implementations
{
    public class OverlapCheckerService : IOverlapCheckerService
    {
        private readonly Dictionary<string, Func<ShapeBase, ShapeBase, bool>> pairOverlapLogics;

        public OverlapCheckerService()
        {
            pairOverlapLogics = new Dictionary<string, Func<ShapeBase, ShapeBase, bool>>();

            pairOverlapLogics[ShapePairs.LineSegmentLineSegment] = LineSegmentWithLineSegment;
            pairOverlapLogics[ShapePairs.LineSegmentTriangle] = LineSegmentWithTriangle;
            pairOverlapLogics[ShapePairs.LineSegmentRectangle] = LineSegmentWithRectangle;
            pairOverlapLogics[ShapePairs.LineSegmentCircle] = LineSegmentWithCircle;
            pairOverlapLogics[ShapePairs.TriangleTriangle] = TriangleWithTriangle;
            pairOverlapLogics[ShapePairs.TriangleRectangle] = TriangleWithRectangle;
            pairOverlapLogics[ShapePairs.TriangleCircle] = TriangleWithCircle;
            pairOverlapLogics[ShapePairs.RectangleRectangle] = RectangleWithRectangle;
            pairOverlapLogics[ShapePairs.RectangleCircle] = RectangleWithCircle;
            pairOverlapLogics[ShapePairs.CircleCircle] = CircleWithCircle;

            pairOverlapLogics[ShapePairs.TriangleLineSegment] = (shape1, shape2) => LineSegmentWithTriangle(shape2, shape1);
            pairOverlapLogics[ShapePairs.RectangleLineSegment] = (shape1, shape2) => LineSegmentWithRectangle(shape2, shape1);
            pairOverlapLogics[ShapePairs.RectangleTriangle] = (shape1, shape2) => TriangleWithRectangle(shape2, shape1);
            pairOverlapLogics[ShapePairs.CircleLineSegment] = (shape1, shape2) => LineSegmentWithCircle(shape2, shape1);
            pairOverlapLogics[ShapePairs.CircleTriangle] = (shape1, shape2) => TriangleWithCircle(shape2, shape1);
            pairOverlapLogics[ShapePairs.CircleRectangle] = (shape1, shape2) => RectangleWithCircle(shape2, shape1);
        }

        public bool CheckOverlap(ShapeBase shape1, ShapeBase shape2)
        {
            var pairName = shape1.GetType().Name + shape2.GetType().Name;

            if (pairOverlapLogics.TryGetValue(pairName, out Func<ShapeBase, ShapeBase, bool> overlapCheker))
                return overlapCheker(shape1, shape2);

            throw new NotImplementedException("Overlap checking logic daoes not implemented for this pair");
        }

        private bool LineSegmentWithLineSegment(ShapeBase shape1, ShapeBase shape2)
        {
            var line1 = (LineSegment)shape1;
            var line2 = (LineSegment)shape2;

            double d1 = Direction(line1.A, line1.B, line2.A);
            double d2 = Direction(line1.A, line1.B, line2.B);
            double d3 = Direction(line2.A, line2.B, line1.A);
            double d4 = Direction(line2.A, line2.B, line1.B);

            if (d1 != d2 && d3 != d4)
                return true;

            if ((d1 == 0 && OnLine(line1.A, line2.A, line1.B))
             || (d2 == 0 && OnLine(line1.A, line2.B, line1.B))
             || (d3 == 0 && OnLine(line2.A, line1.A, line2.B))
             || (d4 == 0 && OnLine(line2.A, line1.B, line2.B)))
                return true;

            return false;
        }

        private bool LineSegmentWithTriangle(ShapeBase shape1, ShapeBase shape2)
        {
            var line = (LineSegment)shape1;
            var triangle = (Triangle)shape2;

            return CheckSidesIntersection(line, triangle);
        }

        private bool LineSegmentWithRectangle(ShapeBase shape1, ShapeBase shape2)
        {
            var line = (LineSegment)shape1;
            var rectangle = (Triangle)shape2;

            return CheckSidesIntersection(line, rectangle);
        }

        private bool LineSegmentWithCircle(ShapeBase shape1, ShapeBase shape2)
        {
            var line = (LineSegment)shape1;
            var circle = (Circle)shape2;

            double distanceFromAtoCenter = Math.Sqrt(Math.Pow(line.A.X - circle.Center.X, 2)
                                                   + Math.Pow(line.A.Y - circle.Center.Y, 2));

            double distanceFromBtoCenter = Math.Sqrt(Math.Pow(line.B.X - circle.Center.X, 2)
                                                   + Math.Pow(line.B.Y - circle.Center.Y, 2));

            if (distanceFromAtoCenter <= circle.Radius || distanceFromBtoCenter <= circle.Radius)
                return true;

            double a = line.A.Y - line.B.Y;
            double b = line.B.X - line.A.X;
            double c = line.A.X * line.B.Y - line.B.X * line.A.Y;

            double distanceOfCenterFromLine = Math.Abs(a * circle.Center.X + b * circle.Center.Y + c)
                            / Math.Sqrt(a * a + b * b);

            double distanceOfFarthestPoint = Math.Max(distanceFromAtoCenter, distanceFromBtoCenter);

            double projection = Math.Sqrt(Math.Pow(distanceOfFarthestPoint, 2)
                                        - Math.Pow(distanceOfCenterFromLine, 2));

            double lineSegmentLength = Math.Sqrt(Math.Pow(line.A.X - line.B.X, 2)
                                               + Math.Pow(line.A.Y - line.B.Y, 2));

            if (distanceOfCenterFromLine <= circle.Radius && projection <= lineSegmentLength)
                return true;

            return false;
        }

        private bool TriangleWithTriangle(ShapeBase shape1, ShapeBase shape2)
        {
            var triangle1 = (Triangle)shape1;
            var triangle2 = (Triangle)shape2;

            if (CheckSidesIntersection(triangle1, triangle2))
                return true;

            if (CheckPointInTriangle(triangle2.A, triangle1))
                return true;

            if (CheckPointInTriangle(triangle1.A, triangle2))
                return true;

            return false;
        }

        private bool TriangleWithRectangle(ShapeBase shape1, ShapeBase shape2)
        {
            var triangle = (Triangle)shape1;
            var rectangle = (Rectangle)shape2;

            if (CheckSidesIntersection(triangle, rectangle))
                return true;

            if (CheckPointInRectangle(triangle.A, rectangle))
                return true;

            if (CheckPointInTriangle(rectangle.TopLeftPoint, triangle))
                return true;

            return false;
        }

        private bool TriangleWithCircle(ShapeBase shape1, ShapeBase shape2)
        {
            var triangle = (Triangle)shape1;
            var circle = (Circle)shape2;

            foreach (var side in triangle.Sides)
                if (LineSegmentWithCircle(side, circle))
                    return true;

            return false;
        }

        private bool RectangleWithRectangle(ShapeBase shape1, ShapeBase shape2)
        {
            var rectangle1 = (Rectangle)shape1;
            var rectangle2 = (Rectangle)shape2;

            if (CheckSidesIntersection(rectangle1, rectangle2))
                return true;

            if (CheckPointInRectangle(rectangle1.TopLeftPoint, rectangle2))
                return true;

            if (CheckPointInRectangle(rectangle2.TopLeftPoint, rectangle1))
                return true;

            return false;
        }

        private bool RectangleWithCircle(ShapeBase shape1, ShapeBase shape2)
        {
            var rectangle = (Rectangle)shape1;
            var circle = (Circle)shape2;

            foreach (var side in rectangle.Sides)
                if (LineSegmentWithCircle(side, circle))
                    return true;

            return false;
        }

        private bool CircleWithCircle(ShapeBase shape1, ShapeBase shape2)
        {
            var circle1 = (Circle)shape1;
            var circle2 = (Circle)shape2;

            double distanceOfRadiuses = Math.Sqrt(Math.Pow(circle1.Center.X - circle2.Center.X, 2)
                                                + Math.Pow(circle1.Center.Y - circle2.Center.Y, 2));

            if (distanceOfRadiuses <= circle1.Radius + circle2.Radius)
                return true;

            return false;
        }

        private bool CheckSidesIntersection(IShapeHasSides shape1, IShapeHasSides shape2)
        {
            foreach (var side1 in shape1.Sides)
                foreach (var side2 in shape2.Sides)
                    if (LineSegmentWithLineSegment(side1, side2))
                        return true;

            return false;
        }

        private bool CheckPointInTriangle(Point point, Triangle triangle)
        {
            double d1, d2, d3;
            bool hasNegative, hasPositive;

            d1 = Sign(point, triangle.A, triangle.B);
            d2 = Sign(point, triangle.A, triangle.C);
            d3 = Sign(point, triangle.C, triangle.A);

            hasNegative = (d1 < 0) || (d2 < 0) || (d3 < 0);
            hasPositive = (d1 > 0) || (d2 > 0) || (d3 > 0);

            return !(hasNegative && hasPositive);
        }

        private bool CheckPointInRectangle(Point point, Rectangle rectangle)
        {
            if (rectangle.TopLeftPoint.X < point.X && point.X < rectangle.TopLeftPoint.X + rectangle.Width &&
                rectangle.TopLeftPoint.Y < point.Y && point.Y < rectangle.TopLeftPoint.Y + rectangle.Height)
                return true;

            return false;
        }

        private double Sign(Point p1, Point p2, Point p3)
        {
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
        }

        private bool OnLine(Point a, Point b, Point c)
        {
            if (b.X <= Math.Max(a.X, c.X) && b.X >= Math.Min(a.X, c.X) &&
                b.Y <= Math.Max(a.Y, c.Y) && b.Y >= Math.Min(a.Y, c.Y))
                return true;

            return false;
        }

        private double Direction(Point a, Point b, Point c)
        {
            double value = (b.Y - a.Y) * (c.X - b.X) -
                         (b.X - a.X) * (c.Y - b.Y);

            if (value == 0) return 0;

            return (value > 0) ? 1 : 2;
        }
    }
}