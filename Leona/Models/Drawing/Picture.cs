using System.Drawing;
using System.Text;

namespace Leona.Models.Drawing
{
    public class Picture
    {
        public List<Line> Lines { get; set; }

        private double minX = 0;
        private double maxX = 0;
        private double minY = 0;
        private double maxY = 0;

        public Picture()
        {
            Lines = new List<Line>();
        }

        public void AddLine(Line line)
        {
            Lines.Add(line);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (Line line in Lines)
            {
                result.AppendLine(line.ToString());
            }

            return result.ToString().Trim();
        }

        public void WriteToFile(string filePath, int margin = 100)
        {
            foreach (Line line in Lines)
                UpdateBounds(line);

            int width = (int)(maxX - minX) + margin * 2;
            int height = (int)(maxY - minY) + margin * 2;

            BitmapWriter.BitmapWriter writer = new BitmapWriter.BitmapWriter(width, height);

            foreach(Line line in Lines)
                DrawLine(writer, line, margin);

            writer.SaveColorImage(filePath);
        }

        private void DrawLine(BitmapWriter.BitmapWriter writer, Line line, int margin)
        {
            int x0 = (int)Math.Round(line.Start.X);
            int y0 = (int)Math.Round(line.Start.Y);
            int x1 = (int)Math.Round(line.End.X);
            int y1 = (int)Math.Round(line.End.Y);
            Color color = ColorTranslator.FromHtml("#" + line.Color);

            int dx = Math.Abs(x1 - x0);
            int dy = Math.Abs(y1 - y0);
            int sx = (x0 < x1) ? 1 : -1;
            int sy = (y0 < y1) ? 1 : -1;
            int err = dx - dy;

            while (true)
            {
                writer.SetPixel(x0 + margin, y0 + margin, color.R, color.G, color.B);

                if (x0 == x1 && y0 == y1) break;
                int e2 = 2 * err;

                if (e2 > -dy)
                {
                    err -= dy;
                    x0 += sx;
                }

                if (e2 < dx)
                {
                    err += dx;
                    y0 += sy;
                }
            }
        }

        private void UpdateBounds(Line line) // will keep track of where max and min points are. Necessary if we want to later create an image from the lines
        {
            if (line.Start.X < minX)
                minX = line.Start.X;
            if (line.Start.X > maxX)
                maxX = line.Start.X;

            if (line.Start.Y < minY)
                minY = line.Start.Y;
            if (line.Start.Y > maxY)
                maxY = line.Start.Y;

            if (line.End.X < minX)
                minX = line.End.X;
            if (line.End.X > maxX)
                maxX = line.End.X;

            if (line.End.Y < minY)
                minY = line.End.Y;
            if (line.End.Y > maxY)
                maxY = line.End.Y;
        }
    }
}
