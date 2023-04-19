using Leona.Helpers;

namespace Leona.Models.Drawing
{
    public class Position
    {
        private const double precisionLimit = 0.000000001;

        public double X { get; set; }
        public double Y { get; set; }

        public Position(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Position CreateCopy()
        {
            return new Position(X, Y);
        }

        public void Offset(double x, double y)
        {
            X += Math.Abs(x) < precisionLimit ? 0 : x; // if x is too small, set it to 0
            Y += Math.Abs(y) < precisionLimit ? 0 : y; // same with y. This is to prevent floating point errors
        }

        public override string ToString()
        {
            return $"{X.ToFormattedString()} {Y.ToFormattedString()}";
        }
    }
}
