using System;
using System.Drawing;

namespace Laboratory._6
{
    public enum R { S, M, H };
    public class Utilities
    {
        public static Point GetPointFromNumber(int n, int maxValue, R x = R.S)
        {
            var v = n * Math.PI / GetCoeficient(x);
            return new Point
            {
                X = (int)(maxValue * Math.Sin(Convert.ToDouble(v))),
                Y = (int)(maxValue * Math.Cos(Convert.ToDouble(v)))
            };
        }
        public static double GetCoeficient(R x)
        {
            switch (x)
            {
                case R.S: return 30d;
                case R.M: return 30d;
                case R.H: return 6d;
            }
            throw new ArgumentException(nameof(x));
        }
    }
}
