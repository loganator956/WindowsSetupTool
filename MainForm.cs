using Newtonsoft.Json;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;

namespace WindowsSetupTool
{
    public partial class MainForm : Form
    {
        ApplicationSource[] apps = new ApplicationSource[0];
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadApps();
            RepopulateAppList();
        }

        private void LoadApps()
        {
            // load from resource json file
            string resourcesFile = File.ReadAllText("Resources/apps.json");
            ApplicationSource[]? newApps = JsonConvert.DeserializeObject<ApplicationSource[]>(resourcesFile);
            if (newApps != null) { apps = newApps; };
        }

        private void RepopulateAppList()
        {
            availableApplicationsCheckedListBox.Items.Clear();
            for (int i = 0; i < apps.Length; i++)
            {
                availableApplicationsCheckedListBox.Items.Add(apps[i]);
            }
        }

        private void installAllToolStripButton_Click(object sender, EventArgs e)
        {
            installAllToolStripButton.Enabled = false;

            var sel = availableApplicationsCheckedListBox.CheckedItems;

            InstallApps(sel.Cast<ApplicationSource>().ToArray<ApplicationSource>());
        }

        private void InstallApps(ApplicationSource[] apps)
        {
            for (int i = 0; i < apps.Length; i++)
            {
                ApplicationSource currentApp = apps[i];
                appInstallToolStripStatusLabel1.Text = $"Installing: {currentApp.AppName}";
                appInstallToolStripProgressBar1.Value = i / apps.Length;

                // install using winget
                switch (currentApp.Type)
                {
                    case InstallType.Winget:
                        foreach (string appID in currentApp.GetIDs())
                        {
                            ProcessStartInfo wingetInfo = new ProcessStartInfo("winget.exe");
                            wingetInfo.ArgumentList.Add("install");
                            wingetInfo.ArgumentList.Add("-e");
                            wingetInfo.ArgumentList.Add(appID);

                            Process wingetProc = new Process();
                            wingetProc.StartInfo = wingetInfo;
                            wingetProc.Start();
                            // TODO: implement multi-threading and update the GUI with any new things (BackgroundWorker?)
                            wingetProc.WaitForExit();
                            Debug.WriteLine($"Installed {appID}");
                        }
                        break;
                    case InstallType.DirectInstaller:
                        string fileName = Path.Combine("temp", (currentApp.TempFileName != null ? currentApp.TempFileName : Path.GetFileName(currentApp.AppID)));
                        if (!Directory.Exists("temp"))
                            Directory.CreateDirectory("temp");
                        using (var client = new HttpClient())
                        {
                            using (var s = client.GetStreamAsync(currentApp.AppID))
                            {
                                using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
                                {
                                    s.Result.CopyTo(fs);
                                }
                            }
                        }
                        ProcessStartInfo dInfo = new ProcessStartInfo(fileName);
                        
                        // try running the app as user, if it requires administration to start then will run as admin ?
                        Process installer = new Process();
                        installer.StartInfo = dInfo;
                        try
                        {
                            installer.Start();
                            installer.WaitForExit();
                        }
                        catch(Win32Exception e)
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
                        break;
                }
            }
            installAllToolStripButton.Enabled = true;
            appInstallToolStripStatusLabel1.Text = "Completed installing apps";
            appInstallToolStripProgressBar1.Value = 100;
        }

        private void availableApplicationsCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplicationSource selected = (ApplicationSource)availableApplicationsCheckedListBox.SelectedItem;
            ProcessStartInfo inf = new ProcessStartInfo("winget.exe");
            inf.ArgumentList.Add("show");
            inf.ArgumentList.Add(selected.AppID);
            inf.UseShellExecute = false;
            inf.RedirectStandardOutput = true;
            Process winget = new Process();
            winget.StartInfo = inf;
            winget.Start();
            StreamReader reader = winget.StandardOutput;
            string output = reader.ReadToEnd();
            appInformationTextBox.Text = output;
            winget.WaitForExit();
        }
    }
}