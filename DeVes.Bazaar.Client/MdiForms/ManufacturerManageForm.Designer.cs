namespace DeVes.Bazaar.Client.MdiForms
{
    partial class ManufacturerManageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManufacturerManageForm));
            this.label1 = new System.Windows.Forms.Label();
            this.m_removeCatBtn = new System.Windows.Forms.Button();
            this.m_addCatBtn = new System.Windows.Forms.Button();
            this.m_catLv = new DeVes.Bazaar.Client.CustControls.DvListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_catInputTb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // titelBarCtrl1
            // 
            this.titelBarCtrl1.Margin = new System.Windows.Forms.Padding(43, 33, 43, 33);
            this.titelBarCtrl1.Size = new System.Drawing.Size(1741, 141);
            this.titelBarCtrl1.TitelText = "Hersteller Verwaltung";
            this.titelBarCtrl1.TitelImage = global::DeVes.Bazaar.Client.Properties.Resources.factory_32x32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 150);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hersteller:";
            // 
            // m_removeCatBtn
            // 
            this.m_removeCatBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_removeCatBtn.Enabled = false;
            this.m_removeCatBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_removeCatBtn.Image = ((System.Drawing.Image)(resources.GetObject("m_removeCatBtn.Image")));
            this.m_removeCatBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_removeCatBtn.Location = new System.Drawing.Point(1341, 334);
            this.m_removeCatBtn.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.m_removeCatBtn.Name = "m_removeCatBtn";
            this.m_removeCatBtn.Size = new System.Drawing.Size(387, 155);
            this.m_removeCatBtn.TabIndex = 5;
            this.m_removeCatBtn.Text = "Löschen";
            this.m_removeCatBtn.UseVisualStyleBackColor = true;
            this.m_removeCatBtn.Click += new System.EventHandler(this.m_removeCatBtn_Click);
            // 
            // m_addCatBtn
            // 
            this.m_addCatBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_addCatBtn.Enabled = false;
            this.m_addCatBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_addCatBtn.Image = ((System.Drawing.Image)(resources.GetObject("m_addCatBtn.Image")));
            this.m_addCatBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_addCatBtn.Location = new System.Drawing.Point(1341, 160);
            this.m_addCatBtn.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.m_addCatBtn.Name = "m_addCatBtn";
            this.m_addCatBtn.Size = new System.Drawing.Size(387, 155);
            this.m_addCatBtn.TabIndex = 4;
            this.m_addCatBtn.Text = "Hinzufügen";
            this.m_addCatBtn.UseVisualStyleBackColor = true;
            this.m_addCatBtn.Click += new System.EventHandler(this.m_addCatBtn_Click);
            // 
            // m_catLv
            // 
            this.m_catLv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_catLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.m_catLv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_catLv.FullRowSelect = true;
            this.m_catLv.GridLines = true;
            this.m_catLv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_catLv.HideSelection = false;
            this.m_catLv.Location = new System.Drawing.Point(32, 267);
            this.m_catLv.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.m_catLv.Name = "m_catLv";
            this.m_catLv.ResizeColumns = true;
            this.m_catLv.ShowGroups = false;
            this.m_catLv.Size = new System.Drawing.Size(1279, 934);
            this.m_catLv.TabIndex = 3;
            this.m_catLv.UseCompatibleStateImageBehavior = false;
            this.m_catLv.View = System.Windows.Forms.View.Details;
            this.m_catLv.Click += new System.EventHandler(this.m_catLv_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Bezeichnung";
            this.columnHeader1.Width = 1274;
            // 
            // m_catInputTb
            // 
            this.m_catInputTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_catInputTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_catInputTb.Location = new System.Drawing.Point(32, 198);
            this.m_catInputTb.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.m_catInputTb.Name = "m_catInputTb";
            this.m_catInputTb.Size = new System.Drawing.Size(1279, 53);
            this.m_catInputTb.TabIndex = 2;
            this.m_catInputTb.Enter += new System.EventHandler(this.m_catInputTb_Enter);
            this.m_catInputTb.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_catInputTb_KeyUp);
            // 
            // ManufacturerManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1741, 1219);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_removeCatBtn);
            this.Controls.Add(this.m_addCatBtn);
            this.Controls.Add(this.m_catLv);
            this.Controls.Add(this.m_catInputTb);
            this.Margin = new System.Windows.Forms.Padding(21, 17, 21, 17);
            this.Name = "ManufacturerManageForm";
            this.Text = "Hersteller Verwaltung";
            this.Load += new System.EventHandler(this.ManufacturerManageForm_Load);
            this.Controls.SetChildIndex(this.titelBarCtrl1, 0);
            this.Controls.SetChildIndex(this.m_catInputTb, 0);
            this.Controls.SetChildIndex(this.m_catLv, 0);
            this.Controls.SetChildIndex(this.m_addCatBtn, 0);
            this.Controls.SetChildIndex(this.m_removeCatBtn, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button m_removeCatBtn;
        private System.Windows.Forms.Button m_addCatBtn;
        private DeVes.Bazaar.Client.CustControls.DvListView m_catLv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TextBox m_catInputTb;
    }
}