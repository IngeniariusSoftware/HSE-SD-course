using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Tools
{
    using System.Drawing;

    public static class Eraser
    {
        private static Point startPosition;

        private static Bitmap _eraserBoard;

        public static void StartDrawing(Image picture, Pen pen, Point cursor)
        {
            _eraserBoard = (Bitmap)picture;
            for (int y = (int)Math.Max(startPosition.Y - pen.Width, 0);
                 y < Math.Min(startPosition.Y + pen.Width, _eraserBoard.Height);
                 ++y)
            {
                for (int x = (int)Math.Max(startPosition.X - pen.Width, 0);
                     x < Math.Min(startPosition.X + pen.Width, _eraserBoard.Width);
                     ++x)
                {
                    _eraserBoard.SetPixel(x, y, Color.Empty);
                }
            }

            startPosition = cursor;
        }

        public static void Drawing(Graphics graphics, Pen pen, Point cursor)
        {
            for (int y = (int)Math.Max(startPosition.Y - pen.Width, 0);
                 y < Math.Min(startPosition.Y + pen.Width, _eraserBoard.Height);
                 ++y)
            {
                for (int x = (int)Math.Max(startPosition.X - pen.Width, 0);
                     x < Math.Min(startPosition.X + pen.Width, _eraserBoard.Width);
                     ++x)
                {
                    _eraserBoard.SetPixel(x, y, Color.Empty);
                }
            }

            startPosition = cursor;
        }
    }
}
