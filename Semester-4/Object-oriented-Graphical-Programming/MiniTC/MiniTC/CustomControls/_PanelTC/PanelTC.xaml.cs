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

        #region Events
        public static readonly RoutedEvent DriveChangedEvent =
        EventManager.RegisterRoutedEvent("TabItemSelected",
             RoutingStrategy.Bubble, typeof(RoutedEventHandler),
             typeof(PanelTC));

        public event RoutedEventHandler DriveChanged
        {
            add { AddHandler(DriveChangedEvent, value); }
            remove { RemoveHandler(DriveChangedEvent, value); }
        }

        void RaiseDriveChanged()
        {
            RoutedEventArgs newEventArgs =
                    new RoutedEventArgs(PanelTC.DriveChangedEvent);
            RaiseEvent(newEventArgs);
        }

        public static readonly RoutedEvent ItemSelectedEvent =
        EventManager.RegisterRoutedEvent("TabItemSelected",
             RoutingStrategy.Bubble, typeof(RoutedEventHandler),
             typeof(PanelTC));

        public event RoutedEventHandler ItemSelected
        {
            add { AddHandler(ItemSelectedEvent, value); }
            remove { RemoveHandler(ItemSelectedEvent, value); }
        }

        void RaiseItemSelected()
        {
            RoutedEventArgs newEventArgs =
                    new RoutedEventArgs(PanelTC.ItemSelectedEvent);
            RaiseEvent(newEventArgs);
        }
        #endregion

        #region Depedency Properties
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

        public string[] CurrentPathContents
        {
            get { return (string[])GetValue(CurrentPathContentsProperty); }
            set { SetValue(CurrentPathContentsProperty, value); }
        }

        public string CurrentDrive
        {
            get { return (string)GetValue(CurrentDriveProperty); }
            set { SetValue(CurrentDriveProperty, value); }
        }

        public object SelectedEntry
        {
            get { return (object)GetValue(SelectedEntryProperty); }
            set { SetValue(SelectedEntryProperty, value); }
        }
        #endregion

        #region Event Raise
        void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RaiseDriveChanged();
        }

        private void ListBox_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            RaiseItemSelected();
        }
        #endregion
    }
}
