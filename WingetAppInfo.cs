namespace WindowsSetupTool
{
    internal struct WingetAppInfo
    {
        public WingetAppInfo()
        {
            AppID = string.Empty;
            Details = string.Empty;
        }
        public WingetAppInfo(string id, string details)
        {
            AppID = id;
            Details = details;
        }
        public string AppID;
        public string Details;
    }
}