namespace MiniTC.CustomControls._PanelTC
{
    using System.Collections.Generic;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows;
    public partial class PanelTC : UserControl, IPanelTC
    {
        public PanelTC()
        {
            InitializeComponent();
        }

        #region Depedency Properties

        public static readonly DependencyProperty CurrentPathProperty =
            DependencyProperty.Register(nameof(CurrentPath), typeof(string), typeof(PanelTC), new PropertyMetadata(null));

        public static readonly DependencyProperty AvailableDrivesProperty =
            DependencyProperty.Register(nameof(AvailableDrives), typeof(string[]), typeof(PanelTC), new PropertyMetadata(null));

        public static readonly DependencyProperty CurrentDriveProperty =
            DependencyProperty.Register(nameof(CurrentDrive), typeof(int), typeof(PanelTC), new PropertyMetadata(null));

        public static readonly DependencyProperty CurrentPathContentsProperty =
            DependencyProperty.Register(nameof(CurrentPathContents), typeof(IEnumerable<object>), typeof(PanelTC), new PropertyMetadata(null));

        public static readonly DependencyProperty SelectedEntryProperty =
            DependencyProperty.Register(nameof(SelectedEntry), typeof(object), typeof(PanelTC), new PropertyMetadata(null));

        public static readonly DependencyProperty ListClickProperty =
            DependencyProperty.Register(nameof(ListClick), typeof(ICommand), typeof(PanelTC), new PropertyMetadata(null));

        #endregion

        #region Internal Properties

        public string CurrentPath
        { 
            get { return (string)GetValue(CurrentPathProperty); }
            set { SetValue(CurrentPathProperty, value); }
        }

        public string[] AvailableDrives
        {
            get { return (string[])GetValue(AvailableDrivesProperty); }
            set { SetValue(AvailableDrivesProperty, value); }
        }

        public IEnumerable<object> CurrentPathContents
        {
            get { return (IEnumerable<object>)GetValue(CurrentPathContentsProperty); }
            set { SetValue(CurrentPathContentsProperty, value); }
        }

        public int CurrentDrive
        {
            get { return (int)GetValue(CurrentDriveProperty); }
            set { SetValue(CurrentDriveProperty, value); }
        }

        public object SelectedEntry
        {
            get { return (object)GetValue(SelectedEntryProperty); }
            set { SetValue(SelectedEntryProperty, value); }
        }

        public ICommand ListClick
        {
            get { return (ICommand)GetValue(ListClickProperty); }
            set { SetValue(ListClickProperty, value); }
        }

        #endregion
    }
}
