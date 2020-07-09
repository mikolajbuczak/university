namespace Graphipcs_and_Detectors
{
    using System.Drawing;
    using System.Diagnostics;
    using System;
    static class Graphics
    {
        static readonly uint MATRIX_SIZE = 3;
        static readonly uint WEIGHT = 8;
        public static void GetKeyPointsPicture(string inputPath, string outputPath)
        {
            Bitmap bitmap = new Bitmap(inputPath);

            Bitmap newBitmap = new Bitmap(bitmap);

            Color[,] colors = GetColors(bitmap);

            int[][] matrix = GetMatrix();
            int matrixSum = CalculateMatrixSum(matrix);

            for(int i = 0; i < bitmap.Width - 2; i++)
            {
                for(int j = 0; j < bitmap.Height - 2; j++)
                {
                    int sumR = 0, sumG = 0, sumB = 0;
                    for (int k = 0; k < MATRIX_SIZE; k++)
                    {
                        for (int l = 0; l < MATRIX_SIZE; l++)
                        {
                            sumR += colors[i + k, j + k].R * matrix[k][l];
                            sumG += colors[i + k, j + k].G * matrix[k][l];
                            sumB += colors[i + k, j + k].B * matrix[k][l];
                        }
                    }
                    if (matrixSum != 0)
                    {
                        sumR /= matrixSum;
                        sumG /= matrixSum;
                        sumB /= matrixSum;
                    }

                    if (sumR > 255) sumR = 255;
                    else if (sumR < 0) sumR = 0;
                    if (sumG > 255) sumG = 255;
                    else if (sumG < 0) sumG = 0;
                    if (sumB > 255) sumB = 255;
                    else if (sumB < 0) sumB = 0;
                    Color dozmiany = Color.FromArgb(sumR, sumG, sumB);
                    if (dozmiany.GetBrightness() > 0.35)
                    {
                        newBitmap.SetPixel(i + 2, j + 2, Color.FromArgb(255, 255, 0));
                    }
                }
            }

            newBitmap.Save(outputPath, System.Drawing.Imaging.ImageFormat.Png);
            Process.Start(@"cmd.exe ", @"/c" + Environment.CurrentDirectory + outputPath);
            Console.WriteLine("JPG file with keypoints saved correctly.");
        }

        static Color[,] GetColors(Bitmap bitmap)
        {
            Color[,] colors = new Color[bitmap.Width, bitmap.Height];
            for (int i = 0; i < bitmap.Width; i++)
                for (int j = 0; j < bitmap.Height; j++)
                    colors[i, j] = bitmap.GetPixel(i, j);
            return colors;
        }

        static int[][] GetMatrix()
        {
            int[][] matrix = new int[MATRIX_SIZE][];

            for(int i = 0; i < MATRIX_SIZE; i++)
            {
                matrix[i] = new int[MATRIX_SIZE];
                for (int j = 0; j < MATRIX_SIZE; j++)
                    matrix[i][j] = -1;
            }
                
            if(MATRIX_SIZE % 2 != 0)
            {
                matrix[MATRIX_SIZE / 2][MATRIX_SIZE / 2] = (int)WEIGHT;
            }
            else
            {
                for (int i = 0; i < 2; i++)
                    for (int j = 0; j < 2; j++)
                        matrix[(MATRIX_SIZE / 2) - i][(MATRIX_SIZE / 2) - j] = (int)WEIGHT;
            }

            return matrix;
        }

        static int CalculateMatrixSum(int[][] matrix)
        {
            int sum = 0;
            for (int i = 0; i < MATRIX_SIZE; i++)
                for (int j = 0; j < MATRIX_SIZE; j++)
                    sum += matrix[i][j];
            return sum;
        }
    }
}
