using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private List<Point> points = new List<Point>
        {
            new Point { X = 0, Y = 0 },
            new Point { X = 100, Y = 100 },
            new Point { X = 120, Y = 200 },
            new Point { X = 140, Y = 250 },

            new Point { X = 160, Y = 310 },
            new Point { X = 150, Y = 350 },
            new Point { X = 80, Y = 360 },
        }.Select(x => Point.Add(x, new Size(200, 100))).ToList();
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawBeziers(new Pen(Color.Black, 2), points.Select(x => x).ToArray());
            points.ForEach(x => e.Graphics.DrawRectangle(Pens.Red, x.X, x.Y, 2, 2));
        }
        public void CallOnPaint(PaintEventArgs e) => this.OnPaint(e);
        public List<Point> Points => this.points;
    }
}
