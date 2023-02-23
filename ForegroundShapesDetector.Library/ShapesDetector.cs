using ForegroundShapesDetector.Library.Models.Abstractions;

namespace ForegroundShapesDetector.Library
{
    public class ShapesDetector
    {
        public static List<ShapeBase> GetForegroundShapes(List<ShapeBase> shapes)
        {
            List<ShapeBase> foregroundShapes = new List<ShapeBase>
            {
                shapes[shapes.Count - 1]
            };

            bool isForeground;

            for (int i = shapes.Count - 2; i >= 0; i--)
            {
                isForeground = true;

                for (int j = i + 1; j < shapes.Count; j++)
                {
                    if (shapes[i].CheckOverlap(shapes[j]))
                    {
                        isForeground = false;
                        break;
                    }
                }

                if (isForeground)
                {
                    foregroundShapes.Add(shapes[i]);
                }
            }

            return foregroundShapes;
        }
    }
}
