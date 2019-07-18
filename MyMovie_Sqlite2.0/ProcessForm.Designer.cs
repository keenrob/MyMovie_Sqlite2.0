namespace MyMovie_Sqlite2._0
{
    partial class ProcessForm
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
            this._demoBGWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBarSum = new System.Windows.Forms.ProgressBar();
            this.labelSum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBarSum
            // 
            this.progressBarSum.Location = new System.Drawing.Point(85, 183);
            this.progressBarSum.Name = "progressBarSum";
            this.progressBarSum.Size = new System.Drawing.Size(589, 23);
            this.progressBarSum.TabIndex = 0;
            // 
            // labelSum
            // 
            this.labelSum.AutoSize = true;
            this.labelSum.Location = new System.Drawing.Point(82, 147);
            this.labelSum.Name = "labelSum";
            this.labelSum.Size = new System.Drawing.Size(55, 15);
            this.labelSum.TabIndex = 1;
            this.labelSum.Text = "label1";
            // 
            // ProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelSum);
            this.Controls.Add(this.progressBarSum);
            this.Name = "ProcessForm";
            this.Text = "ProcessForm";
            this.Load += new System.EventHandler(this.ProcessForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker _demoBGWorker;
        private System.Windows.Forms.ProgressBar progressBarSum;
        private System.Windows.Forms.Label labelSum;
    }
}