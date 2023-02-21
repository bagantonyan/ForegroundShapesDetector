using ForegroundShapesDetector.Library.Models.Interfaces;

namespace ForegroundShapesDetector.Library.Models.Shapes
{
    public class Rectangle : IShape
    {
        private Point topLeftPoint;
        private double width;
        private double height;

        public Rectangle(Point topLeftPoint, double width, double height)
        {
            TopLeftPoint = topLeftPoint;
            Width = width;
            Height = height;
        }

        public Point TopLeftPoint
        {
            get { return topLeftPoint; }
            set
            {
                if (value is null)
                    throw new ArgumentNullException("Rectangle's center point can't be null");
                TopLeftPoint = value;
            }
        }
        public double Width
        {
            get { return width; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Rectangle's width must be greater than 0");
                width = value;
            }
        }
        public double Height
        {
            get { return height; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Rectangle's height must be greater than 0");
                height = value;
            }
        }

        public double GetArea()
        {
            return Width * Height;
        }
    }
}
