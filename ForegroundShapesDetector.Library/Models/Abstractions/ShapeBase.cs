using ForegroundShapesDetector.Library.Models.Shapes;

namespace ForegroundShapesDetector.Library.Models.Abstractions
{
    public abstract class ShapeBase
    {
        public bool CheckOverlap(ShapeBase shape)
        {
            return shape switch
            {
                LineSegment lineSegment => WithLineSegment(lineSegment),
                Triangle triangle => WithTriangle(triangle),
                Rectangle rectangle => WithRectangle(rectangle),
                Circle circle => WithCircle(circle),
                _ => false
            };
        }
        public abstract double GetSquare();
        protected abstract bool WithLineSegment(LineSegment lineSegment);
        protected abstract bool WithTriangle(Triangle triangle);
        protected abstract bool WithRectangle(Rectangle rectangle);
        protected abstract bool WithCircle(Circle circle);
    }
}
