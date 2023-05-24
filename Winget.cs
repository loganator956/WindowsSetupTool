using Newtonsoft.Json;
using System.ComponentModel;
using System.Diagnostics;

namespace WindowsSetupTool.Installers
{
    internal static class Winget
    {
        static List<WingetAppInfo> infoCache = new List<WingetAppInfo>();

        public static void InstallApp(string appID)
        {
            RunOperation("install", appID);
        }

        public static void RemoveApp(string appID)
        {
            RunOperation("uninstall", appID);
        }

        public static string GetAppInfo(string appID)
        {
            foreach(var app in infoCache)
            {
                if (app.AppID == appID)
                {
                    return app.Details;
                }
            }
            // not got the app in cache

            // get the information of package
            ProcessStartInfo inf = new ProcessStartInfo("winget.exe");
            inf.ArgumentList.Add("show");
            inf.ArgumentList.Add(appID);
            inf.ArgumentList.Add("--disable-interactivity");
            inf.UseShellExecute = false;
            inf.RedirectStandardOutput = true;
            inf.RedirectStandardError = true;
            inf.CreateNoWindow = true;
            Process winget = new Process();
            winget.StartInfo = inf;
            winget.Start();
            StreamReader reader = winget.StandardOutput;
            string output = reader.ReadToEnd();
            winget.WaitForExit();

            infoCache.Add(new WingetAppInfo(appID, output));
            return output;
        }

        public static BackgroundWorker GetAppInfoInBackground(string appID)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += AppInfoBackgroundWorker_DoWork;
            worker.RunWorkerAsync(appID);
            return worker;
        }

        private static void AppInfoBackgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            string? appID = e.Argument as string;
            if (appID != null)
            {
                e.Result = GetAppInfo(appID);
            }
            else
            {
                e.Result = null;
            }
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
