using System.Collections.Generic; // ben�tigt f�r Listen

namespace gdi_PointAndClick
{
    public partial class FrmMain : Form
    {
        List<Rectangle> rectangles = new List<Rectangle>();
        List<Point> points = new List<Point>();

        public FrmMain()
        {
            InitializeComponent();
            ResizeRedraw = true;
        }

        private void FrmMain_Paint(object sender, PaintEventArgs e)
        {
            // Hilfsvarablen
            Graphics g = e.Graphics;
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            // Zeichenmittel
            Brush b = new SolidBrush(Color.Red);


            for (int i = 0; i < rectangles.Count; i++)
            {
                g.FillRectangle(b, rectangles[i]);
            }

        }

        private void FrmMain_MouseClick(object sender, MouseEventArgs e)
        {
            Point mausposition = e.Location;
            
            Rectangle r = new Rectangle(mausposition.X-20, mausposition.Y-20, 40, 40);
            
            if (!points.Contains(mausposition))
            {
                rectangles.Add(r); // Kurze Variante: rectangles.Add( new Rectangle(...)  );
                points.Add(mausposition);
            }
                
            Refresh();
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                rectangles.Clear();
                Refresh();
            }
        }
    }
}