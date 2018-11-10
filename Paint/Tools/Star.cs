namespace Paint.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Star
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
