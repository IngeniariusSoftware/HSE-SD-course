namespace Paint
{
    using System;
    using System.Drawing;

    public static class Rectangle
    {
        private static Point startPosition;

        public static void StartDrawing(Point cursor)
        {
            startPosition = cursor;
        }

        public static void Drawing(Graphics graphics, Pen pen, Point cursor)
        {
            graphics.DrawRectangle(
                pen,
                Math.Min(startPosition.X, cursor.X),
                Math.Min(startPosition.Y, cursor.Y),
                Math.Abs(cursor.X - startPosition.X),
                Math.Abs(cursor.Y - startPosition.Y));
        }
    }
}
