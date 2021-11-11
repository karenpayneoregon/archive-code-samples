
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ArchiveFileNameTextBox = new System.Windows.Forms.TextBox();
            this.ArchiveFolderNameTextBox = new System.Windows.Forms.TextBox();
            this.CancelSaveButton = new System.Windows.Forms.Button();
            this.CreateUniqueZipFileNameButton = new System.Windows.Forms.Button();
            this.SaveZipSettingsButton = new System.Windows.Forms.Button();
            this.SelectArchiveFolderButton = new System.Windows.Forms.Button();
            this.RemoveCurrentFolderButton = new System.Windows.Forms.Button();
            this.SaveFoldersButton = new System.Windows.Forms.Button();
            this.CommentTextBox = new System.Windows.Forms.TextBox();
            this.CloseFormButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            this.FoldersCheckListBox.TabIndex = 0;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // ArchiveFileNameTextBox
            // 
            this.ArchiveFileNameTextBox.Location = new System.Drawing.Point(6, 99);
            this.ArchiveFileNameTextBox.Name = "ArchiveFileNameTextBox";
            this.ArchiveFileNameTextBox.Size = new System.Drawing.Size(194, 20);
            this.ArchiveFileNameTextBox.TabIndex = 2;
            this.ArchiveFileNameTextBox.Text = "Backups.zip";
            this.toolTip1.SetToolTip(this.ArchiveFileNameTextBox, "Name of .zip file to add directories to into archive folder");
            // 
            // ArchiveFolderNameTextBox
            // 
            this.ArchiveFolderNameTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ArchiveFolderNameTextBox.Location = new System.Drawing.Point(6, 44);
            this.ArchiveFolderNameTextBox.Name = "ArchiveFolderNameTextBox";
            this.ArchiveFolderNameTextBox.ReadOnly = true;
            this.ArchiveFolderNameTextBox.Size = new System.Drawing.Size(709, 20);
            this.ArchiveFolderNameTextBox.TabIndex = 0;
            this.toolTip1.SetToolTip(this.ArchiveFolderNameTextBox, "Location of backup .zip file");
            // 
            // CancelSaveButton
            // 
            this.CancelSaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelSaveButton.Image = global::UserDocumentControl.Properties.Resources.Cancel_16x;
            this.CancelSaveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CancelSaveButton.Location = new System.Drawing.Point(206, 183);
            this.CancelSaveButton.Name = "CancelSaveButton";
            this.CancelSaveButton.Size = new System.Drawing.Size(194, 23);
            this.CancelSaveButton.TabIndex = 6;
            this.CancelSaveButton.Text = "Cancel Changes";
            this.toolTip1.SetToolTip(this.CancelSaveButton, "Save to configuration file");
            this.CancelSaveButton.UseVisualStyleBackColor = true;
            this.CancelSaveButton.Click += new System.EventHandler(this.CancelSaveButton_Click);
            // 
            // CreateUniqueZipFileNameButton
            // 
            this.CreateUniqueZipFileNameButton.Image = global::UserDocumentControl.Properties.Resources.BinaryFile_16x;
            this.CreateUniqueZipFileNameButton.Location = new System.Drawing.Point(206, 97);
            this.CreateUniqueZipFileNameButton.Name = "CreateUniqueZipFileNameButton";
            this.CreateUniqueZipFileNameButton.Size = new System.Drawing.Size(26, 23);
            this.CreateUniqueZipFileNameButton.TabIndex = 3;
            this.toolTip1.SetToolTip(this.CreateUniqueZipFileNameButton, "Generate a file name for you");
            this.CreateUniqueZipFileNameButton.UseVisualStyleBackColor = true;
            this.CreateUniqueZipFileNameButton.Click += new System.EventHandler(this.CreateUniqueZipFileNameButton_Click);
            // 
            // SaveZipSettingsButton
            // 
            this.SaveZipSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveZipSettingsButton.Image = global::UserDocumentControl.Properties.Resources.Save_16x;
            this.SaveZipSettingsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveZipSettingsButton.Location = new System.Drawing.Point(6, 183);
            this.SaveZipSettingsButton.Name = "SaveZipSettingsButton";
            this.SaveZipSettingsButton.Size = new System.Drawing.Size(194, 23);
            this.SaveZipSettingsButton.TabIndex = 5;
            this.SaveZipSettingsButton.Text = "Save zip settings";
            this.toolTip1.SetToolTip(this.SaveZipSettingsButton, "Save to configuration file");
            this.SaveZipSettingsButton.UseVisualStyleBackColor = true;
            this.SaveZipSettingsButton.Click += new System.EventHandler(this.SaveZipSettingsButton_Click);
            // 
            // SelectArchiveFolderButton
            // 
            this.SelectArchiveFolderButton.Image = global::UserDocumentControl.Properties.Resources.Folder_16xSM;
            this.SelectArchiveFolderButton.Location = new System.Drawing.Point(721, 42);
            this.SelectArchiveFolderButton.Name = "SelectArchiveFolderButton";
            this.SelectArchiveFolderButton.Size = new System.Drawing.Size(25, 23);
            this.SelectArchiveFolderButton.TabIndex = 1;
            this.toolTip1.SetToolTip(this.SelectArchiveFolderButton, "Select folder");
            this.SelectArchiveFolderButton.UseVisualStyleBackColor = true;
            this.SelectArchiveFolderButton.Click += new System.EventHandler(this.SelectArchiveFolderButton_Click);
            // 
            // RemoveCurrentFolderButton
            // 
            this.RemoveCurrentFolderButton.Enabled = false;
            this.RemoveCurrentFolderButton.Image = global::UserDocumentControl.Properties.Resources.DeleteFolder_16x;
            this.RemoveCurrentFolderButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RemoveCurrentFolderButton.Location = new System.Drawing.Point(236, 203);
            this.RemoveCurrentFolderButton.Name = "RemoveCurrentFolderButton";
            this.RemoveCurrentFolderButton.Size = new System.Drawing.Size(194, 23);
            this.RemoveCurrentFolderButton.TabIndex = 2;
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
            this.SaveFoldersButton.TabIndex = 1;
            this.SaveFoldersButton.Text = "Save folders";
            this.toolTip1.SetToolTip(this.SaveFoldersButton, "Save to configuration file");
            this.SaveFoldersButton.UseVisualStyleBackColor = true;
            this.SaveFoldersButton.Click += new System.EventHandler(this.SaveFoldersButton_Click);
            // 
            // CommentTextBox
            // 
            this.CommentTextBox.Location = new System.Drawing.Point(6, 149);
            this.CommentTextBox.Name = "CommentTextBox";
            this.CommentTextBox.Size = new System.Drawing.Size(194, 20);
            this.CommentTextBox.TabIndex = 4;
            this.toolTip1.SetToolTip(this.CommentTextBox, "Name of .zip file to add directories to into archive folder");
            // 
            // CloseFormButton
            // 
            this.CloseFormButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CloseFormButton.Image = global::UserDocumentControl.Properties.Resources.Exit_16x;
            this.CloseFormButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CloseFormButton.Location = new System.Drawing.Point(575, 472);
            this.CloseFormButton.Name = "CloseFormButton";
            this.CloseFormButton.Size = new System.Drawing.Size(194, 23);
            this.CloseFormButton.TabIndex = 3;
            this.CloseFormButton.Text = "Close";
            this.toolTip1.SetToolTip(this.CloseFormButton, "Save to configuration file");
            this.CloseFormButton.UseVisualStyleBackColor = true;
            this.CloseFormButton.Click += new System.EventHandler(this.CloseFormButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CommentTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.CancelSaveButton);
            this.groupBox1.Controls.Add(this.CreateUniqueZipFileNameButton);
            this.groupBox1.Controls.Add(this.SaveZipSettingsButton);
            this.groupBox1.Controls.Add(this.ArchiveFileNameTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.SelectArchiveFolderButton);
            this.groupBox1.Controls.Add(this.ArchiveFolderNameTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 246);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(757, 216);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zip settings";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Archive file comment";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Archive folder";
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
            // UserSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 507);
            this.Controls.Add(this.CloseFormButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.RemoveCurrentFolderButton);
            this.Controls.Add(this.SaveFoldersButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FoldersCheckListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UserSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
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
        private System.Windows.Forms.Button CreateUniqueZipFileNameButton;
        private System.Windows.Forms.Button CancelSaveButton;
        private System.Windows.Forms.TextBox CommentTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CloseFormButton;
    }
}

