using System.ComponentModel;
using System.Diagnostics;

namespace WindowsSetupTool.Installers
{
    internal static class DirectInstaller
    {
        public static void InstallApp(ApplicationSource currentApp)
        {
            string fileName = Path.Combine("temp", (currentApp.TempFileName != null ? currentApp.TempFileName : Path.GetFileName(currentApp.InstallID)));
            if (!Directory.Exists("temp"))
                Directory.CreateDirectory("temp");

            DownloadApp(fileName, currentApp.InstallID);

            ProcessStartInfo dInfo = new ProcessStartInfo(fileName);

            // try running the app as user, if it requires administration to start then will run as admin ?
            Process installer = new Process();
            installer.StartInfo = dInfo;
            try
            {
                installer.Start();
                installer.WaitForExit();
            }
            catch (Win32Exception e)
            {
                // 740
                if (e.NativeErrorCode == 740)
                {
                    // needs to be executed as admin
                    dInfo.UseShellExecute = true;
                    dInfo.Verb = "runas";
                    installer.Start();
                    installer.WaitForExit();
                }
            }
            File.Delete(fileName);
        }

        private static void DownloadApp(string fileName, string URL)
        {
            using (var client = new HttpClient())
            {
                using (var s = client.GetStreamAsync(URL))
                {
                    using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
                    {
                        s.Result.CopyTo(fs);
                    }
                }
            }
        }
    }
}
