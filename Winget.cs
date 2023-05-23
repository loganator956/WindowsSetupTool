using System.Diagnostics;

namespace WindowsSetupTool.Installers
{
    internal static class Winget
    {
        public static void InstallApp(string appID)
        {
            RunOperation("install", appID);
        }

        public static void RemoveApp(string appID)
        {
            RunOperation("uninstall", appID);
        }

        private static void RunOperation(string operation, string appID)
        {
            ProcessStartInfo wingetInfo = new ProcessStartInfo("winget.exe");
            wingetInfo.ArgumentList.Add(operation);
            wingetInfo.ArgumentList.Add("-e");
            wingetInfo.ArgumentList.Add(appID);

            Process wingetProc = new Process();
            wingetProc.StartInfo = wingetInfo;
            wingetProc.Start();

            wingetProc.WaitForExit();
        }
    }
}
