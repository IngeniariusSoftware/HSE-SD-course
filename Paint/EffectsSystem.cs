namespace Paint
{
    using System.Drawing;
    using AForge.Imaging.Filters;

    public static class EffectsSystem
    {
        public static Sepia SepiaEffect = new Sepia();

        public static GaussianBlur GaussianBlurEffect = new GaussianBlur();

        public static GaussianSharpen GaussianSharpenEffect = new GaussianSharpen();

        public static Negative NegativeEffect = new Negative();

        public static Stamping StampingEffect = new Stamping();

        public class Negative
        {
            public void ApplyInPlace(Bitmap image)
            {

                for (int y = 0; y < image.Height; y++)
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        Color pixelColor = image.GetPixel(x, y);
                        if (pixelColor.A > 0.1)
                        {
                            image.SetPixel(
                                x,
                                y,
                                Color.FromArgb(
                                    pixelColor.A,
                                    255 - pixelColor.R,
                                    255 - pixelColor.G,
                                    255 - pixelColor.B));
                        }
                    }
                }
            }
        }

        public class Stamping
        {
            public void ApplyInPlace(Bitmap image)
            {
                
            }
        }
    }
}