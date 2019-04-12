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
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.lblGain = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBarM
            // 
            this.progressBarM.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.progressBarM.Location = new System.Drawing.Point(11, 45);
            this.progressBarM.Name = "progressBarM";
            this.progressBarM.Size = new System.Drawing.Size(1166, 23);
            this.progressBarM.Step = 1;
            this.progressBarM.TabIndex = 0;
            this.progressBarM.Value = 100;
            // 
            // progressBarL
            // 
            this.progressBarL.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.progressBarL.Location = new System.Drawing.Point(11, 130);
            this.progressBarL.Name = "progressBarL";
            this.progressBarL.Size = new System.Drawing.Size(1166, 23);
            this.progressBarL.Step = 1;
            this.progressBarL.TabIndex = 1;
            this.progressBarL.Value = 100;
            // 
            // progressBarR
            // 
            this.progressBarR.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.progressBarR.Location = new System.Drawing.Point(12, 206);
            this.progressBarR.Name = "progressBarR";
            this.progressBarR.Size = new System.Drawing.Size(1166, 23);
            this.progressBarR.Step = 1;
            this.progressBarR.TabIndex = 2;
            this.progressBarR.Value = 100;
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(12, 297);
            this.trackBar.Maximum = 200;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(1166, 45);
            this.trackBar.TabIndex = 3;
            this.trackBar.Value = 100;
            // 
            // lblGain
            // 
            this.lblGain.AutoSize = true;
            this.lblGain.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblGain.Location = new System.Drawing.Point(12, 263);
            this.lblGain.Name = "lblGain";
            this.lblGain.Size = new System.Drawing.Size(71, 31);
            this.lblGain.TabIndex = 5;
            this.lblGain.Text = "Gain";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(5, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "Right";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label2.Location = new System.Drawing.Point(6, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "Left";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label3.Location = new System.Drawing.Point(6, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 31);
            this.label3.TabIndex = 8;
            this.label3.Text = "Master";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 355);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblGain);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.progressBarR);
            this.Controls.Add(this.progressBarL);
            this.Controls.Add(this.progressBarM);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarM;
        private System.Windows.Forms.ProgressBar progressBarL;
        private System.Windows.Forms.ProgressBar progressBarR;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label lblGain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

