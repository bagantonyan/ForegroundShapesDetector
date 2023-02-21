using Microsoft.Spatial;

namespace ForegroundShapesDetector.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            CoordinateSystem coordinateSystem = new CoordinateSystem();
        }
    }
}