
namespace TestBedProject
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
            this.CompressFolderButton = new System.Windows.Forms.Button();
            this.CompressFolderWithPasswordButton = new System.Windows.Forms.Button();
            this.UnCompressButton = new System.Windows.Forms.Button();
            this.InformationLabel = new System.Windows.Forms.Label();
            this.CheckPasswordButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CompressFolderButton
            // 
            this.CompressFolderButton.Location = new System.Drawing.Point(34, 37);
            this.CompressFolderButton.Name = "CompressFolderButton";
            this.CompressFolderButton.Size = new System.Drawing.Size(206, 23);
            this.CompressFolderButton.TabIndex = 0;
            this.CompressFolderButton.Text = "Compress Folder";
            this.CompressFolderButton.UseVisualStyleBackColor = true;
            this.CompressFolderButton.Click += new System.EventHandler(this.CompressFolderButton_Click);
            // 
            // CompressFolderWithPasswordButton
            // 
            this.CompressFolderWithPasswordButton.Location = new System.Drawing.Point(34, 78);
            this.CompressFolderWithPasswordButton.Name = "CompressFolderWithPasswordButton";
            this.CompressFolderWithPasswordButton.Size = new System.Drawing.Size(206, 23);
            this.CompressFolderWithPasswordButton.TabIndex = 1;
            this.CompressFolderWithPasswordButton.Text = "Compress Folder with password";
            this.CompressFolderWithPasswordButton.UseVisualStyleBackColor = true;
            this.CompressFolderWithPasswordButton.Click += new System.EventHandler(this.CompressFolderWithPasswordButton_Click);
            // 
            // UnCompressButton
            // 
            this.UnCompressButton.Location = new System.Drawing.Point(34, 107);
            this.UnCompressButton.Name = "UnCompressButton";
            this.UnCompressButton.Size = new System.Drawing.Size(206, 23);
            this.UnCompressButton.TabIndex = 2;
            this.UnCompressButton.Text = "Uncompress Folder with password";
            this.UnCompressButton.UseVisualStyleBackColor = true;
            this.UnCompressButton.Click += new System.EventHandler(this.UnCompressButton_Click);
            // 
            // InformationLabel
            // 
            this.InformationLabel.AutoSize = true;
            this.InformationLabel.Location = new System.Drawing.Point(31, 151);
            this.InformationLabel.Name = "InformationLabel";
            this.InformationLabel.Size = new System.Drawing.Size(146, 13);
            this.InformationLabel.TabIndex = 3;
            this.InformationLabel.Text = "information (populate in code)";
            // 
            // CheckPasswordButton
            // 
            this.CheckPasswordButton.Location = new System.Drawing.Point(246, 78);
            this.CheckPasswordButton.Name = "CheckPasswordButton";
            this.CheckPasswordButton.Size = new System.Drawing.Size(206, 23);
            this.CheckPasswordButton.TabIndex = 4;
            this.CheckPasswordButton.Text = "Check password";
            this.CheckPasswordButton.UseVisualStyleBackColor = true;
            this.CheckPasswordButton.Click += new System.EventHandler(this.CheckPasswordButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(450, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 188);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CheckPasswordButton);
            this.Controls.Add(this.InformationLabel);
            this.Controls.Add(this.UnCompressButton);
            this.Controls.Add(this.CompressFolderWithPasswordButton);
            this.Controls.Add(this.CompressFolderButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code sample";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CompressFolderButton;
        private System.Windows.Forms.Button CompressFolderWithPasswordButton;
        private System.Windows.Forms.Button UnCompressButton;
        private System.Windows.Forms.Label InformationLabel;
        private System.Windows.Forms.Button CheckPasswordButton;
        private System.Windows.Forms.Button button1;
    }
}

