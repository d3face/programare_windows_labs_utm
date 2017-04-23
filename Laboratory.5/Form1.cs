using Laboratory._4;
using FormLab3 = Laboratory._3.Form1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory._5
{
    public partial class FormLab5 : Form1
    {
        private FormLab3 bezierOnPaint = new FormLab3();
        public FormLab5(): base()
        {
            InitializeComponent();
        }
        private List<Point> points => this.bezierOnPaint.Points;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.bezierOnPaint.CallOnPaint(e);
        }
        protected Point? clickedPoint = null;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (MouseButtons.HasFlag(MouseButtons.Left))
            {
                const int V = 20;
                var clicked = points.FirstOrDefault(
                    x =>
                      x.X >= e.Location.X - V &&
                      x.X <= e.Location.X + V &&
                      x.Y >= e.Location.Y - V &&
                      x.Y <= e.Location.Y + V
                    );
                if (clicked == null || clicked.IsEmpty)
                {
                    return;
                }
                clickedPoint = clicked;
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (clickedPoint != null)
            {
                points[points.IndexOf(clickedPoint.Value)] = e.Location;
                this.Invalidate();
                clickedPoint = null;
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (MouseButtons.HasFlag(MouseButtons.Right))
            {
                var diff = new Size(
                    e.Location.X - this.sheep.First().X,
                    e.Location.Y - this.sheep.First().Y
                );
                this.sheep = this.sheep.Select(x => Point.Add(x, diff)).ToList();
                this.Invalidate();
            }
            if (clickedPoint != null)
            {
                lock (points)
                {
                    points[points.IndexOf(clickedPoint.Value)] = e.Location;
                    clickedPoint = e.Location;
                    this.Invalidate();
                }
            }
        }
    }
}
