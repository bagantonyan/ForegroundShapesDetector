using ForegroundShapesDetector.Library.Models.Abstractions;

namespace ForegroundShapesDetector.Library.Services.Interfaces
{
    public interface IOverlapCheckerService
    {
        bool CheckOverlap(ShapeBase shape1, ShapeBase shape2);
    }
}
