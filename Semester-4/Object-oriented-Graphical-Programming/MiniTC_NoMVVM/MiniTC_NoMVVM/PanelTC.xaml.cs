namespace MiniTC_NoMVVM
{
    using System.Windows.Controls;
    using System.Collections.Generic;
    using System.IO;
    using System;
    using System.Linq;
    using System.Windows;

    public partial class PanelTC : UserControl, IPanelTC
    {
        string currentPath = null;
        string[] availableDrives = null;
        string[] currentPathContents = null;

        public PanelTC()
        {
            InitializeComponent();
            availableDrives = Directory.GetLogicalDrives();
            currentPath = Path.GetPathRoot(Environment.SystemDirectory);
            currentPathContents = GetContents();

            Path_tb.Text = CurrentPath;
            Drives.ItemsSource = AvailableDrives;
            Drives.SelectedIndex = 0;
            PathContents.ItemsSource = currentPathContents;
        }

        public string CurrentPath
        {
            get => currentPath;
            set
            {
                currentPath = value;
            }
        }
        public string[] AvailableDrives
        {
            get => availableDrives;
            set
            {
                availableDrives = value;
            }
        }
        public string[] CurrentPathContents
        {
            get => currentPathContents;
            set
            {
                currentPathContents = value;
            }
        }

        public string[] GetContents()
        {
            string[] temp1 = null;
            string[] temp2 = null;
            string[] temp3 = null;
            try
            {
                temp1 = Directory.GetDirectories(currentPath);
                for (int i = 0; i < temp1.Length; i++)
                {
                    temp1[i] = Path.GetFileName(temp1[i]);
                    temp1[i] = $"<D>{temp1[i]}";
                }

                temp2 = Directory.GetFiles(currentPath);
                for (int i = 0; i < temp2.Length; i++)
                    temp2[i] = Path.GetFileName(temp2[i]);

                int size = temp1.Length + temp2.Length;
                temp3 = null;
                if (!availableDrives.Contains(currentPath))
                {
                    temp3 = new string[size + 1];
                    temp3[0] = "..";
                    Array.Copy(temp1, 0, temp3, 1, temp1.Length);
                    Array.Copy(temp2, 0, temp3, temp1.Length + 1, temp2.Length);
                }
                else
                {
                    temp3 = new string[size];
                    Array.Copy(temp1, temp3, temp1.Length);
                    Array.Copy(temp2, 0, temp3, temp1.Length, temp2.Length);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                currentPath = currentPath.Substring(0, currentPath.Length - 1);
                int index = currentPath.LastIndexOf("\\");
                currentPath = currentPath.Substring(0, index + 1);
                Path_tb.Text = currentPath;
                return GetContents();
            }
            return temp3;
        }

        private void Drives_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Drives.SelectedIndex == -1) return;
            currentPath = availableDrives[Drives.SelectedIndex];
            Path_tb.Text = currentPath;
            currentPathContents = GetContents();
            PathContents.ItemsSource = currentPathContents;
        }

        private void PathContents_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (PathContents.SelectedIndex == -1) return;
            string item = currentPathContents[PathContents.SelectedIndex];
            if (item.StartsWith("<D>"))
            {
                currentPath += $"{item.Substring(3)}\\";
                Path_tb.Text = currentPath;
                currentPathContents = GetContents();
                PathContents.ItemsSource = currentPathContents;
                PathContents.SelectedIndex = -1;
            }
            else if (item == "..")
            {
                currentPath = currentPath.Substring(0, currentPath.Length - 1);
                int index = currentPath.LastIndexOf("\\");
                currentPath = currentPath.Substring(0, index + 1);
                Path_tb.Text = currentPath;
                currentPathContents = GetContents();
                PathContents.ItemsSource = currentPathContents;
                PathContents.SelectedIndex = -1;
            }
        }
    }
}
