using System.ComponentModel;
using System.Diagnostics;

namespace WindowsSetupTool.Installers
{
    internal static class Winget
    {
        /// <summary>
        /// Caches winget package info for quicker access
        /// </summary>
        static List<WingetAppInfo> infoCache = new List<WingetAppInfo>();

        /// <summary>
        /// Installs the winget package
        /// </summary>
        /// <param name="appID">Winget package ID to install</param>
        public static void InstallApp(string appID)
        {
            RunOperation("install", appID);
        }

        /// <summary>
        /// Uninstalls the winget package
        /// </summary>
        /// <param name="appID">Winget package ID to uninstall</param>
        public static void RemoveApp(string appID)
        {
            RunOperation("uninstall", appID);
        }

        /// <summary>
        /// Runs the winget show command to get info about package
        /// </summary>
        /// <param name="appID">Winget package ID to get information about</param>
        /// <returns>Output from winget show command</returns>
        private static string GetAppInfo(string appID)
        {
            // check cache
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

        /// <summary>
        /// Finds the winget package information in a BackgroundWorker
        /// </summary>
        /// <param name="appID">Winget package ID to find information about</param>
        /// <returns>Reference to the BackgroundWorker which is running the command</returns>
        public static BackgroundWorker GetAppInfoInBackground(string appID)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += AppInfoBackgroundWorker_DoWork;
            worker.RunWorkerAsync(appID);
            return worker;
        }

        /// <summary>
        /// Run the winget operation
        /// </summary>
        /// <param name="operation">Which operation to run</param>
        /// <param name="appID">Winget package ID to run specified operation on</param>
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

        #region Event Handlers
        private static void AppInfoBackgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            string? appID = e.Argument as string;
            if (appID != null)
                e.Result = GetAppInfo(appID);
            else
                e.Result = null;
        }
        #endregion
    }
}
