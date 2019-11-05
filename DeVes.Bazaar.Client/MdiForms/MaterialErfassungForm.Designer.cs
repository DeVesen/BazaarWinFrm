using DeVes.Bazaar.Client.CustControls;
namespace DeVes.Bazaar.Client.MdiForms
{
    partial class MaterialErfassungForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialErfassungForm));
            this.m_positionGb = new DeVes.Bazaar.Client.CustControls.BkGroupBox();
            this.m_newMatlManufBtn = new System.Windows.Forms.Button();
            this.m_newMatlCatBtn = new System.Windows.Forms.Button();
            this.m_copyLineBtn = new System.Windows.Forms.Button();
            this.m_importBtn = new System.Windows.Forms.Button();
            this.m_clearPosCtrlsBtn = new System.Windows.Forms.Button();
            this.m_posMinPriceTb = new DeVes.Bazaar.Client.CustControls.DvTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.m_herstellerCb = new DeVes.Bazaar.Client.CustControls.DvComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.m_printListBtn = new System.Windows.Forms.Button();
            this.m_matlPosLv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_selPosRemoveBtn = new System.Windows.Forms.Button();
            this.m_selPosSaveEditBtn = new System.Windows.Forms.Button();
            this.m_selPosSaveNewBtn = new System.Windows.Forms.Button();
            this.m_posMaxPriceTb = new DeVes.Bazaar.Client.CustControls.DvTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.m_posCatCb = new DeVes.Bazaar.Client.CustControls.DvComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_posTitelTb = new DeVes.Bazaar.Client.CustControls.DvTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_posNrTb = new DeVes.Bazaar.Client.CustControls.DvTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_importOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.m_supplierSelection = new DeVes.Bazaar.Client.CustControls.SupplierSelection();
            ((System.ComponentModel.ISupportInitialize)(this.m_frmPb)).BeginInit();
            this.m_positionGb.SuspendLayout();
            this.SuspendLayout();
            // 
            // titelBarCtrl1
            // 
            this.titelBarCtrl1.Margin = new System.Windows.Forms.Padding(43, 33, 43, 33);
            this.titelBarCtrl1.Size = new System.Drawing.Size(2704, 141);
            this.titelBarCtrl1.TitelText = "Material Erfassung";
            // 
            // m_frmPb
            // 
            this.m_frmPb.Image = global::DeVes.Bazaar.Client.Properties.Resources.note_32x32;
            this.m_frmPb.Margin = new System.Windows.Forms.Padding(21, 17, 21, 17);
            this.m_frmPb.Size = new System.Drawing.Size(341, 272);
            // 
            // m_positionGb
            // 
            this.m_positionGb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_positionGb.Controls.Add(this.m_newMatlManufBtn);
            this.m_positionGb.Controls.Add(this.m_newMatlCatBtn);
            this.m_positionGb.Controls.Add(this.m_copyLineBtn);
            this.m_positionGb.Controls.Add(this.m_importBtn);
            this.m_positionGb.Controls.Add(this.m_clearPosCtrlsBtn);
            this.m_positionGb.Controls.Add(this.m_posMinPriceTb);
            this.m_positionGb.Controls.Add(this.label11);
            this.m_positionGb.Controls.Add(this.m_herstellerCb);
            this.m_positionGb.Controls.Add(this.label10);
            this.m_positionGb.Controls.Add(this.m_printListBtn);
            this.m_positionGb.Controls.Add(this.m_matlPosLv);
            this.m_positionGb.Controls.Add(this.m_selPosRemoveBtn);
            this.m_positionGb.Controls.Add(this.m_selPosSaveEditBtn);
            this.m_positionGb.Controls.Add(this.m_selPosSaveNewBtn);
            this.m_positionGb.Controls.Add(this.m_posMaxPriceTb);
            this.m_positionGb.Controls.Add(this.label8);
            this.m_positionGb.Controls.Add(this.m_posCatCb);
            this.m_positionGb.Controls.Add(this.label6);
            this.m_positionGb.Controls.Add(this.m_posTitelTb);
            this.m_positionGb.Controls.Add(this.label5);
            this.m_positionGb.Controls.Add(this.m_posNrTb);
            this.m_positionGb.Controls.Add(this.label4);
            this.m_positionGb.Enabled = false;
            this.m_positionGb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_positionGb.Location = new System.Drawing.Point(0, 582);
            this.m_positionGb.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.m_positionGb.Name = "m_positionGb";
            this.m_positionGb.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.m_positionGb.Size = new System.Drawing.Size(2701, 1309);
            this.m_positionGb.TabIndex = 2;
            this.m_positionGb.TabStop = false;
            this.m_positionGb.Text = "Materialliste:";
            this.m_positionGb.Enter += new System.EventHandler(this.m_positionGb_Enter);
            // 
            // m_newMatlManufBtn
            // 
            this.m_newMatlManufBtn.Image = global::DeVes.Bazaar.Client.Properties.Resources.Untitled1;
            this.m_newMatlManufBtn.Location = new System.Drawing.Point(1085, 193);
            this.m_newMatlManufBtn.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.m_newMatlManufBtn.Name = "m_newMatlManufBtn";
            this.m_newMatlManufBtn.Size = new System.Drawing.Size(61, 55);
            this.m_newMatlManufBtn.TabIndex = 23;
            this.m_newMatlManufBtn.UseVisualStyleBackColor = true;
            this.m_newMatlManufBtn.Click += new System.EventHandler(this.OnNewMatlDescItembtn);
            // 
            // m_newMatlCatBtn
            // 
            this.m_newMatlCatBtn.Image = global::DeVes.Bazaar.Client.Properties.Resources.Untitled1;
            this.m_newMatlCatBtn.Location = new System.Drawing.Point(517, 193);
            this.m_newMatlCatBtn.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.m_newMatlCatBtn.Name = "m_newMatlCatBtn";
            this.m_newMatlCatBtn.Size = new System.Drawing.Size(61, 55);
            this.m_newMatlCatBtn.TabIndex = 22;
            this.m_newMatlCatBtn.UseVisualStyleBackColor = true;
            this.m_newMatlCatBtn.Click += new System.EventHandler(this.OnNewMatlDescItembtn);
            // 
            // m_copyLineBtn
            // 
            this.m_copyLineBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_copyLineBtn.Enabled = false;
            this.m_copyLineBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_copyLineBtn.Image = global::DeVes.Bazaar.Client.Properties.Resources.note_pinned_32x32;
            this.m_copyLineBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_copyLineBtn.Location = new System.Drawing.Point(2240, 327);
            this.m_copyLineBtn.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.m_copyLineBtn.Name = "m_copyLineBtn";
            this.m_copyLineBtn.Size = new System.Drawing.Size(443, 83);
            this.m_copyLineBtn.TabIndex = 21;
            this.m_copyLineBtn.Text = "Kopieren";
            this.m_copyLineBtn.UseVisualStyleBackColor = true;
            this.m_copyLineBtn.Click += new System.EventHandler(this.m_copyLineBtn_Click);
            // 
            // m_importBtn
            // 
            this.m_importBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_importBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_importBtn.Image = global::DeVes.Bazaar.Client.Properties.Resources.box_into_32x32;
            this.m_importBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_importBtn.Location = new System.Drawing.Point(2240, 634);
            this.m_importBtn.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.m_importBtn.Name = "m_importBtn";
            this.m_importBtn.Size = new System.Drawing.Size(443, 83);
            this.m_importBtn.TabIndex = 20;
            this.m_importBtn.Text = "Import";
            this.m_importBtn.UseVisualStyleBackColor = true;
            this.m_importBtn.Click += new System.EventHandler(this.m_importBtn_Click);
            // 
            // m_clearPosCtrlsBtn
            // 
            this.m_clearPosCtrlsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_clearPosCtrlsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_clearPosCtrlsBtn.Image = global::DeVes.Bazaar.Client.Properties.Resources.note_new_32x32;
            this.m_clearPosCtrlsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_clearPosCtrlsBtn.Location = new System.Drawing.Point(2240, 48);
            this.m_clearPosCtrlsBtn.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.m_clearPosCtrlsBtn.Name = "m_clearPosCtrlsBtn";
            this.m_clearPosCtrlsBtn.Size = new System.Drawing.Size(443, 83);
            this.m_clearPosCtrlsBtn.TabIndex = 14;
            this.m_clearPosCtrlsBtn.Text = "Leeren";
            this.m_clearPosCtrlsBtn.UseVisualStyleBackColor = true;
            this.m_clearPosCtrlsBtn.Click += new System.EventHandler(this.m_clearPosCtrlsBtn_Click);
            // 
            // m_posMinPriceTb
            // 
            this.m_posMinPriceTb.AllowSpace = false;
            this.m_posMinPriceTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_posMinPriceTb.IsMargin = false;
            this.m_posMinPriceTb.Location = new System.Drawing.Point(1541, 253);
            this.m_posMinPriceTb.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.m_posMinPriceTb.Name = "m_posMinPriceTb";
            this.m_posMinPriceTb.ResultType = DeVes.Bazaar.Client.CustControls.DvTextBox.ResultTypes.Double;
            this.m_posMinPriceTb.Size = new System.Drawing.Size(345, 53);
            this.m_posMinPriceTb.TabIndex = 11;
            this.m_posMinPriceTb.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnPosInputCtrlKeyUp);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(1168, 196);
            this.label11.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(356, 46);
            this.label11.TabIndex = 8;
            this.label11.Text = "normal Preis (in €):";
            // 
            // m_herstellerCb
            // 
            this.m_herstellerCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_herstellerCb.FormattingEnabled = true;
            this.m_herstellerCb.IsMargin = false;
            this.m_herstellerCb.Location = new System.Drawing.Point(600, 253);
            this.m_herstellerCb.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.m_herstellerCb.Name = "m_herstellerCb";
            this.m_herstellerCb.Size = new System.Drawing.Size(540, 54);
            this.m_herstellerCb.TabIndex = 7;
            this.m_herstellerCb.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnPosInputCtrlKeyUp);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(600, 196);
            this.label10.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(201, 46);
            this.label10.TabIndex = 6;
            this.label10.Text = "Hersteller:";
            // 
            // m_printListBtn
            // 
            this.m_printListBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_printListBtn.Enabled = false;
            this.m_printListBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_printListBtn.Image = global::DeVes.Bazaar.Client.Properties.Resources.printer2_32x32;
            this.m_printListBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_printListBtn.Location = new System.Drawing.Point(2240, 527);
            this.m_printListBtn.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.m_printListBtn.Name = "m_printListBtn";
            this.m_printListBtn.Size = new System.Drawing.Size(443, 83);
            this.m_printListBtn.TabIndex = 19;
            this.m_printListBtn.Text = "Drucken";
            this.m_printListBtn.UseVisualStyleBackColor = true;
            this.m_printListBtn.Click += new System.EventHandler(this.m_printListBtn_Click);
            // 
            // m_matlPosLv
            // 
            this.m_matlPosLv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_matlPosLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader7,
            this.columnHeader6,
            this.columnHeader8});
            this.m_matlPosLv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_matlPosLv.FullRowSelect = true;
            this.m_matlPosLv.GridLines = true;
            this.m_matlPosLv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_matlPosLv.HideSelection = false;
            this.m_matlPosLv.Location = new System.Drawing.Point(32, 327);
            this.m_matlPosLv.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.m_matlPosLv.Name = "m_matlPosLv";
            this.m_matlPosLv.ShowGroups = false;
            this.m_matlPosLv.Size = new System.Drawing.Size(2180, 955);
            this.m_matlPosLv.TabIndex = 17;
            this.m_matlPosLv.UseCompatibleStateImageBehavior = false;
            this.m_matlPosLv.View = System.Windows.Forms.View.Details;
            this.m_matlPosLv.Click += new System.EventHandler(this.m_matlPosLv_Click);
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
            // columnHeader3
            // 
            this.columnHeader3.Text = "Kategorie";
            this.columnHeader3.Width = 102;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Hersteller";
            this.columnHeader4.Width = 75;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Preis je Stück";
            this.columnHeader5.Width = 102;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Min. Preis";
            this.columnHeader7.Width = 81;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Verkauft";
            this.columnHeader6.Width = 81;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Abgeholt";
            this.columnHeader8.Width = 77;
            // 
            // m_selPosRemoveBtn
            // 
            this.m_selPosRemoveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_selPosRemoveBtn.Enabled = false;
            this.m_selPosRemoveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_selPosRemoveBtn.Image = global::DeVes.Bazaar.Client.Properties.Resources.note_delete_32x32;
            this.m_selPosRemoveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_selPosRemoveBtn.Location = new System.Drawing.Point(2240, 420);
            this.m_selPosRemoveBtn.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.m_selPosRemoveBtn.Name = "m_selPosRemoveBtn";
            this.m_selPosRemoveBtn.Size = new System.Drawing.Size(443, 83);
            this.m_selPosRemoveBtn.TabIndex = 18;
            this.m_selPosRemoveBtn.Text = "Löschen";
            this.m_selPosRemoveBtn.UseVisualStyleBackColor = true;
            this.m_selPosRemoveBtn.Click += new System.EventHandler(this.m_selPosRemoveBtn_Click);
            // 
            // m_selPosSaveEditBtn
            // 
            this.m_selPosSaveEditBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_selPosSaveEditBtn.Enabled = false;
            this.m_selPosSaveEditBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_selPosSaveEditBtn.Image = global::DeVes.Bazaar.Client.Properties.Resources.note_edit_32x32;
            this.m_selPosSaveEditBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_selPosSaveEditBtn.Location = new System.Drawing.Point(2240, 241);
            this.m_selPosSaveEditBtn.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.m_selPosSaveEditBtn.Name = "m_selPosSaveEditBtn";
            this.m_selPosSaveEditBtn.Size = new System.Drawing.Size(443, 83);
            this.m_selPosSaveEditBtn.TabIndex = 16;
            this.m_selPosSaveEditBtn.Text = "Ändern";
            this.m_selPosSaveEditBtn.UseVisualStyleBackColor = true;
            this.m_selPosSaveEditBtn.Click += new System.EventHandler(this.m_selPosSaveEditBtn_Click);
            // 
            // m_selPosSaveNewBtn
            // 
            this.m_selPosSaveNewBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_selPosSaveNewBtn.Enabled = false;
            this.m_selPosSaveNewBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_selPosSaveNewBtn.Image = global::DeVes.Bazaar.Client.Properties.Resources.note_add_32x32;
            this.m_selPosSaveNewBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_selPosSaveNewBtn.Location = new System.Drawing.Point(2240, 155);
            this.m_selPosSaveNewBtn.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.m_selPosSaveNewBtn.Name = "m_selPosSaveNewBtn";
            this.m_selPosSaveNewBtn.Size = new System.Drawing.Size(443, 83);
            this.m_selPosSaveNewBtn.TabIndex = 15;
            this.m_selPosSaveNewBtn.Text = "Hinzufügen";
            this.m_selPosSaveNewBtn.UseVisualStyleBackColor = true;
            this.m_selPosSaveNewBtn.Click += new System.EventHandler(this.m_selPosSaveNewBtn_Click);
            // 
            // m_posMaxPriceTb
            // 
            this.m_posMaxPriceTb.AllowSpace = false;
            this.m_posMaxPriceTb.BackColor = System.Drawing.Color.PapayaWhip;
            this.m_posMaxPriceTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_posMaxPriceTb.IsMargin = true;
            this.m_posMaxPriceTb.Location = new System.Drawing.Point(1168, 253);
            this.m_posMaxPriceTb.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.m_posMaxPriceTb.Name = "m_posMaxPriceTb";
            this.m_posMaxPriceTb.ResultType = DeVes.Bazaar.Client.CustControls.DvTextBox.ResultTypes.Double;
            this.m_posMaxPriceTb.Size = new System.Drawing.Size(345, 53);
            this.m_posMaxPriceTb.TabIndex = 9;
            this.m_posMaxPriceTb.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnPosInputCtrlKeyUp);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1541, 196);
            this.label8.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(309, 46);
            this.label8.TabIndex = 10;
            this.label8.Text = "min. Preis (in €):";
            // 
            // m_posCatCb
            // 
            this.m_posCatCb.BackColor = System.Drawing.Color.PapayaWhip;
            this.m_posCatCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_posCatCb.FormattingEnabled = true;
            this.m_posCatCb.IsMargin = true;
            this.m_posCatCb.Location = new System.Drawing.Point(32, 253);
            this.m_posCatCb.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.m_posCatCb.Name = "m_posCatCb";
            this.m_posCatCb.Size = new System.Drawing.Size(540, 54);
            this.m_posCatCb.TabIndex = 5;
            this.m_posCatCb.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnPosInputCtrlKeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(32, 196);
            this.label6.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 46);
            this.label6.TabIndex = 4;
            this.label6.Text = "Kategorie:";
            // 
            // m_posTitelTb
            // 
            this.m_posTitelTb.AllowSpace = false;
            this.m_posTitelTb.BackColor = System.Drawing.Color.PapayaWhip;
            this.m_posTitelTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_posTitelTb.IsMargin = true;
            this.m_posTitelTb.Location = new System.Drawing.Point(411, 112);
            this.m_posTitelTb.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.m_posTitelTb.Name = "m_posTitelTb";
            this.m_posTitelTb.ResultType = DeVes.Bazaar.Client.CustControls.DvTextBox.ResultTypes.String;
            this.m_posTitelTb.Size = new System.Drawing.Size(1044, 53);
            this.m_posTitelTb.TabIndex = 3;
            this.m_posTitelTb.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnPosInputCtrlKeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(411, 55);
            this.label5.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(262, 46);
            this.label5.TabIndex = 2;
            this.label5.Text = "Bezeichnung:";
            // 
            // m_posNrTb
            // 
            this.m_posNrTb.AllowSpace = false;
            this.m_posNrTb.BackColor = System.Drawing.Color.PapayaWhip;
            this.m_posNrTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_posNrTb.IsMargin = true;
            this.m_posNrTb.Location = new System.Drawing.Point(32, 112);
            this.m_posNrTb.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.m_posNrTb.Name = "m_posNrTb";
            this.m_posNrTb.ResultType = DeVes.Bazaar.Client.CustControls.DvTextBox.ResultTypes.Int32;
            this.m_posNrTb.Size = new System.Drawing.Size(345, 53);
            this.m_posNrTb.TabIndex = 1;
            this.m_posNrTb.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnPosInputCtrlKeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 55);
            this.label4.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 46);
            this.label4.TabIndex = 0;
            this.label4.Text = "Pos Nr:";
            // 
            // m_importOpenFile
            // 
            this.m_importOpenFile.Filter = "CSV (ImportExcelBase.csv)|*.csv|Materials (PositionsTable.xml)|PositionsTable.xml" +
    "|All XML files (*.Xml)|*.Xml";
            // 
            // m_supplierSelection
            // 
            this.m_supplierSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_supplierSelection.Location = new System.Drawing.Point(0, 141);
            this.m_supplierSelection.Margin = new System.Windows.Forms.Padding(21, 17, 21, 17);
            this.m_supplierSelection.Name = "m_supplierSelection";
            this.m_supplierSelection.Size = new System.Drawing.Size(2701, 427);
            this.m_supplierSelection.TabIndex = 3;
            this.m_supplierSelection.ViewSupplierAdd = true;
            this.m_supplierSelection.SupplierSet += new DeVes.Bazaar.Client.CustControls.SupplierSelection.OnSupplierSet(this.supplierSelection1_SupplierSet);
            // 
            // MaterialErfassungForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2704, 1898);
            this.Controls.Add(this.m_supplierSelection);
            this.Controls.Add(this.m_positionGb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(21, 17, 21, 17);
            this.Name = "MaterialErfassungForm";
            this.Text = "Material Erfassung";
            this.Load += new System.EventHandler(this.MaterialErfassungForm_Load);
            this.Controls.SetChildIndex(this.titelBarCtrl1, 0);
            this.Controls.SetChildIndex(this.m_frmPb, 0);
            this.Controls.SetChildIndex(this.m_positionGb, 0);
            this.Controls.SetChildIndex(this.m_supplierSelection, 0);
            ((System.ComponentModel.ISupportInitialize)(this.m_frmPb)).EndInit();
            this.m_positionGb.ResumeLayout(false);
            this.m_positionGb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BkGroupBox m_positionGb;
        private System.Windows.Forms.Button m_importBtn;
        private System.Windows.Forms.Button m_clearPosCtrlsBtn;
        private DeVes.Bazaar.Client.CustControls.DvTextBox m_posMinPriceTb;
        private System.Windows.Forms.Label label11;
        private DeVes.Bazaar.Client.CustControls.DvComboBox m_herstellerCb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button m_printListBtn;
        private System.Windows.Forms.ListView m_matlPosLv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button m_selPosRemoveBtn;
        private System.Windows.Forms.Button m_selPosSaveEditBtn;
        private System.Windows.Forms.Button m_selPosSaveNewBtn;
        private DeVes.Bazaar.Client.CustControls.DvTextBox m_posMaxPriceTb;
        private System.Windows.Forms.Label label8;
        private DeVes.Bazaar.Client.CustControls.DvComboBox m_posCatCb;
        private System.Windows.Forms.Label label6;
        private DeVes.Bazaar.Client.CustControls.DvTextBox m_posTitelTb;
        private System.Windows.Forms.Label label5;
        private DeVes.Bazaar.Client.CustControls.DvTextBox m_posNrTb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button m_copyLineBtn;
        private System.Windows.Forms.OpenFileDialog m_importOpenFile;
        private SupplierSelection m_supplierSelection;
        private System.Windows.Forms.Button m_newMatlCatBtn;
        private System.Windows.Forms.Button m_newMatlManufBtn;
    }
}