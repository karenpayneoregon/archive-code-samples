
namespace UserDocumentControl
{
    partial class UserSettingsForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.FoldersCheckListBox = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ArchiveFolderNameTextBox = new System.Windows.Forms.TextBox();
            this.SelectArchiveFolderButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RemoveCurrentFolderButton = new System.Windows.Forms.Button();
            this.SaveFoldersButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ArchiveFileNameTextBox = new System.Windows.Forms.TextBox();
            this.SaveZipSettingsButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Drag folders from Windows Explorer into container below";
            // 
            // FoldersCheckListBox
            // 
            this.FoldersCheckListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FoldersCheckListBox.CheckOnClick = true;
            this.FoldersCheckListBox.FormattingEnabled = true;
            this.FoldersCheckListBox.HorizontalScrollbar = true;
            this.FoldersCheckListBox.Location = new System.Drawing.Point(12, 32);
            this.FoldersCheckListBox.Name = "FoldersCheckListBox";
            this.FoldersCheckListBox.Size = new System.Drawing.Size(758, 154);
            this.FoldersCheckListBox.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(589, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SaveZipSettingsButton);
            this.groupBox1.Controls.Add(this.ArchiveFileNameTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.SelectArchiveFolderButton);
            this.groupBox1.Controls.Add(this.ArchiveFolderNameTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 246);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(757, 165);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zip settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Archive folder";
            // 
            // ArchiveFolderNameTextBox
            // 
            this.ArchiveFolderNameTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ArchiveFolderNameTextBox.Location = new System.Drawing.Point(6, 44);
            this.ArchiveFolderNameTextBox.Name = "ArchiveFolderNameTextBox";
            this.ArchiveFolderNameTextBox.ReadOnly = true;
            this.ArchiveFolderNameTextBox.Size = new System.Drawing.Size(709, 20);
            this.ArchiveFolderNameTextBox.TabIndex = 1;
            // 
            // SelectArchiveFolderButton
            // 
            this.SelectArchiveFolderButton.Image = global::UserDocumentControl.Properties.Resources.Folder_16xSM;
            this.SelectArchiveFolderButton.Location = new System.Drawing.Point(721, 42);
            this.SelectArchiveFolderButton.Name = "SelectArchiveFolderButton";
            this.SelectArchiveFolderButton.Size = new System.Drawing.Size(25, 23);
            this.SelectArchiveFolderButton.TabIndex = 2;
            this.SelectArchiveFolderButton.UseVisualStyleBackColor = true;
            this.SelectArchiveFolderButton.Click += new System.EventHandler(this.SelectArchiveFolderButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UserDocumentControl.Properties.Resources.FolderDrop;
            this.pictureBox1.Location = new System.Drawing.Point(12, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // RemoveCurrentFolderButton
            // 
            this.RemoveCurrentFolderButton.Image = global::UserDocumentControl.Properties.Resources.DeleteFolder_16x;
            this.RemoveCurrentFolderButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RemoveCurrentFolderButton.Location = new System.Drawing.Point(236, 203);
            this.RemoveCurrentFolderButton.Name = "RemoveCurrentFolderButton";
            this.RemoveCurrentFolderButton.Size = new System.Drawing.Size(194, 23);
            this.RemoveCurrentFolderButton.TabIndex = 7;
            this.RemoveCurrentFolderButton.Text = "Remove current folder";
            this.toolTip1.SetToolTip(this.RemoveCurrentFolderButton, "Remove current item from folder list");
            this.RemoveCurrentFolderButton.UseVisualStyleBackColor = true;
            this.RemoveCurrentFolderButton.Click += new System.EventHandler(this.RemoveCurrentFolderButton_Click);
            // 
            // SaveFoldersButton
            // 
            this.SaveFoldersButton.Image = global::UserDocumentControl.Properties.Resources.Save_16x;
            this.SaveFoldersButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveFoldersButton.Location = new System.Drawing.Point(25, 203);
            this.SaveFoldersButton.Name = "SaveFoldersButton";
            this.SaveFoldersButton.Size = new System.Drawing.Size(194, 23);
            this.SaveFoldersButton.TabIndex = 4;
            this.SaveFoldersButton.Text = "Save folders";
            this.toolTip1.SetToolTip(this.SaveFoldersButton, "Save to configuration file");
            this.SaveFoldersButton.UseVisualStyleBackColor = true;
            this.SaveFoldersButton.Click += new System.EventHandler(this.SaveFoldersButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Archive file name (e.g. MyBackup.zip)";
            // 
            // ArchiveFileNameTextBox
            // 
            this.ArchiveFileNameTextBox.Location = new System.Drawing.Point(6, 99);
            this.ArchiveFileNameTextBox.Name = "ArchiveFileNameTextBox";
            this.ArchiveFileNameTextBox.Size = new System.Drawing.Size(269, 20);
            this.ArchiveFileNameTextBox.TabIndex = 4;
            this.ArchiveFileNameTextBox.Text = "Backups.zip";
            // 
            // SaveZipSettingsButton
            // 
            this.SaveZipSettingsButton.Image = global::UserDocumentControl.Properties.Resources.Save_16x;
            this.SaveZipSettingsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveZipSettingsButton.Location = new System.Drawing.Point(6, 136);
            this.SaveZipSettingsButton.Name = "SaveZipSettingsButton";
            this.SaveZipSettingsButton.Size = new System.Drawing.Size(194, 23);
            this.SaveZipSettingsButton.TabIndex = 10;
            this.SaveZipSettingsButton.Text = "Save zip settings";
            this.toolTip1.SetToolTip(this.SaveZipSettingsButton, "Save to configuration file");
            this.SaveZipSettingsButton.UseVisualStyleBackColor = true;
            this.SaveZipSettingsButton.Click += new System.EventHandler(this.SaveZipSettingsButton_Click);
            // 
            // UserSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 423);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.RemoveCurrentFolderButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SaveFoldersButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FoldersCheckListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UserSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code Sample";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox FoldersCheckListBox;
        private System.Windows.Forms.Button SaveFoldersButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button RemoveCurrentFolderButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SelectArchiveFolderButton;
        private System.Windows.Forms.TextBox ArchiveFolderNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SaveZipSettingsButton;
        private System.Windows.Forms.TextBox ArchiveFileNameTextBox;
        private System.Windows.Forms.Label label3;
    }
}

