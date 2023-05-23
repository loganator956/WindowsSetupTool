namespace WindowsSetupTool
{
    struct ApplicationSource
    {
        public ApplicationSource()
        {
            AppName = String.Empty;
            AppID = String.Empty;
            Dependencies = new List<ApplicationSource>();
            Type = InstallType.Winget;
            TempFileName = null;
        }
        public ApplicationSource(string name, string url, InstallType type)
        {
            AppName = name;
            AppID = url;
            Type = type;
            Dependencies = new List<ApplicationSource>();
            TempFileName = null;
        }
        public string AppName;
        public string AppID;
        public InstallType Type;
        public string? TempFileName;

        public List<ApplicationSource> Dependencies;
        public string[] GetIDs()
        {
            List<string> ids = new List<string>();
            ids.Add(AppID);
            foreach(ApplicationSource dependency in Dependencies)
            {
                ids.AddRange(dependency.GetIDs());
            }
            return ids.ToArray();
        }

        public override string ToString()
        {
            return AppName;
        }
    }
}
