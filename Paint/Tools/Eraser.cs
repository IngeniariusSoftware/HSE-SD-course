namespace Paint.Tools
{
    using System;
    using System.Drawing;

    public class Eraser : BaseTool
    {
        private Bitmap _eraserBoard;

        public void StartDrawing(Image picture, Pen pen, Point cursor)
        {
            _pen = pen;
            _startPosition = cursor;
            _eraserBoard = (Bitmap)picture;
            Drawing(cursor);
        }

        public override void Drawing(Point cursor)
        {
            for (int y = (int)Math.Max(_startPosition.Y - _pen.Width, 0);
                 y < Math.Min(_startPosition.Y + _pen.Width, _eraserBoard.Height);
                 ++y)
            {
                for (int x = (int)Math.Max(_startPosition.X - _pen.Width, 0);
                     x < Math.Min(_startPosition.X + _pen.Width, _eraserBoard.Width);
                     ++x)
                {
                    _eraserBoard.SetPixel(x, y, Color.Empty);
                }
            }

            _startPosition = cursor;
        }
    }
}