namespace WindowsSetupTool
{
    struct ApplicationSource
    {
        public ApplicationSource()
        {
            AppName = String.Empty;
            AppID = String.Empty;
            InstallID = String.Empty;
            Dependencies = new List<ApplicationSource>();
            Type = InstallType.Winget;
            TempFileName = null;
        }
        public string AppName;
        public string AppID;
        public string InstallID;
        public InstallType Type;
        public string? TempFileName;

        public List<ApplicationSource> Dependencies;
        public string[] GetInstallIDs()
        {
            List<string> ids = new List<string>();
            ids.Add(InstallID);
            foreach(ApplicationSource dependency in Dependencies)
            {
                ids.AddRange(dependency.GetInstallIDs());
            }
            return ids.ToArray();
        }

        public override string ToString()
        {
            return AppName;
        }
    }
}
