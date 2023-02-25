using ForegroundShapesDetector.Library.Models.Shapes;

namespace ForegroundShapesDetector.Library.Models.Abstractions
{
    public interface IShapeHasSides
    {
        LineSegment[] Sides { get; }
    }
}
