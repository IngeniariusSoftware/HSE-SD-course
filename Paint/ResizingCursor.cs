namespace Paint
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public static class ResizingCursor
    {
        public static void CheckCursor(Cursor cursor, Point locationElement, Size sizeElement, Point cursorLocalPosition)
        {
            double deltaDistance = 5;
            if (Math.Abs(cursorLocalPosition.X - sizeElement.Width - locationElement.X) < deltaDistance)
            {
                if (Math.Abs(cursorLocalPosition.Y - sizeElement.Height - locationElement.Y) < deltaDistance)
                {
                    cursor = Cursors.SizeNWSE;
                }
                else
                {
                    if (Math.Abs(cursorLocalPosition.Y - locationElement.Y) < deltaDistance)
                    {
                        cursor = Cursors.SizeWE;
                    }
                    else
                    {
                        cursor = Cursors.Arrow;
                    }
                }
            }
            else
            {
                if (Math.Abs(cursorLocalPosition.Y - sizeElement.Height - locationElement.Y) < deltaDistance)
                {
                    cursor = Cursors.SizeNWSE;
                }
                else
                {
                    if (Math.Abs(cursorLocalPosition.Y - locationElement.Y) < deltaDistance)
                    {
                        cursor = Cursors.SizeWE;
                    }
                    else
                    {
                        cursor = Cursors.Arrow;
                    }
                }
            }
        }
    }
}