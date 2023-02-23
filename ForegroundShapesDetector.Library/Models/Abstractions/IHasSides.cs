using ForegroundShapesDetector.Library.Models.Shapes;

namespace ForegroundShapesDetector.Library.Models.Abstractions
{
    public interface IHasSides
    {
        LineSegment[] Sides { get; }
    }
}
