
namespace UserDocumentControl
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ConfigurationButton = new System.Windows.Forms.Button();
            this.PerformBackupButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LastBackupDateLabel = new System.Windows.Forms.Label();
            this.ArchiveFolderNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CommentTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ArchiveFileNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OpenArchiveFolderButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ConfigurationButton);
            this.panel1.Controls.Add(this.PerformBackupButton);
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 207);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(695, 46);
            this.panel1.TabIndex = 0;
            // 
            // ConfigurationButton
            // 
            this.ConfigurationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ConfigurationButton.Image = global::UserDocumentControl.Properties.Resources.ConfigurationEditor_16x;
            this.ConfigurationButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ConfigurationButton.Location = new System.Drawing.Point(155, 11);
            this.ConfigurationButton.Name = "ConfigurationButton";
            this.ConfigurationButton.Size = new System.Drawing.Size(137, 23);
            this.ConfigurationButton.TabIndex = 1;
            this.ConfigurationButton.Text = "Configuration";
            this.ConfigurationButton.UseVisualStyleBackColor = true;
            this.ConfigurationButton.Click += new System.EventHandler(this.ConfigurationButton_Click);
            // 
            // PerformBackupButton
            // 
            this.PerformBackupButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PerformBackupButton.Image = global::UserDocumentControl.Properties.Resources.ZipFile_16x;
            this.PerformBackupButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PerformBackupButton.Location = new System.Drawing.Point(12, 11);
            this.PerformBackupButton.Name = "PerformBackupButton";
            this.PerformBackupButton.Size = new System.Drawing.Size(137, 23);
            this.PerformBackupButton.TabIndex = 0;
            this.PerformBackupButton.Text = "Perform backup";
            this.PerformBackupButton.UseVisualStyleBackColor = true;
            this.PerformBackupButton.Click += new System.EventHandler(this.PerformBackupButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.Image = global::UserDocumentControl.Properties.Resources.Exit_16x;
            this.CloseButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CloseButton.Location = new System.Drawing.Point(546, 11);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(137, 23);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Last backup date:";
            // 
            // LastBackupDateLabel
            // 
            this.LastBackupDateLabel.AutoSize = true;
            this.LastBackupDateLabel.Location = new System.Drawing.Point(115, 11);
            this.LastBackupDateLabel.Name = "LastBackupDateLabel";
            this.LastBackupDateLabel.Size = new System.Drawing.Size(65, 13);
            this.LastBackupDateLabel.TabIndex = 2;
            this.LastBackupDateLabel.Text = "01/01/0000";
            // 
            // ArchiveFolderNameTextBox
            // 
            this.ArchiveFolderNameTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ArchiveFolderNameTextBox.Location = new System.Drawing.Point(19, 53);
            this.ArchiveFolderNameTextBox.Name = "ArchiveFolderNameTextBox";
            this.ArchiveFolderNameTextBox.ReadOnly = true;
            this.ArchiveFolderNameTextBox.Size = new System.Drawing.Size(633, 20);
            this.ArchiveFolderNameTextBox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Archive folder";
            // 
            // CommentTextBox
            // 
            this.CommentTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CommentTextBox.Location = new System.Drawing.Point(19, 156);
            this.CommentTextBox.Name = "CommentTextBox";
            this.CommentTextBox.Size = new System.Drawing.Size(288, 20);
            this.CommentTextBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Archive file comment";
            // 
            // ArchiveFileNameTextBox
            // 
            this.ArchiveFileNameTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ArchiveFileNameTextBox.Location = new System.Drawing.Point(19, 106);
            this.ArchiveFileNameTextBox.Name = "ArchiveFileNameTextBox";
            this.ArchiveFileNameTextBox.Size = new System.Drawing.Size(288, 20);
            this.ArchiveFileNameTextBox.TabIndex = 1;
            this.ArchiveFileNameTextBox.Text = "Backups.zip";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Archive file name";
            // 
            // OpenArchiveFolderButton
            // 
            this.OpenArchiveFolderButton.Image = global::UserDocumentControl.Properties.Resources.Folder_16xSM;
            this.OpenArchiveFolderButton.Location = new System.Drawing.Point(658, 53);
            this.OpenArchiveFolderButton.Name = "OpenArchiveFolderButton";
            this.OpenArchiveFolderButton.Size = new System.Drawing.Size(25, 23);
            this.OpenArchiveFolderButton.TabIndex = 18;
            this.toolTip1.SetToolTip(this.OpenArchiveFolderButton, "Open folder with Windows Explorer");
            this.OpenArchiveFolderButton.UseVisualStyleBackColor = true;
            this.OpenArchiveFolderButton.Click += new System.EventHandler(this.OpenArchiveFolderButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 253);
            this.Controls.Add(this.OpenArchiveFolderButton);
            this.Controls.Add(this.CommentTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ArchiveFileNameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ArchiveFolderNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LastBackupDateLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backup/Restore";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LastBackupDateLabel;
        private System.Windows.Forms.TextBox ArchiveFolderNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CommentTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ArchiveFileNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button PerformBackupButton;
        private System.Windows.Forms.Button ConfigurationButton;
        private System.Windows.Forms.Button OpenArchiveFolderButton;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}