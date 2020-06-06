namespace Graphipcs_and_Detectors
{
    using System.Drawing;
    static class Graphics
    {
        public static void GetKeyPoints(string filePath)
        {
            Bitmap bitmap = new Bitmap(filePath);

            Bitmap newBitmap = new Bitmap(bitmap);

            Color[,] colors = GetColors(bitmap);
        }

        static Color[,] GetColors(Bitmap bitmap)
        {
            Color[,] colors = new Color[bitmap.Width, bitmap.Height];
            for (int i = 0; i < bitmap.Width; i++)
                for (int j = 0; j < bitmap.Height; j++)
                    colors[i, j] = bitmap.GetPixel(i, j);
            return colors;
        }
    }
}
