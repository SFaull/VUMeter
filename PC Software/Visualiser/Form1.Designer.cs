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
            this.SuspendLayout();
            // 
            // progressBarM
            // 
            this.progressBarM.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.progressBarM.Location = new System.Drawing.Point(12, 12);
            this.progressBarM.Name = "progressBarM";
            this.progressBarM.Size = new System.Drawing.Size(1166, 23);
            this.progressBarM.Step = 1;
            this.progressBarM.TabIndex = 0;
            this.progressBarM.Value = 100;
            // 
            // progressBarL
            // 
            this.progressBarL.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.progressBarL.Location = new System.Drawing.Point(12, 82);
            this.progressBarL.Name = "progressBarL";
            this.progressBarL.Size = new System.Drawing.Size(1166, 23);
            this.progressBarL.Step = 1;
            this.progressBarL.TabIndex = 1;
            this.progressBarL.Value = 100;
            // 
            // progressBarR
            // 
            this.progressBarR.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.progressBarR.Location = new System.Drawing.Point(12, 111);
            this.progressBarR.Name = "progressBarR";
            this.progressBarR.Size = new System.Drawing.Size(1166, 23);
            this.progressBarR.Step = 1;
            this.progressBarR.TabIndex = 2;
            this.progressBarR.Value = 100;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 187);
            this.Controls.Add(this.progressBarR);
            this.Controls.Add(this.progressBarL);
            this.Controls.Add(this.progressBarM);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarM;
        private System.Windows.Forms.ProgressBar progressBarL;
        private System.Windows.Forms.ProgressBar progressBarR;
    }
}

