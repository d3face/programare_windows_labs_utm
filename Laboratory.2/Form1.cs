using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory._2
{
    public partial class Form1 : Form
    {
        private const int V = 80;

        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 2);

            // Create points that define line.
            Point point1 = new Point(100, 100);
            Point point2 = new Point(500, 100);
            int[] px = new int[100];
            int[] py = new int[100];
            for (int i = 0; i < V; i++)
            {
                px[i] = 50 + (i % 20) * 20;
                py[i] = 50 + ((i + 15) % 30) * 20;
            }
            for (int i = 1; i < V; i++)
            {
                e.Graphics.DrawLine(blackPen, px[i - 1], py[i - 1], px[i], py[i]);
            }
                        
            e.Graphics.DrawEllipse(blackPen, 500, 100, 700, 200);
        }
    }
}
