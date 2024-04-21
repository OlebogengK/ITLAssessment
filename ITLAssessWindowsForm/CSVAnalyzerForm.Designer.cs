namespace ITLAssessWindowsForm
{
    partial class CSVAnalyzerForm
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
            this.lblEarliestDate = new System.Windows.Forms.Label();
            this.lblLatestDate = new System.Windows.Forms.Label();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.lblHighestTotalCost = new System.Windows.Forms.Label();
            this.lblAverageQuantity = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblEarliestDate
            // 
            this.lblEarliestDate.AutoSize = true;
            this.lblEarliestDate.Location = new System.Drawing.Point(36, 197);
            this.lblEarliestDate.Name = "lblEarliestDate";
            this.lblEarliestDate.Size = new System.Drawing.Size(44, 16);
            this.lblEarliestDate.TabIndex = 0;
            this.lblEarliestDate.Text = "label1";
            // 
            // lblLatestDate
            // 
            this.lblLatestDate.AutoSize = true;
            this.lblLatestDate.Location = new System.Drawing.Point(36, 229);
            this.lblLatestDate.Name = "lblLatestDate";
            this.lblLatestDate.Size = new System.Drawing.Size(44, 16);
            this.lblLatestDate.TabIndex = 1;
            this.lblLatestDate.Text = "label2";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Location = new System.Drawing.Point(36, 264);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(44, 16);
            this.lblTotalCost.TabIndex = 2;
            this.lblTotalCost.Text = "label3";
            // 
            // lblHighestTotalCost
            // 
            this.lblHighestTotalCost.AutoSize = true;
            this.lblHighestTotalCost.Location = new System.Drawing.Point(36, 297);
            this.lblHighestTotalCost.Name = "lblHighestTotalCost";
            this.lblHighestTotalCost.Size = new System.Drawing.Size(44, 16);
            this.lblHighestTotalCost.TabIndex = 3;
            this.lblHighestTotalCost.Text = "label4";
            // 
            // lblAverageQuantity
            // 
            this.lblAverageQuantity.AutoSize = true;
            this.lblAverageQuantity.Location = new System.Drawing.Point(36, 327);
            this.lblAverageQuantity.Name = "lblAverageQuantity";
            this.lblAverageQuantity.Size = new System.Drawing.Size(44, 16);
            this.lblAverageQuantity.TabIndex = 4;
            this.lblAverageQuantity.Text = "label5";
            // 
            // CSVAnalyzerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblAverageQuantity);
            this.Controls.Add(this.lblHighestTotalCost);
            this.Controls.Add(this.lblTotalCost);
            this.Controls.Add(this.lblLatestDate);
            this.Controls.Add(this.lblEarliestDate);
            this.Name = "CSVAnalyzerForm";
            this.Text = "CSVAnalyzerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEarliestDate;
        private System.Windows.Forms.Label lblLatestDate;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.Label lblHighestTotalCost;
        private System.Windows.Forms.Label lblAverageQuantity;
    }
}