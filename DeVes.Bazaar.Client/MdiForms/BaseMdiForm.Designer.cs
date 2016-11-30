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
            this.m_frmPb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_frmPb)).BeginInit();
            this.SuspendLayout();
            // 
            // titelBarCtrl1
            // 
            this.titelBarCtrl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.titelBarCtrl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titelBarCtrl1.Location = new System.Drawing.Point(0, 0);
            this.titelBarCtrl1.Margin = new System.Windows.Forms.Padding(6);
            this.titelBarCtrl1.Name = "titelBarCtrl1";
            this.titelBarCtrl1.Size = new System.Drawing.Size(671, 59);
            this.titelBarCtrl1.TabIndex = 0;
            this.titelBarCtrl1.TabStop = false;
            this.titelBarCtrl1.TitelText = null;
            this.titelBarCtrl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.titelBarCtrl1_MouseUp);
            // 
            // m_frmPb
            // 
            this.m_frmPb.BackColor = System.Drawing.Color.Transparent;
            this.m_frmPb.Image = global::DeVes.Bazaar.Client.Properties.Resources.shoppingcart_32x32;
            this.m_frmPb.Location = new System.Drawing.Point(5, 5);
            this.m_frmPb.Name = "m_frmPb";
            this.m_frmPb.Size = new System.Drawing.Size(48, 48);
            this.m_frmPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_frmPb.TabIndex = 1;
            this.m_frmPb.TabStop = false;
            // 
            // BaseMdiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(671, 350);
            this.Controls.Add(this.m_frmPb);
            this.Controls.Add(this.titelBarCtrl1);
            this.Name = "BaseMdiForm";
            ((System.ComponentModel.ISupportInitialize)(this.m_frmPb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected CustControls.TitelBarCtrl titelBarCtrl1;
        protected System.Windows.Forms.PictureBox m_frmPb;



    }
}