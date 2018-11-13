namespace Paint
{
    using AForge.Imaging.Filters;

    public static class EffectsSystem
    {
        public static Blur BlurEffect = new Blur();

        public static Sharpen SharpenEffect = new Sharpen();

        public static Mirror MirrorXEffect = new Mirror(true, false);

        public static Mirror MirrorYEffect = new Mirror(false, true);

        public static Sepia SepiaEffect = new Sepia();

        public static SimpleSkeletonization SimpleSkeletonizationEffect = new SimpleSkeletonization();

        public static GaussianBlur GaussianBlurEffect = new GaussianBlur();

        public static GaussianSharpen GaussianSharpenEffect = new GaussianSharpen();
    }
}
