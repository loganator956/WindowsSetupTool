namespace WindowsSetupTool
{
    struct ApplicationSource
    {
        public ApplicationSource()
        {
            AppName = "";
            AppDescription = "";
            AppIDs = new string[0];
        }
        public string AppName;
        public string AppDescription;
        public string[] AppIDs;

        public override string ToString()
        {
            return AppName;
        }
    }
}
