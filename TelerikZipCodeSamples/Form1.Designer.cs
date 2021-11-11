
namespace TelerikZipCodeSamples
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
            this.CreateZipPassworedButton = new System.Windows.Forms.Button();
            this.FromFolderWithPasswordButton = new System.Windows.Forms.Button();
            this.FromFolderRecursiveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreateZipPassworedButton
            // 
            this.CreateZipPassworedButton.Location = new System.Drawing.Point(16, 20);
            this.CreateZipPassworedButton.Name = "CreateZipPassworedButton";
            this.CreateZipPassworedButton.Size = new System.Drawing.Size(205, 23);
            this.CreateZipPassworedButton.TabIndex = 0;
            this.CreateZipPassworedButton.Text = "Create zip with password";
            this.CreateZipPassworedButton.UseVisualStyleBackColor = true;
            this.CreateZipPassworedButton.Click += new System.EventHandler(this.CreateZipPasswordButton_Click);
            // 
            // FromFolderWithPasswordButton
            // 
            this.FromFolderWithPasswordButton.Location = new System.Drawing.Point(16, 63);
            this.FromFolderWithPasswordButton.Name = "FromFolderWithPasswordButton";
            this.FromFolderWithPasswordButton.Size = new System.Drawing.Size(205, 23);
            this.FromFolderWithPasswordButton.TabIndex = 1;
            this.FromFolderWithPasswordButton.Text = "Create zip from folder with password";
            this.FromFolderWithPasswordButton.UseVisualStyleBackColor = true;
            this.FromFolderWithPasswordButton.Click += new System.EventHandler(this.FromFolderWithPasswordButton_Click);
            // 
            // FromFolderRecursiveButton
            // 
            this.FromFolderRecursiveButton.Location = new System.Drawing.Point(14, 99);
            this.FromFolderRecursiveButton.Name = "FromFolderRecursiveButton";
            this.FromFolderRecursiveButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FromFolderRecursiveButton.Size = new System.Drawing.Size(207, 23);
            this.FromFolderRecursiveButton.TabIndex = 2;
            this.FromFolderRecursiveButton.Text = "Create zip from folder recursive";
            this.FromFolderRecursiveButton.UseVisualStyleBackColor = true;
            this.FromFolderRecursiveButton.Click += new System.EventHandler(this.FromFolderRecursiveButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 154);
            this.Controls.Add(this.FromFolderRecursiveButton);
            this.Controls.Add(this.FromFolderWithPasswordButton);
            this.Controls.Add(this.CreateZipPassworedButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Telerik code sample";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateZipPassworedButton;
        private System.Windows.Forms.Button FromFolderWithPasswordButton;
        private System.Windows.Forms.Button FromFolderRecursiveButton;
    }
}

