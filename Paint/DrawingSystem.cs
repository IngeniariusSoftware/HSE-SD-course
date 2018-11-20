namespace Paint
{
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    using Paint.Tools;

    public static class DrawingSystem
    {
        private static BaseTool _tool = new Pencil();

        private static Ellipse _ellipse = new Ellipse();

        private static Eraser _eraser = new Eraser();

        private static Line _line = new Line();

        private static Pencil _pencil = new Pencil();

        private static Rectangle _rectangle = new Rectangle();

        private static Star _star = new Star();

        private static BaseTool ToTool(string toolName)
        {
            _tool = _pencil;
            switch (toolName)
            {
                case "Rectangle":
                    {
                        _tool = _rectangle;
                        break;
                    }

                case "Ellipse":
                    {
                        _tool = _ellipse;
                        break;
                    }

                case "Star":
                    {
                        _tool = _star;
                        break;
                    }

                case "Eraser":
                    {
                        _tool = _eraser;
                        break;
                    }

                case "Line":
                    {
                        _tool = _line;
                        break;
                    }
            }

            return _tool;
        }

        private static Graphics _graphics;

        public static bool IsDrawing;

        public static Bitmap Buffer;

        private static Pen _pen = new Pen(Color.Black, 1);

        public static void EndDrawing(Image lastImage)
        {
            _graphics?.Dispose();
            _graphics = Graphics.FromImage(lastImage);
            if (Buffer != null)
            {
                _graphics.DrawImage(Buffer, 0, 0);
            }

            _graphics.Dispose();
            if (Buffer != null)
            {
                _graphics = Graphics.FromImage(Buffer);
                _graphics.Dispose();
                Buffer.Dispose();
                Buffer = null;
            }

            IsDrawing = false;
        }

        public static void StartDrawing(Point cursor, PictureBox pictureBox)
        {
            Buffer = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
            if (_tool is Eraser)
            {
                ((Eraser)_tool).StartDrawing(pictureBox.BackgroundImage, _pen, cursor);
            }
            else
            {
                pictureBox.Image = Buffer;
                _graphics = Graphics.FromImage(Buffer);
                _graphics.CompositingQuality = CompositingQuality.HighQuality;
                _graphics.SmoothingMode = SmoothingMode.HighQuality;
                _tool.StartDrawing(_graphics, _pen, cursor);
            }

            IsDrawing = true;
        }

        public static void Drawing(Point currentPosition)
        {
            if (!(_tool is Eraser || _tool is Pencil))
            {
                _graphics.Clear(Color.Empty);
            }

            _tool.Drawing(currentPosition);
        }

        public static void ChangePenSize(float penSize)
        {
            _pen.Width = penSize;
        }

        public static void ChangePenColor(Color newColor)
        {
            _pen.Color = newColor;
        }

        public static void ChangeTool(string newTool)
        {
            _tool = ToTool(newTool);
        }
    }
}