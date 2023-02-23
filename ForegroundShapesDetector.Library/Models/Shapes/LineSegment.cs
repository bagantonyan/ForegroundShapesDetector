using ForegroundShapesDetector.Library.Models.Abstractions;

namespace ForegroundShapesDetector.Library.Models.Shapes
{
    public class LineSegment : ShapeBase, IHasSides
    {
        private Point a;
        private Point b;
        private LineSegment[] sides;

        public LineSegment(Point a, Point b)
        {
            A = a;
            B = b;

            CheckLineIsValid();

            Sides = new LineSegment[1] { this };
        }

        public Point A
        {
            get { return a; }
            private set
            {
                if (value is null)
                    throw new ArgumentNullException("Line's point can't be null");
                a = value;
            }
        }

        public Point B
        {
            get { return b; }
            private set
            {
                if (value is null)
                    throw new ArgumentNullException("Line's point can't be null");
                b = value;
            }
        }

        public LineSegment[] Sides
        {
            get
                => (LineSegment[])sides.Clone();
            private set
                => sides = value;
        }

        public sealed override double GetArea()
        {
            return 0;
        }

        protected sealed override bool WithLineSegment(LineSegment line)
            => ShapesOverlapHelper.LineSegmentWithLineSegment(this, line);

        protected sealed override bool WithTriangle(Triangle triangle)
            => ShapesOverlapHelper.LineSegmentWithTriangle(this, triangle);

        protected sealed override bool WithRectangle(Rectangle rectangle)
            => ShapesOverlapHelper.LineSegmentWithRectangle(this, rectangle);

        protected sealed override bool WithCircle(Circle circle)
            => ShapesOverlapHelper.CircleWithLineSegment(this, circle);

        private void CheckLineIsValid()
        {
            if (a.X == b.X && a.Y == b.Y)
                throw new ArgumentException("Invalid line");
        }
    }
}
