using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsSetupTool
{
    public partial class ImportMenu : Form
    {
        public ImportMenu()
        {
            InitializeComponent();
        }

        public string Url;
        public string FilePath;

        public bool IsUrl;

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            IsUrl = urlTextBox.Enabled = radioButton1.Checked;
            localFilePathTextBox.Enabled = radioButton2.Checked;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            IsUrl = urlTextBox.Enabled = radioButton1.Checked;
            localFilePathTextBox.Enabled = radioButton2.Checked;
        }

        private void ImportMenu_Load(object sender, EventArgs e)
        {
            IsUrl = urlTextBox.Enabled = radioButton1.Checked;
            localFilePathTextBox.Enabled = radioButton2.Checked;
        }

        private void urlTextBox_TextChanged(object sender, EventArgs e)
        {
            Url = urlTextBox.Text;
        }

        private void localFilePathTextBox_TextChanged(object sender, EventArgs e)
        {
            FilePath = localFilePathTextBox.Text;
        }
    }
}
