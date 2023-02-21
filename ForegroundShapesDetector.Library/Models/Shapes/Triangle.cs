using ForegroundShapesDetector.Library.Models.Interfaces;

namespace ForegroundShapesDetector.Library.Models.Shapes
{
    public class Triangle : IShape
    {
        private Point a;
        private Point b;
        private Point c;

        public Triangle(Point a, Point b, Point c)
        {
            A = a;
            B = b;
            C = c;

            CheckTriangleIsValid();
        }

        public Point A
        {
            get { return a; }
            set
            {
                if (value is null)
                    throw new ArgumentNullException("Triangle's point can't be null");
                a = value;
            }
        }

        public Point B
        {
            get { return b; }
            set
            {
                if (value is null)
                    throw new ArgumentNullException("Triangle's point can't be null");
                b = value;
            }
        }

        public Point C
        {
            get { return c; }
            set
            {
                if (value is null)
                    throw new ArgumentNullException("Triangle's point can't be null");
                c = value;
            }
        }

        public double GetArea()
        {
            return Math.Abs((A.X * (B.Y - C.Y)
                           + B.X * (C.Y - A.Y)
                           + C.X * (A.Y - B.Y))
                           / 2);
        }

        private void CheckTriangleIsValid()
        {
            double triangleArea = GetArea();

            if (triangleArea == 0)
                throw new ArgumentException("Invalid triangle");
        }
    }
}