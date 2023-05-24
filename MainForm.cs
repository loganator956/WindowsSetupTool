using Newtonsoft.Json;
using System.ComponentModel;
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

        /// <summary>
        /// Loads ApplicationSource objects from resources directory
        /// </summary>
        private void LoadAppSources()
        {
            string resourcesFile = File.ReadAllText("Resources/apps.json");
            ApplicationSource[]? newApps = JsonConvert.DeserializeObject<ApplicationSource[]>(resourcesFile);
            if (newApps != null) { apps = newApps; };

            RepopulateAppList();
        }

        /// <summary>
        /// Updates the checked list box with the app sources
        /// </summary>
        private void RepopulateAppList()
        {
            availableApplicationsCheckedListBox.Items.Clear();
            for (int i = 0; i < apps.Length; i++)
                availableApplicationsCheckedListBox.Items.Add(apps[i]);
        }

        private void InstallApps(ApplicationSource[] apps)
        {
            List<ApplicationSource> installQueue = new List<ApplicationSource>();

            // gather apps + dependencies
            foreach (ApplicationSource app in apps)
            {
                installQueue.AddRange(GatherSourcesRecursively(app));
            }

            // iterate through each app and install them
            for (int i = 0; i < installQueue.Count; i++)
            {
                InstallApp(installQueue[i]);
                // update status strip
                appInstallToolStripStatusLabel1.Text = $"Installed: {installQueue[i]}";
                appInstallToolStripProgressBar1.Value = i / apps.Length;
            }
            // re-enable install button
            installAllToolStripButton.Enabled = true;
            appInstallToolStripStatusLabel1.Text = "Completed installing apps";
            appInstallToolStripProgressBar1.Value = 100;
        }

        private List<ApplicationSource> GatherSourcesRecursively(ApplicationSource parent)
        {
            List<ApplicationSource> applicationSources = new List<ApplicationSource>();
            applicationSources.Add(parent);
            foreach (ApplicationSource source in parent.Dependencies)
            {
                applicationSources.AddRange(GatherSourcesRecursively(source));
            }
            return applicationSources;
        }

        private void InstallApp(ApplicationSource app)
        {
            switch (app.Type)
            {
                case InstallType.Winget:
                    Winget.InstallApp(app.InstallID);
                    break;
                case InstallType.DirectInstaller:
                    DirectInstaller.InstallApp(app);
                    break;
            }
        }

        /// <summary>
        /// Downloads string stream from a URL
        /// </summary>
        /// <param name="url">URL of the text file</param>
        /// <returns>String contents of the text file</returns>
        private string DownloadStringFromURL(string url)
        {
            using (var client = new HttpClient())
            {
                using (var s = client.GetStreamAsync(url))
                {
                    using (var stream = new StreamReader(s.Result))
                    {
                        string result = stream.ReadToEnd();
                        return result;
                    }
                }
            }
        }

        /// <summary>
        /// Checks the apps in the CheckedListBox according to a list of AppIDs
        /// </summary>
        /// <param name="list">Array containing AppIDs to check</param>
        private void ApplySelectionFromList(string[] list)
        {
            // clear checked items
            for (int i = 0; i < availableApplicationsCheckedListBox.Items.Count; i++)
                availableApplicationsCheckedListBox.SetItemChecked(i, false);

            // check the app in the list
            foreach (string appID in list)
                availableApplicationsCheckedListBox.SetItemChecked(GetAppSourceArrayIndex(appID), true);
        }

        /// <summary>
        /// Get the index for an ApplicationSource in the ApplicationSource array
        /// </summary>
        /// <param name="appID">The app to find the index for</param>
        /// <returns>Corresponding index for the application source. If cannot find, returns -1</returns>
        private int GetAppSourceArrayIndex(string appID)
        {
            int index = 0;
            foreach (ApplicationSource package in apps)
            {
                if (package.AppID == appID)
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        #region Event Handlers
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadAppSources();
        }

        private void installAllToolStripButton_Click(object sender, EventArgs e)
        {
            installAllToolStripButton.Enabled = false;

            var sel = availableApplicationsCheckedListBox.CheckedItems;

            InstallApps(sel.Cast<ApplicationSource>().ToArray<ApplicationSource>());
        }

        private void availableApplicationsCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BackgroundWorker worker = Winget.GetAppInfoInBackground(((ApplicationSource)availableApplicationsCheckedListBox.SelectedItem).AppID);
            worker.RunWorkerCompleted += WingetGetAppInfoWorker_RunWorkerCompleted;
        }

        private void importListToolStripButton_Click(object sender, EventArgs e)
        {
            ImportMenu menu = new ImportMenu();
            DialogResult res = menu.ShowDialog();
            if (res == DialogResult.OK)
            {
                if (menu.IsUrl)
                    ApplySelectionFromList(DownloadStringFromURL(menu.Url).Split('\n'));
                else
                    ApplySelectionFromList(File.ReadAllLines(menu.FilePath));
            }
        }

        private void exportListToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.DefaultExt = ".txt";
            dialog.Title = "Save package list";
            dialog.CheckPathExists = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                List<string> appIDs = new List<string>();
                foreach (ApplicationSource app in availableApplicationsCheckedListBox.CheckedItems)
                {
                    appIDs.Add(app.AppID);
                }
                File.WriteAllLines(dialog.FileName, appIDs.ToArray());
            }

        }

        private void WingetGetAppInfoWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            string? result = e.Result as string;
            if (result != null)
            {
                appInformationTextBox.Text = result;
            }
        }
        #endregion
    }
}