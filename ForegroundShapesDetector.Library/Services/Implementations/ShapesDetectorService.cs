using ForegroundShapesDetector.Library.Models.Abstractions;
using ForegroundShapesDetector.Library.Services.Interfaces;

namespace ForegroundShapesDetector.Library.Services.Implementations
{
    public class ShapesDetectorService : IShapesDetectorService
    {
        private readonly IOverlapCheckerService _overlapChecker;

        public ShapesDetectorService(
            IOverlapCheckerService overlapChecker)
        {
            _overlapChecker = overlapChecker;
        }

        public IEnumerable<int> GetForegroundShapesSync(List<ShapeBase> shapes, int? count = null, double? minimalSquare = null)
        {
            if (shapes is null)
                throw new ArgumentException("Shapes list can't be null");

            if (!shapes.Any())
                throw new ArgumentException("Shapes list can't be empty");

            if (count is not null)
            {
                if (count <= 0)
                    throw new ArgumentException("Count must be greater than 0");

                if (count == 1)
                    return new List<int>() { shapes[^1].Id };
            }

            var foregroundShapeIds = new List<int>
            {
                shapes[^1].Id
            };

            for (int i = shapes.Count - 2; i >= 0; i--)
            {
                if (!IsForeground(shapes.GetRange(i, shapes.Count - i)))
                    continue;

                if (minimalSquare is not null)
                    if (minimalSquare > shapes[i].GetSquare())
                        continue;

                foregroundShapeIds.Add(shapes[i].Id);

                if (count is not null && foregroundShapeIds.Count == count)
                    return foregroundShapeIds;
            }

            return foregroundShapeIds;
        }

        public async IAsyncEnumerable<int> GetForegroundShapesAsync(List<ShapeBase> shapes, int? count = null, double? minimalSquare = null)
        {
            if (shapes is null)
                throw new ArgumentException("Shapes list can't be null");

            if (!shapes.Any())
                throw new ArgumentException("Shapes list can't be empty");

            if (count is not null)
            {
                if (count <= 0)
                    throw new ArgumentException("Count must be greater than 0");

                if (count == 1)
                {
                    yield return shapes[^1].Id;
                    yield break;
                }
            }

            yield return shapes[^1].Id;

            int foregroundsCount = 1;

            for (int i = shapes.Count - 2; i >= 0; i--)
            {
                if (!IsForeground(shapes.GetRange(i, shapes.Count - i)))
                    continue;

                if (minimalSquare is not null)
                    if (minimalSquare > shapes[i].GetSquare())
                        continue;

                await Task.Delay(1000);

                yield return shapes[i].Id;

                if (count is not null && ++foregroundsCount == count)
                    yield break;
            }
        }

        private bool IsForeground(List<ShapeBase> shapes)
        {
            var current = shapes.First();

            return shapes.Skip(1).ToList().All(shape => !_overlapChecker.CheckOverlap(current, shape));
        }
    }
}