namespace WindowsSetupTool
{
    struct ApplicationSource
    {
        public ApplicationSource()
        {
            AppName = "";
            AppDescription = "";
            AppID = "";
        }
        public string AppName;
        public string AppDescription;
        public string AppID;
        // TODO: Implement dependencies (Could just add multiple AppIDs?)

        public override string ToString()
        {
            return AppName;
        }
    }
}
