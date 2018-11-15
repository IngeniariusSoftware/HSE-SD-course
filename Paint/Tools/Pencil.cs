namespace Paint
{
    using System.Drawing;

    using Paint.Tools;

    public class Pencil : BaseTool
    {
        public override void StartDrawing(Graphics graphics, Pen pen, Point cursor)
        {
            _pen = pen;
            _graphics = graphics;
            _startPosition = cursor;
            Drawing(cursor);
        }

        public override void Drawing(Point cursor)
        {
            _graphics.DrawLine(_pen, _startPosition.X, _startPosition.Y, cursor.X, cursor.Y);
            _startPosition = cursor;
        }
    }
}