
namespace CreateZipWithExtensions
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
            this.CreateZipWithOneFileButton = new System.Windows.Forms.Button();
            this.CreateZipFromFolderButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ExtractButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // CreateZipWithOneFileButton
            // 
            this.CreateZipWithOneFileButton.Location = new System.Drawing.Point(27, 12);
            this.CreateZipWithOneFileButton.Name = "CreateZipWithOneFileButton";
            this.CreateZipWithOneFileButton.Size = new System.Drawing.Size(219, 23);
            this.CreateZipWithOneFileButton.TabIndex = 0;
            this.CreateZipWithOneFileButton.Text = "Create zip file from one file";
            this.CreateZipWithOneFileButton.UseVisualStyleBackColor = true;
            this.CreateZipWithOneFileButton.Click += new System.EventHandler(this.CreateZipWithOneFileButton_Click);
            // 
            // CreateZipFromFolderButton
            // 
            this.CreateZipFromFolderButton.Location = new System.Drawing.Point(27, 41);
            this.CreateZipFromFolderButton.Name = "CreateZipFromFolderButton";
            this.CreateZipFromFolderButton.Size = new System.Drawing.Size(219, 23);
            this.CreateZipFromFolderButton.TabIndex = 1;
            this.CreateZipFromFolderButton.Text = "Create zip file from folder";
            this.CreateZipFromFolderButton.UseVisualStyleBackColor = true;
            this.CreateZipFromFolderButton.Click += new System.EventHandler(this.CreateZipFromFolderButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CreateZipWithExtensions.Properties.Resources.loading_27;
            this.pictureBox1.Location = new System.Drawing.Point(160, -54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(233, 182);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // ExtractButton
            // 
            this.ExtractButton.Location = new System.Drawing.Point(27, 96);
            this.ExtractButton.Name = "ExtractButton";
            this.ExtractButton.Size = new System.Drawing.Size(219, 23);
            this.ExtractButton.TabIndex = 3;
            this.ExtractButton.Text = "Extract";
            this.ExtractButton.UseVisualStyleBackColor = true;
            this.ExtractButton.Click += new System.EventHandler(this.ExtractButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 131);
            this.Controls.Add(this.ExtractButton);
            this.Controls.Add(this.CreateZipFromFolderButton);
            this.Controls.Add(this.CreateZipWithOneFileButton);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code Sample";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateZipWithOneFileButton;
        private System.Windows.Forms.Button CreateZipFromFolderButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ExtractButton;
    }
}

