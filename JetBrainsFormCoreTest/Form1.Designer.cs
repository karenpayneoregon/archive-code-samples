
using JetBrainsFormCoreTest.Classes;

namespace JetBrainsFormCoreTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericTextBox1 = new JetBrainsFormCoreTest.Classes.NumericTextBox();
            this.amountNumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.specialNumericUpDown1 = new CustomControls.SpecialNumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.amountNumericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.specialNumericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // numericTextBox1
            // 
            this.numericTextBox1.Location = new System.Drawing.Point(46, 25);
            this.numericTextBox1.Name = "numericTextBox1";
            this.numericTextBox1.Size = new System.Drawing.Size(238, 23);
            this.numericTextBox1.TabIndex = 0;
            this.numericTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // amountNumericUpDown1
            // 
            this.amountNumericUpDown1.Location = new System.Drawing.Point(46, 65);
            this.amountNumericUpDown1.Name = "amountNumericUpDown1";
            this.amountNumericUpDown1.Size = new System.Drawing.Size(120, 23);
            this.amountNumericUpDown1.TabIndex = 1;
            this.amountNumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // specialNumericUpDown1
            // 
            this.specialNumericUpDown1.DecimalPlaces = 2;
            this.specialNumericUpDown1.Location = new System.Drawing.Point(46, 94);
            this.specialNumericUpDown1.Name = "specialNumericUpDown1";
            this.specialNumericUpDown1.Size = new System.Drawing.Size(120, 23);
            this.specialNumericUpDown1.TabIndex = 2;
            this.specialNumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(172, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 149);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.specialNumericUpDown1);
            this.Controls.Add(this.amountNumericUpDown1);
            this.Controls.Add(this.numericTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.amountNumericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.specialNumericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NumericTextBox numericTextBox1;
        private System.Windows.Forms.NumericUpDown amountNumericUpDown1;
        private CustomControls.SpecialNumericUpDown specialNumericUpDown1;
        private System.Windows.Forms.Button button1;
    }
}

