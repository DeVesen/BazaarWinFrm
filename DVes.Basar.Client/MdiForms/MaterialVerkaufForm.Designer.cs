namespace DVes.Basar.Client.MdiForms
{
    partial class MaterialVerkaufForm
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
            this.bkGroupBox2 = new DVes.Basar.Client.CustControls.BkGroupBox();
            this.m_matlPosLv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bkGroupBox1 = new DVes.Basar.Client.CustControls.BkGroupBox();
            this.m_cancelPositionBtn = new System.Windows.Forms.Button();
            this.m_sellMinPriceBtn = new System.Windows.Forms.Button();
            this.m_sellMaxPriceBtn = new System.Windows.Forms.Button();
            this.m_positonNoTb = new DVes.Basar.Client.CustControls.DVTextBox();
            this.m_confirmSellBtn = new System.Windows.Forms.Button();
            this.m_clearCellPositonsBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.m_qtySum = new System.Windows.Forms.Label();
            this.m_badScanLb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_frmPb)).BeginInit();
            this.bkGroupBox2.SuspendLayout();
            this.bkGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // titelBarCtrl1
            // 
            this.titelBarCtrl1.Size = new System.Drawing.Size(943, 59);
            this.titelBarCtrl1.TitelText = "Verkauf";
            // 
            // m_frmPb
            // 
            this.m_frmPb.Image = global::DVes.Basar.Client.Properties.Resources.cashier_32x32;
            // 
            // bkGroupBox2
            // 
            this.bkGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bkGroupBox2.Controls.Add(this.m_matlPosLv);
            this.bkGroupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.bkGroupBox2.Location = new System.Drawing.Point(7, 257);
            this.bkGroupBox2.Name = "bkGroupBox2";
            this.bkGroupBox2.Size = new System.Drawing.Size(752, 297);
            this.bkGroupBox2.TabIndex = 3;
            this.bkGroupBox2.TabStop = false;
            this.bkGroupBox2.Text = "Restliche zu importierende Positionen";
            // 
            // m_matlPosLv
            // 
            this.m_matlPosLv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_matlPosLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader6});
            this.m_matlPosLv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_matlPosLv.FullRowSelect = true;
            this.m_matlPosLv.GridLines = true;
            this.m_matlPosLv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_matlPosLv.HideSelection = false;
            this.m_matlPosLv.Location = new System.Drawing.Point(7, 21);
            this.m_matlPosLv.Name = "m_matlPosLv";
            this.m_matlPosLv.ShowGroups = false;
            this.m_matlPosLv.Size = new System.Drawing.Size(735, 267);
            this.m_matlPosLv.TabIndex = 18;
            this.m_matlPosLv.UseCompatibleStateImageBehavior = false;
            this.m_matlPosLv.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Pos. Nr.";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Bezeichnung";
            this.columnHeader2.Width = 244;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Preis";
            this.columnHeader6.Width = 82;
            // 
            // bkGroupBox1
            // 
            this.bkGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bkGroupBox1.Controls.Add(this.m_badScanLb);
            this.bkGroupBox1.Controls.Add(this.m_cancelPositionBtn);
            this.bkGroupBox1.Controls.Add(this.m_sellMinPriceBtn);
            this.bkGroupBox1.Controls.Add(this.m_sellMaxPriceBtn);
            this.bkGroupBox1.Controls.Add(this.m_positonNoTb);
            this.bkGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bkGroupBox1.Location = new System.Drawing.Point(7, 68);
            this.bkGroupBox1.Name = "bkGroupBox1";
            this.bkGroupBox1.Size = new System.Drawing.Size(754, 183);
            this.bkGroupBox1.TabIndex = 2;
            this.bkGroupBox1.TabStop = false;
            this.bkGroupBox1.Text = "Positionseingabe";
            // 
            // m_cancelPositionBtn
            // 
            this.m_cancelPositionBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cancelPositionBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cancelPositionBtn.Image = global::DVes.Basar.Client.Properties.Resources.delete2_32x32;
            this.m_cancelPositionBtn.Location = new System.Drawing.Point(682, 113);
            this.m_cancelPositionBtn.Margin = new System.Windows.Forms.Padding(4);
            this.m_cancelPositionBtn.Name = "m_cancelPositionBtn";
            this.m_cancelPositionBtn.Size = new System.Drawing.Size(60, 60);
            this.m_cancelPositionBtn.TabIndex = 24;
            this.m_cancelPositionBtn.Tag = "";
            this.m_cancelPositionBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cancelPositionBtn.UseVisualStyleBackColor = true;
            this.m_cancelPositionBtn.Click += new System.EventHandler(this.m_cancelPositionBtn_Click);
            // 
            // m_sellMinPriceBtn
            // 
            this.m_sellMinPriceBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_sellMinPriceBtn.Enabled = false;
            this.m_sellMinPriceBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_sellMinPriceBtn.Image = global::DVes.Basar.Client.Properties.Resources.cashier_32x32;
            this.m_sellMinPriceBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_sellMinPriceBtn.Location = new System.Drawing.Point(220, 113);
            this.m_sellMinPriceBtn.Margin = new System.Windows.Forms.Padding(4);
            this.m_sellMinPriceBtn.Name = "m_sellMinPriceBtn";
            this.m_sellMinPriceBtn.Size = new System.Drawing.Size(215, 60);
            this.m_sellMinPriceBtn.TabIndex = 23;
            this.m_sellMinPriceBtn.Tag = "(F4) Buche mit {0} €";
            this.m_sellMinPriceBtn.Text = "(F4) Buche mit 500 €";
            this.m_sellMinPriceBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_sellMinPriceBtn.UseVisualStyleBackColor = true;
            this.m_sellMinPriceBtn.Click += new System.EventHandler(this.OnConfirmSellPosBtn);
            // 
            // m_sellMaxPriceBtn
            // 
            this.m_sellMaxPriceBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_sellMaxPriceBtn.Enabled = false;
            this.m_sellMaxPriceBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_sellMaxPriceBtn.Image = global::DVes.Basar.Client.Properties.Resources.cashier_32x32;
            this.m_sellMaxPriceBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_sellMaxPriceBtn.Location = new System.Drawing.Point(453, 113);
            this.m_sellMaxPriceBtn.Margin = new System.Windows.Forms.Padding(4);
            this.m_sellMaxPriceBtn.Name = "m_sellMaxPriceBtn";
            this.m_sellMaxPriceBtn.Size = new System.Drawing.Size(221, 60);
            this.m_sellMaxPriceBtn.TabIndex = 23;
            this.m_sellMaxPriceBtn.Tag = "(F5) Buche mit {0} €";
            this.m_sellMaxPriceBtn.Text = "(F5) Buche mit 500 €";
            this.m_sellMaxPriceBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_sellMaxPriceBtn.UseVisualStyleBackColor = true;
            this.m_sellMaxPriceBtn.Click += new System.EventHandler(this.OnConfirmSellPosBtn);
            // 
            // m_positonNoTb
            // 
            this.m_positonNoTb.AllowSpace = false;
            this.m_positonNoTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_positonNoTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_positonNoTb.IsMargin = false;
            this.m_positonNoTb.Location = new System.Drawing.Point(12, 21);
            this.m_positonNoTb.Name = "m_positonNoTb";
            this.m_positonNoTb.ResultType = DVes.Basar.Client.CustControls.DVTextBox.ResultTypes.Int32;
            this.m_positonNoTb.Size = new System.Drawing.Size(732, 53);
            this.m_positonNoTb.TabIndex = 0;
            this.m_positonNoTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // m_confirmSellBtn
            // 
            this.m_confirmSellBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_confirmSellBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_confirmSellBtn.Image = global::DVes.Basar.Client.Properties.Resources.cashier_32x32;
            this.m_confirmSellBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_confirmSellBtn.Location = new System.Drawing.Point(768, 559);
            this.m_confirmSellBtn.Margin = new System.Windows.Forms.Padding(4);
            this.m_confirmSellBtn.Name = "m_confirmSellBtn";
            this.m_confirmSellBtn.Size = new System.Drawing.Size(166, 60);
            this.m_confirmSellBtn.TabIndex = 8;
            this.m_confirmSellBtn.Text = "(F9) Buchen";
            this.m_confirmSellBtn.UseVisualStyleBackColor = true;
            this.m_confirmSellBtn.Click += new System.EventHandler(this.m_confirmSellBtn_Click);
            // 
            // m_clearCellPositonsBtn
            // 
            this.m_clearCellPositonsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_clearCellPositonsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_clearCellPositonsBtn.Image = global::DVes.Basar.Client.Properties.Resources.delete2_32x32;
            this.m_clearCellPositonsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_clearCellPositonsBtn.Location = new System.Drawing.Point(768, 257);
            this.m_clearCellPositonsBtn.Margin = new System.Windows.Forms.Padding(4);
            this.m_clearCellPositonsBtn.Name = "m_clearCellPositonsBtn";
            this.m_clearCellPositonsBtn.Size = new System.Drawing.Size(166, 60);
            this.m_clearCellPositonsBtn.TabIndex = 9;
            this.m_clearCellPositonsBtn.Text = "Liste leeren";
            this.m_clearCellPositonsBtn.UseVisualStyleBackColor = true;
            this.m_clearCellPositonsBtn.Click += new System.EventHandler(this.m_clearCellPositonsBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::DVes.Basar.Client.Properties.Resources.moneybag_euro_32x32;
            this.pictureBox1.Location = new System.Drawing.Point(549, 561);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(69, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // m_qtySum
            // 
            this.m_qtySum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_qtySum.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_qtySum.Location = new System.Drawing.Point(624, 561);
            this.m_qtySum.Name = "m_qtySum";
            this.m_qtySum.Size = new System.Drawing.Size(127, 59);
            this.m_qtySum.TabIndex = 21;
            this.m_qtySum.Tag = "0";
            this.m_qtySum.Text = "0,00";
            this.m_qtySum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_badScanLb
            // 
            this.m_badScanLb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_badScanLb.BackColor = System.Drawing.Color.Transparent;
            this.m_badScanLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_badScanLb.Location = new System.Drawing.Point(9, 77);
            this.m_badScanLb.Name = "m_badScanLb";
            this.m_badScanLb.Size = new System.Drawing.Size(735, 32);
            this.m_badScanLb.TabIndex = 25;
            this.m_badScanLb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MaterialVerkaufForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 629);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.m_qtySum);
            this.Controls.Add(this.m_clearCellPositonsBtn);
            this.Controls.Add(this.m_confirmSellBtn);
            this.Controls.Add(this.bkGroupBox2);
            this.Controls.Add(this.bkGroupBox1);
            this.Name = "MaterialVerkaufForm";
            this.Text = "Verkauf";
            this.Load += new System.EventHandler(this.MaterialVerkaufForm_Load);
            this.Controls.SetChildIndex(this.titelBarCtrl1, 0);
            this.Controls.SetChildIndex(this.m_frmPb, 0);
            this.Controls.SetChildIndex(this.bkGroupBox1, 0);
            this.Controls.SetChildIndex(this.bkGroupBox2, 0);
            this.Controls.SetChildIndex(this.m_confirmSellBtn, 0);
            this.Controls.SetChildIndex(this.m_clearCellPositonsBtn, 0);
            this.Controls.SetChildIndex(this.m_qtySum, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.m_frmPb)).EndInit();
            this.bkGroupBox2.ResumeLayout(false);
            this.bkGroupBox1.ResumeLayout(false);
            this.bkGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustControls.BkGroupBox bkGroupBox2;
        private System.Windows.Forms.ListView m_matlPosLv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private CustControls.BkGroupBox bkGroupBox1;
        private CustControls.DVTextBox m_positonNoTb;
        private System.Windows.Forms.Button m_confirmSellBtn;
        private System.Windows.Forms.Button m_clearCellPositonsBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label m_qtySum;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button m_cancelPositionBtn;
        private System.Windows.Forms.Button m_sellMinPriceBtn;
        private System.Windows.Forms.Button m_sellMaxPriceBtn;
        private System.Windows.Forms.Label m_badScanLb;


    }
}