using ForegroundShapesDetector.Library;
using ForegroundShapesDetector.Library.Models;
using ForegroundShapesDetector.Library.Models.Abstractions;
using ForegroundShapesDetector.Library.Models.Shapes;

namespace ForegroundShapesDetector.ConsoleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(6, 9);
            Point p2 = new Point(5, 7);
            Point c = new Point(8, 8);

            ShapeBase lineTest = new LineSegment(p1, p2);

            Circle circle = new Circle(c, 4);

            Console.WriteLine(circle.CheckOverlap(lineTest));
        }
    }
}