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
        private DateTime now = DateTime.Now;
        private bool isFaked = false;
        private Random r = new Random();
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
            now = DateTime.Now;
            clock.Interval = isFaked ? (int)numericUpDown1.Value : 1000;
            mode_name.Text = isFaked ? "faked" : "real";
            if (isFaked) now = now.Add(new TimeSpan(r.Next() % 24, r.Next() % 60, r.Next() % 60));
            label1.Text = $"{now:s}";
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(Pens.Red, centerX, centerY, radius, radius);

            var realSecond = now.Second;
            var fakedSecond = -realSecond + 30;
            var point = Utilities.GetPointFromNumber(fakedSecond, radius / 2);
            e.Graphics.DrawLine(Pens.Blue, Center,
                Point.Add(point, new Size(200, 200))
            );
            second.Text = $"{realSecond} - {point}";

            var realMinute = now.Minute;
            var fakedMinute = -realMinute + 30;
            point = Utilities.GetPointFromNumber(fakedMinute, radius / 2, R.M);
            e.Graphics.DrawLine(Pens.BlueViolet, Center,
                Point.Add(point, new Size(200, 200))
            );
            minute.Text = $"{realMinute} - {point}";

            var realHour = now.Hour;
            var fakedHour = -realHour + 6;
            point = Utilities.GetPointFromNumber(fakedHour, radius / 2, R.H);
            e.Graphics.DrawLine(Pens.DodgerBlue, Center,
                Point.Add(point, new Size(200, 200))
            );
            hour.Text = $"{realHour} - {point}";
        }
        protected Point Center => new Point(centerX + radius / 2, centerY + radius / 2);

        private void button1_Click(object sender, EventArgs e)
        {
            this.isFaked = !this.isFaked;
            this.Clock_Tick(null, null);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.isFaked = true;
            this.Clock_Tick(null, null);
        }
    }
}
