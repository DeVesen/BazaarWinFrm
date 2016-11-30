namespace DeVes.Bazaar.Client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.materialErfassungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.lieferantenverwaltungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.materialKategorienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialHerstellerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.verkaufToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.sucheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.toolStripButton2,
            this.toolStripSeparator3,
            this.toolStripDropDownButton2,
            this.toolStripSeparator4,
            this.toolStripLabel1,
            this.toolStripSeparator5,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(674, 39);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.materialErfassungToolStripMenuItem,
            this.sucheToolStripMenuItem,
            this.toolStripMenuItem2,
            this.lieferantenverwaltungToolStripMenuItem,
            this.toolStripMenuItem1,
            this.materialKategorienToolStripMenuItem,
            this.materialHerstellerToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::DeVes.Bazaar.Client.Properties.Resources.box_32x32;
            this.toolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(103, 36);
            this.toolStripDropDownButton1.Text = "Erfassung";
            // 
            // materialErfassungToolStripMenuItem
            // 
            this.materialErfassungToolStripMenuItem.Image = global::DeVes.Bazaar.Client.Properties.Resources.note_32x32;
            this.materialErfassungToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.materialErfassungToolStripMenuItem.Name = "materialErfassungToolStripMenuItem";
            this.materialErfassungToolStripMenuItem.Size = new System.Drawing.Size(208, 38);
            this.materialErfassungToolStripMenuItem.Tag = "MaterialInput";
            this.materialErfassungToolStripMenuItem.Text = "Material Erfassung";
            this.materialErfassungToolStripMenuItem.Click += new System.EventHandler(this.OnToolStripItemClicked);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(205, 6);
            // 
            // lieferantenverwaltungToolStripMenuItem
            // 
            this.lieferantenverwaltungToolStripMenuItem.Image = global::DeVes.Bazaar.Client.Properties.Resources.id_card_32x32;
            this.lieferantenverwaltungToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lieferantenverwaltungToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.lieferantenverwaltungToolStripMenuItem.Name = "lieferantenverwaltungToolStripMenuItem";
            this.lieferantenverwaltungToolStripMenuItem.Size = new System.Drawing.Size(208, 38);
            this.lieferantenverwaltungToolStripMenuItem.Tag = "SupplierManage";
            this.lieferantenverwaltungToolStripMenuItem.Text = "Lieferantenverwaltung";
            this.lieferantenverwaltungToolStripMenuItem.Click += new System.EventHandler(this.OnToolStripItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(205, 6);
            // 
            // materialKategorienToolStripMenuItem
            // 
            this.materialKategorienToolStripMenuItem.Image = global::DeVes.Bazaar.Client.Properties.Resources.index_32x32;
            this.materialKategorienToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.materialKategorienToolStripMenuItem.Name = "materialKategorienToolStripMenuItem";
            this.materialKategorienToolStripMenuItem.Size = new System.Drawing.Size(208, 38);
            this.materialKategorienToolStripMenuItem.Tag = "Category";
            this.materialKategorienToolStripMenuItem.Text = "Material Kategorien";
            this.materialKategorienToolStripMenuItem.Click += new System.EventHandler(this.OnToolStripItemClicked);
            // 
            // materialHerstellerToolStripMenuItem
            // 
            this.materialHerstellerToolStripMenuItem.Image = global::DeVes.Bazaar.Client.Properties.Resources.factory_32x32;
            this.materialHerstellerToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.materialHerstellerToolStripMenuItem.Name = "materialHerstellerToolStripMenuItem";
            this.materialHerstellerToolStripMenuItem.Size = new System.Drawing.Size(208, 38);
            this.materialHerstellerToolStripMenuItem.Tag = "Manufacturer";
            this.materialHerstellerToolStripMenuItem.Text = "Material Hersteller";
            this.materialHerstellerToolStripMenuItem.Click += new System.EventHandler(this.OnToolStripItemClicked);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::DeVes.Bazaar.Client.Properties.Resources.cashier_32x32;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(83, 36);
            this.toolStripButton1.Tag = "Verkauf";
            this.toolStripButton1.Text = "Verkauf";
            this.toolStripButton1.Click += new System.EventHandler(this.OnToolStripItemClicked);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::DeVes.Bazaar.Client.Properties.Resources.handshake_32x32;
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(96, 36);
            this.toolStripButton2.Tag = "ReturnToSupplier";
            this.toolStripButton2.Text = "Abholung";
            this.toolStripButton2.Click += new System.EventHandler(this.OnToolStripItemClicked);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verkaufToolStripMenuItem});
            this.toolStripDropDownButton2.Image = global::DeVes.Bazaar.Client.Properties.Resources.line_chart_32x32;
            this.toolStripDropDownButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(93, 36);
            this.toolStripDropDownButton2.Text = "Statistik";
            // 
            // verkaufToolStripMenuItem
            // 
            this.verkaufToolStripMenuItem.Image = global::DeVes.Bazaar.Client.Properties.Resources.moneybag_euro_32x32;
            this.verkaufToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.verkaufToolStripMenuItem.Name = "verkaufToolStripMenuItem";
            this.verkaufToolStripMenuItem.Size = new System.Drawing.Size(130, 38);
            this.verkaufToolStripMenuItem.Tag = "ScreenList_Summery";
            this.verkaufToolStripMenuItem.Text = "Verkauf";
            this.verkaufToolStripMenuItem.Click += new System.EventHandler(this.OnToolStripItemClicked);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(97, 36);
            this.toolStripLabel1.Text = "                              ";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::DeVes.Bazaar.Client.Properties.Resources.harddisk_network_32x32;
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(114, 36);
            this.toolStripButton3.Tag = "Settings";
            this.toolStripButton3.Text = "Einstellungen";
            this.toolStripButton3.Click += new System.EventHandler(this.OnToolStripItemClicked);
            // 
            // sucheToolStripMenuItem
            // 
            this.sucheToolStripMenuItem.Image = global::DeVes.Bazaar.Client.Properties.Resources.find;
            this.sucheToolStripMenuItem.Name = "sucheToolStripMenuItem";
            this.sucheToolStripMenuItem.Size = new System.Drawing.Size(208, 38);
            this.sucheToolStripMenuItem.Tag = "SearchMaterialInfo";
            this.sucheToolStripMenuItem.Text = "Suche";
            this.sucheToolStripMenuItem.Click += new System.EventHandler(this.OnToolStripItemClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 538);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem materialErfassungToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem materialKategorienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materialHerstellerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem verkaufToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem lieferantenverwaltungToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sucheToolStripMenuItem;
    }
}