namespace DVes.Basar.Client.CustControls
{
    partial class SupplierSelection
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierSelection));
            this.m_supplierInfoGb = new DVes.Basar.Client.CustControls.BkGroupBox();
            this.m_returnedTb = new System.Windows.Forms.TextBox();
            this.m_supplierNoTb = new DVes.Basar.Client.CustControls.DVTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_suplAdressTb = new DVes.Basar.Client.CustControls.DVTextBox();
            this.m_newSellerBtn = new System.Windows.Forms.Button();
            this.m_searchSellerBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.m_suplNameTb = new DVes.Basar.Client.CustControls.DVTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_suplTitelTb = new DVes.Basar.Client.CustControls.DVTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_supplierInfoGb.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_supplierInfoGb
            // 
            this.m_supplierInfoGb.Controls.Add(this.m_returnedTb);
            this.m_supplierInfoGb.Controls.Add(this.m_supplierNoTb);
            this.m_supplierInfoGb.Controls.Add(this.label4);
            this.m_supplierInfoGb.Controls.Add(this.m_suplAdressTb);
            this.m_supplierInfoGb.Controls.Add(this.m_newSellerBtn);
            this.m_supplierInfoGb.Controls.Add(this.m_searchSellerBtn);
            this.m_supplierInfoGb.Controls.Add(this.label3);
            this.m_supplierInfoGb.Controls.Add(this.m_suplNameTb);
            this.m_supplierInfoGb.Controls.Add(this.label2);
            this.m_supplierInfoGb.Controls.Add(this.m_suplTitelTb);
            this.m_supplierInfoGb.Controls.Add(this.label1);
            this.m_supplierInfoGb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_supplierInfoGb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_supplierInfoGb.Location = new System.Drawing.Point(0, 0);
            this.m_supplierInfoGb.Name = "m_supplierInfoGb";
            this.m_supplierInfoGb.Size = new System.Drawing.Size(695, 181);
            this.m_supplierInfoGb.TabIndex = 0;
            this.m_supplierInfoGb.TabStop = false;
            this.m_supplierInfoGb.Text = "Verkäufer";
            // 
            // m_returnedTb
            // 
            this.m_returnedTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_returnedTb.BackColor = System.Drawing.Color.LightSalmon;
            this.m_returnedTb.Location = new System.Drawing.Point(16, 148);
            this.m_returnedTb.Name = "m_returnedTb";
            this.m_returnedTb.ReadOnly = true;
            this.m_returnedTb.Size = new System.Drawing.Size(523, 26);
            this.m_returnedTb.TabIndex = 10;
            // 
            // m_supplierNoTb
            // 
            this.m_supplierNoTb.AllowSpace = false;
            this.m_supplierNoTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_supplierNoTb.IsMargin = false;
            this.m_supplierNoTb.Location = new System.Drawing.Point(12, 41);
            this.m_supplierNoTb.Margin = new System.Windows.Forms.Padding(4);
            this.m_supplierNoTb.Name = "m_supplierNoTb";
            this.m_supplierNoTb.ResultType = DVes.Basar.Client.CustControls.DVTextBox.ResultTypes.Int32;
            this.m_supplierNoTb.Size = new System.Drawing.Size(83, 26);
            this.m_supplierNoTb.TabIndex = 1;
            this.m_supplierNoTb.TabStop = false;
            this.m_supplierNoTb.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_supplierNoTb_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nummer:";
            // 
            // m_suplAdressTb
            // 
            this.m_suplAdressTb.AllowSpace = false;
            this.m_suplAdressTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_suplAdressTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_suplAdressTb.IsMargin = false;
            this.m_suplAdressTb.Location = new System.Drawing.Point(12, 91);
            this.m_suplAdressTb.Margin = new System.Windows.Forms.Padding(4);
            this.m_suplAdressTb.Multiline = true;
            this.m_suplAdressTb.Name = "m_suplAdressTb";
            this.m_suplAdressTb.ReadOnly = true;
            this.m_suplAdressTb.ResultType = DVes.Basar.Client.CustControls.DVTextBox.ResultTypes.String;
            this.m_suplAdressTb.Size = new System.Drawing.Size(527, 50);
            this.m_suplAdressTb.TabIndex = 7;
            this.m_suplAdressTb.TabStop = false;
            this.m_suplAdressTb.Text = "11111\r\n11111 1111";
            // 
            // m_newSellerBtn
            // 
            this.m_newSellerBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_newSellerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_newSellerBtn.Image = ((System.Drawing.Image)(resources.GetObject("m_newSellerBtn.Image")));
            this.m_newSellerBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_newSellerBtn.Location = new System.Drawing.Point(547, 84);
            this.m_newSellerBtn.Margin = new System.Windows.Forms.Padding(4);
            this.m_newSellerBtn.Name = "m_newSellerBtn";
            this.m_newSellerBtn.Size = new System.Drawing.Size(141, 60);
            this.m_newSellerBtn.TabIndex = 9;
            this.m_newSellerBtn.Text = "Neu";
            this.m_newSellerBtn.UseVisualStyleBackColor = true;
            this.m_newSellerBtn.Click += new System.EventHandler(this.m_newSellerBtn_Click);
            // 
            // m_searchSellerBtn
            // 
            this.m_searchSellerBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_searchSellerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_searchSellerBtn.Image = ((System.Drawing.Image)(resources.GetObject("m_searchSellerBtn.Image")));
            this.m_searchSellerBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_searchSellerBtn.Location = new System.Drawing.Point(547, 18);
            this.m_searchSellerBtn.Margin = new System.Windows.Forms.Padding(4);
            this.m_searchSellerBtn.Name = "m_searchSellerBtn";
            this.m_searchSellerBtn.Size = new System.Drawing.Size(141, 60);
            this.m_searchSellerBtn.TabIndex = 8;
            this.m_searchSellerBtn.Text = "Verkäufer\r\nSuchen";
            this.m_searchSellerBtn.UseVisualStyleBackColor = true;
            this.m_searchSellerBtn.Click += new System.EventHandler(this.m_searchSellerBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Anschrift:";
            // 
            // m_suplNameTb
            // 
            this.m_suplNameTb.AllowSpace = false;
            this.m_suplNameTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_suplNameTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_suplNameTb.IsMargin = false;
            this.m_suplNameTb.Location = new System.Drawing.Point(228, 42);
            this.m_suplNameTb.Margin = new System.Windows.Forms.Padding(4);
            this.m_suplNameTb.Name = "m_suplNameTb";
            this.m_suplNameTb.ReadOnly = true;
            this.m_suplNameTb.ResultType = DVes.Basar.Client.CustControls.DVTextBox.ResultTypes.String;
            this.m_suplNameTb.Size = new System.Drawing.Size(311, 26);
            this.m_suplNameTb.TabIndex = 5;
            this.m_suplNameTb.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(224, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name:";
            // 
            // m_suplTitelTb
            // 
            this.m_suplTitelTb.AllowSpace = false;
            this.m_suplTitelTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_suplTitelTb.IsMargin = false;
            this.m_suplTitelTb.Location = new System.Drawing.Point(103, 42);
            this.m_suplTitelTb.Margin = new System.Windows.Forms.Padding(4);
            this.m_suplTitelTb.Name = "m_suplTitelTb";
            this.m_suplTitelTb.ReadOnly = true;
            this.m_suplTitelTb.ResultType = DVes.Basar.Client.CustControls.DVTextBox.ResultTypes.String;
            this.m_suplTitelTb.Size = new System.Drawing.Size(113, 26);
            this.m_suplTitelTb.TabIndex = 3;
            this.m_suplTitelTb.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Anrede:";
            // 
            // SupplierSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_supplierInfoGb);
            this.Name = "SupplierSelection";
            this.Size = new System.Drawing.Size(695, 181);
            this.m_supplierInfoGb.ResumeLayout(false);
            this.m_supplierInfoGb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BkGroupBox m_supplierInfoGb;
        private DVTextBox m_suplAdressTb;
        private System.Windows.Forms.Button m_newSellerBtn;
        private System.Windows.Forms.Button m_searchSellerBtn;
        private System.Windows.Forms.Label label3;
        private DVTextBox m_suplNameTb;
        private System.Windows.Forms.Label label2;
        private DVTextBox m_suplTitelTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        public DVTextBox m_supplierNoTb;
        private System.Windows.Forms.TextBox m_returnedTb;
    }
}
