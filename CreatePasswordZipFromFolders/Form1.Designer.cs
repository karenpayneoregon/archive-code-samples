
namespace CreatePasswordedZipFromFolders
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.SelectedFoldersCheckListBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveFileNameTextBox = new System.Windows.Forms.TextBox();
            this.UsePasswordCheckBox = new System.Windows.Forms.CheckBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.ShowPassCheckBox = new System.Windows.Forms.CheckBox();
            this.EncryptionCheckBox = new System.Windows.Forms.CheckBox();
            this.UnzipButton = new System.Windows.Forms.Button();
            this.CreateZipButton = new System.Windows.Forms.Button();
            this.SaveFileNameButton = new System.Windows.Forms.Button();
            this.ViewZipContentsButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.CurrentExtractonLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectedFoldersCheckListBox
            // 
            this.SelectedFoldersCheckListBox.CheckOnClick = true;
            this.SelectedFoldersCheckListBox.FormattingEnabled = true;
            this.SelectedFoldersCheckListBox.HorizontalScrollbar = true;
            this.SelectedFoldersCheckListBox.Location = new System.Drawing.Point(15, 28);
            this.SelectedFoldersCheckListBox.Name = "SelectedFoldersCheckListBox";
            this.SelectedFoldersCheckListBox.Size = new System.Drawing.Size(577, 154);
            this.SelectedFoldersCheckListBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Drag folders from Windows Explorer into container below";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Save zip filename";
            // 
            // SaveFileNameTextBox
            // 
            this.SaveFileNameTextBox.BackColor = System.Drawing.Color.White;
            this.SaveFileNameTextBox.Location = new System.Drawing.Point(15, 221);
            this.SaveFileNameTextBox.Name = "SaveFileNameTextBox";
            this.SaveFileNameTextBox.ReadOnly = true;
            this.SaveFileNameTextBox.Size = new System.Drawing.Size(542, 20);
            this.SaveFileNameTextBox.TabIndex = 4;
            this.SaveFileNameTextBox.Text = "C:\\OED\\ZipFileHome\\Sample1.zip";
            // 
            // UsePasswordCheckBox
            // 
            this.UsePasswordCheckBox.AutoSize = true;
            this.UsePasswordCheckBox.Location = new System.Drawing.Point(15, 265);
            this.UsePasswordCheckBox.Name = "UsePasswordCheckBox";
            this.UsePasswordCheckBox.Size = new System.Drawing.Size(93, 17);
            this.UsePasswordCheckBox.TabIndex = 6;
            this.UsePasswordCheckBox.Text = "Use password";
            this.UsePasswordCheckBox.UseVisualStyleBackColor = true;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(15, 288);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(313, 20);
            this.PasswordTextBox.TabIndex = 7;
            this.PasswordTextBox.Text = "payne";
            // 
            // ShowPassCheckBox
            // 
            this.ShowPassCheckBox.AutoSize = true;
            this.ShowPassCheckBox.Location = new System.Drawing.Point(334, 291);
            this.ShowPassCheckBox.Name = "ShowPassCheckBox";
            this.ShowPassCheckBox.Size = new System.Drawing.Size(101, 17);
            this.ShowPassCheckBox.TabIndex = 8;
            this.ShowPassCheckBox.Text = "Show password";
            this.ShowPassCheckBox.UseVisualStyleBackColor = true;
            this.ShowPassCheckBox.CheckedChanged += new System.EventHandler(this.ShowPassCheckBox_CheckedChanged);
            // 
            // EncryptionCheckBox
            // 
            this.EncryptionCheckBox.AutoSize = true;
            this.EncryptionCheckBox.Location = new System.Drawing.Point(114, 265);
            this.EncryptionCheckBox.Name = "EncryptionCheckBox";
            this.EncryptionCheckBox.Size = new System.Drawing.Size(97, 17);
            this.EncryptionCheckBox.TabIndex = 10;
            this.EncryptionCheckBox.Text = "Use encryption";
            this.EncryptionCheckBox.UseVisualStyleBackColor = true;
            // 
            // UnzipButton
            // 
            this.UnzipButton.Image = global::CreatePasswordedZipFromFolders.Properties.Resources.Run_16x;
            this.UnzipButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UnzipButton.Location = new System.Drawing.Point(145, 324);
            this.UnzipButton.Name = "UnzipButton";
            this.UnzipButton.Size = new System.Drawing.Size(103, 23);
            this.UnzipButton.TabIndex = 11;
            this.UnzipButton.Text = "Unzip";
            this.UnzipButton.UseVisualStyleBackColor = true;
            this.UnzipButton.Click += new System.EventHandler(this.UnzipButton_Click);
            // 
            // CreateZipButton
            // 
            this.CreateZipButton.Image = global::CreatePasswordedZipFromFolders.Properties.Resources.Create_16x;
            this.CreateZipButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreateZipButton.Location = new System.Drawing.Point(15, 324);
            this.CreateZipButton.Name = "CreateZipButton";
            this.CreateZipButton.Size = new System.Drawing.Size(103, 23);
            this.CreateZipButton.TabIndex = 9;
            this.CreateZipButton.Text = "Create zip";
            this.CreateZipButton.UseVisualStyleBackColor = true;
            this.CreateZipButton.Click += new System.EventHandler(this.CreateZipButton_Click);
            // 
            // SaveFileNameButton
            // 
            this.SaveFileNameButton.Image = global::CreatePasswordedZipFromFolders.Properties.Resources.Folder_16xSM;
            this.SaveFileNameButton.Location = new System.Drawing.Point(563, 219);
            this.SaveFileNameButton.Name = "SaveFileNameButton";
            this.SaveFileNameButton.Size = new System.Drawing.Size(29, 23);
            this.SaveFileNameButton.TabIndex = 5;
            this.SaveFileNameButton.UseVisualStyleBackColor = true;
            this.SaveFileNameButton.Click += new System.EventHandler(this.SaveFileNameButton_Click);
            // 
            // ViewZipContentsButton
            // 
            this.ViewZipContentsButton.Image = global::CreatePasswordedZipFromFolders.Properties.Resources.View_16x;
            this.ViewZipContentsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ViewZipContentsButton.Location = new System.Drawing.Point(275, 324);
            this.ViewZipContentsButton.Name = "ViewZipContentsButton";
            this.ViewZipContentsButton.Size = new System.Drawing.Size(103, 23);
            this.ViewZipContentsButton.TabIndex = 2;
            this.ViewZipContentsButton.Text = "View";
            this.ViewZipContentsButton.UseVisualStyleBackColor = true;
            this.ViewZipContentsButton.Click += new System.EventHandler(this.ViewZipContentsButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(18, 371);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(574, 23);
            this.progressBar1.TabIndex = 12;
            this.progressBar1.Visible = false;
            // 
            // CurrentExtractonLabel
            // 
            this.CurrentExtractonLabel.AutoSize = true;
            this.CurrentExtractonLabel.Location = new System.Drawing.Point(20, 400);
            this.CurrentExtractonLabel.Name = "CurrentExtractonLabel";
            this.CurrentExtractonLabel.Size = new System.Drawing.Size(85, 13);
            this.CurrentExtractonLabel.TabIndex = 13;
            this.CurrentExtractonLabel.Text = "Extract file name";
            this.CurrentExtractonLabel.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(489, 305);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 421);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CurrentExtractonLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.UnzipButton);
            this.Controls.Add(this.EncryptionCheckBox);
            this.Controls.Add(this.CreateZipButton);
            this.Controls.Add(this.ShowPassCheckBox);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.UsePasswordCheckBox);
            this.Controls.Add(this.SaveFileNameButton);
            this.Controls.Add(this.SaveFileNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ViewZipContentsButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectedFoldersCheckListBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create zip file for one or more folders";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox SelectedFoldersCheckListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ViewZipContentsButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SaveFileNameTextBox;
        private System.Windows.Forms.Button SaveFileNameButton;
        private System.Windows.Forms.CheckBox UsePasswordCheckBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.CheckBox ShowPassCheckBox;
        private System.Windows.Forms.Button CreateZipButton;
        private System.Windows.Forms.CheckBox EncryptionCheckBox;
        private System.Windows.Forms.Button UnzipButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label CurrentExtractonLabel;
        private System.Windows.Forms.Button button1;
    }
}

