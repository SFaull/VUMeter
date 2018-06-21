namespace Visualiser
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
            this.progressBarM = new System.Windows.Forms.ProgressBar();
            this.progressBarL = new System.Windows.Forms.ProgressBar();
            this.progressBarR = new System.Windows.Forms.ProgressBar();
            this.boxConnection = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cmbSerialPorts = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.boxConnection.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBarM
            // 
            this.progressBarM.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.progressBarM.Location = new System.Drawing.Point(12, 113);
            this.progressBarM.Name = "progressBarM";
            this.progressBarM.Size = new System.Drawing.Size(463, 23);
            this.progressBarM.Step = 1;
            this.progressBarM.TabIndex = 0;
            this.progressBarM.Value = 100;
            // 
            // progressBarL
            // 
            this.progressBarL.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.progressBarL.Location = new System.Drawing.Point(12, 183);
            this.progressBarL.Name = "progressBarL";
            this.progressBarL.Size = new System.Drawing.Size(436, 23);
            this.progressBarL.Step = 1;
            this.progressBarL.TabIndex = 1;
            this.progressBarL.Value = 100;
            // 
            // progressBarR
            // 
            this.progressBarR.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.progressBarR.Location = new System.Drawing.Point(12, 212);
            this.progressBarR.Name = "progressBarR";
            this.progressBarR.Size = new System.Drawing.Size(446, 23);
            this.progressBarR.Step = 1;
            this.progressBarR.TabIndex = 2;
            this.progressBarR.Value = 100;
            // 
            // boxConnection
            // 
            this.boxConnection.Controls.Add(this.btnConnect);
            this.boxConnection.Controls.Add(this.cmbSerialPorts);
            this.boxConnection.Location = new System.Drawing.Point(12, 12);
            this.boxConnection.Name = "boxConnection";
            this.boxConnection.Size = new System.Drawing.Size(227, 57);
            this.boxConnection.TabIndex = 3;
            this.boxConnection.TabStop = false;
            this.boxConnection.Text = "Connect to Device";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(134, 19);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cmbSerialPorts
            // 
            this.cmbSerialPorts.FormattingEnabled = true;
            this.cmbSerialPorts.Location = new System.Drawing.Point(6, 19);
            this.cmbSerialPorts.Name = "cmbSerialPorts";
            this.cmbSerialPorts.Size = new System.Drawing.Size(121, 21);
            this.cmbSerialPorts.TabIndex = 0;
            this.cmbSerialPorts.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbSerialPorts_MouseClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelConnectionStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 253);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(487, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelConnectionStatus
            // 
            this.labelConnectionStatus.Name = "labelConnectionStatus";
            this.labelConnectionStatus.Size = new System.Drawing.Size(129, 17);
            this.labelConnectionStatus.Text = "Status: Not Connected ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 275);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.boxConnection);
            this.Controls.Add(this.progressBarR);
            this.Controls.Add(this.progressBarL);
            this.Controls.Add(this.progressBarM);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.boxConnection.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarM;
        private System.Windows.Forms.ProgressBar progressBarL;
        private System.Windows.Forms.ProgressBar progressBarR;
        private System.Windows.Forms.GroupBox boxConnection;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cmbSerialPorts;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelConnectionStatus;
    }
}

