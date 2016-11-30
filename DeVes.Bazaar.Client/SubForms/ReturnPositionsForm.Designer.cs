namespace DeVes.Bazaar.Client.SubForms
{
    partial class ReturnPositionsForm
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
            this.bkGroupBox1 = new DeVes.Bazaar.Client.CustControls.BkGroupBox();
            this.dvTextBox1 = new DeVes.Bazaar.Client.CustControls.DvTextBox();
            this.bkGroupBox2 = new DeVes.Bazaar.Client.CustControls.BkGroupBox();
            this.m_matlPosLv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.m_confirmAllBtn = new System.Windows.Forms.Button();
            this.bkGroupBox1.SuspendLayout();
            this.bkGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bkGroupBox1
            // 
            this.bkGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bkGroupBox1.Controls.Add(this.dvTextBox1);
            this.bkGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bkGroupBox1.Location = new System.Drawing.Point(5, 5);
            this.bkGroupBox1.Name = "bkGroupBox1";
            this.bkGroupBox1.Size = new System.Drawing.Size(752, 83);
            this.bkGroupBox1.TabIndex = 0;
            this.bkGroupBox1.TabStop = false;
            this.bkGroupBox1.Text = "Positionseingabe";
            // 
            // dvTextBox1
            // 
            this.dvTextBox1.AllowSpace = false;
            this.dvTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dvTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dvTextBox1.IsMargin = false;
            this.dvTextBox1.Location = new System.Drawing.Point(12, 21);
            this.dvTextBox1.Name = "dvTextBox1";
            this.dvTextBox1.ResultType = DeVes.Bazaar.Client.CustControls.DvTextBox.ResultTypes.String;
            this.dvTextBox1.Size = new System.Drawing.Size(730, 53);
            this.dvTextBox1.TabIndex = 0;
            this.dvTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dvTextBox1.TextChanged += new System.EventHandler(this.dvTextBox1_TextChanged);
            this.dvTextBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dvTextBox1_KeyUp);
            // 
            // bkGroupBox2
            // 
            this.bkGroupBox2.Controls.Add(this.m_matlPosLv);
            this.bkGroupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.bkGroupBox2.Location = new System.Drawing.Point(5, 94);
            this.bkGroupBox2.Name = "bkGroupBox2";
            this.bkGroupBox2.Size = new System.Drawing.Size(752, 248);
            this.bkGroupBox2.TabIndex = 1;
            this.bkGroupBox2.TabStop = false;
            this.bkGroupBox2.Text = "Noch nicht verkaufte Positionen";
            // 
            // m_matlPosLv
            // 
            this.m_matlPosLv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_matlPosLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader7});
            this.m_matlPosLv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_matlPosLv.FullRowSelect = true;
            this.m_matlPosLv.GridLines = true;
            this.m_matlPosLv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_matlPosLv.HideSelection = false;
            this.m_matlPosLv.Location = new System.Drawing.Point(7, 21);
            this.m_matlPosLv.Name = "m_matlPosLv";
            this.m_matlPosLv.ShowGroups = false;
            this.m_matlPosLv.Size = new System.Drawing.Size(735, 218);
            this.m_matlPosLv.TabIndex = 18;
            this.m_matlPosLv.UseCompatibleStateImageBehavior = false;
            this.m_matlPosLv.View = System.Windows.Forms.View.Details;
            this.m_matlPosLv.DoubleClick += new System.EventHandler(this.m_matlPosLv_DoubleClick);
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
            // columnHeader3
            // 
            this.columnHeader3.Text = "Kategorie";
            this.columnHeader3.Width = 102;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Hersteller";
            this.columnHeader4.Width = 103;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Preis je Stück";
            this.columnHeader5.Width = 102;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Min. Preis";
            this.columnHeader7.Width = 81;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::DeVes.Bazaar.Client.Properties.Resources.delete2_32x32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(597, 348);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 59);
            this.button1.TabIndex = 2;
            this.button1.Text = "Schließen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // m_confirmAllBtn
            // 
            this.m_confirmAllBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_confirmAllBtn.Image = global::DeVes.Bazaar.Client.Properties.Resources.handshake_32x32;
            this.m_confirmAllBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_confirmAllBtn.Location = new System.Drawing.Point(12, 348);
            this.m_confirmAllBtn.Name = "m_confirmAllBtn";
            this.m_confirmAllBtn.Size = new System.Drawing.Size(160, 59);
            this.m_confirmAllBtn.TabIndex = 3;
            this.m_confirmAllBtn.Text = "Alle bestätigen";
            this.m_confirmAllBtn.UseVisualStyleBackColor = true;
            this.m_confirmAllBtn.Click += new System.EventHandler(this.m_confirmAllBtn_Click);
            // 
            // ReturnPositionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 413);
            this.Controls.Add(this.m_confirmAllBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bkGroupBox2);
            this.Controls.Add(this.bkGroupBox1);
            this.Name = "ReturnPositionsForm";
            this.Text = "Rückgabenerfassung";
            this.Load += new System.EventHandler(this.ImportPositionForm_Load);
            this.bkGroupBox1.ResumeLayout(false);
            this.bkGroupBox1.PerformLayout();
            this.bkGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CustControls.BkGroupBox bkGroupBox1;
        private CustControls.DvTextBox dvTextBox1;
        private CustControls.BkGroupBox bkGroupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView m_matlPosLv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button m_confirmAllBtn;
    }
}