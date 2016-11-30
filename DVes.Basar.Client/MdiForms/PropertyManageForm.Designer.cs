namespace DVes.Basar.Client.MdiForms
{
    partial class PropertyManageForm
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
            this.bkGroupBox1 = new DVes.Basar.Client.CustControls.BkGroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_httpComStremTb = new DVes.Basar.Client.CustControls.DVTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.m_serverPortTb = new DVes.Basar.Client.CustControls.DVTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_serverIpTb = new DVes.Basar.Client.CustControls.DVTextBox();
            this.m_saveSettingsBtn = new System.Windows.Forms.Button();
            this.bkGroupBox2 = new DVes.Basar.Client.CustControls.BkGroupBox();
            this.m_ipListLb = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_machineNameTb = new DVes.Basar.Client.CustControls.DVTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_frmPb)).BeginInit();
            this.bkGroupBox1.SuspendLayout();
            this.bkGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // titelBarCtrl1
            // 
            this.titelBarCtrl1.Size = new System.Drawing.Size(816, 59);
            this.titelBarCtrl1.TitelText = "Einstellungen";
            // 
            // m_frmPb
            // 
            this.m_frmPb.Image = global::DVes.Basar.Client.Properties.Resources.harddisk_network_32x32;
            // 
            // bkGroupBox1
            // 
            this.bkGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bkGroupBox1.Controls.Add(this.label3);
            this.bkGroupBox1.Controls.Add(this.m_httpComStremTb);
            this.bkGroupBox1.Controls.Add(this.button1);
            this.bkGroupBox1.Controls.Add(this.label2);
            this.bkGroupBox1.Controls.Add(this.m_serverPortTb);
            this.bkGroupBox1.Controls.Add(this.label1);
            this.bkGroupBox1.Controls.Add(this.m_serverIpTb);
            this.bkGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bkGroupBox1.Location = new System.Drawing.Point(5, 189);
            this.bkGroupBox1.Name = "bkGroupBox1";
            this.bkGroupBox1.Size = new System.Drawing.Size(632, 179);
            this.bkGroupBox1.TabIndex = 2;
            this.bkGroupBox1.TabStop = false;
            this.bkGroupBox1.Text = "Verbindung zum Server:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(7, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Komunikationsstream:";
            // 
            // m_httpComStremTb
            // 
            this.m_httpComStremTb.AllowSpace = false;
            this.m_httpComStremTb.IsMargin = false;
            this.m_httpComStremTb.Location = new System.Drawing.Point(10, 89);
            this.m_httpComStremTb.Name = "m_httpComStremTb";
            this.m_httpComStremTb.ReadOnly = true;
            this.m_httpComStremTb.ResultType = DVes.Basar.Client.CustControls.DVTextBox.ResultTypes.String;
            this.m_httpComStremTb.Size = new System.Drawing.Size(398, 22);
            this.m_httpComStremTb.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::DVes.Basar.Client.Properties.Resources.refresh_32x32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(212, 125);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(196, 41);
            this.button1.TabIndex = 9;
            this.button1.Text = "Verbindungstest";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(209, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Server Port:";
            // 
            // m_serverPortTb
            // 
            this.m_serverPortTb.AllowSpace = false;
            this.m_serverPortTb.IsMargin = false;
            this.m_serverPortTb.Location = new System.Drawing.Point(212, 42);
            this.m_serverPortTb.Name = "m_serverPortTb";
            this.m_serverPortTb.ResultType = DVes.Basar.Client.CustControls.DVTextBox.ResultTypes.String;
            this.m_serverPortTb.Size = new System.Drawing.Size(196, 22);
            this.m_serverPortTb.TabIndex = 2;
            this.m_serverPortTb.TextChanged += new System.EventHandler(this.OnServerAdressCtrlsChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server Name / IP:";
            // 
            // m_serverIpTb
            // 
            this.m_serverIpTb.AllowSpace = false;
            this.m_serverIpTb.IsMargin = false;
            this.m_serverIpTb.Location = new System.Drawing.Point(10, 42);
            this.m_serverIpTb.Name = "m_serverIpTb";
            this.m_serverIpTb.ResultType = DVes.Basar.Client.CustControls.DVTextBox.ResultTypes.String;
            this.m_serverIpTb.Size = new System.Drawing.Size(196, 22);
            this.m_serverIpTb.TabIndex = 0;
            this.m_serverIpTb.TextChanged += new System.EventHandler(this.OnServerAdressCtrlsChanged);
            // 
            // m_saveSettingsBtn
            // 
            this.m_saveSettingsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_saveSettingsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_saveSettingsBtn.Image = global::DVes.Basar.Client.Properties.Resources.disk_blue_32x32;
            this.m_saveSettingsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_saveSettingsBtn.Location = new System.Drawing.Point(644, 65);
            this.m_saveSettingsBtn.Margin = new System.Windows.Forms.Padding(4);
            this.m_saveSettingsBtn.Name = "m_saveSettingsBtn";
            this.m_saveSettingsBtn.Size = new System.Drawing.Size(166, 60);
            this.m_saveSettingsBtn.TabIndex = 8;
            this.m_saveSettingsBtn.Text = "Speichern";
            this.m_saveSettingsBtn.UseVisualStyleBackColor = true;
            this.m_saveSettingsBtn.Click += new System.EventHandler(this.m_saveSettingsBtn_Click);
            // 
            // bkGroupBox2
            // 
            this.bkGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bkGroupBox2.Controls.Add(this.m_ipListLb);
            this.bkGroupBox2.Controls.Add(this.label5);
            this.bkGroupBox2.Controls.Add(this.label6);
            this.bkGroupBox2.Controls.Add(this.m_machineNameTb);
            this.bkGroupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bkGroupBox2.Location = new System.Drawing.Point(5, 65);
            this.bkGroupBox2.Name = "bkGroupBox2";
            this.bkGroupBox2.Size = new System.Drawing.Size(632, 120);
            this.bkGroupBox2.TabIndex = 9;
            this.bkGroupBox2.TabStop = false;
            this.bkGroupBox2.Text = "Verbindung zum Server:";
            // 
            // m_ipListLb
            // 
            this.m_ipListLb.FormattingEnabled = true;
            this.m_ipListLb.ItemHeight = 16;
            this.m_ipListLb.Location = new System.Drawing.Point(178, 42);
            this.m_ipListLb.Name = "m_ipListLb";
            this.m_ipListLb.Size = new System.Drawing.Size(210, 68);
            this.m_ipListLb.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(175, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Server Port:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(7, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Server Name / IP:";
            // 
            // m_machineNameTb
            // 
            this.m_machineNameTb.AllowSpace = false;
            this.m_machineNameTb.IsMargin = false;
            this.m_machineNameTb.Location = new System.Drawing.Point(10, 42);
            this.m_machineNameTb.Name = "m_machineNameTb";
            this.m_machineNameTb.ReadOnly = true;
            this.m_machineNameTb.ResultType = DVes.Basar.Client.CustControls.DVTextBox.ResultTypes.String;
            this.m_machineNameTb.Size = new System.Drawing.Size(151, 22);
            this.m_machineNameTb.TabIndex = 0;
            // 
            // PropertyManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 511);
            this.Controls.Add(this.bkGroupBox2);
            this.Controls.Add(this.m_saveSettingsBtn);
            this.Controls.Add(this.bkGroupBox1);
            this.Name = "PropertyManageForm";
            this.Text = "Einstellungen";
            this.Load += new System.EventHandler(this.PropertyManageForm_Load);
            this.Controls.SetChildIndex(this.bkGroupBox1, 0);
            this.Controls.SetChildIndex(this.titelBarCtrl1, 0);
            this.Controls.SetChildIndex(this.m_frmPb, 0);
            this.Controls.SetChildIndex(this.m_saveSettingsBtn, 0);
            this.Controls.SetChildIndex(this.bkGroupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.m_frmPb)).EndInit();
            this.bkGroupBox1.ResumeLayout(false);
            this.bkGroupBox1.PerformLayout();
            this.bkGroupBox2.ResumeLayout(false);
            this.bkGroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustControls.BkGroupBox bkGroupBox1;
        private System.Windows.Forms.Button m_saveSettingsBtn;
        private System.Windows.Forms.Label label3;
        private CustControls.DVTextBox m_httpComStremTb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private CustControls.DVTextBox m_serverPortTb;
        private System.Windows.Forms.Label label1;
        private CustControls.DVTextBox m_serverIpTb;
        private CustControls.BkGroupBox bkGroupBox2;
        private System.Windows.Forms.ListBox m_ipListLb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private CustControls.DVTextBox m_machineNameTb;

    }
}