using System.Collections.Generic;

namespace CustomTextBox
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.myTextBox3 = new CustomTextBox.FilterTextBox();
            this.myTextBox2 = new CustomTextBox.FilterTextBox();
            this.myTextBox1 = new CustomTextBox.FilterTextBox();
            this.customTextBox1 = new CustomTextBox.FilterTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "numbers:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "alphabets:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "alpha numeric";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "AL NUM SIG";
            // 
            // myTextBox3
            // 
            this.myTextBox3.AllowNumeric = true;
            this.myTextBox3.BeepOnError = false;
            this.myTextBox3.Location = new System.Drawing.Point(159, 89);
            this.myTextBox3.Name = "myTextBox3";
            this.myTextBox3.Size = new System.Drawing.Size(100, 20);
            this.myTextBox3.SpecialChars = ((System.Collections.Generic.List<char>)(resources.GetObject("myTextBox3.SpecialChars")));
            this.myTextBox3.TabIndex = 0;
            // 
            // myTextBox2
            // 
            this.myTextBox2.AllowAlphabets = false;
            this.myTextBox2.AllowNumeric = true;
            this.myTextBox2.BeepOnError = false;
            this.myTextBox2.Location = new System.Drawing.Point(159, 63);
            this.myTextBox2.Name = "myTextBox2";
            this.myTextBox2.Size = new System.Drawing.Size(100, 20);
            this.myTextBox2.TabIndex = 0;
            // 
            // myTextBox1
            // 
            this.myTextBox1.AllowAlphabets = false;
            this.myTextBox1.BeepOnError = false;
            this.myTextBox1.Location = new System.Drawing.Point(159, 37);
            this.myTextBox1.Name = "myTextBox1";
            this.myTextBox1.Size = new System.Drawing.Size(100, 20);
            this.myTextBox1.TabIndex = 0;
            // 
            // customTextBox1
            // 
            this.customTextBox1.AllowAlphabets = false;
            this.customTextBox1.AllowNumeric = true;
            this.customTextBox1.BeepOnError = false;
            this.customTextBox1.Location = new System.Drawing.Point(159, 12);
            this.customTextBox1.MaxLength = 9;
            this.customTextBox1.Name = "customTextBox1";
            this.customTextBox1.Size = new System.Drawing.Size(100, 20);
            this.customTextBox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.myTextBox3);
            this.Controls.Add(this.myTextBox2);
            this.Controls.Add(this.myTextBox1);
            this.Controls.Add(this.customTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FilterTextBox customTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private FilterTextBox myTextBox1;
        private FilterTextBox myTextBox2;
        private System.Windows.Forms.Label label3;
        private FilterTextBox myTextBox3;
        private System.Windows.Forms.Label label4;
    }
}

