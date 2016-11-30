namespace DeVes.Bazaar.Client.SubForms
{
    partial class NewSellerform
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
            this.m_takeBtn = new System.Windows.Forms.Button();
            this.m_cancelBtn = new System.Windows.Forms.Button();
            this.m_sellerDescRtb = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_sellerPhoneTb = new DeVes.Bazaar.Client.CustControls.DVTextBox();
            this.m_sellerTownTb = new DeVes.Bazaar.Client.CustControls.DVTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_sellerZipTb = new DeVes.Bazaar.Client.CustControls.DVTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_sellerStreetTb = new DeVes.Bazaar.Client.CustControls.DVTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_sellerVNameTb = new DeVes.Bazaar.Client.CustControls.DVTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_sellerNameTb = new DeVes.Bazaar.Client.CustControls.DVTextBox();
            this.m_sellerTitelCb = new DeVes.Bazaar.Client.CustControls.DVComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_takeBtn
            // 
            this.m_takeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_takeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_takeBtn.Image = global::DeVes.Bazaar.Client.Properties.Resources.id_card_add_32x32;
            this.m_takeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_takeBtn.Location = new System.Drawing.Point(232, 325);
            this.m_takeBtn.Margin = new System.Windows.Forms.Padding(4);
            this.m_takeBtn.Name = "m_takeBtn";
            this.m_takeBtn.Size = new System.Drawing.Size(145, 65);
            this.m_takeBtn.TabIndex = 34;
            this.m_takeBtn.Text = "Übernehmen";
            this.m_takeBtn.UseVisualStyleBackColor = true;
            this.m_takeBtn.Click += new System.EventHandler(this.m_takeBtn_Click);
            // 
            // m_cancelBtn
            // 
            this.m_cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cancelBtn.Image = global::DeVes.Bazaar.Client.Properties.Resources.delete2_32x32;
            this.m_cancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cancelBtn.Location = new System.Drawing.Point(385, 325);
            this.m_cancelBtn.Margin = new System.Windows.Forms.Padding(4);
            this.m_cancelBtn.Name = "m_cancelBtn";
            this.m_cancelBtn.Size = new System.Drawing.Size(145, 65);
            this.m_cancelBtn.TabIndex = 33;
            this.m_cancelBtn.Text = "Abbruch";
            this.m_cancelBtn.UseVisualStyleBackColor = true;
            this.m_cancelBtn.Click += new System.EventHandler(this.m_cancelBtn_Click);
            // 
            // m_sellerDescRtb
            // 
            this.m_sellerDescRtb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_sellerDescRtb.Location = new System.Drawing.Point(98, 219);
            this.m_sellerDescRtb.Name = "m_sellerDescRtb";
            this.m_sellerDescRtb.Size = new System.Drawing.Size(432, 97);
            this.m_sellerDescRtb.TabIndex = 32;
            this.m_sellerDescRtb.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(12, 219);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Bemerkung:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(12, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Telefon:";
            // 
            // m_sellerPhoneTb
            // 
            this.m_sellerPhoneTb.AllowSpace = false;
            this.m_sellerPhoneTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_sellerPhoneTb.BackColor = System.Drawing.Color.PapayaWhip;
            this.m_sellerPhoneTb.IsMargin = true;
            this.m_sellerPhoneTb.Location = new System.Drawing.Point(98, 171);
            this.m_sellerPhoneTb.Name = "m_sellerPhoneTb";
            this.m_sellerPhoneTb.ResultType = DeVes.Bazaar.Client.CustControls.DVTextBox.ResultTypes.String;
            this.m_sellerPhoneTb.Size = new System.Drawing.Size(432, 20);
            this.m_sellerPhoneTb.TabIndex = 29;
            // 
            // m_sellerTownTb
            // 
            this.m_sellerTownTb.AllowSpace = false;
            this.m_sellerTownTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_sellerTownTb.BackColor = System.Drawing.Color.PapayaWhip;
            this.m_sellerTownTb.IsMargin = true;
            this.m_sellerTownTb.Location = new System.Drawing.Point(153, 125);
            this.m_sellerTownTb.Name = "m_sellerTownTb";
            this.m_sellerTownTb.ResultType = DeVes.Bazaar.Client.CustControls.DVTextBox.ResultTypes.String;
            this.m_sellerTownTb.Size = new System.Drawing.Size(377, 20);
            this.m_sellerTownTb.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(12, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "PLZ / Ort:";
            // 
            // m_sellerZipTb
            // 
            this.m_sellerZipTb.AllowSpace = false;
            this.m_sellerZipTb.IsMargin = false;
            this.m_sellerZipTb.Location = new System.Drawing.Point(98, 125);
            this.m_sellerZipTb.Name = "m_sellerZipTb";
            this.m_sellerZipTb.ResultType = DeVes.Bazaar.Client.CustControls.DVTextBox.ResultTypes.String;
            this.m_sellerZipTb.Size = new System.Drawing.Size(49, 20);
            this.m_sellerZipTb.TabIndex = 26;
            this.m_sellerZipTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(12, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Strasse:";
            // 
            // m_sellerStreetTb
            // 
            this.m_sellerStreetTb.AllowSpace = false;
            this.m_sellerStreetTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_sellerStreetTb.IsMargin = false;
            this.m_sellerStreetTb.Location = new System.Drawing.Point(98, 96);
            this.m_sellerStreetTb.Name = "m_sellerStreetTb";
            this.m_sellerStreetTb.ResultType = DeVes.Bazaar.Client.CustControls.DVTextBox.ResultTypes.String;
            this.m_sellerStreetTb.Size = new System.Drawing.Size(432, 20);
            this.m_sellerStreetTb.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Vorname:";
            // 
            // m_sellerVNameTb
            // 
            this.m_sellerVNameTb.AllowSpace = false;
            this.m_sellerVNameTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_sellerVNameTb.IsMargin = false;
            this.m_sellerVNameTb.Location = new System.Drawing.Point(98, 67);
            this.m_sellerVNameTb.Name = "m_sellerVNameTb";
            this.m_sellerVNameTb.ResultType = DeVes.Bazaar.Client.CustControls.DVTextBox.ResultTypes.String;
            this.m_sellerVNameTb.Size = new System.Drawing.Size(432, 20);
            this.m_sellerVNameTb.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Name:";
            // 
            // m_sellerNameTb
            // 
            this.m_sellerNameTb.AllowSpace = false;
            this.m_sellerNameTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_sellerNameTb.BackColor = System.Drawing.Color.PapayaWhip;
            this.m_sellerNameTb.IsMargin = true;
            this.m_sellerNameTb.Location = new System.Drawing.Point(98, 38);
            this.m_sellerNameTb.Name = "m_sellerNameTb";
            this.m_sellerNameTb.ResultType = DeVes.Bazaar.Client.CustControls.DVTextBox.ResultTypes.String;
            this.m_sellerNameTb.Size = new System.Drawing.Size(432, 20);
            this.m_sellerNameTb.TabIndex = 20;
            // 
            // m_sellerTitelCb
            // 
            this.m_sellerTitelCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_sellerTitelCb.FormattingEnabled = true;
            this.m_sellerTitelCb.IsMargin = false;
            this.m_sellerTitelCb.Items.AddRange(new object[] {
            "Herr",
            "Frau",
            "Firma"});
            this.m_sellerTitelCb.Location = new System.Drawing.Point(97, 11);
            this.m_sellerTitelCb.Name = "m_sellerTitelCb";
            this.m_sellerTitelCb.Size = new System.Drawing.Size(92, 21);
            this.m_sellerTitelCb.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Anrede:";
            // 
            // NewSellerform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 401);
            this.Controls.Add(this.m_takeBtn);
            this.Controls.Add(this.m_cancelBtn);
            this.Controls.Add(this.m_sellerDescRtb);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_sellerPhoneTb);
            this.Controls.Add(this.m_sellerTownTb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_sellerZipTb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_sellerStreetTb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_sellerVNameTb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_sellerNameTb);
            this.Controls.Add(this.m_sellerTitelCb);
            this.Controls.Add(this.label1);
            this.Name = "NewSellerform";
            this.Text = "Neuer Verkäufer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_takeBtn;
        private System.Windows.Forms.Button m_cancelBtn;
        private System.Windows.Forms.RichTextBox m_sellerDescRtb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private DeVes.Bazaar.Client.CustControls.DVTextBox m_sellerPhoneTb;
        private DeVes.Bazaar.Client.CustControls.DVTextBox m_sellerTownTb;
        private System.Windows.Forms.Label label5;
        private DeVes.Bazaar.Client.CustControls.DVTextBox m_sellerZipTb;
        private System.Windows.Forms.Label label4;
        private DeVes.Bazaar.Client.CustControls.DVTextBox m_sellerStreetTb;
        private System.Windows.Forms.Label label3;
        private DeVes.Bazaar.Client.CustControls.DVTextBox m_sellerVNameTb;
        private System.Windows.Forms.Label label2;
        private DeVes.Bazaar.Client.CustControls.DVTextBox m_sellerNameTb;
        private DeVes.Bazaar.Client.CustControls.DVComboBox m_sellerTitelCb;
        private System.Windows.Forms.Label label1;
    }
}