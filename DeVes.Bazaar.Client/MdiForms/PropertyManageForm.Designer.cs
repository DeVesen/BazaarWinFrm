namespace DeVes.Bazaar.Client.MdiForms
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
            this.bkGroupBox1 = new DeVes.Bazaar.Client.CustControls.BkGroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_httpComStremTb = new DeVes.Bazaar.Client.CustControls.DvTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.m_serverPortTb = new DeVes.Bazaar.Client.CustControls.DvTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_serverIpTb = new DeVes.Bazaar.Client.CustControls.DvTextBox();
            this.m_saveSettingsBtn = new System.Windows.Forms.Button();
            this.bkGroupBox2 = new DeVes.Bazaar.Client.CustControls.BkGroupBox();
            this.m_ipListLb = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_machineNameTb = new DeVes.Bazaar.Client.CustControls.DvTextBox();
            this.bkGroupBox1.SuspendLayout();
            this.bkGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // titelBarCtrl1
            // 
            this.titelBarCtrl1.Margin = new System.Windows.Forms.Padding(43, 33, 43, 33);
            this.titelBarCtrl1.Size = new System.Drawing.Size(2176, 141);
            this.titelBarCtrl1.TitelText = "Einstellungen";
            this.titelBarCtrl1.TitelImage = global::DeVes.Bazaar.Client.Properties.Resources.harddisk_network_32x32;
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
            this.bkGroupBox1.Location = new System.Drawing.Point(13, 451);
            this.bkGroupBox1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.bkGroupBox1.Name = "bkGroupBox1";
            this.bkGroupBox1.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.bkGroupBox1.Size = new System.Drawing.Size(1685, 427);
            this.bkGroupBox1.TabIndex = 2;
            this.bkGroupBox1.TabStop = false;
            this.bkGroupBox1.Text = "Verbindung zum Server:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(19, 167);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(340, 38);
            this.label3.TabIndex = 11;
            this.label3.Text = "Komunikationsstream:";
            // 
            // m_httpComStremTb
            // 
            this.m_httpComStremTb.AllowSpace = false;
            this.m_httpComStremTb.IsMargin = false;
            this.m_httpComStremTb.Location = new System.Drawing.Point(27, 212);
            this.m_httpComStremTb.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.m_httpComStremTb.Name = "m_httpComStremTb";
            this.m_httpComStremTb.ReadOnly = true;
            this.m_httpComStremTb.ResultType = DeVes.Bazaar.Client.CustControls.DvTextBox.ResultTypes.String;
            this.m_httpComStremTb.Size = new System.Drawing.Size(1055, 44);
            this.m_httpComStremTb.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::DeVes.Bazaar.Client.Properties.Resources.refresh_32x32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(565, 298);
            this.button1.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(523, 98);
            this.button1.TabIndex = 9;
            this.button1.Text = "Verbindungstest";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(557, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 38);
            this.label2.TabIndex = 3;
            this.label2.Text = "Server Port:";
            // 
            // m_serverPortTb
            // 
            this.m_serverPortTb.AllowSpace = false;
            this.m_serverPortTb.IsMargin = false;
            this.m_serverPortTb.Location = new System.Drawing.Point(565, 100);
            this.m_serverPortTb.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.m_serverPortTb.Name = "m_serverPortTb";
            this.m_serverPortTb.ResultType = DeVes.Bazaar.Client.CustControls.DvTextBox.ResultTypes.String;
            this.m_serverPortTb.Size = new System.Drawing.Size(516, 44);
            this.m_serverPortTb.TabIndex = 2;
            this.m_serverPortTb.TextChanged += new System.EventHandler(this.OnServerAdressCtrlsChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(19, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server Name / IP:";
            // 
            // m_serverIpTb
            // 
            this.m_serverIpTb.AllowSpace = false;
            this.m_serverIpTb.IsMargin = false;
            this.m_serverIpTb.Location = new System.Drawing.Point(27, 100);
            this.m_serverIpTb.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.m_serverIpTb.Name = "m_serverIpTb";
            this.m_serverIpTb.ResultType = DeVes.Bazaar.Client.CustControls.DvTextBox.ResultTypes.String;
            this.m_serverIpTb.Size = new System.Drawing.Size(516, 44);
            this.m_serverIpTb.TabIndex = 0;
            this.m_serverIpTb.TextChanged += new System.EventHandler(this.OnServerAdressCtrlsChanged);
            // 
            // m_saveSettingsBtn
            // 
            this.m_saveSettingsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_saveSettingsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_saveSettingsBtn.Image = global::DeVes.Bazaar.Client.Properties.Resources.disk_blue_32x32;
            this.m_saveSettingsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_saveSettingsBtn.Location = new System.Drawing.Point(1717, 155);
            this.m_saveSettingsBtn.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.m_saveSettingsBtn.Name = "m_saveSettingsBtn";
            this.m_saveSettingsBtn.Size = new System.Drawing.Size(443, 143);
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
            this.bkGroupBox2.Location = new System.Drawing.Point(13, 155);
            this.bkGroupBox2.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.bkGroupBox2.Name = "bkGroupBox2";
            this.bkGroupBox2.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.bkGroupBox2.Size = new System.Drawing.Size(1685, 286);
            this.bkGroupBox2.TabIndex = 9;
            this.bkGroupBox2.TabStop = false;
            this.bkGroupBox2.Text = "Verbindung zum Server:";
            // 
            // m_ipListLb
            // 
            this.m_ipListLb.FormattingEnabled = true;
            this.m_ipListLb.ItemHeight = 37;
            this.m_ipListLb.Location = new System.Drawing.Point(475, 100);
            this.m_ipListLb.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.m_ipListLb.Name = "m_ipListLb";
            this.m_ipListLb.Size = new System.Drawing.Size(553, 152);
            this.m_ipListLb.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(467, 55);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 38);
            this.label5.TabIndex = 3;
            this.label5.Text = "Server Port:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(19, 55);
            this.label6.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(276, 38);
            this.label6.TabIndex = 1;
            this.label6.Text = "Server Name / IP:";
            // 
            // m_machineNameTb
            // 
            this.m_machineNameTb.AllowSpace = false;
            this.m_machineNameTb.IsMargin = false;
            this.m_machineNameTb.Location = new System.Drawing.Point(27, 100);
            this.m_machineNameTb.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.m_machineNameTb.Name = "m_machineNameTb";
            this.m_machineNameTb.ReadOnly = true;
            this.m_machineNameTb.ResultType = DeVes.Bazaar.Client.CustControls.DvTextBox.ResultTypes.String;
            this.m_machineNameTb.Size = new System.Drawing.Size(396, 44);
            this.m_machineNameTb.TabIndex = 0;
            // 
            // PropertyManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2176, 1219);
            this.Controls.Add(this.bkGroupBox2);
            this.Controls.Add(this.m_saveSettingsBtn);
            this.Controls.Add(this.bkGroupBox1);
            this.Margin = new System.Windows.Forms.Padding(21, 17, 21, 17);
            this.Name = "PropertyManageForm";
            this.Text = "Einstellungen";
            this.Load += new System.EventHandler(this.PropertyManageForm_Load);
            this.Controls.SetChildIndex(this.bkGroupBox1, 0);
            this.Controls.SetChildIndex(this.titelBarCtrl1, 0);
            this.Controls.SetChildIndex(this.m_saveSettingsBtn, 0);
            this.Controls.SetChildIndex(this.bkGroupBox2, 0);
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
        private CustControls.DvTextBox m_httpComStremTb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private CustControls.DvTextBox m_serverPortTb;
        private System.Windows.Forms.Label label1;
        private CustControls.DvTextBox m_serverIpTb;
        private CustControls.BkGroupBox bkGroupBox2;
        private System.Windows.Forms.ListBox m_ipListLb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private CustControls.DvTextBox m_machineNameTb;

    }
}