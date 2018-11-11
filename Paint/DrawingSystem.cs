namespace Paint
{
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    using Paint.Tools;

    public static class DrawingSystem
    {
        public enum Tools
        {
            Pen,

            Line,

            Rectangle,

            Ellipse,

            Star,

            Eraser,

            LoupePlus,

            LoupeMinus
        }

        private static Tools _tool = Tools.Pen;

        private static Tools ToTool(string toolName)
        {
            Tools tool = Tools.Pen;
            switch (toolName)
            {
                case "Rectangle":
                    {
                        tool = Tools.Rectangle;
                        break;
                    }

                case "Ellipse":
                    {
                        tool = Tools.Ellipse;
                        break;
                    }

                case "Star":
                    {
                        tool = Tools.Star;
                        break;
                    }

                case "Eraser":
                    {
                        tool = Tools.Eraser;
                        break;
                    }

                case "Line":
                    {
                        tool = Tools.Line;
                        break;
                    }

                case "LoupeMinus":
                    {
                        tool = Tools.LoupeMinus;
                        break;
                    }

                case "LoupePlus":
                    {
                        tool = Tools.LoupePlus;
                        break;
                    }
            }

            return tool;
        }

        private static Graphics _graphics;

        public static bool IsDrawing = false;

        public static Bitmap Buffer = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

        private static Color _penColor = Color.Black;

        private static Size _paintRegionSize;

        private static Color PenColor
        {
            get
            {
                return _penColor;
            }
            set
            {
                _penColor = value;
                _pen.Color = _penColor;
            }
        }

        private static Color _eraserColor = Color.Empty;

        private static Pen _pen = new Pen(Color.Black, 1);

        public static void EndDrawing(Image lastImage)
        {
            _graphics = Graphics.FromImage(lastImage);
            _graphics.SetClip(new System.Drawing.Rectangle(0, 0, _paintRegionSize.Width, _paintRegionSize.Height));
            _graphics.DrawImage(Buffer, 0, 0);
            _graphics = Graphics.FromImage(Buffer);
            _graphics.Clear(Color.Empty);
            IsDrawing = false;
            _pen.Color = _penColor;
        }

        public static void StartDrawing(Point cursor)
        {
            _graphics = Graphics.FromImage(Buffer);

            _graphics.CompositingQuality = CompositingQuality.HighQuality;
            _graphics.SmoothingMode = SmoothingMode.HighQuality;
            IsDrawing = true;
            switch (_tool)
            {
                case Tools.Line:
                    {
                        Line.StartDrawing(cursor);
                        break;
                    }

                case Tools.Rectangle:
                    {
                        Rectangle.StartDrawing(cursor);
                        break;
                    }

                case Tools.Ellipse:
                    {
                        Ellipse.StartDrawing(cursor);
                        break;
                    }

                case Tools.Star:
                    {
                        Star.StartDrawing(cursor);
                        break;
                    }

                case Tools.Pen:
                    {
                        Pencil.StartDrawing(_graphics, _pen, cursor);
                        break;
                    }

                case Tools.Eraser:
                    {
                        _pen.Color = _eraserColor;
                        Pencil.StartDrawing(_graphics, _pen, cursor);
                        break;
                    }
            }
        }

        public static void Drawing(Point currentPosition)
        {
            switch (_tool)
            {
                case Tools.Line:
                    {
                        _graphics.Clear(Color.Empty);
                        Line.Drawing(_graphics, _pen, currentPosition);
                        break;
                    }

                case Tools.Rectangle:
                    {
                        _graphics.Clear(Color.Empty);
                        Rectangle.Drawing(_graphics, _pen, currentPosition);
                        break;
                    }

                case Tools.Ellipse:
                    {
                        _graphics.Clear(Color.Empty);
                        Ellipse.Drawing(_graphics, _pen, currentPosition);
                        break;
                    }

                case Tools.Star:
                    {
                        _graphics.Clear(Color.Empty);
                        Star.Drawing(_graphics, _pen, currentPosition);
                        break;
                    }

                case Tools.Pen:
                    {
                        Pencil.Drawing(_graphics, _pen, currentPosition);
                        break;
                    }

                case Tools.Eraser:
                    {
                        Pencil.Drawing(_graphics, _pen, currentPosition);
                        break;
                    }
            }
        }

        public static void ChangePenSize(float penSize)
        {
            _pen.Width = penSize;
        }

        public static void ChangePenColor(Color newColor)
        {
            PenColor = newColor;

        }

        public static void ChangeTool(string newTool)
        {
            _tool = ToTool(newTool);
        }

        public static void SetBackgroundColor(Color backGroundColor)
        {
            _eraserColor = backGroundColor;
        }

        public static void SetPaintRegionSize(Size size)
        {
            _paintRegionSize = size;
        }
    }
}
