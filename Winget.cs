using Newtonsoft.Json;
using System.Diagnostics;

namespace WindowsSetupTool.Installers
{
    internal static class Winget
    {
        private const string cacheName = "wingetcache.json";
        static List<WingetAppInfo> infoCache = new List<WingetAppInfo>();
        public static void LoadInfoCache()
        {
            if (File.Exists(cacheName))
            {
                WingetAppInfo[]? cache = JsonConvert.DeserializeObject<WingetAppInfo[]>(File.ReadAllText(cacheName));
                if (cache != null)
                {
                    infoCache.Clear();
                    infoCache.AddRange(cache);
                }
            }
        }

        public static void SaveInfoCache()
        {
            string json = JsonConvert.SerializeObject(infoCache);
            File.WriteAllText(cacheName, json);
        }
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
            inf.UseShellExecute = false;
            inf.RedirectStandardOutput = true;
            Process winget = new Process();
            winget.StartInfo = inf;
            winget.Start();
            StreamReader reader = winget.StandardOutput;
            string output = reader.ReadToEnd();
            winget.WaitForExit();

            infoCache.Add(new WingetAppInfo(appID, output));
            SaveInfoCache();
            return output;
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
