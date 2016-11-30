namespace DVes.Basar.Server
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.m_notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.m_startUpTimer = new System.Windows.Forms.Timer(this.components);
            this.bkGroupBox4 = new DVes.Basar.Server.CustControls.BkGroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.bkGroupBox3 = new DVes.Basar.Server.CustControls.BkGroupBox();
            this.m_licenseTb = new DVes.Basar.Server.CustControls.DVTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.m_lizPb = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.m_pcCodeTb = new DVes.Basar.Server.CustControls.DVTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.bkGroupBox1 = new DVes.Basar.Server.CustControls.BkGroupBox();
            this.m_conStatePb = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.m_ownPort = new DVes.Basar.Server.CustControls.DVTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.m_ipListLb = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.m_machineNameTb = new DVes.Basar.Server.CustControls.DVTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.bkGroupBox2 = new DVes.Basar.Server.CustControls.BkGroupBox();
            this.m_lieferGewinnTb = new DVes.Basar.Server.CustControls.DVTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.m_eigenBetragTb = new DVes.Basar.Server.CustControls.DVTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.m_einnahmenTb = new DVes.Basar.Server.CustControls.DVTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_returnPosCountTb = new DVes.Basar.Server.CustControls.DVTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_soldPosCountTb = new DVes.Basar.Server.CustControls.DVTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_notSoldPosCountTb = new DVes.Basar.Server.CustControls.DVTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_numSuplTb = new DVes.Basar.Server.CustControls.DVTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_paramsGb = new DVes.Basar.Server.CustControls.BkGroupBox();
            this.m_printPrevCb = new System.Windows.Forms.CheckBox();
            this.m_saveBtn = new System.Windows.Forms.Button();
            this.m_infoMsgPosPrintTb = new DVes.Basar.Server.CustControls.DVTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_prozGewinTb = new DVes.Basar.Server.CustControls.DVTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.titelBarCtrl1 = new DVes.Basar.Server.CustControls.TitelBarCtrl();
            this.button5 = new System.Windows.Forms.Button();
            this.bkGroupBox4.SuspendLayout();
            this.bkGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_lizPb)).BeginInit();
            this.bkGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_conStatePb)).BeginInit();
            this.bkGroupBox2.SuspendLayout();
            this.m_paramsGb.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_notifyIcon
            // 
            this.m_notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.m_notifyIcon.BalloonTipTitle = "Dves Basar Server";
            this.m_notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("m_notifyIcon.Icon")));
            this.m_notifyIcon.Text = "Dves Basar Server";
            this.m_notifyIcon.Visible = true;
            this.m_notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.m_notifyIcon_MouseDoubleClick);
            // 
            // m_startUpTimer
            // 
            this.m_startUpTimer.Tick += new System.EventHandler(this.m_startUpTimer_Tick);
            // 
            // bkGroupBox4
            // 
            this.bkGroupBox4.Controls.Add(this.button5);
            this.bkGroupBox4.Controls.Add(this.button4);
            this.bkGroupBox4.Controls.Add(this.button3);
            this.bkGroupBox4.Location = new System.Drawing.Point(820, 73);
            this.bkGroupBox4.Name = "bkGroupBox4";
            this.bkGroupBox4.Size = new System.Drawing.Size(139, 522);
            this.bkGroupBox4.TabIndex = 5;
            this.bkGroupBox4.TabStop = false;
            this.bkGroupBox4.Text = "Datenbereinigung:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(15, 74);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(108, 45);
            this.button4.TabIndex = 19;
            this.button4.Text = "Rückgabe löschen";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(15, 23);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 45);
            this.button3.TabIndex = 18;
            this.button3.Text = "Verkauf löschen";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // bkGroupBox3
            // 
            this.bkGroupBox3.Controls.Add(this.m_licenseTb);
            this.bkGroupBox3.Controls.Add(this.label13);
            this.bkGroupBox3.Controls.Add(this.m_lizPb);
            this.bkGroupBox3.Controls.Add(this.button2);
            this.bkGroupBox3.Controls.Add(this.m_pcCodeTb);
            this.bkGroupBox3.Controls.Add(this.label15);
            this.bkGroupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.bkGroupBox3.Location = new System.Drawing.Point(3, 194);
            this.bkGroupBox3.Name = "bkGroupBox3";
            this.bkGroupBox3.Size = new System.Drawing.Size(811, 123);
            this.bkGroupBox3.TabIndex = 4;
            this.bkGroupBox3.TabStop = false;
            this.bkGroupBox3.Text = "Eigene Lizens:";
            // 
            // m_licenseTb
            // 
            this.m_licenseTb.AllowSpace = false;
            this.m_licenseTb.IsMargin = false;
            this.m_licenseTb.Location = new System.Drawing.Point(190, 46);
            this.m_licenseTb.Multiline = true;
            this.m_licenseTb.Name = "m_licenseTb";
            this.m_licenseTb.ResultType = DVes.Basar.Server.CustControls.DVTextBox.ResultTypes.String;
            this.m_licenseTb.Size = new System.Drawing.Size(210, 63);
            this.m_licenseTb.TabIndex = 12;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(187, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 16);
            this.label13.TabIndex = 11;
            this.label13.Text = "Lizens:";
            // 
            // m_lizPb
            // 
            this.m_lizPb.BackColor = System.Drawing.Color.Transparent;
            this.m_lizPb.Image = global::DVes.Basar.Server.Properties.Resources.delete2_32x32;
            this.m_lizPb.Location = new System.Drawing.Point(647, 21);
            this.m_lizPb.Name = "m_lizPb";
            this.m_lizPb.Size = new System.Drawing.Size(151, 46);
            this.m_lizPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_lizPb.TabIndex = 10;
            this.m_lizPb.TabStop = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::DVes.Basar.Server.Properties.Resources.disk_blue_32x32;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(647, 73);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 36);
            this.button2.TabIndex = 8;
            this.button2.Text = "Speichern";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // m_pcCodeTb
            // 
            this.m_pcCodeTb.AllowSpace = false;
            this.m_pcCodeTb.IsMargin = false;
            this.m_pcCodeTb.Location = new System.Drawing.Point(12, 46);
            this.m_pcCodeTb.Name = "m_pcCodeTb";
            this.m_pcCodeTb.ReadOnly = true;
            this.m_pcCodeTb.ResultType = DVes.Basar.Server.CustControls.DVTextBox.ResultTypes.String;
            this.m_pcCodeTb.Size = new System.Drawing.Size(151, 22);
            this.m_pcCodeTb.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(9, 27);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 16);
            this.label15.TabIndex = 2;
            this.label15.Text = "PC - Code:";
            // 
            // bkGroupBox1
            // 
            this.bkGroupBox1.Controls.Add(this.m_conStatePb);
            this.bkGroupBox1.Controls.Add(this.button1);
            this.bkGroupBox1.Controls.Add(this.m_ownPort);
            this.bkGroupBox1.Controls.Add(this.label12);
            this.bkGroupBox1.Controls.Add(this.m_ipListLb);
            this.bkGroupBox1.Controls.Add(this.label11);
            this.bkGroupBox1.Controls.Add(this.m_machineNameTb);
            this.bkGroupBox1.Controls.Add(this.label10);
            this.bkGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.bkGroupBox1.Location = new System.Drawing.Point(3, 69);
            this.bkGroupBox1.Name = "bkGroupBox1";
            this.bkGroupBox1.Size = new System.Drawing.Size(811, 123);
            this.bkGroupBox1.TabIndex = 3;
            this.bkGroupBox1.TabStop = false;
            this.bkGroupBox1.Text = "Eigene IP Daten:";
            // 
            // m_conStatePb
            // 
            this.m_conStatePb.BackColor = System.Drawing.Color.Transparent;
            this.m_conStatePb.Image = global::DVes.Basar.Server.Properties.Resources.delete2_16x16;
            this.m_conStatePb.Location = new System.Drawing.Point(777, 27);
            this.m_conStatePb.Name = "m_conStatePb";
            this.m_conStatePb.Size = new System.Drawing.Size(16, 16);
            this.m_conStatePb.TabIndex = 9;
            this.m_conStatePb.TabStop = false;
            this.m_conStatePb.Click += new System.EventHandler(this.m_conStatePb_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::DVes.Basar.Server.Properties.Resources.disk_blue_32x32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(647, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 36);
            this.button1.TabIndex = 8;
            this.button1.Text = "Speichern";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // m_ownPort
            // 
            this.m_ownPort.AllowSpace = false;
            this.m_ownPort.IsMargin = false;
            this.m_ownPort.Location = new System.Drawing.Point(647, 46);
            this.m_ownPort.Name = "m_ownPort";
            this.m_ownPort.ResultType = DVes.Basar.Server.CustControls.DVTextBox.ResultTypes.Int32;
            this.m_ownPort.Size = new System.Drawing.Size(151, 22);
            this.m_ownPort.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(644, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 16);
            this.label12.TabIndex = 6;
            this.label12.Text = "Eigener Port:";
            // 
            // m_ipListLb
            // 
            this.m_ipListLb.FormattingEnabled = true;
            this.m_ipListLb.ItemHeight = 16;
            this.m_ipListLb.Location = new System.Drawing.Point(190, 46);
            this.m_ipListLb.Name = "m_ipListLb";
            this.m_ipListLb.Size = new System.Drawing.Size(210, 68);
            this.m_ipListLb.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(187, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(128, 16);
            this.label11.TabIndex = 4;
            this.label11.Text = "Lokale IP Adressen:";
            // 
            // m_machineNameTb
            // 
            this.m_machineNameTb.AllowSpace = false;
            this.m_machineNameTb.IsMargin = false;
            this.m_machineNameTb.Location = new System.Drawing.Point(12, 46);
            this.m_machineNameTb.Name = "m_machineNameTb";
            this.m_machineNameTb.ReadOnly = true;
            this.m_machineNameTb.ResultType = DVes.Basar.Server.CustControls.DVTextBox.ResultTypes.String;
            this.m_machineNameTb.Size = new System.Drawing.Size(151, 22);
            this.m_machineNameTb.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(9, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 16);
            this.label10.TabIndex = 2;
            this.label10.Text = "PC - Name:";
            // 
            // bkGroupBox2
            // 
            this.bkGroupBox2.Controls.Add(this.m_lieferGewinnTb);
            this.bkGroupBox2.Controls.Add(this.label9);
            this.bkGroupBox2.Controls.Add(this.m_eigenBetragTb);
            this.bkGroupBox2.Controls.Add(this.label8);
            this.bkGroupBox2.Controls.Add(this.m_einnahmenTb);
            this.bkGroupBox2.Controls.Add(this.label7);
            this.bkGroupBox2.Controls.Add(this.m_returnPosCountTb);
            this.bkGroupBox2.Controls.Add(this.label6);
            this.bkGroupBox2.Controls.Add(this.m_soldPosCountTb);
            this.bkGroupBox2.Controls.Add(this.label5);
            this.bkGroupBox2.Controls.Add(this.m_notSoldPosCountTb);
            this.bkGroupBox2.Controls.Add(this.label4);
            this.bkGroupBox2.Controls.Add(this.m_numSuplTb);
            this.bkGroupBox2.Controls.Add(this.label3);
            this.bkGroupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.bkGroupBox2.Location = new System.Drawing.Point(414, 320);
            this.bkGroupBox2.Name = "bkGroupBox2";
            this.bkGroupBox2.Size = new System.Drawing.Size(400, 275);
            this.bkGroupBox2.TabIndex = 2;
            this.bkGroupBox2.TabStop = false;
            this.bkGroupBox2.Text = "Statistik";
            // 
            // m_lieferGewinnTb
            // 
            this.m_lieferGewinnTb.AllowSpace = false;
            this.m_lieferGewinnTb.IsMargin = false;
            this.m_lieferGewinnTb.Location = new System.Drawing.Point(274, 157);
            this.m_lieferGewinnTb.Name = "m_lieferGewinnTb";
            this.m_lieferGewinnTb.ReadOnly = true;
            this.m_lieferGewinnTb.ResultType = DVes.Basar.Server.CustControls.DVTextBox.ResultTypes.Double;
            this.m_lieferGewinnTb.Size = new System.Drawing.Size(113, 22);
            this.m_lieferGewinnTb.TabIndex = 15;
            this.m_lieferGewinnTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(271, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 16);
            this.label9.TabIndex = 14;
            this.label9.Text = "Liefer-Gewinn:";
            // 
            // m_eigenBetragTb
            // 
            this.m_eigenBetragTb.AllowSpace = false;
            this.m_eigenBetragTb.IsMargin = false;
            this.m_eigenBetragTb.Location = new System.Drawing.Point(145, 157);
            this.m_eigenBetragTb.Name = "m_eigenBetragTb";
            this.m_eigenBetragTb.ReadOnly = true;
            this.m_eigenBetragTb.ResultType = DVes.Basar.Server.CustControls.DVTextBox.ResultTypes.Double;
            this.m_eigenBetragTb.Size = new System.Drawing.Size(113, 22);
            this.m_eigenBetragTb.TabIndex = 13;
            this.m_eigenBetragTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(142, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "Eigen:";
            // 
            // m_einnahmenTb
            // 
            this.m_einnahmenTb.AllowSpace = false;
            this.m_einnahmenTb.IsMargin = false;
            this.m_einnahmenTb.Location = new System.Drawing.Point(17, 157);
            this.m_einnahmenTb.Name = "m_einnahmenTb";
            this.m_einnahmenTb.ReadOnly = true;
            this.m_einnahmenTb.ResultType = DVes.Basar.Server.CustControls.DVTextBox.ResultTypes.Double;
            this.m_einnahmenTb.Size = new System.Drawing.Size(113, 22);
            this.m_einnahmenTb.TabIndex = 11;
            this.m_einnahmenTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(14, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Einnahmen:";
            // 
            // m_returnPosCountTb
            // 
            this.m_returnPosCountTb.AllowSpace = false;
            this.m_returnPosCountTb.IsMargin = false;
            this.m_returnPosCountTb.Location = new System.Drawing.Point(274, 100);
            this.m_returnPosCountTb.Name = "m_returnPosCountTb";
            this.m_returnPosCountTb.ReadOnly = true;
            this.m_returnPosCountTb.ResultType = DVes.Basar.Server.CustControls.DVTextBox.ResultTypes.Double;
            this.m_returnPosCountTb.Size = new System.Drawing.Size(113, 22);
            this.m_returnPosCountTb.TabIndex = 9;
            this.m_returnPosCountTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(271, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Rück. Positionen:";
            // 
            // m_soldPosCountTb
            // 
            this.m_soldPosCountTb.AllowSpace = false;
            this.m_soldPosCountTb.IsMargin = false;
            this.m_soldPosCountTb.Location = new System.Drawing.Point(145, 100);
            this.m_soldPosCountTb.Name = "m_soldPosCountTb";
            this.m_soldPosCountTb.ReadOnly = true;
            this.m_soldPosCountTb.ResultType = DVes.Basar.Server.CustControls.DVTextBox.ResultTypes.Double;
            this.m_soldPosCountTb.Size = new System.Drawing.Size(113, 22);
            this.m_soldPosCountTb.TabIndex = 7;
            this.m_soldPosCountTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(142, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Verk. Positionen:";
            // 
            // m_notSoldPosCountTb
            // 
            this.m_notSoldPosCountTb.AllowSpace = false;
            this.m_notSoldPosCountTb.IsMargin = false;
            this.m_notSoldPosCountTb.Location = new System.Drawing.Point(17, 100);
            this.m_notSoldPosCountTb.Name = "m_notSoldPosCountTb";
            this.m_notSoldPosCountTb.ReadOnly = true;
            this.m_notSoldPosCountTb.ResultType = DVes.Basar.Server.CustControls.DVTextBox.ResultTypes.Double;
            this.m_notSoldPosCountTb.Size = new System.Drawing.Size(113, 22);
            this.m_notSoldPosCountTb.TabIndex = 5;
            this.m_notSoldPosCountTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(14, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Offene Positionen:";
            // 
            // m_numSuplTb
            // 
            this.m_numSuplTb.AllowSpace = false;
            this.m_numSuplTb.IsMargin = false;
            this.m_numSuplTb.Location = new System.Drawing.Point(17, 49);
            this.m_numSuplTb.Name = "m_numSuplTb";
            this.m_numSuplTb.ReadOnly = true;
            this.m_numSuplTb.ResultType = DVes.Basar.Server.CustControls.DVTextBox.ResultTypes.Double;
            this.m_numSuplTb.Size = new System.Drawing.Size(74, 22);
            this.m_numSuplTb.TabIndex = 3;
            this.m_numSuplTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(14, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Lieferanten:";
            // 
            // m_paramsGb
            // 
            this.m_paramsGb.Controls.Add(this.m_printPrevCb);
            this.m_paramsGb.Controls.Add(this.m_saveBtn);
            this.m_paramsGb.Controls.Add(this.m_infoMsgPosPrintTb);
            this.m_paramsGb.Controls.Add(this.label2);
            this.m_paramsGb.Controls.Add(this.m_prozGewinTb);
            this.m_paramsGb.Controls.Add(this.label1);
            this.m_paramsGb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_paramsGb.Location = new System.Drawing.Point(3, 320);
            this.m_paramsGb.Name = "m_paramsGb";
            this.m_paramsGb.Size = new System.Drawing.Size(400, 275);
            this.m_paramsGb.TabIndex = 1;
            this.m_paramsGb.TabStop = false;
            this.m_paramsGb.Text = "Parameter";
            // 
            // m_printPrevCb
            // 
            this.m_printPrevCb.AutoSize = true;
            this.m_printPrevCb.BackColor = System.Drawing.Color.Transparent;
            this.m_printPrevCb.Location = new System.Drawing.Point(12, 197);
            this.m_printPrevCb.Name = "m_printPrevCb";
            this.m_printPrevCb.Size = new System.Drawing.Size(117, 20);
            this.m_printPrevCb.TabIndex = 5;
            this.m_printPrevCb.Text = "Druckvorschau";
            this.m_printPrevCb.UseVisualStyleBackColor = false;
            // 
            // m_saveBtn
            // 
            this.m_saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_saveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_saveBtn.Image = global::DVes.Basar.Server.Properties.Resources.disk_blue_32x32;
            this.m_saveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_saveBtn.Location = new System.Drawing.Point(252, 222);
            this.m_saveBtn.Name = "m_saveBtn";
            this.m_saveBtn.Size = new System.Drawing.Size(133, 46);
            this.m_saveBtn.TabIndex = 4;
            this.m_saveBtn.Text = "Speichern";
            this.m_saveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_saveBtn.UseVisualStyleBackColor = true;
            this.m_saveBtn.Click += new System.EventHandler(this.m_saveBtn_Click);
            // 
            // m_infoMsgPosPrintTb
            // 
            this.m_infoMsgPosPrintTb.AllowSpace = false;
            this.m_infoMsgPosPrintTb.IsMargin = false;
            this.m_infoMsgPosPrintTb.Location = new System.Drawing.Point(12, 100);
            this.m_infoMsgPosPrintTb.Multiline = true;
            this.m_infoMsgPosPrintTb.Name = "m_infoMsgPosPrintTb";
            this.m_infoMsgPosPrintTb.ResultType = DVes.Basar.Server.CustControls.DVTextBox.ResultTypes.String;
            this.m_infoMsgPosPrintTb.Size = new System.Drawing.Size(373, 79);
            this.m_infoMsgPosPrintTb.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(9, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Infotext für den Abgabeausdruck:";
            // 
            // m_prozGewinTb
            // 
            this.m_prozGewinTb.AllowSpace = false;
            this.m_prozGewinTb.IsMargin = false;
            this.m_prozGewinTb.Location = new System.Drawing.Point(12, 49);
            this.m_prozGewinTb.Name = "m_prozGewinTb";
            this.m_prozGewinTb.ResultType = DVes.Basar.Server.CustControls.DVTextBox.ResultTypes.Double;
            this.m_prozGewinTb.Size = new System.Drawing.Size(151, 22);
            this.m_prozGewinTb.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(9, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Eigen Gewinn in Prozent:";
            // 
            // titelBarCtrl1
            // 
            this.titelBarCtrl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.titelBarCtrl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold);
            this.titelBarCtrl1.Location = new System.Drawing.Point(0, 0);
            this.titelBarCtrl1.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.titelBarCtrl1.Name = "titelBarCtrl1";
            this.titelBarCtrl1.Size = new System.Drawing.Size(963, 61);
            this.titelBarCtrl1.TabIndex = 0;
            this.titelBarCtrl1.TitelText = "DVes.Basar.Server";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(15, 148);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(108, 45);
            this.button5.TabIndex = 20;
            this.button5.Text = "Alle Positionen von Verkäufer löschen";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(963, 596);
            this.Controls.Add(this.bkGroupBox4);
            this.Controls.Add(this.bkGroupBox3);
            this.Controls.Add(this.bkGroupBox1);
            this.Controls.Add(this.bkGroupBox2);
            this.Controls.Add(this.m_paramsGb);
            this.Controls.Add(this.titelBarCtrl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "DVes.Basar.Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.bkGroupBox4.ResumeLayout(false);
            this.bkGroupBox3.ResumeLayout(false);
            this.bkGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_lizPb)).EndInit();
            this.bkGroupBox1.ResumeLayout(false);
            this.bkGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_conStatePb)).EndInit();
            this.bkGroupBox2.ResumeLayout(false);
            this.bkGroupBox2.PerformLayout();
            this.m_paramsGb.ResumeLayout(false);
            this.m_paramsGb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon m_notifyIcon;
        private System.Windows.Forms.Timer m_startUpTimer;
        private CustControls.TitelBarCtrl titelBarCtrl1;
        private CustControls.BkGroupBox m_paramsGb;
        private System.Windows.Forms.Label label1;
        private CustControls.BkGroupBox bkGroupBox2;
        private CustControls.DVTextBox m_infoMsgPosPrintTb;
        private System.Windows.Forms.Label label2;
        private CustControls.DVTextBox m_prozGewinTb;
        private System.Windows.Forms.Button m_saveBtn;
        private CustControls.DVTextBox m_numSuplTb;
        private System.Windows.Forms.Label label3;
        private CustControls.DVTextBox m_returnPosCountTb;
        private System.Windows.Forms.Label label6;
        private CustControls.DVTextBox m_soldPosCountTb;
        private System.Windows.Forms.Label label5;
        private CustControls.DVTextBox m_notSoldPosCountTb;
        private System.Windows.Forms.Label label4;
        private CustControls.DVTextBox m_lieferGewinnTb;
        private System.Windows.Forms.Label label9;
        private CustControls.DVTextBox m_eigenBetragTb;
        private System.Windows.Forms.Label label8;
        private CustControls.DVTextBox m_einnahmenTb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox m_printPrevCb;
        private CustControls.BkGroupBox bkGroupBox1;
        private CustControls.DVTextBox m_machineNameTb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox m_ipListLb;
        private System.Windows.Forms.Button button1;
        private CustControls.DVTextBox m_ownPort;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox m_conStatePb;
        private CustControls.BkGroupBox bkGroupBox3;
        private System.Windows.Forms.Button button2;
        private CustControls.DVTextBox m_pcCodeTb;
        private System.Windows.Forms.Label label15;
        private CustControls.DVTextBox m_licenseTb;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox m_lizPb;
        private CustControls.BkGroupBox bkGroupBox4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
    }
}