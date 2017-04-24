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
            new Point { X = 127, Y = 159 },
            new Point { X = 237, Y = 122 },
            new Point { X = 351, Y = 191 },
            new Point { X = 277, Y = 316 },

            new Point { X = 211, Y = 431 },
            new Point { X = 46, Y = 436 },
            new Point { X = 201, Y = 293 },
        }.Select(x => Point.Add(x, new Size(100, -70))).ToList();
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawBeziers(new Pen(Color.Black, 2), points.Select(x => x).ToArray());
            points.ForEach(x => e.Graphics.DrawRectangle(Pens.Red, x.X, x.Y, 2, 2));
        }
        public void CallOnPaint(PaintEventArgs e) => this.OnPaint(e);
        public List<Point> Points => this.points;
    }
}
