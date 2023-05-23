using Newtonsoft.Json;
using System.ComponentModel;
using System.Diagnostics;
using WindowsSetupTool.Installers;

namespace WindowsSetupTool
{
    public partial class MainForm : Form
    {
        ApplicationSource[] apps = Array.Empty<ApplicationSource>();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Winget.LoadInfoCache();
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
            List<ApplicationSource> installQueue = new List<ApplicationSource>();

            foreach (ApplicationSource app in apps)
            {
                installQueue.AddRange(GatherSources(app));
            }

            for (int i = 0; i < installQueue.Count; i++)
            {
                ApplicationSource currentApp = installQueue[i];
                InstallApp(currentApp);
                appInstallToolStripStatusLabel1.Text = $"Installing: {currentApp.AppName}";
                appInstallToolStripProgressBar1.Value = i / apps.Length;
            }
            installAllToolStripButton.Enabled = true;
            appInstallToolStripStatusLabel1.Text = "Completed installing apps";
            appInstallToolStripProgressBar1.Value = 100;
        }

        private List<ApplicationSource> GatherSources(ApplicationSource parent)
        {
            List<ApplicationSource> applicationSources = new List<ApplicationSource>();
            applicationSources.Add(parent);
            foreach (ApplicationSource source in parent.Dependencies)
            {
                applicationSources.AddRange(GatherSources(source));
            }
            return applicationSources;
        }

        private void InstallApp(ApplicationSource app)
        {
            switch (app.Type)
            {
                case InstallType.Winget:
                    Winget.InstallApp(app.AppID);
                    break;
                case InstallType.DirectInstaller:
                    DirectInstaller.InstallApp(app);
                    break;
            }
        }

        private void availableApplicationsCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            appInformationTextBox.Text = Winget.GetAppInfo(((ApplicationSource)availableApplicationsCheckedListBox.SelectedItem).AppID);
        }
    }
}