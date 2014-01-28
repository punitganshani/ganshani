namespace BluetoothPoC
{
    partial class frmBluetooth
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
            this.lstDevices = new System.Windows.Forms.ListBox();
            this.btnDiscover = new System.Windows.Forms.Button();
            this.btnGetMAC = new System.Windows.Forms.Button();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstDevices
            // 
            this.lstDevices.FormattingEnabled = true;
            this.lstDevices.Location = new System.Drawing.Point(13, 13);
            this.lstDevices.Name = "lstDevices";
            this.lstDevices.Size = new System.Drawing.Size(133, 134);
            this.lstDevices.TabIndex = 0;
            // 
            // btnDiscover
            // 
            this.btnDiscover.Location = new System.Drawing.Point(152, 13);
            this.btnDiscover.Name = "btnDiscover";
            this.btnDiscover.Size = new System.Drawing.Size(120, 23);
            this.btnDiscover.TabIndex = 1;
            this.btnDiscover.Text = "&Device Discovery";
            this.btnDiscover.UseVisualStyleBackColor = true;
            this.btnDiscover.Click += new System.EventHandler(this.btnDiscover_Click);
            // 
            // btnGetMAC
            // 
            this.btnGetMAC.Location = new System.Drawing.Point(152, 43);
            this.btnGetMAC.Name = "btnGetMAC";
            this.btnGetMAC.Size = new System.Drawing.Size(120, 23);
            this.btnGetMAC.TabIndex = 2;
            this.btnGetMAC.Text = "Get &MAC Address";
            this.btnGetMAC.UseVisualStyleBackColor = true;
            this.btnGetMAC.Click += new System.EventHandler(this.btnGetMAC_Click);
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(152, 73);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(120, 23);
            this.btnSendFile.TabIndex = 3;
            this.btnSendFile.Text = "&Send File";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(152, 122);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(120, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 157);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSendFile);
            this.Controls.Add(this.btnGetMAC);
            this.Controls.Add(this.btnDiscover);
            this.Controls.Add(this.lstDevices);
            this.Name = "Form1";
            this.Text = "Bluetooth";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstDevices;
        private System.Windows.Forms.Button btnDiscover;
        private System.Windows.Forms.Button btnGetMAC;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.Button btnExit;

    }
}

