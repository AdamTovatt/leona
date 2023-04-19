namespace Leona.Models.Drawing
{
    public class Line
    {
        public Position Start { get; set; }
        public Position End { get; set; }
        public string Color { get; set; }

        public Line(Position start, Position end, string color)
        {
            Start = start;
            End = end;
            Color = color;
        }

        public override string ToString()
        {
            return $"#{Color} {Start} {End}";
        }
    }
}
