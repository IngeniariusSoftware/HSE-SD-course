namespace Paint
{
    using System.Drawing;

    public static class Pencil
    {
        private static Point startPosition;

        public static void StartDrawing(Graphics graphics, Pen pen, Point cursor)
        {
            graphics.DrawLine(pen, startPosition.X, startPosition.Y, startPosition.X, startPosition.Y);
            startPosition = cursor;
        }

        public static void Drawing(Graphics graphics, Pen pen, Point cursor)
        {
            graphics.DrawLine(pen, startPosition.X, startPosition.Y, cursor.X, cursor.Y);
            startPosition = cursor;
        }
    }
}