namespace Programowanie
{
    class Grafika
    {
        public static byte[] MACIERZ(ref System.Windows.Media.Imaging.WriteableBitmap input)
        {
            int width = input.PixelWidth;
            int height = input.PixelHeight;
            int stride = width * 4;
            int arraySize = stride * height;
            byte[] pixels = new byte[arraySize];

            input.CopyPixels(pixels, stride, 0);

            return pixels;
        }

        public static void GRAYSCALE(ref System.Windows.Media.Imaging.WriteableBitmap input)
        {
            byte[] pixels = MACIERZ(ref input);

            int color = 0;
            for (int i = 0; i < pixels.Length; i += 4)
            {
                color = (pixels[i] + pixels[i + 1] + pixels[i + 2]) / 3;
                pixels[i] = (byte)color;
                pixels[i + 1] = (byte)color;
                pixels[i + 2] = (byte)color;
                pixels[i + 3] = 255;
            }
            input.WritePixels(new System.Windows.Int32Rect(0, 0, input.PixelWidth, input.PixelHeight), pixels, input.PixelWidth * 4, 0);
        }

        public static void SEPIA(ref System.Windows.Media.Imaging.WriteableBitmap input)
        {
            byte[] pixels = MACIERZ(ref input);
            for (int i = 0; i < pixels.Length; i += 4)
            {
                int r = pixels[i + 2];
                int g = pixels[i + 1];
                int b = pixels[i];

                int tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                int tg = (int)(0.349 * r + 0.686 * g + 0.168 * b);
                int tb = (int)(0.272 * r + 0.534 * g + 0.131 * b);

                if (tr > 255)
                    tr = 255;
                if (tg > 255)
                    tg = 255;
                if (tb > 255)
                    tb = 255;

                pixels[i + 2] = (byte)tr;
                pixels[i + 1] = (byte)tg;
                pixels[i] = (byte)tb;
            }
            input.WritePixels(new System.Windows.Int32Rect(0, 0, input.PixelWidth, input.PixelHeight), pixels, input.PixelWidth * 4, 0);
        }

        public static void BLUR(ref System.Windows.Media.Imaging.WriteableBitmap input)
        {
            byte[] pixels = MACIERZ(ref input);
            int width = input.PixelWidth;
            int height = input.PixelHeight;
            int scale = 5;

            for (int x = scale; x < width - scale; x++)
            {
                for (int y = scale; y < height - scale; y++)
                {
                    int index = ((y * width) + x) * 4;

                    byte prevXB = pixels[index - (scale * 4) + 0];
                    byte prevXG = pixels[index - (scale * 4) + 1];
                    byte prevXR = pixels[index - (scale * 4) + 2];

                    byte nextXB = pixels[index + (scale * 4) + 0];
                    byte nextXG = pixels[index + (scale * 4) + 1];
                    byte nextXR = pixels[index + (scale * 4) + 2];

                    byte prevYB = pixels[index - (scale * width * 4) + 0];
                    byte prevYG = pixels[index - (scale * width * 4) + 1];
                    byte prevYR = pixels[index - (scale * width * 4) + 2];

                    byte nextYB = pixels[index + (scale * width * 4) + 0];
                    byte nextYG = pixels[index + (scale * width * 4) + 1];
                    byte nextYR = pixels[index + (scale * width * 4) + 2];

                    byte avgB = (byte)((prevXB + nextXB + prevYB + nextYB) / 4);
                    byte avgG = (byte)((prevXG + nextXG + prevYG + nextYG) / 4);
                    byte avgR = (byte)((prevXR + nextXR + prevYR + nextYR) / 4);

                    pixels[index] = avgB;
                    pixels[index + 1] = avgG;
                    pixels[index + 2] = avgR;
                }
            }
            input.WritePixels(new System.Windows.Int32Rect(0, 0, input.PixelWidth, input.PixelHeight), pixels, input.PixelWidth * 4, 0);
        }

        public static void NEGATYW(ref System.Windows.Media.Imaging.WriteableBitmap input)
        {
            byte[] pixels = MACIERZ(ref input);
            for (int i = 0; i < pixels.Length; i += 4)
            {
                pixels[i] = (byte)(255 - pixels[i]);
                pixels[i + 1] = (byte)(255 - pixels[i + 1]);
                pixels[i + 2] = (byte)(255 - pixels[i + 2]);
            }
            input.WritePixels(new System.Windows.Int32Rect(0, 0, input.PixelWidth, input.PixelHeight), pixels, input.PixelWidth * 4, 0);
        }

        public static void SHARPEN(ref System.Windows.Media.Imaging.WriteableBitmap input)
        {
            byte[] pixels = MACIERZ(ref input);
            int filterWidth = 3;
            int filterHeight = 3;
            int width = input.PixelWidth;
            int height = input.PixelHeight;

            double[,] filter = new double[filterWidth, filterHeight];
            filter[0, 0] = filter[0, 1] = filter[0, 2] = 
            filter[1, 0] = filter[1, 2] = 
            filter[2, 0] = filter[2, 1] = filter[2, 2] = -1;
            filter[1, 1] = 9;

            double factor = 1.0;
            double bias = 0.0;

            System.Drawing.Color[,] result = new System.Drawing.Color[width, height];

            int rgb = 0; ;
            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    double red = 0.0, green = 0.0, blue = 0.0;

                    for (int filterX = 0; filterX < filterWidth; filterX++)
                    {
                        for (int filterY = 0; filterY < filterHeight; filterY++)
                        {
                            int imageX = (x - filterWidth / 2 + filterX + width) % width;
                            int imageY = (y - filterHeight / 2 + filterY + height) % height;

                            rgb = imageY * (width * 4) + 3 * imageX;

                            red += pixels[rgb + 2] * filter[filterX, filterY];
                            green += pixels[rgb + 1] * filter[filterX, filterY];
                            blue += pixels[rgb + 0] * filter[filterX, filterY];
                        }
                        int r = System.Math.Min(System.Math.Max((int)(factor * red + bias), 0), 255);
                        int g = System.Math.Min(System.Math.Max((int)(factor * green + bias), 0), 255);
                        int b = System.Math.Min(System.Math.Max((int)(factor * blue + bias), 0), 255);

                        pixels[rgb + 0] = (byte)b;
                        pixels[rgb + 1] = (byte)g;
                        pixels[rgb + 2] = (byte)r;
                        result[x, y] = System.Drawing.Color.FromArgb(pixels[rgb + 2], pixels[rgb + 1], pixels[rgb + 0]);
                    }
                }
            }
            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    //input.WritePixels(new System.Windows.Int32Rect(0, 0, x, y), result[x, y], x * 4, 0);
                }
            }
            input.WritePixels(new System.Windows.Int32Rect(0, 0, input.PixelWidth, input.PixelHeight), pixels, input.PixelWidth * 4, 0);
        }
    }
}
