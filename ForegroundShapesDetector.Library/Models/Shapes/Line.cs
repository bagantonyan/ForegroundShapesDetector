using ForegroundShapesDetector.Library.Models.Interfaces;

namespace ForegroundShapesDetector.Library.Models.Shapes
{
    public class Line : IShape
    {
        private Point a;
        private Point b;

        public Line(Point a, Point b)
        {
            A = a;
            B = b;

            CheckLineIsValid();
        }

        public Point A
        {
            get { return a; }
            set 
            {
                if (value is null)
                    throw new ArgumentNullException("Line's point can't be null");
                a = value;
            }
        }

        public Point B
        {
            get { return b; }
            set
            {
                if (value is null)
                    throw new ArgumentNullException("Line's point can't be null");
                b = value;
            }
        }

        private void CheckLineIsValid() 
        {
            if (a.X == b.X && a.Y == b.Y)
                throw new ArgumentException("Invalid line");
        }

        public double GetArea()
        {
            return 0;
        }
    }
}
