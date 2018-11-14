namespace Paint
{
    using System;
    using System.Drawing;

    using Paint.Tools;

    public class Ellipse:BaseTool
    {
        private Point startPosition;

        public void StartDrawing(Graphics graphics, Pen pen, Point cursor):base(graphics, pen, cursor)
        {

        }

        public void Drawing(Point cursor):base(cursor)
        {
            graphics.DrawEllipse(
                pen,
                Math.Min(startPosition.X, cursor.X),
                Math.Min(startPosition.Y, cursor.Y),
                Math.Abs(cursor.X - startPosition.X),
                Math.Abs(cursor.Y - startPosition.Y));
        }
    }
}