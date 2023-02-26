namespace ForegroundShapesDetector.Library.Models.Abstractions
{
    public abstract class ShapeBase
    {
        private static int id = 1;

        public int Id { get; }

        protected ShapeBase()
        {
            Id = id++;
        }

        public abstract double GetSquare();
    }
}
