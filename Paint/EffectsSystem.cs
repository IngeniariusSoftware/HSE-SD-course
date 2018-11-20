namespace Paint
{
    using System.Drawing;
    using AForge.Imaging.Filters;

    public static class EffectsSystem
    {
        public static Sepia SepiaEffect = new Sepia();

        public static SimpleSkeletonization SimpleSkeletonizationEffect = new SimpleSkeletonization();

        public static GaussianBlur GaussianBlurEffect = new GaussianBlur();

        public static GaussianSharpen GaussianSharpenEffect = new GaussianSharpen();

        public static Negative NegativeEffect = new Negative();

        public static GreenNegative GreenNegativeEffect = new GreenNegative();

        public static Stamping StampingEffect = new Stamping();

        public class Negative
        {
            public void ApplyInPlace(Bitmap image)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        image.SetPixel(x, y, Color.Aqua);
                    }
                }
            }
        }

        public class GreenNegative
        {
            public void ApplyInPlace(Bitmap image)
            {

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