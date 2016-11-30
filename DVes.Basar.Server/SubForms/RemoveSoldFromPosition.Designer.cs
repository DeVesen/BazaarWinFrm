namespace DVes.Basar.Server.SubForms
{
    partial class RemoveSoldFromPosition
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
            this.titelBarCtrl1 = new DVes.Basar.Server.CustControls.TitelBarCtrl();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dvTextBox2 = new DVes.Basar.Server.CustControls.DVTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titelBarCtrl1
            // 
            this.titelBarCtrl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.titelBarCtrl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold);
            this.titelBarCtrl1.Location = new System.Drawing.Point(0, 0);
            this.titelBarCtrl1.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.titelBarCtrl1.Name = "titelBarCtrl1";
            this.titelBarCtrl1.Size = new System.Drawing.Size(284, 83);
            this.titelBarCtrl1.TabIndex = 0;
            this.titelBarCtrl1.TabStop = false;
            this.titelBarCtrl1.TitelText = "Verkauf zurücksetzten:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(40, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(163, 173);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Abbruch";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dvTextBox2
            // 
            this.dvTextBox2.AllowSpace = false;
            this.dvTextBox2.IsMargin = false;
            this.dvTextBox2.Location = new System.Drawing.Point(16, 134);
            this.dvTextBox2.Name = "dvTextBox2";
            this.dvTextBox2.ResultType = DVes.Basar.Server.CustControls.DVTextBox.ResultTypes.String;
            this.dvTextBox2.Size = new System.Drawing.Size(256, 20);
            this.dvTextBox2.TabIndex = 2;
            this.dvTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dvTextBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dvTextBox2_KeyDown);
            this.dvTextBox2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dvTextBox2_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Positionsnummer:";
            // 
            // RemoveSoldFromPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(284, 208);
            this.Controls.Add(this.dvTextBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.titelBarCtrl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RemoveSoldFromPosition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustControls.TitelBarCtrl titelBarCtrl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private CustControls.DVTextBox dvTextBox2;
        private System.Windows.Forms.Label label2;
    }
}