using ForegroundShapesDetector.Library.Models.Abstractions;

namespace ForegroundShapesDetector.Library
{
    public static class ShapesDetector
    {
        public static IEnumerable<ShapeBase> GetForegroundShapesSync(List<ShapeBase> shapes, int? count = null, double? minimalSquare = null)
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
                    return new List<ShapeBase>() { shapes[^1] };
            }

            List<ShapeBase> foregroundShapes = new()
            {
                shapes[^1]
            };

            for (int i = shapes.Count - 2; i >= 0; i--)
            {
                if (!IsForeground(shapes.GetRange(i, shapes.Count - i)))
                    continue;

                if (minimalSquare is not null)
                    if (minimalSquare > shapes[i].GetSquare())
                        continue;

                foregroundShapes.Add(shapes[i]);

                if (count is not null && foregroundShapes.Count == count)
                    return foregroundShapes;
            }

            return foregroundShapes;
        }

        public static async IAsyncEnumerable<ShapeBase> GetForegroundShapesAsync(List<ShapeBase> shapes, int? count = null, double? minimalSquare = null)
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
                    yield return shapes[^1];
                    yield break;
                }
            }

            yield return shapes[^1];

            int foregroundsCount = 1;

            for (int i = shapes.Count - 2; i >= 0; i--)
            {
                if (!IsForeground(shapes.GetRange(i, shapes.Count - i))) 
                    continue;

                if (minimalSquare is not null)
                    if (minimalSquare > shapes[i].GetSquare())
                        continue;

                await Task.Delay(1000);

                yield return shapes[i];

                if (count is not null && ++foregroundsCount == count)
                    yield break;
            }
        }

        private static bool IsForeground(List<ShapeBase> shapes)
        {
            ShapeBase current = shapes.First();

            return shapes.Skip(1).ToList().All(shape => !current.CheckOverlap(shape));
        }
    }
}
