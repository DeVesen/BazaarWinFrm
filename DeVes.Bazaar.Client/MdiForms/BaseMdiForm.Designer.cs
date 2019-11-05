namespace DeVes.Bazaar.Client.MdiForms
{
    partial class BaseMdiForm
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
            this.titelBarCtrl1 = new DeVes.Bazaar.Client.CustControls.TitelBarCtrl();
            this.SuspendLayout();
            // 
            // titelBarCtrl1
            // 
            this.titelBarCtrl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.titelBarCtrl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titelBarCtrl1.Location = new System.Drawing.Point(0, 0);
            this.titelBarCtrl1.Margin = new System.Windows.Forms.Padding(16, 14, 16, 14);
            this.titelBarCtrl1.Name = "titelBarCtrl1";
            this.titelBarCtrl1.Size = new System.Drawing.Size(1789, 141);
            this.titelBarCtrl1.TabIndex = 0;
            this.titelBarCtrl1.TabStop = false;
            this.titelBarCtrl1.TitelText = null;
            this.titelBarCtrl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.titelBarCtrl1_MouseUp);
            // 
            // BaseMdiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1789, 835);
            this.Controls.Add(this.titelBarCtrl1);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "BaseMdiForm";
            this.ResumeLayout(false);

        }

        #endregion

        protected CustControls.TitelBarCtrl titelBarCtrl1;
    }
}