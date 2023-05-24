namespace WindowsSetupTool
{
    partial class ImportMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            urlTextBox = new TextBox();
            button1 = new Button();
            button2 = new Button();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            localFilePathTextBox = new TextBox();
            localFileBrowserButton = new Button();
            SuspendLayout();
            // 
            // urlTextBox
            // 
            urlTextBox.Location = new Point(92, 12);
            urlTextBox.Name = "urlTextBox";
            urlTextBox.Size = new Size(352, 23);
            urlTextBox.TabIndex = 0;
            urlTextBox.TextChanged += urlTextBox_TextChanged;
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.Cancel;
            button1.Location = new Point(369, 70);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.DialogResult = DialogResult.OK;
            button2.Location = new Point(288, 70);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "OK";
            button2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(12, 13);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(46, 19);
            radioButton1.TabIndex = 4;
            radioButton1.Text = "URL";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Checked = true;
            radioButton2.Location = new Point(12, 42);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(74, 19);
            radioButton2.TabIndex = 5;
            radioButton2.TabStop = true;
            radioButton2.Text = "Local File";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // localFilePathTextBox
            // 
            localFilePathTextBox.Location = new Point(92, 41);
            localFilePathTextBox.Name = "localFilePathTextBox";
            localFilePathTextBox.Size = new Size(315, 23);
            localFilePathTextBox.TabIndex = 6;
            localFilePathTextBox.TextChanged += localFilePathTextBox_TextChanged;
            // 
            // localFileBrowserButton
            // 
            localFileBrowserButton.Location = new Point(413, 42);
            localFileBrowserButton.Name = "localFileBrowserButton";
            localFileBrowserButton.Size = new Size(31, 23);
            localFileBrowserButton.TabIndex = 7;
            localFileBrowserButton.Text = "...";
            localFileBrowserButton.UseVisualStyleBackColor = true;
            localFileBrowserButton.Click += localFileBrowserButton_Click;
            // 
            // ImportMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(456, 100);
            Controls.Add(localFileBrowserButton);
            Controls.Add(localFilePathTextBox);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(urlTextBox);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ImportMenu";
            Text = "ImportMenu";
            Load += ImportMenu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox urlTextBox;
        private Button button1;
        private Button button2;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private TextBox localFilePathTextBox;
        private Button localFileBrowserButton;
    }
}