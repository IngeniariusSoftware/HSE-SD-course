namespace Paint.Tools
{
    using System;
    using System.Drawing;

    public class Star : BaseTool
    {
        public override void Drawing(Point cursor)
        {
            int externalRadius = (int)Math.Sqrt(
                Math.Pow(_startPosition.X - cursor.X, 2) + Math.Pow(_startPosition.Y - cursor.Y, 2));
            int interiorRadius = (int)(externalRadius * 0.4);
            int countNodes = 5;
            double angle = -Math.Atan((double)(_startPosition.Y - cursor.Y) / (_startPosition.X - cursor.X));
            Point[] starPoints = new Point[(countNodes + 1) * 2];
            for (int i = 0; i < countNodes; i++)
            {
                starPoints[i * 2] = new Point(
                    x: _startPosition.X - (int)(externalRadius * Math.Sin((2.0 * Math.PI / countNodes * i) + angle)),
                    y: _startPosition.Y - (int)(externalRadius * Math.Cos((2.0 * Math.PI / countNodes * i) + angle)));
                starPoints[(i * 2) + 1] = new Point(
                    x: _startPosition.X
                       - (int)(interiorRadius * Math.Sin((2 * Math.PI / countNodes * i) + (Math.PI / 5.0) + angle)),
                    y: _startPosition.Y
                       - (int)(interiorRadius * Math.Cos((2 * Math.PI / countNodes * i) + (Math.PI / 5.0) + angle)));
            }

            starPoints[starPoints.Length - 2] = new Point(
                x: _startPosition.X - (int)(externalRadius * Math.Sin(angle)),
                y: _startPosition.Y - (int)(externalRadius * Math.Cos(angle)));
            starPoints[starPoints.Length - 1] = new Point(
                x: _startPosition.X - (int)(interiorRadius * Math.Sin((Math.PI / 5.0) + angle)),
                y: _startPosition.Y - (int)(interiorRadius * Math.Cos((Math.PI / 5.0) + angle)));
            _graphics.DrawLines(_pen, starPoints);
        }
    }
}