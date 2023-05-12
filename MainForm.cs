using Newtonsoft.Json;
using System.Diagnostics;

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
            if (newApps != null ) { apps = newApps; };
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

            var sel = availableApplicationsCheckedListBox.SelectedItems;

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
                foreach (string appID in currentApp.AppIDs)
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
            }
            installAllToolStripButton.Enabled = true;
            appInstallToolStripStatusLabel1.Text = "Completed installing apps";
            appInstallToolStripProgressBar1.Value = 100;
        }
    }
}