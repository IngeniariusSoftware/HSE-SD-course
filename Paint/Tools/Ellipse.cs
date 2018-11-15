namespace Paint
{
    using System;
    using System.Drawing;

    using Paint.Tools;

    public class Ellipse : BaseTool
    {
        public override void Drawing(Point cursor)
        {
            _graphics.DrawEllipse(
                _pen,
                Math.Min(_startPosition.X, cursor.X),
                Math.Min(_startPosition.Y, cursor.Y),
                Math.Abs(cursor.X - _startPosition.X),
                Math.Abs(cursor.Y - _startPosition.Y));
        }
    }
}