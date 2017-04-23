using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory._6
{
    public partial class Form1 : Form
    {
        private const int centerX = 100;
        private const int centerY = 100;
        private const int radius = 200;
        private Timer clock = new Timer();
        public Form1()
        {
            InitializeComponent();
            clock.Interval = 1000;
            clock.Tick += Clock_Tick;
            clock.Start();
            Clock_Tick(null, EventArgs.Empty);
        }

        private void Clock_Tick(object sender, EventArgs e)
        {
            label1.Text = $"{DateTime.Now:s}";
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(Pens.Red, centerX, centerY, radius, radius);

            var realSecond = DateTime.Now.Second;
            var fakedSecond = -realSecond + 30;
            var point = Utilities.GetPointFromNumber(fakedSecond, radius / 2);
            point = Point.Add(point, new Size(200, 200));
            e.Graphics.DrawLine(Pens.Blue, Center,
                point
            );

            var realMinute = DateTime.Now.Minute;
            var fakedMinute = -realMinute + 30;
            point = Utilities.GetPointFromNumber(fakedMinute, radius / 2, R.M);
            point = Point.Add(point, new Size(200, 200));
            e.Graphics.DrawLine(Pens.BlueViolet, Center,
                point
            );

            var realHour = DateTime.Now.Hour;
            var fakedHour = realHour;
            point = Utilities.GetPointFromNumber(fakedHour, radius / 2, R.H);
            point = Point.Add(point, new Size(200, 200));
            e.Graphics.DrawLine(Pens.DodgerBlue, Center,
                point
            );
        }
        protected Point Center => new Point(centerX + radius / 2, centerY + radius / 2);
    }
}
