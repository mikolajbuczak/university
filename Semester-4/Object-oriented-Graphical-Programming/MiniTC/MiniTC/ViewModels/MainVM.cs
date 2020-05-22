namespace MiniTC.ViewModels
{
    using BaseClass;
    using System.IO;
    using System.Windows;
    using System;
    using System.Linq;
    using System.Collections.ObjectModel;

    internal partial class MainVM:ViewModelBase
    {
        static int defaultDriveIndex = 0;
        static string defaultPath = Path.GetPathRoot(Environment.SystemDirectory);
        static string[] defaultContent = GetCurrentContent(defaultPath);

        string[] drives = Directory.GetLogicalDrives();

        int currentLeftDriveIndex = defaultDriveIndex;
        string currentLeftPath = defaultPath;
        ObservableCollection<string> currentLeftContent = new ObservableCollection<string>();

        int currentRightDriveIndex = defaultDriveIndex;
        string currentRightPath = defaultPath;
        ObservableCollection<string> currentRightContent = new ObservableCollection<string>();

        public string[] Drives
        {
            get => drives;
            set
            {
                drives = value;
            }
        }

        public string CurrentLeftPath
        {
            get => currentLeftPath;
            set
            {
                currentLeftPath = value;
            }
        }

        public ObservableCollection<string> CurrentLeftContent
        {
            get => currentLeftContent;
            set
            {
                currentLeftContent = value;
            }
        }

        public int CurrentLeftDriveIndex
        {
            get => currentLeftDriveIndex;
            set
            {
                currentLeftDriveIndex = value;
            }
        }

        public string CurrentRightPath
        {
            get => currentRightPath;
            set
            {
                currentRightPath = value;
            }
        }

        public ObservableCollection<string> CurrentRightContent
        {
            get => currentRightContent;
            set
            {
                currentRightContent = value;
            }
        }

        public int CurrentRightDriveIndex
        {
            get => currentRightDriveIndex;
            set
            {
                currentRightDriveIndex = value;
            }
        }

        static string[] GetCurrentContent(string path)
        {
            string[] temp1 = null;
            string[] temp2 = null;
            string[] temp3 = null;
            try
            {
                temp1 = Directory.GetDirectories(path);
                for (int i = 0; i < temp1.Length; i++)
                {
                    temp1[i] = Path.GetFileName(temp1[i]);
                    temp1[i] = $"<D>{temp1[i]}";
                }

                temp2 = Directory.GetFiles(path);
                for (int i = 0; i < temp2.Length; i++)
                    temp2[i] = Path.GetFileName(temp2[i]);

                int size = temp1.Length + temp2.Length;
                temp3 = null;
                string[] logicalDrives = Directory.GetLogicalDrives();
                if (!logicalDrives.Contains(path))
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                path = path.Substring(0, path.Length - 1);
                int index = path.LastIndexOf("\\") + 1;
                path = path.Substring(0, index);
                return GetCurrentContent(path);
            }
            return temp3;
        }
    }
}
