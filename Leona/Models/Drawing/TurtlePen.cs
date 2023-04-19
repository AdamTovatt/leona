namespace Leona.Models.Drawing
{
    public class TurtlePen
    {
        public bool IsDown { get; set; }
        public Position Position { get; set; }
        public double Angle { get; set; }
        public string Color { get; set; }

        private Picture picture;

        public TurtlePen(Picture picture)
        {
            IsDown = false;
            Position = new Position(0, 0);
            Color = "0000FF";
            Angle = 0;
            this.picture = picture;
        }

        public void Move(int distance)
        {
            double radians = Angle * Math.PI / 180;
            double x = (double)Math.Cos((double)radians) * distance;
            double y = (double)Math.Sin((double)radians) * distance;

            double startX = Position.X;
            double startY = Position.Y;

            Position.Offset(x, y);

            if (IsDown)
                picture.AddLine(new Line(new Position(startX, startY), Position.CreateCopy(), Color));
        }

        public void Turn(int angle)
        {
            Angle += angle;
        }

        public void SetColor(string color)
        {
            Color = color;
        }
    }
}
