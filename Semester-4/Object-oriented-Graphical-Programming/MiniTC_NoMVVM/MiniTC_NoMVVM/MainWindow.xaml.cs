namespace MiniTC_NoMVVM
{
    using System.Windows;
    using System.IO;
    using System;
    using System.Linq;

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Left.PathContents.SelectedIndex == -1) return;
            string leftFile = Path.Combine(Left.CurrentPath, Left.CurrentPathContents[Left.PathContents.SelectedIndex]);
            string rightFile = Path.Combine(Right.CurrentPath, Left.CurrentPathContents[Left.PathContents.SelectedIndex]);

            try{
                if (Right.CurrentPathContents.Contains(Left.CurrentPathContents[Left.PathContents.SelectedIndex]))
                {
                    MessageBoxResult overwrite =  MessageBox.Show($"Do you want to overwrite {Left.CurrentPathContents[Left.PathContents.SelectedIndex]}?", "OVERWRITE", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                    if(overwrite == MessageBoxResult.Yes)
                    {
                        File.Copy(leftFile, rightFile, true);
                        Right.PathContents.ItemsSource = Right.GetContents();
                        return;
                    }
                    return;
                }
                File.Copy(leftFile, rightFile, true);
                Right.PathContents.ItemsSource = Right.GetContents();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                Left.PathContents.ItemsSource = Left.GetContents();
                Right.PathContents.ItemsSource = Right.GetContents();
            }
        }
    }
}
