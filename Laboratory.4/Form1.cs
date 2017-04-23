using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using WPoint = System.Windows.Point;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory._4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private List<Point> sheep = new List<Point>
        {
            new Point { X = 0, Y = 0 },
            new Point { X = 0, Y = 50 },
            new Point { X = 25, Y = 75 },
            new Point { X = 25, Y = -25 },
        }.Select(x => Point.Add(x, new Size(200, 200))).ToList();
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawPolygon(Pens.Black, sheep.ToArray());
            sheep.ForEach(x => e.Graphics.DrawRectangle(Pens.Black, x.X, x.Y, 2, 2));
        }
        protected override void OnResizeBegin(EventArgs e)
        {
            last = Size;
        }
        private Size last;
        protected override void OnResizeEnd(EventArgs e)
        {
            var diag = (new WPoint() - new WPoint(this.last.Width, this.last.Height)).Length / (new WPoint() - new WPoint(this.Size.Width, this.Size.Height)).Length;
            diag = 1 / diag;
            sheep = 
                sheep.Take(0).Union(
                    sheep.Skip(0).Select(x => new Point((int)(diag * x.X), (int)(diag * x.Y))).ToList()
                    ).ToList();
            this.Invalidate();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            Size diff = new Size();
            double angle = 0;
            switch (e.KeyCode)
            {
                case Keys.Up:
                    diff = new Size(0, -10);
                    break;
                case Keys.Down:
                    diff = new Size(0, 10);
                    break;
                case Keys.Left:
                    diff = new Size(-10, 0);
                    break;
                case Keys.Right:
                    diff = new Size(10, 0);
                    break;
                case Keys.A:
                    angle = -10;
                    break;
                case Keys.D:
                    angle = 10;
                    break;
            }
            var point = sheep.First();
            sheep = sheep.Select(x => Point.Add(x.Rotate(point, angle), diff)).ToList();
            this.Invalidate();
        }
    }
}
