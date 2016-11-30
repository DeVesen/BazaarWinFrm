namespace DeVes.Bazaar.Client.MdiForms.ScreenLists
{
    partial class BaseScreenListForm
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
            this.m_screenLv = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.m_frmPb)).BeginInit();
            this.SuspendLayout();
            // 
            // titelBarCtrl1
            // 
            this.titelBarCtrl1.Size = new System.Drawing.Size(867, 59);
            // 
            // m_frmPb
            // 
            this.m_frmPb.Image = global::DeVes.Bazaar.Client.Properties.Resources.table_sql_32x32;
            // 
            // m_screenLv
            // 
            this.m_screenLv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_screenLv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_screenLv.FullRowSelect = true;
            this.m_screenLv.GridLines = true;
            this.m_screenLv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_screenLv.HideSelection = false;
            this.m_screenLv.Location = new System.Drawing.Point(5, 59);
            this.m_screenLv.Name = "m_screenLv";
            this.m_screenLv.ShowGroups = false;
            this.m_screenLv.Size = new System.Drawing.Size(857, 353);
            this.m_screenLv.TabIndex = 18;
            this.m_screenLv.UseCompatibleStateImageBehavior = false;
            this.m_screenLv.View = System.Windows.Forms.View.Details;
            // 
            // BaseScreenListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 417);
            this.Controls.Add(this.m_screenLv);
            this.Name = "BaseScreenListForm";
            this.Load += new System.EventHandler(this.BaseScreenListForm_Load);
            this.Controls.SetChildIndex(this.titelBarCtrl1, 0);
            this.Controls.SetChildIndex(this.m_frmPb, 0);
            this.Controls.SetChildIndex(this.m_screenLv, 0);
            ((System.ComponentModel.ISupportInitialize)(this.m_frmPb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.ListView m_screenLv;
    }
}