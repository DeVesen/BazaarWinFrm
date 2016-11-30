namespace DeVes.Bazaar.Client.SubForms
{
    partial class InputTextForm
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
            this.m_cancelActionBtn = new System.Windows.Forms.Button();
            this.m_addValueBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(428, 61);
            this.label1.TabIndex = 0;
            // 
            // m_cancelActionBtn
            // 
            this.m_cancelActionBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cancelActionBtn.Image = global::DeVes.Bazaar.Client.Properties.Resources.delete2_32x32;
            this.m_cancelActionBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cancelActionBtn.Location = new System.Drawing.Point(335, 109);
            this.m_cancelActionBtn.Name = "m_cancelActionBtn";
            this.m_cancelActionBtn.Size = new System.Drawing.Size(100, 41);
            this.m_cancelActionBtn.TabIndex = 3;
            this.m_cancelActionBtn.Text = "Abbruch";
            this.m_cancelActionBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cancelActionBtn.UseVisualStyleBackColor = true;
            this.m_cancelActionBtn.Click += new System.EventHandler(this.OnBtnClick);
            // 
            // m_addValueBtn
            // 
            this.m_addValueBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_addValueBtn.Image = global::DeVes.Bazaar.Client.Properties.Resources.add2_32x32;
            this.m_addValueBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_addValueBtn.Location = new System.Drawing.Point(220, 109);
            this.m_addValueBtn.Name = "m_addValueBtn";
            this.m_addValueBtn.Size = new System.Drawing.Size(109, 41);
            this.m_addValueBtn.TabIndex = 2;
            this.m_addValueBtn.Text = "Übernehmen";
            this.m_addValueBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_addValueBtn.UseVisualStyleBackColor = true;
            this.m_addValueBtn.Click += new System.EventHandler(this.OnBtnClick);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.textBox1.Location = new System.Drawing.Point(3, 74);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(428, 30);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // InputTextForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 154);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.m_addValueBtn);
            this.Controls.Add(this.m_cancelActionBtn);
            this.Controls.Add(this.label1);
            this.Name = "InputTextForm";
            this.Text = "";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button m_cancelActionBtn;
        private System.Windows.Forms.Button m_addValueBtn;
        private System.Windows.Forms.TextBox textBox1;
    }
}