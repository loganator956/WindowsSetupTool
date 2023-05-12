namespace WindowsSetupTool
{
    struct ApplicationSource
    {
        public ApplicationSource()
        {
            AppName = "";
            AppIDs = new string[0];
        }
        public string AppName;
        public string[] AppIDs;

        public override string ToString()
        {
            return AppName;
        }
    }
}
