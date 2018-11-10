namespace Paint.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Star
    {
        private static Point startPosition;

        public static void StartDrawing(Point cursor)
        {
            startPosition = cursor;
        }

        public static void Drawing(Graphics graphics, Pen pen, Point cursor)
        {
            int externalRadius = (int)Math.Sqrt(
                Math.Pow(startPosition.X - cursor.X, 2) + Math.Pow(startPosition.Y - cursor.Y, 2));
            int interiorRadius = (int)(externalRadius * 0.2);
            int countNodes = 5;
            double angle = -Math.Atan((double)(startPosition.Y - cursor.Y) / (startPosition.X - cursor.X));
            Point[] starPoints = new Point[(countNodes + 1) * 2];
            for (int i = 0; i < countNodes; i++)
            {
                starPoints[i * 2] = new Point(
                    x: startPosition.X - (int)(externalRadius * Math.Sin(2.0 * Math.PI / countNodes * i + angle)),
                    y: startPosition.Y - (int)(externalRadius * Math.Cos(2.0 * Math.PI / countNodes * i + angle)));
                starPoints[(i * 2) + 1] = new Point(
                    x: startPosition.X - (int)(interiorRadius
                                               * Math.Sin((2 * Math.PI / countNodes * i) + (Math.PI / 5.0) + angle)),
                    y: startPosition.Y - (int)(interiorRadius
                                               * Math.Cos((2 * Math.PI / countNodes * i) + (Math.PI / 5.0) + angle)));
            }

            starPoints[starPoints.Length - 2] = new Point(
                x: startPosition.X - (int)(externalRadius * Math.Sin(angle)),
                y: startPosition.Y - (int)(externalRadius * Math.Cos(angle)));
            starPoints[starPoints.Length - 1] = new Point(
                x: startPosition.X - (int)(interiorRadius * Math.Sin((Math.PI / 5.0) + angle)),
                y: startPosition.Y - (int)(interiorRadius * Math.Cos((Math.PI / 5.0) + angle)));
            graphics.DrawLines(pen, starPoints);
        }
    }
}