namespace MiniTC.CustomControls._PanelTC
{
    using System.Collections.Generic;
    interface IPanelTC
    {
        string CurrentPath { get; }
        string[] AvailableDrives { get; }
        IEnumerable<object> CurrentPathContents { get; }
    }
}
