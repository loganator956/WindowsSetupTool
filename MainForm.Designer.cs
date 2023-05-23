namespace WindowsSetupTool
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            tabControl1 = new TabControl();
            applicationsTabPage = new TabPage();
            splitContainer1 = new SplitContainer();
            groupBox1 = new GroupBox();
            availableApplicationsCheckedListBox = new CheckedListBox();
            toolStrip1 = new ToolStrip();
            installAllToolStripButton = new ToolStripButton();
            splitContainer2 = new SplitContainer();
            groupBox2 = new GroupBox();
            appInformationTextBox = new TextBox();
            groupBox3 = new GroupBox();
            applicationsLogTextBox = new TextBox();
            statusStrip1 = new StatusStrip();
            appInstallToolStripProgressBar1 = new ToolStripProgressBar();
            appInstallToolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButton1 = new ToolStripButton();
            menuStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            applicationsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(applicationsTabPage);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 24);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 426);
            tabControl1.TabIndex = 1;
            // 
            // applicationsTabPage
            // 
            applicationsTabPage.Controls.Add(splitContainer1);
            applicationsTabPage.Controls.Add(statusStrip1);
            applicationsTabPage.Location = new Point(4, 24);
            applicationsTabPage.Name = "applicationsTabPage";
            applicationsTabPage.Padding = new Padding(3);
            applicationsTabPage.Size = new Size(792, 398);
            applicationsTabPage.TabIndex = 1;
            applicationsTabPage.Text = "Applications";
            applicationsTabPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(786, 370);
            splitContainer1.SplitterDistance = 262;
            splitContainer1.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(availableApplicationsCheckedListBox);
            groupBox1.Controls.Add(toolStrip1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(262, 370);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Available Applications";
            // 
            // availableApplicationsCheckedListBox
            // 
            availableApplicationsCheckedListBox.Dock = DockStyle.Fill;
            availableApplicationsCheckedListBox.FormattingEnabled = true;
            availableApplicationsCheckedListBox.Location = new Point(3, 44);
            availableApplicationsCheckedListBox.Name = "availableApplicationsCheckedListBox";
            availableApplicationsCheckedListBox.Size = new Size(256, 323);
            availableApplicationsCheckedListBox.TabIndex = 0;
            availableApplicationsCheckedListBox.SelectedIndexChanged += availableApplicationsCheckedListBox_SelectedIndexChanged;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { installAllToolStripButton, toolStripSeparator1, toolStripButton1 });
            toolStrip1.Location = new Point(3, 19);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(256, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // installAllToolStripButton
            // 
            installAllToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            installAllToolStripButton.Image = Properties.Resources.baseline_install_desktop_black_24dp;
            installAllToolStripButton.ImageTransparentColor = Color.Magenta;
            installAllToolStripButton.Name = "installAllToolStripButton";
            installAllToolStripButton.Size = new Size(23, 22);
            installAllToolStripButton.Text = "Install All";
            installAllToolStripButton.Click += installAllToolStripButton_Click;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(groupBox2);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(groupBox3);
            splitContainer2.Size = new Size(520, 370);
            splitContainer2.SplitterDistance = 250;
            splitContainer2.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(appInformationTextBox);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(250, 370);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Application Information";
            // 
            // appInformationTextBox
            // 
            appInformationTextBox.Dock = DockStyle.Fill;
            appInformationTextBox.Location = new Point(3, 19);
            appInformationTextBox.Multiline = true;
            appInformationTextBox.Name = "appInformationTextBox";
            appInformationTextBox.Size = new Size(244, 348);
            appInformationTextBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(applicationsLogTextBox);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(0, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(266, 370);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Applications Log";
            // 
            // applicationsLogTextBox
            // 
            applicationsLogTextBox.Dock = DockStyle.Fill;
            applicationsLogTextBox.Location = new Point(3, 19);
            applicationsLogTextBox.Multiline = true;
            applicationsLogTextBox.Name = "applicationsLogTextBox";
            applicationsLogTextBox.Size = new Size(260, 348);
            applicationsLogTextBox.TabIndex = 1;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { appInstallToolStripProgressBar1, appInstallToolStripStatusLabel1 });
            statusStrip1.Location = new Point(3, 373);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(786, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // appInstallToolStripProgressBar1
            // 
            appInstallToolStripProgressBar1.Name = "appInstallToolStripProgressBar1";
            appInstallToolStripProgressBar1.Size = new Size(100, 16);
            // 
            // appInstallToolStripStatusLabel1
            // 
            appInstallToolStripStatusLabel1.Name = "appInstallToolStripStatusLabel1";
            appInstallToolStripStatusLabel1.Size = new Size(118, 17);
            appInstallToolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(23, 22);
            toolStripButton1.Text = "toolStripButton1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Windows Setup Tool";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            applicationsTabPage.ResumeLayout(false);
            applicationsTabPage.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private TabControl tabControl1;
        private TabPage applicationsTabPage;
        private SplitContainer splitContainer1;
        private GroupBox groupBox1;
        private CheckedListBox availableApplicationsCheckedListBox;
        private ToolStrip toolStrip1;
        private ToolStripButton installAllToolStripButton;
        private StatusStrip statusStrip1;
        private SplitContainer splitContainer2;
        private GroupBox groupBox2;
        private TextBox appInformationTextBox;
        private GroupBox groupBox3;
        private TextBox applicationsLogTextBox;
        private ToolStripProgressBar appInstallToolStripProgressBar1;
        private ToolStripStatusLabel appInstallToolStripStatusLabel1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton1;
    }
}