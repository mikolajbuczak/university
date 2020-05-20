namespace MiniTC_NoMVVM
{
    using System.Collections.Generic;
    interface IPanelTC
    {
        string CurrentPath { get; }
        string[] AvailableDrives { get; }
        string[] CurrentPathContents { get; }
    }
}
