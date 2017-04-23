using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory._4
{
    public static class PointExtensions
    {
        public static Point Rotate(this Point point, Point pivot, double angleDegree)
        {
            if (angleDegree == 0)
                return point;
            double angle = angleDegree * Math.PI / 180;
            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);
            int dx = point.X - pivot.X;
            int dy = point.Y - pivot.Y;
            double x = cos * dx - sin * dy + pivot.X;
            double y = sin * dx + cos * dy + pivot.Y;

            Point rotated = new Point((int)Math.Round(x), (int)Math.Round(y));
            return rotated;
        }
    }
}
