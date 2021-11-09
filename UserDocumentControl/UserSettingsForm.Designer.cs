
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
            this.RemoveCurrentButton = new System.Windows.Forms.Button();
            this.SaveSettingsButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
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
            this.button1.Location = new System.Drawing.Point(281, 203);
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
            // RemoveCurrentButton
            // 
            this.RemoveCurrentButton.Image = global::UserDocumentControl.Properties.Resources.DeleteFolder_16x;
            this.RemoveCurrentButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RemoveCurrentButton.Location = new System.Drawing.Point(150, 203);
            this.RemoveCurrentButton.Name = "RemoveCurrentButton";
            this.RemoveCurrentButton.Size = new System.Drawing.Size(125, 23);
            this.RemoveCurrentButton.TabIndex = 7;
            this.RemoveCurrentButton.Text = "Remove current";
            this.toolTip1.SetToolTip(this.RemoveCurrentButton, "Remove current item from folder list");
            this.RemoveCurrentButton.UseVisualStyleBackColor = true;
            this.RemoveCurrentButton.Click += new System.EventHandler(this.RemoveCurrentButton_Click);
            // 
            // SaveSettingsButton
            // 
            this.SaveSettingsButton.Image = global::UserDocumentControl.Properties.Resources.Save_16x;
            this.SaveSettingsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveSettingsButton.Location = new System.Drawing.Point(12, 203);
            this.SaveSettingsButton.Name = "SaveSettingsButton";
            this.SaveSettingsButton.Size = new System.Drawing.Size(125, 23);
            this.SaveSettingsButton.TabIndex = 4;
            this.SaveSettingsButton.Text = "Save settings";
            this.toolTip1.SetToolTip(this.SaveSettingsButton, "Save to configuration file");
            this.SaveSettingsButton.UseVisualStyleBackColor = true;
            this.SaveSettingsButton.Click += new System.EventHandler(this.SaveSettingsButton_Click);
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(371, 203);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // UserSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 380);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.RemoveCurrentButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SaveSettingsButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FoldersCheckListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UserSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code Sample";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox FoldersCheckListBox;
        private System.Windows.Forms.Button SaveSettingsButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button RemoveCurrentButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
    }
}

