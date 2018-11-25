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

        public static WaterWave WaterWaveEffect = new WaterWave();

        public static Jitter JitterEffect = new Jitter();

        private static int[,] _kernelMatrix = { { -2, -1, 0 }, { -1, 1, 1 }, { 0, 1, 2 } };

        public static Convolution ConvolutionEffect = new Convolution(_kernelMatrix);

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
    }
}