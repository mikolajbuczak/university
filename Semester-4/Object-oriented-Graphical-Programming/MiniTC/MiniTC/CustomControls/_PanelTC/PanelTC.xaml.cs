namespace MiniTC.CustomControls._PanelTC
{
    using System.Collections.Generic;
    using System.Windows.Controls;
    using System.Windows;
    public partial class PanelTC : UserControl, IPanelTC
    {
        public PanelTC()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty CurrentPathProperty =
            DependencyProperty.Register(nameof(CurrentPath), typeof(string), typeof(PanelTC), new PropertyMetadata(""));

        public static readonly DependencyProperty AvailableDrivesProperty =
            DependencyProperty.Register(nameof(AvailableDrives), typeof(string[]), typeof(PanelTC), new PropertyMetadata(null));

        public static readonly DependencyProperty CurrentDriveProperty =
            DependencyProperty.Register(nameof(CurrentDrive), typeof(string), typeof(PanelTC), new PropertyMetadata(""));

        public static readonly DependencyProperty CurrentPathContentsProperty =
            DependencyProperty.Register(nameof(CurrentPathContents), typeof(IEnumerable<object>), typeof(PanelTC), new PropertyMetadata(null));

        public static readonly DependencyProperty SelectedEntryProperty =
            DependencyProperty.Register(nameof(SelectedEntry), typeof(object), typeof(PanelTC), new PropertyMetadata(null));

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

        public string CurrentDrive
        {
            get { return (string)GetValue(CurrentDriveProperty); }
            set { SetValue(CurrentDriveProperty, value); }
        }

        public IEnumerable<object> CurrentPathContents
        {
            get { return (IEnumerable<object>)GetValue(CurrentPathContentsProperty); }
            set { SetValue(CurrentPathContentsProperty, value); }
        }

        public object SelectedEntry
        {
            get { return (object)GetValue(SelectedEntryProperty); }
            set { SetValue(SelectedEntryProperty, value); }
        }
    }
}
