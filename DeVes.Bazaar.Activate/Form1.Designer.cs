namespace DVes.Basar.Activate
{
    partial class MainWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.m_groundCodeTb = new System.Windows.Forms.TextBox();
            this.m_finalLizTb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Basis Code";
            // 
            // m_groundCodeTb
            // 
            this.m_groundCodeTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_groundCodeTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_groundCodeTb.Location = new System.Drawing.Point(15, 25);
            this.m_groundCodeTb.Name = "m_groundCodeTb";
            this.m_groundCodeTb.Size = new System.Drawing.Size(696, 38);
            this.m_groundCodeTb.TabIndex = 1;
            this.m_groundCodeTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_groundCodeTb.TextChanged += new System.EventHandler(this.m_groundCodeTb_TextChanged);
            // 
            // m_finalLizTb
            // 
            this.m_finalLizTb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_finalLizTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_finalLizTb.Location = new System.Drawing.Point(15, 93);
            this.m_finalLizTb.Multiline = true;
            this.m_finalLizTb.Name = "m_finalLizTb";
            this.m_finalLizTb.ReadOnly = true;
            this.m_finalLizTb.Size = new System.Drawing.Size(696, 154);
            this.m_finalLizTb.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lizence:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 255);
            this.Controls.Add(this.m_finalLizTb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_groundCodeTb);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_groundCodeTb;
        private System.Windows.Forms.TextBox m_finalLizTb;
        private System.Windows.Forms.Label label2;
    }
}

