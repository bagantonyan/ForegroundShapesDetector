using ForegroundShapesDetector.DataGenerator;
using ForegroundShapesDetector.Library;
using ForegroundShapesDetector.Library.Models;
using ForegroundShapesDetector.Library.Models.Abstractions;
using ForegroundShapesDetector.Library.Models.Shapes;
using ForegroundShapesDetector.Library.Services.Extensions;
using ForegroundShapesDetector.Library.Services.Implementations;
using ForegroundShapesDetector.Library.Services.Interfaces;

namespace ForegroundShapesDetector.ConsoleClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            var generatedShapes = ShapesGenerator.GetGeneratedShapes(30).ToList();
            IOverlapCheckerService overlapChecker = new OverlapCheckerService();
            IShapesDetectorService shapesDetector = new ShapesDetectorService(overlapChecker);

            var result = shapesDetector.GetForegroundShapesSync(generatedShapes).ToList();

            await foreach (var shape in shapesDetector.GetForegroundShapesAsync(generatedShapes))
            {
                
            }

            //var resultSyncForGen = ShapesDetector.GetForegroundShapesSync(generatedShapes);

            Point k1 = new Point(5, 5);
            Point k2 = new Point(5, 5);

            try
            {
                ShapeBase shape = new LineSegment(k1, k2);
            }
            catch (Exception)
            {

            }

            Point a1 = new Point(5, 8);
            Point a2 = new Point(8, 10);
            ShapeBase line1 = new LineSegment(a1, a2);

            Point b1 = new Point(7, 4);
            Point b2 = new Point(9, 8);
            Point b3 = new Point(12, 5);
            ShapeBase triangle1 = new Triangle(b1, b2, b3);

            Point c1 = new Point(11, 7);
            ShapeBase rectangle1 = new Rectangle(c1, 4, 3);

            Point d1 = new Point(1, 7);
            ShapeBase rectangle2 = new Rectangle(d1, 3, 3);

            Point e1 = new Point(3, 3);
            ShapeBase circle1 = new Circle(e1, 2);

            List<ShapeBase> shapes = new List<ShapeBase>
            {
                line1, triangle1, rectangle1, rectangle2, circle1
            };

            OverlapCheckerService helper = new OverlapCheckerService();

            //var result = helper.CheckOverlap(circle1, line1);


            //var resultSync = ShapesDetector.GetForegroundShapesSync(shapes, minimalSquare: 12);

            //await foreach (var shape in ShapesDetector.GetForegroundShapesAsync(generatedShapes))
            //{
            //    Console.WriteLine(shape.GetType());
            //}
        }
    }
}