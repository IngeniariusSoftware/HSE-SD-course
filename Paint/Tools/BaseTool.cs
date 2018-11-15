namespace Paint.Tools
{
    using System.Drawing;

    public abstract class BaseTool
    {
        protected Point _startPosition;

        protected Graphics _graphics;

        protected Pen _pen;

        public virtual void StartDrawing(Graphics graphics, Pen pen, Point cursor)
        {
            _pen = pen;
            _graphics = graphics;
            _startPosition = cursor;
        }

        public abstract void Drawing(Point cursor);
    }
}
