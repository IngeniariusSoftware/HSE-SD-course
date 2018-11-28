namespace Paint
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public static class ResizingCursor
    {
        private static double _deltaDistance = 10;

        public static bool isResizeMode = false;

        public static bool CheckCursor(Point locationElement, Size sizeElement, Point cursorLocalPosition)
        {
            Console.WriteLine(
                $"locationElement: {locationElement} sizeElement {sizeElement} cursor: {cursorLocalPosition}");
            if (Math.Abs(cursorLocalPosition.X - sizeElement.Width - locationElement.X) < _deltaDistance)
            {
                if (Math.Abs(cursorLocalPosition.Y - sizeElement.Height - locationElement.Y) < _deltaDistance)
                {
                    Cursor.Current = Cursors.SizeNWSE;
                }
                else
                {
                    if (locationElement.Y < cursorLocalPosition.Y
                        && cursorLocalPosition.Y < sizeElement.Height + locationElement.Y)
                    {
                        Cursor.Current = Cursors.SizeWE;
                    }
                    else
                    {
                        Cursor.Current = Cursors.Arrow;
                    }
                }
            }
            else
            {
                if (Math.Abs(cursorLocalPosition.Y - sizeElement.Height - locationElement.Y) < _deltaDistance)
                {
                    if (locationElement.X < cursorLocalPosition.X
                        && cursorLocalPosition.X < sizeElement.Width + locationElement.X)
                    {
                        Cursor.Current = Cursors.SizeNS;
                    }
                    else
                    {
                        Cursor.Current = Cursors.Arrow;
                    }
                }
                else
                {
                    Cursor.Current = Cursors.Arrow;
                }
            }

            if (Cursor.Current == Cursors.Arrow)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}