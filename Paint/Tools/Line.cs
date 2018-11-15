namespace Paint
{
    using System.Drawing;

    using Paint.Tools;

    public class Line : BaseTool
    {
        public override void Drawing(Point cursor)
        {
            _graphics.DrawLine(_pen, _startPosition.X, _startPosition.Y, cursor.X, cursor.Y);
        }
    }
}