namespace Paint.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class BaseTool
    {
        private Point _startPosition;

        private Graphics _graphics;

        private Pen _pen;

        public void StartDrawing(Graphics graphics, Pen pen, Point cursor)
        {
            _pen = pen;
            _graphics = graphics;
            _startPosition = cursor;
        }

        public abstract void Drawing(Point cursor);

    }
}
