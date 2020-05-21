namespace MiniTC.CustomControls._PanelTC
{
    interface IPanelTC
    {
        string CurrentPath { get; }
        string[] AvailableDrives { get; }
        string[] CurrentPathContents { get; }
    }
}
