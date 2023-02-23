using ForegroundShapesDetector.Library.Models;
using ForegroundShapesDetector.Library.Models.Abstractions;
using ForegroundShapesDetector.Library.Models.Shapes;

namespace ForegroundShapesDetector.Library
{
    public class ShapesOverlapHelper
    {
        public static bool LineSegmentWithLineSegment(LineSegment line1, LineSegment line2)
        {
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

        public static bool LineSegmentWithTriangle(LineSegment line, Triangle triangle)
            => CheckSidesIntersection(line, triangle);

        public static bool LineSegmentWithRectangle(LineSegment line, Rectangle rectangle)
            => CheckSidesIntersection(line, rectangle);

        public static bool TriangleWithTriangle(Triangle triangle1, Triangle triangle2)
        {
            if (CheckSidesIntersection(triangle1, triangle2))
                return true;

            if (PointInTriangle(triangle2.A, triangle1.A, triangle1.B, triangle1.C))
                return true;

            if (PointInTriangle(triangle1.A, triangle2.A, triangle2.B, triangle2.C))
                return true;

            return false;
        }

        public static bool TriangleWithRectangle(Triangle triangle, Rectangle rectangle)
        {
            if (CheckSidesIntersection(triangle, rectangle))
                return true;

            if (PointInRectangle(rectangle, triangle.A))
                return true;

            if (PointInTriangle(rectangle.TopLeftPoint, triangle.A, triangle.B, triangle.C))
                return true;

            return false;
        }

        public static bool RectangleWithRectangle(Rectangle rectangle1, Rectangle rectangle2)
        {
            if (CheckSidesIntersection(rectangle1, rectangle2))
                return true;

            if (PointInRectangle(rectangle2, rectangle1.TopLeftPoint))
                return true;

            if (PointInRectangle(rectangle1, rectangle2.TopLeftPoint))
                return true;

            return false;
        }

        public static bool CircleWithLineSegment(LineSegment line, Circle circle)
        {
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

        public static bool CircleWithTriangle(Circle circle, Triangle triangle)
        {
            foreach (var side in triangle.Sides)
                if (CircleWithLineSegment(side, circle))
                    return true;

            return false;
        }

        public static bool CircleWithRectangle(Circle circle, Rectangle rectangle)
        {
            foreach (var side in rectangle.Sides)
                if (CircleWithLineSegment(side, circle))
                    return true;

            return false;
        }

        public static bool CircleWithCircle(Circle circle1, Circle circle2)
        {
            double distanceOfRadiuses = Math.Sqrt(Math.Pow(circle1.Center.X - circle2.Center.X, 2)
                                                + Math.Pow(circle1.Center.Y - circle2.Center.Y, 2));

            if (distanceOfRadiuses <= circle1.Radius + circle2.Radius)
                return true;

            return false;
        }

        private static bool CheckSidesIntersection(IHasSides shape1, IHasSides shape2)
        {
            for (int i = 0; i < shape1.Sides.Length; i++)
                for (int j = 0; j < shape2.Sides.Length; j++)
                    if (LineSegmentWithLineSegment(shape1.Sides[i], shape2.Sides[j]))
                        return true;

            return false;
        }

        private static double Direction(Point a, Point b, Point c)
        {
            double value = (b.Y - a.Y) * (c.X - b.X) -
                         (b.X - a.X) * (c.Y - b.Y);

            if (value == 0) return 0;

            return (value > 0) ? 1 : 2;
        }

        private static bool OnLine(Point a, Point b, Point c)
        {
            if (b.X <= Math.Max(a.X, c.X) && b.X >= Math.Min(a.X, c.X) &&
                b.Y <= Math.Max(a.Y, c.Y) && b.Y >= Math.Min(a.Y, c.Y))
                return true;

            return false;
        }

        private static bool PointInRectangle(Rectangle rectangle, Point point)
        {
            if (rectangle.TopLeftPoint.X < point.X && point.X < rectangle.TopLeftPoint.X + rectangle.Width &&
                rectangle.TopLeftPoint.Y < point.Y && point.Y < rectangle.TopLeftPoint.Y + rectangle.Height)
                return true;

            return false;
        }

        private static bool PointInTriangle(Point point, Point t1, Point t2, Point t3)
        {
            double d1, d2, d3;
            bool hasNegative, hasPositive;

            d1 = Sign(point, t1, t2);
            d2 = Sign(point, t2, t3);
            d3 = Sign(point, t3, t1);

            hasNegative = (d1 < 0) || (d2 < 0) || (d3 < 0);
            hasPositive = (d1 > 0) || (d2 > 0) || (d3 > 0);

            return !(hasNegative && hasPositive);
        }

        private static double Sign(Point p1, Point p2, Point p3)
        {
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
        }
    }
}
