namespace Programowanie
{
    public partial class GrafikaWindow : System.Windows.Window
    {
        private System.Windows.Media.Imaging.WriteableBitmap image;
        private System.Windows.Media.Imaging.BitmapImage original;
        public GrafikaWindow()
        {
            InitializeComponent();
        }

        private void OpenBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "JPG|*.jpg|JPEG|*.jpeg|BMP|*.bmp|PNG|*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                original = new System.Windows.Media.Imaging.BitmapImage();
                original.BeginInit();
                original.UriSource = new System.Uri(openFileDialog.FileName);
                original.EndInit();

                image = new System.Windows.Media.Imaging.WriteableBitmap(original);

                ImageBox.Source = image;

                SavePixelsBtn.IsEnabled = true;
                SaveBtn.IsEnabled = true;
                MethodsList.IsEnabled = true;
                MethodsList.SelectedIndex = 0;
                SetBtn.IsEnabled = true;
            }
        }

        private void SavePixelsBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "Text File|*.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                byte[] pixels = Grafika.MACIERZ(ref image);
                System.Text.StringBuilder result = new System.Text.StringBuilder();
                int j = 0;
                for (int i = 0; i < pixels.Length / 4; ++i)
                {
                    result.Append(pixels[j]);
                    result.Append(' ');
                    result.Append(pixels[j + 1]);
                    result.Append(' ');
                    result.Append(pixels[j + 2]);
                    result.Append(' ');
                    result.Append(pixels[j + 3]);
                    result.Append('\n');
                    j += 4;
                }
                System.IO.File.WriteAllText(saveFileDialog.FileName, result.ToString());
            }
        }

        private void SaveBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "JPG|*.jpg|JPEG|*.jpeg|BMP|*.bmp|PNG|*.png";
            if (saveFileDialog.ShowDialog() == true)
            {
                System.Windows.Media.Imaging.BitmapEncoder encoder = new System.Windows.Media.Imaging.PngBitmapEncoder();
                encoder.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(image));

                using (var fileStream = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                {
                    encoder.Save(fileStream);
                }
            }
        }

        private void SetBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            switch (MethodsList.SelectedIndex)
            {
                case 0:
                    Grafika.GRAYSCALE(ref image);
                    ImageBox.Source = image;
                    break;
                case 1:
                    Grafika.SEPIA(ref image);
                    ImageBox.Source = image;
                    break;
                case 2:
                    Grafika.BLUR(ref image);
                    ImageBox.Source = image;
                    break;
                case 3:
                    Grafika.NEGATYW(ref image);
                    ImageBox.Source = image;
                    break;
                case 4:
                    Grafika.SHARPEN(ref image);
                    ImageBox.Source = image;
                    break;
            }
        }
    }
}
