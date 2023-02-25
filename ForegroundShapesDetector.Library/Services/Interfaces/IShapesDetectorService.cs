using ForegroundShapesDetector.Library.Models.Abstractions;

namespace ForegroundShapesDetector.Library.Services.Interfaces
{
    public interface IShapesDetectorService
    {
        IEnumerable<int> GetForegroundShapesSync(List<ShapeBase> shapes, int? count = null, double? minimalSquare = null);
        IAsyncEnumerable<int> GetForegroundShapesAsync(List<ShapeBase> shapes, int? count = null, double? minimalSquare = null);
    }
}
