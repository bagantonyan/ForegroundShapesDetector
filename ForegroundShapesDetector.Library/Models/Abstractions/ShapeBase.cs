using ForegroundShapesDetector.Library.Models.Shapes;

namespace ForegroundShapesDetector.Library.Models.Abstractions
{
    public abstract class ShapeBase
    {
        public bool CheckOverlap(ShapeBase shape)
        {
            return shape switch
            {
                LineSegment l => WithLineSegment(l),
                Triangle t => WithTriangle(t),
                Rectangle r => WithRectangle(r),
                _ => false
            };
        }
        public abstract double GetArea();
        protected abstract bool WithLineSegment(LineSegment line);
        protected abstract bool WithTriangle(Triangle tri);
        protected abstract bool WithRectangle(Rectangle rec);
        protected abstract bool WithCircle(Circle circle);
    }
}
