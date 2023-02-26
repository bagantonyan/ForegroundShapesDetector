using ForegroundShapesDetector.DataGenerator;
using ForegroundShapesDetector.Library.Models.Abstractions;
using ForegroundShapesDetector.Library.Models.Shapes;
using ForegroundShapesDetector.Library.Services.Implementations;
using ForegroundShapesDetector.Library.Services.Interfaces;
using Rectangle = ForegroundShapesDetector.Library.Models.Shapes.Rectangle;

namespace ForegroundShapesDetector.UI
{
    public partial class MainForm : Form
    {
        private readonly IShapesDetectorService _shapesDetectorService;

        private Graphics _graphics;
        private Pen _pen;
        private Bitmap _pictureBoxImage;

        private List<ShapeBase> _shapes;
        public MainForm()
        {
            InitializeComponent();

            IOverlapCheckerService overlapChecker = new OverlapCheckerService();
            _shapesDetectorService = new ShapesDetectorService(overlapChecker);

            _pictureBoxImage = new Bitmap(PictureBox.Width, PictureBox.Height);
            _graphics = Graphics.FromImage(_pictureBoxImage);
            _pen = new Pen(Color.Black);
        }

        private void GenerateShapes_Click(object sender, EventArgs e)
        {
            double maxShapeSize = MaxShapeSize.Value != 0 ? (double)MaxShapeSize.Value : 1000;
            _shapes = ShapesGenerator.GetGeneratedShapes(
                (int)ShapesCount.Value, 
                PictureBox.Width, 
                PictureBox.Height, 
                (double)MinShapeSize.Value,
                maxShapeSize).ToList();

            Brush brush = new SolidBrush(Color.LightGray);

            _shapes.ForEach(shape => DrawShape(shape, brush));
        }

        private void DrawShape(ShapeBase shape, Brush brush)
        {
            switch (shape)
            {
                case LineSegment lineSegment:
                    {
                        DrawLineSegment(lineSegment, brush);
                        break;
                    }
                case Circle circle:
                    {
                        DrawCircle(circle, brush);
                        break;
                    }
                case Triangle triangle:
                    {
                        DrawTriangle(triangle, brush);
                        break;
                    }
                case Rectangle rectangle:
                    {
                        DrawRectangle(rectangle, brush);
                        break;
                    }
            }

            PictureBox.Image = _pictureBoxImage;
        }

        private void DrawLineSegment(LineSegment lineSegment, Brush brush)
        {
            _graphics.DrawLine(_pen, new Point((int)lineSegment.A.X, (int)lineSegment.A.Y), new Point((int)lineSegment.B.X, (int)lineSegment.B.Y));
        }

        private void DrawRectangle(Rectangle rectangle, Brush brush)
        {
            _graphics.DrawRectangle(_pen, new System.Drawing.Rectangle((int)rectangle.TopLeftPoint.X, (int)rectangle.TopLeftPoint.Y, (int)rectangle.Width, (int)rectangle.Height));
            _graphics.FillRectangle(brush, new System.Drawing.Rectangle((int)rectangle.TopLeftPoint.X, (int)rectangle.TopLeftPoint.Y, (int)rectangle.Width, (int)rectangle.Height));
        }

        private void DrawCircle(Circle circle, Brush brush)
        {
            _graphics.DrawEllipse(_pen, new System.Drawing.Rectangle((int)(circle.Center.X - circle.Radius), (int)(circle.Center.Y - circle.Radius), (int)(circle.Radius * 2), (int)(circle.Radius * 2)));
            _graphics.FillEllipse(brush, new System.Drawing.Rectangle((int)(circle.Center.X - circle.Radius), (int)(circle.Center.Y - circle.Radius), (int)(circle.Radius * 2), (int)(circle.Radius * 2)));
        }

        private void DrawTriangle(Triangle triangle, Brush brush)
        {
            _graphics.DrawPolygon(_pen,
                new Point[]
                {
                    new Point((int)triangle.A.X, (int)triangle.A.Y),
                    new Point((int)triangle.B.X, (int)triangle.B.Y),
                    new Point((int)triangle.C.X, (int)triangle.C.Y)
                });

            _graphics.FillPolygon(brush,
                new Point[]
                {
                    new Point((int)triangle.A.X, (int)triangle.A.Y),
                    new Point((int)triangle.B.X, (int)triangle.B.Y),
                    new Point((int)triangle.C.X, (int)triangle.C.Y)
                });
        }

        private void ClearPanel_Click(object sender, EventArgs e)
        {
            _graphics.Clear(Color.White);
            PictureBox.Image = new Bitmap(PictureBox.Width, PictureBox.Height);
        }

        private void FindSync_Click(object sender, EventArgs e)
        {
            int? shapesCount = FindShapesCount.Value != 0 ? (int?)FindShapesCount.Value : null;
            double? shapesSquare = FindShapesSquare.Value != 0 ? (double?)FindShapesSquare.Value : null;

            var foregroundShapesIds = _shapesDetectorService.GetForegroundShapesSync(_shapes, shapesCount, shapesSquare);
            var foregroundShapes = _shapes.Where(s => foregroundShapesIds.Contains(s.Id)).ToList();

            Brush brush = new SolidBrush(Color.Green);
            foregroundShapes.ForEach(shape => DrawShape(shape, brush));
        }

        private async void FindAsync_Click(object sender, EventArgs e)
        {
            int? shapesCount = FindShapesCount.Value != 0 ? (int?)FindShapesCount.Value : null;
            double? shapesSquare = FindShapesSquare.Value != 0 ? (double?)FindShapesSquare.Value : null;

            Brush brush = new SolidBrush(Color.Green);

            await foreach (var shapeId in _shapesDetectorService.GetForegroundShapesAsync(_shapes, shapesCount, shapesSquare))
            {
                var foreGroundShape = _shapes.First(s => s.Id == shapeId);

                DrawShape(foreGroundShape, brush);
            }
        }
    }
}