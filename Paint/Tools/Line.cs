namespace Paint
{
    using System.Drawing;

    public static class Line
    {
        private static Point startPosition;

        public static void StartDrawing(Point cursor)
        {
            startPosition = cursor;
        }

        public static void Drawing(Graphics graphics, Pen pen, Point cursor)
        {
            graphics.DrawLine(pen, startPosition.X, startPosition.Y, cursor.X, cursor.Y);
        }
    }
}