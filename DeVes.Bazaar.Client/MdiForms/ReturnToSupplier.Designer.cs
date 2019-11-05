namespace DeVes.Bazaar.Client.MdiForms
{
    partial class ReturnToSupplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReturnToSupplier));
            this.m_supplierSelection = new DeVes.Bazaar.Client.CustControls.SupplierSelection();
            this.m_soldPosLv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_notSoldPosLv = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_confirmAbhulungBtn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.m_eigenGeld = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.m_qtySum = new System.Windows.Forms.Label();
            this.m_printNotSoldPositionsBtn = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // titelBarCtrl1
            // 
            this.titelBarCtrl1.Margin = new System.Windows.Forms.Padding(43, 33, 43, 33);
            this.titelBarCtrl1.Size = new System.Drawing.Size(2707, 141);
            this.titelBarCtrl1.TitelText = "Rückgabe";
            this.titelBarCtrl1.TitelImage = global::DeVes.Bazaar.Client.Properties.Resources.handshake_32x32;
            // 
            // m_supplierSelection
            // 
            this.m_supplierSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_supplierSelection.Location = new System.Drawing.Point(0, 141);
            this.m_supplierSelection.Margin = new System.Windows.Forms.Padding(21, 17, 21, 17);
            this.m_supplierSelection.Name = "m_supplierSelection";
            this.m_supplierSelection.Size = new System.Drawing.Size(2701, 434);
            this.m_supplierSelection.TabIndex = 1;
            this.m_supplierSelection.ViewSupplierAdd = false;
            this.m_supplierSelection.SupplierSet += new DeVes.Bazaar.Client.CustControls.SupplierSelection.OnSupplierSet(this.m_supplierSelection_SupplierSet);
            // 
            // m_soldPosLv
            // 
            this.m_soldPosLv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_soldPosLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader5,
            this.columnHeader7,
            this.columnHeader6,
            this.columnHeader8,
            this.columnHeader4});
            this.m_soldPosLv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_soldPosLv.FullRowSelect = true;
            this.m_soldPosLv.GridLines = true;
            this.m_soldPosLv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_soldPosLv.HideSelection = false;
            this.m_soldPosLv.Location = new System.Drawing.Point(16, 14);
            this.m_soldPosLv.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.m_soldPosLv.Name = "m_soldPosLv";
            this.m_soldPosLv.ShowGroups = false;
            this.m_soldPosLv.Size = new System.Drawing.Size(2161, 543);
            this.m_soldPosLv.TabIndex = 0;
            this.m_soldPosLv.UseCompatibleStateImageBehavior = false;
            this.m_soldPosLv.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Pos. Nr.";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Bezeichnung";
            this.columnHeader2.Width = 159;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Preis";
            this.columnHeader5.Width = 80;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Min. Preis";
            this.columnHeader7.Width = 80;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Verkauft für";
            this.columnHeader6.Width = 99;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Verkauft um";
            this.columnHeader8.Width = 101;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Rückgabe um";
            this.columnHeader4.Width = 170;
            // 
            // m_notSoldPosLv
            // 
            this.m_notSoldPosLv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_notSoldPosLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader3});
            this.m_notSoldPosLv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_notSoldPosLv.FullRowSelect = true;
            this.m_notSoldPosLv.GridLines = true;
            this.m_notSoldPosLv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_notSoldPosLv.HideSelection = false;
            this.m_notSoldPosLv.Location = new System.Drawing.Point(16, 14);
            this.m_notSoldPosLv.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.m_notSoldPosLv.Name = "m_notSoldPosLv";
            this.m_notSoldPosLv.ShowGroups = false;
            this.m_notSoldPosLv.Size = new System.Drawing.Size(2161, 610);
            this.m_notSoldPosLv.TabIndex = 0;
            this.m_notSoldPosLv.UseCompatibleStateImageBehavior = false;
            this.m_notSoldPosLv.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Pos. Nr.";
            this.columnHeader9.Width = 80;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Bezeichnung";
            this.columnHeader10.Width = 159;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Preis ";
            this.columnHeader13.Width = 80;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Min. Preis";
            this.columnHeader14.Width = 81;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Rückgabe um";
            this.columnHeader3.Width = 168;
            // 
            // m_confirmAbhulungBtn
            // 
            this.m_confirmAbhulungBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_confirmAbhulungBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_confirmAbhulungBtn.Image = global::DeVes.Bazaar.Client.Properties.Resources.handshake_32x32;
            this.m_confirmAbhulungBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_confirmAbhulungBtn.Location = new System.Drawing.Point(2240, 754);
            this.m_confirmAbhulungBtn.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.m_confirmAbhulungBtn.Name = "m_confirmAbhulungBtn";
            this.m_confirmAbhulungBtn.Size = new System.Drawing.Size(443, 143);
            this.m_confirmAbhulungBtn.TabIndex = 9;
            this.m_confirmAbhulungBtn.Text = "Zurückgeben";
            this.m_confirmAbhulungBtn.UseVisualStyleBackColor = true;
            this.m_confirmAbhulungBtn.Click += new System.EventHandler(this.m_confirmAbhulungBtn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 589);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(2221, 656);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_soldPosLv);
            this.tabPage1.Location = new System.Drawing.Point(10, 63);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tabPage1.Size = new System.Drawing.Size(2201, 583);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Verkaufte Positionen";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_notSoldPosLv);
            this.tabPage2.Location = new System.Drawing.Point(10, 63);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tabPage2.Size = new System.Drawing.Size(2201, 583);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Nicht verkaufte Positionen";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1189, 1307);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(91, 86);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 27;
            this.pictureBox2.TabStop = false;
            // 
            // m_eigenGeld
            // 
            this.m_eigenGeld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_eigenGeld.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_eigenGeld.Location = new System.Drawing.Point(1296, 1307);
            this.m_eigenGeld.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.m_eigenGeld.Name = "m_eigenGeld";
            this.m_eigenGeld.Size = new System.Drawing.Size(347, 86);
            this.m_eigenGeld.TabIndex = 26;
            this.m_eigenGeld.Text = "0,00";
            this.m_eigenGeld.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1672, 1252);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 141);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // m_qtySum
            // 
            this.m_qtySum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_qtySum.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_qtySum.Location = new System.Drawing.Point(1872, 1252);
            this.m_qtySum.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.m_qtySum.Name = "m_qtySum";
            this.m_qtySum.Size = new System.Drawing.Size(347, 141);
            this.m_qtySum.TabIndex = 24;
            this.m_qtySum.Text = "0,00";
            this.m_qtySum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_printNotSoldPositionsBtn
            // 
            this.m_printNotSoldPositionsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_printNotSoldPositionsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_printNotSoldPositionsBtn.Image = global::DeVes.Bazaar.Client.Properties.Resources.printer2_32x32;
            this.m_printNotSoldPositionsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_printNotSoldPositionsBtn.Location = new System.Drawing.Point(2240, 591);
            this.m_printNotSoldPositionsBtn.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.m_printNotSoldPositionsBtn.Name = "m_printNotSoldPositionsBtn";
            this.m_printNotSoldPositionsBtn.Size = new System.Drawing.Size(443, 143);
            this.m_printNotSoldPositionsBtn.TabIndex = 28;
            this.m_printNotSoldPositionsBtn.Text = "Nicht verkaufte drucken";
            this.m_printNotSoldPositionsBtn.UseVisualStyleBackColor = true;
            this.m_printNotSoldPositionsBtn.Click += new System.EventHandler(this.m_printNotSoldPositionsBtn_Click);
            // 
            // ReturnToSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2707, 1402);
            this.Controls.Add(this.m_printNotSoldPositionsBtn);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.m_eigenGeld);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.m_qtySum);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.m_confirmAbhulungBtn);
            this.Controls.Add(this.m_supplierSelection);
            this.Margin = new System.Windows.Forms.Padding(21, 17, 21, 17);
            this.Name = "ReturnToSupplier";
            this.Text = "Rückgabe";
            this.Load += new System.EventHandler(this.ReturnToSupplier_Load);
            this.Controls.SetChildIndex(this.titelBarCtrl1, 0);
            this.Controls.SetChildIndex(this.m_supplierSelection, 0);
            this.Controls.SetChildIndex(this.m_confirmAbhulungBtn, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.m_qtySum, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.m_eigenGeld, 0);
            this.Controls.SetChildIndex(this.pictureBox2, 0);
            this.Controls.SetChildIndex(this.m_printNotSoldPositionsBtn, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustControls.SupplierSelection m_supplierSelection;
        private System.Windows.Forms.ListView m_soldPosLv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ListView m_notSoldPosLv;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.Button m_confirmAbhulungBtn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label m_eigenGeld;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label m_qtySum;
        private System.Windows.Forms.Button m_printNotSoldPositionsBtn;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;

    }
}