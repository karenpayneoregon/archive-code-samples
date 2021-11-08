using System.IO;
using System.IO.Compression;
using ExtractFilesWithProgress.Classes;
using ExtractFilesWithProgress.Delegates;
using ExtractFilesWithProgress.LanguageExtensions;

//INSTANT C# NOTE: Formerly VB project-level imports:
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace ExtractFilesWithProgress
{
	public partial class Form1 : System.Windows.Forms.Form
	{
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;

		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.CompressionFileNameTextBox = new System.Windows.Forms.TextBox();
            this.SelectZipFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ExtractionFolderTextBox = new System.Windows.Forms.TextBox();
            this.ExtractFolderBrowser = new WK.Libraries.BetterFolderBrowserNS.BetterFolderBrowser(this.components);
            this.PurgeTargetFolderButton = new System.Windows.Forms.Button();
            this.UseProgressBarCheckBox = new System.Windows.Forms.CheckBox();
            this.SelectFolderButton = new System.Windows.Forms.Button();
            this.SelectZipFileButton = new System.Windows.Forms.Button();
            this.ExtractButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Location = new System.Drawing.Point(156, 81);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(319, 23);
            this.ProgressBar1.TabIndex = 0;
            this.ProgressBar1.Visible = false;
            // 
            // ListBox1
            // 
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.Location = new System.Drawing.Point(156, 115);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(323, 121);
            this.ListBox1.TabIndex = 2;
            // 
            // CompressionFileNameTextBox
            // 
            this.CompressionFileNameTextBox.BackColor = System.Drawing.Color.Silver;
            this.CompressionFileNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompressionFileNameTextBox.Location = new System.Drawing.Point(156, 13);
            this.CompressionFileNameTextBox.Name = "CompressionFileNameTextBox";
            this.CompressionFileNameTextBox.ReadOnly = true;
            this.CompressionFileNameTextBox.Size = new System.Drawing.Size(319, 20);
            this.CompressionFileNameTextBox.TabIndex = 4;
            // 
            // SelectZipFileDialog
            // 
            this.SelectZipFileDialog.Filter = "Zip files|*.zip";
            // 
            // ExtractionFolderTextBox
            // 
            this.ExtractionFolderTextBox.BackColor = System.Drawing.Color.Silver;
            this.ExtractionFolderTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExtractionFolderTextBox.Location = new System.Drawing.Point(156, 51);
            this.ExtractionFolderTextBox.Name = "ExtractionFolderTextBox";
            this.ExtractionFolderTextBox.ReadOnly = true;
            this.ExtractionFolderTextBox.Size = new System.Drawing.Size(319, 20);
            this.ExtractionFolderTextBox.TabIndex = 6;
            // 
            // ExtractFolderBrowser
            // 
            this.ExtractFolderBrowser.Multiselect = false;
            this.ExtractFolderBrowser.RootFolder = "C:\\";
            this.ExtractFolderBrowser.Title = "Please select a folder...";
            // 
            // PurgeTargetFolderButton
            // 
            this.PurgeTargetFolderButton.Image = global::ExtractFilesWithProgress.Properties.Resources.DeleteFolder_16x;
            this.PurgeTargetFolderButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PurgeTargetFolderButton.Location = new System.Drawing.Point(12, 213);
            this.PurgeTargetFolderButton.Name = "PurgeTargetFolderButton";
            this.PurgeTargetFolderButton.Size = new System.Drawing.Size(123, 23);
            this.PurgeTargetFolderButton.TabIndex = 7;
            this.PurgeTargetFolderButton.Text = "Purge";
            this.PurgeTargetFolderButton.UseVisualStyleBackColor = true;
            this.PurgeTargetFolderButton.Click += new System.EventHandler(this.PurgeTargetFolderButton_Click);
            // 
            // UseProgressBarCheckBox
            // 
            this.UseProgressBarCheckBox.AutoSize = true;
            this.UseProgressBarCheckBox.Location = new System.Drawing.Point(12, 115);
            this.UseProgressBarCheckBox.Name = "UseProgressBarCheckBox";
            this.UseProgressBarCheckBox.Size = new System.Drawing.Size(106, 17);
            this.UseProgressBarCheckBox.TabIndex = 8;
            this.UseProgressBarCheckBox.Text = "Use progress bar";
            this.UseProgressBarCheckBox.UseVisualStyleBackColor = true;
            // 
            // SelectFolderButton
            // 
            this.SelectFolderButton.Image = global::ExtractFilesWithProgress.Properties.Resources.Folder_16x;
            this.SelectFolderButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SelectFolderButton.Location = new System.Drawing.Point(12, 51);
            this.SelectFolderButton.Name = "SelectFolderButton";
            this.SelectFolderButton.Size = new System.Drawing.Size(123, 23);
            this.SelectFolderButton.TabIndex = 5;
            this.SelectFolderButton.Text = "Select folder";
            this.SelectFolderButton.UseVisualStyleBackColor = true;
            this.SelectFolderButton.Click += new System.EventHandler(this.SelectFolderButton_Click);
            // 
            // SelectZipFileButton
            // 
            this.SelectZipFileButton.Image = global::ExtractFilesWithProgress.Properties.Resources.Dialog_16x;
            this.SelectZipFileButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SelectZipFileButton.Location = new System.Drawing.Point(12, 11);
            this.SelectZipFileButton.Name = "SelectZipFileButton";
            this.SelectZipFileButton.Size = new System.Drawing.Size(123, 23);
            this.SelectZipFileButton.TabIndex = 3;
            this.SelectZipFileButton.Text = "Select .zip file";
            this.SelectZipFileButton.UseVisualStyleBackColor = true;
            this.SelectZipFileButton.Click += new System.EventHandler(this.SelectZipFileButton_Click);
            // 
            // ExtractButton
            // 
            this.ExtractButton.Image = global::ExtractFilesWithProgress.Properties.Resources.ExtractMethod_16x;
            this.ExtractButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExtractButton.Location = new System.Drawing.Point(12, 81);
            this.ExtractButton.Name = "ExtractButton";
            this.ExtractButton.Size = new System.Drawing.Size(123, 23);
            this.ExtractButton.TabIndex = 1;
            this.ExtractButton.Text = "Execute";
            this.ExtractButton.UseVisualStyleBackColor = true;
            this.ExtractButton.Click += new System.EventHandler(this.ExtractButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 258);
            this.Controls.Add(this.UseProgressBarCheckBox);
            this.Controls.Add(this.PurgeTargetFolderButton);
            this.Controls.Add(this.ExtractionFolderTextBox);
            this.Controls.Add(this.SelectFolderButton);
            this.Controls.Add(this.CompressionFileNameTextBox);
            this.Controls.Add(this.SelectZipFileButton);
            this.Controls.Add(this.ListBox1);
            this.Controls.Add(this.ExtractButton);
            this.Controls.Add(this.ProgressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extract files from compress file";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		internal ProgressBar ProgressBar1;
		internal Button ExtractButton;
		internal ListBox ListBox1;
		internal Button SelectZipFileButton;
		internal TextBox CompressionFileNameTextBox;
		internal OpenFileDialog SelectZipFileDialog;
		internal Button SelectFolderButton;
		internal TextBox ExtractionFolderTextBox;
		internal WK.Libraries.BetterFolderBrowserNS.BetterFolderBrowser ExtractFolderBrowser;
		internal Button PurgeTargetFolderButton;
		internal CheckBox UseProgressBarCheckBox;
	}

}