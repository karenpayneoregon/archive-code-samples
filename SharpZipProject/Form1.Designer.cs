
namespace SharpZipProject
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
            this.ZipSingleFileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ZipSingleFileButton
            // 
            this.ZipSingleFileButton.Location = new System.Drawing.Point(12, 27);
            this.ZipSingleFileButton.Name = "ZipSingleFileButton";
            this.ZipSingleFileButton.Size = new System.Drawing.Size(208, 23);
            this.ZipSingleFileButton.TabIndex = 0;
            this.ZipSingleFileButton.Text = "Create with single file";
            this.ZipSingleFileButton.UseVisualStyleBackColor = true;
            this.ZipSingleFileButton.Click += new System.EventHandler(this.ZipSingleFileButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 230);
            this.Controls.Add(this.ZipSingleFileButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code Sample";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ZipSingleFileButton;
    }
}

