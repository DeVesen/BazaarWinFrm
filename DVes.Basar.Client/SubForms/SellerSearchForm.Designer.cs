namespace DVes.Basar.Client.SubForms
{
    partial class SellerSearchForm
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
            this.components = new System.ComponentModel.Container();
            this.m_sellerInputTimer = new System.Windows.Forms.Timer(this.components);
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_takeBtn = new System.Windows.Forms.Button();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_searchValTb = new System.Windows.Forms.TextBox();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_filterResListView = new System.Windows.Forms.ListView();
            this.No = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.m_cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_sellerInputTimer
            // 
            this.m_sellerInputTimer.Interval = 750;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Ort";
            this.columnHeader5.Width = 98;
            // 
            // m_takeBtn
            // 
            this.m_takeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_takeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_takeBtn.Image = global::DVes.Basar.Client.Properties.Resources.id_card_preferences_32x32;
            this.m_takeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_takeBtn.Location = new System.Drawing.Point(202, 305);
            this.m_takeBtn.Margin = new System.Windows.Forms.Padding(4);
            this.m_takeBtn.Name = "m_takeBtn";
            this.m_takeBtn.Size = new System.Drawing.Size(145, 65);
            this.m_takeBtn.TabIndex = 12;
            this.m_takeBtn.Text = "Übernehmen";
            this.m_takeBtn.UseVisualStyleBackColor = true;
            this.m_takeBtn.Click += new System.EventHandler(this.m_takeBtn_Click);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "PLZ";
            // 
            // m_searchValTb
            // 
            this.m_searchValTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_searchValTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_searchValTb.Location = new System.Drawing.Point(11, 32);
            this.m_searchValTb.Name = "m_searchValTb";
            this.m_searchValTb.Size = new System.Drawing.Size(489, 22);
            this.m_searchValTb.TabIndex = 8;
            this.m_searchValTb.TextChanged += new System.EventHandler(this.m_searchValTb_TextChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Strasse";
            this.columnHeader3.Width = 98;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 150;
            // 
            // m_filterResListView
            // 
            this.m_filterResListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_filterResListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.No,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.m_filterResListView.FullRowSelect = true;
            this.m_filterResListView.GridLines = true;
            this.m_filterResListView.Location = new System.Drawing.Point(11, 70);
            this.m_filterResListView.MultiSelect = false;
            this.m_filterResListView.Name = "m_filterResListView";
            this.m_filterResListView.ShowGroups = false;
            this.m_filterResListView.Size = new System.Drawing.Size(489, 228);
            this.m_filterResListView.TabIndex = 13;
            this.m_filterResListView.UseCompatibleStateImageBehavior = false;
            this.m_filterResListView.View = System.Windows.Forms.View.Details;
            this.m_filterResListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.m_filterResListView_ItemSelectionChanged);
            this.m_filterResListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.m_filterResListView_MouseDoubleClick);
            // 
            // No
            // 
            this.No.Text = "Nummer";
            this.No.Width = 75;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Anrede";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Suchwert:";
            // 
            // m_cancelBtn
            // 
            this.m_cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cancelBtn.Image = global::DVes.Basar.Client.Properties.Resources.delete2_32x32;
            this.m_cancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cancelBtn.Location = new System.Drawing.Point(355, 305);
            this.m_cancelBtn.Margin = new System.Windows.Forms.Padding(4);
            this.m_cancelBtn.Name = "m_cancelBtn";
            this.m_cancelBtn.Size = new System.Drawing.Size(145, 65);
            this.m_cancelBtn.TabIndex = 11;
            this.m_cancelBtn.Text = "Abbruch";
            this.m_cancelBtn.UseVisualStyleBackColor = true;
            this.m_cancelBtn.Click += new System.EventHandler(this.m_cancelBtn_Click);
            // 
            // SellerSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 381);
            this.Controls.Add(this.m_takeBtn);
            this.Controls.Add(this.m_cancelBtn);
            this.Controls.Add(this.m_searchValTb);
            this.Controls.Add(this.m_filterResListView);
            this.Controls.Add(this.label1);
            this.Name = "SellerSearchForm";
            this.Text = "Verkäufersuche";
            this.Load += new System.EventHandler(this.SellerSearchForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer m_sellerInputTimer;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button m_takeBtn;
        private System.Windows.Forms.Button m_cancelBtn;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox m_searchValTb;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView m_filterResListView;
        private System.Windows.Forms.ColumnHeader No;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label1;
    }
}