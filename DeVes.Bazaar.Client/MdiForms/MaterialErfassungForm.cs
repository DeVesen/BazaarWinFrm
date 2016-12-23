using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DeVes.Bazaar.Client.SubForms;
using DeVes.Bazaar.Client.IBasarCom;
using DeVes.Bazaar.Client.CustControls;
using BHApp.Printing;

namespace DeVes.Bazaar.Client.MdiForms
{
    public partial class MaterialErfassungForm : BaseMdiForm
    {
        private BizPosition ActualEditPosition
        {
            get
            {
                if (this.m_selPosSaveEditBtn.Tag is PositionLvi)
                {
                    return ((PositionLvi)this.m_selPosSaveEditBtn.Tag).DataObj;
                }
                return null;
            }
        }

        private List<Control> PosInputSeq
        {
            get
            {
                var _resList = new List<Control>();

                _resList.Add(this.m_posNrTb);
                _resList.Add(this.m_posTitelTb);

                _resList.Add(this.m_posCatCb);
                _resList.Add(this.m_herstellerCb);

                _resList.Add(this.m_posMaxPriceTb);
                _resList.Add(this.m_posMinPriceTb);

                return _resList;
            }
        }

        public MaterialErfassungForm()
        {
            InitializeComponent();
        }

        private void MaterialErfassungForm_Load(object sender, EventArgs e)
        {
            this.m_supplierSelection.Reset();
            this.RefreshPositionList();
        }


        private void supplierSelection1_SupplierSet(object sender, SupplierSetArgs e)
        {
            this.m_positionGb.Enabled = false;
            this.RefreshPositionList();

            if (e != null && e.Supplier != null)
            {
                this.m_positionGb.Enabled = true;
                this.RefreshPositionList();

                this.m_posNrTb.Focus();
            }
        }


        private void OnPosInputCtrlKeyUp(object sender, KeyEventArgs e)
        {
            var _actual = sender as Control;
            if (_actual != null)
            {
                this.m_selPosSaveNewBtn.Enabled = this.ActualEditPosition == null && this.HasMinForNextPos();
                this.m_selPosSaveEditBtn.Enabled = this.ActualEditPosition != null && this.HasMinForNextPos();

                if (e.KeyCode == Keys.Return)
                {
                    var _currentIndex = this.PosInputSeq.IndexOf(_actual);

                    if (this.PosInputSeq.Count > _currentIndex + 1)
                    {
                        this.PosInputSeq[_currentIndex + 1].Focus();
                    }
                    else if (this.ActualEditPosition == null)
                    {
                        this.m_selPosSaveNewBtn_Click(sender, e);
                    }
                    else if (this.ActualEditPosition != null)
                    {
                        this.m_selPosSaveEditBtn_Click(sender, e);
                    }
                }
            }
        }

        private void m_clearPosCtrlsBtn_Click(object sender, EventArgs e)
        {
            foreach (var _ctrl in this.PosInputSeq)
            {
                if (_ctrl is DvTextBox)
                {
                    ((DvTextBox)_ctrl).ResetText();
                }
                else if (_ctrl is DvComboBox)
                {
                    ((DvComboBox)_ctrl).SelectedIndex = -1;
                    ((DvComboBox)_ctrl).SelectedItem = null;
                }
            }

            this.m_posNrTb.ReadOnly = false;

            this.PosInputSeq[0].Focus();

            this.m_selPosSaveNewBtn.Enabled = false;
            this.m_selPosSaveEditBtn.Tag = null;
            this.m_selPosSaveEditBtn.Enabled = false;
            this.m_selPosRemoveBtn.Enabled = false;
            this.m_copyLineBtn.Enabled = false;
        }

        private void m_selPosSaveNewBtn_Click(object sender, EventArgs e)
        {
            if (!this.HasMinForNextPos())
            {
                return;
            }

            var _positionToChange = new BizPosition();
            this.ScreenToBiz(ref _positionToChange);

            try
            {
                if (GParams.Instance.BasarCom.PositionGet(_positionToChange.PositionNo, true) == null)
                {
                    var _updated = true;
                    var _updatedSpec = true;

                    _positionToChange.SupplierId = this.m_supplierSelection.ActualSupplier.SupplierId;
                    GParams.Instance.BasarCom.PositionCreate(_positionToChange, out _updated, out _updatedSpec);

                    if (_updated && _updatedSpec)
                    {
                        this.m_clearPosCtrlsBtn_Click(sender, e);

                        this.RefreshPositionList();
                    }
                    else
                    {
                        MessageBox.Show("Speichern der Position war nicht möglich!");
                    }
                }
                else
                {
                    MessageBox.Show("Position existiert bereits");
                    this.m_posNrTb.Focus();
                    this.m_posNrTb.SelectAll();
                }
            }
            catch (Exception _ex)
            {
                MessageBox.Show(_ex.Message);
            }
        }

        private void m_selPosSaveEditBtn_Click(object sender, EventArgs e)
        {
            if (!this.HasMinForNextPos())
            {
                return;
            }

            var _positionToChange = this.ActualEditPosition;
            this.ScreenToBiz(ref _positionToChange);

            try
            {
                var _updated = true;
                var _updatedSpec = true;

                GParams.Instance.BasarCom.PositionUpdate(_positionToChange, out _updated, out _updatedSpec);

                if (_updated && _updatedSpec)
                {
                    this.m_clearPosCtrlsBtn_Click(sender, e);

                    this.RefreshPositionList();
                }
                else
                {
                    MessageBox.Show("Speichern der Änderung war nicht möglich!");
                }
            }
            catch(Exception _ex)
            {
                MessageBox.Show(_ex.Message);
            }
        }

        private void m_copyLineBtn_Click(object sender, EventArgs e)
        {
            this.m_selPosSaveNewBtn.Enabled = false;
            this.m_selPosSaveEditBtn.Tag = null;
            this.m_selPosSaveEditBtn.Enabled = false;
            this.m_copyLineBtn.Enabled = false;
            this.m_selPosRemoveBtn.Enabled = false;

            this.m_posNrTb.ReadOnly = false;
            this.m_posNrTb.ResetText();
            this.m_posNrTb.Focus();
        }

        private void m_selPosRemoveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.m_matlPosLv.SelectedItems.Count > 0)
                {
                    if (MessageBox.Show("Position(en) wirklich löschen?", "Löschen...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        foreach (ListViewItem _lvItem in this.m_matlPosLv.SelectedItems)
                        {
                            var _toRemoveLine = _lvItem as PositionLvi;

                            if (_toRemoveLine != null)
                            {
                                var _removed = false;
                                var _removedSpec = false;
                                GParams.Instance.BasarCom.PositionRemove(_toRemoveLine.DataObj.PositionNo, true, out _removed, out _removedSpec);
                            }
                        }

                        this.m_clearPosCtrlsBtn_Click(sender, e);

                        this.RefreshPositionList();
                    }
                }
            }
            catch (Exception _ex)
            {
                MessageBox.Show(_ex.Message);
            }
        }

        private void m_printListBtn_Click(object sender, EventArgs e)
        {
            if (this.m_matlPosLv.Items.Count <= 0)
                return;

            var _tableInfo = new TablePrintDef();
            _tableInfo.AddColumn(new TablePrintDef.ColumnItem("Pos Nr.", 8.50F));
            _tableInfo.AddColumn(new TablePrintDef.ColumnItem("Kategorie", 14.50F));
            _tableInfo.AddColumn(new TablePrintDef.ColumnItem("Hersteller", 14.50F));
            _tableInfo.AddColumn(new TablePrintDef.ColumnItem("Bezeichnung", 40.50F));
            _tableInfo.AddColumn(new TablePrintDef.ColumnItem("Regel Preis", 11.00F));
            _tableInfo.AddColumn(new TablePrintDef.ColumnItem("Min. Preis", 11.00F));


            var _itemsToPrint = new List<ListViewItem>();
            foreach (ListViewItem _lvItem in this.m_matlPosLv.Items)
            {
                _itemsToPrint.Add(_lvItem);
            }

            _itemsToPrint.Sort(delegate(ListViewItem lv01, ListViewItem lv02)
            {
                var _pos01 = GParams.ToInt32(lv01.SubItems[0].Text);
                var _pos02 = GParams.ToInt32(lv02.SubItems[0].Text);

                if (_pos01.HasValue && _pos02.HasValue)
                {
                    if (_pos01.Value > _pos02.Value)
                        return 1;
                    else if (_pos01.Value < _pos02.Value)
                        return -1;
                    else
                        return 0;
                }
                return string.Compare(lv01.SubItems[0].Text, lv02.SubItems[0].Text);
            });


            foreach (var _lvItem in _itemsToPrint)
            {
                var _posNoInfo = new TablePrintDef.FieldDef(_lvItem.SubItems[0].Text);
                var _maxQtyInfo = new TablePrintDef.FieldDef(_lvItem.SubItems[4].Text + " €");
                var _minQtyInfo = new TablePrintDef.FieldDef(_lvItem.SubItems[5].Text + " €");

                _posNoInfo.StringFormat.Alignment = StringAlignment.Center;
                _maxQtyInfo.StringFormat.Alignment = StringAlignment.Far;
                _minQtyInfo.StringFormat.Alignment = StringAlignment.Far;

                _tableInfo.AddLine(_posNoInfo,
                                    new TablePrintDef.FieldDef(_lvItem.SubItems[2].Text),
                                    new TablePrintDef.FieldDef(_lvItem.SubItems[3].Text),
                                    new TablePrintDef.FieldDef(_lvItem.SubItems[1].Text),
                                    _maxQtyInfo,
                                    _minQtyInfo);
            }


            var _printDocument = new PrintDocErfassung(_tableInfo);
            _printDocument.DefaultPageSettings.Landscape = true;
            _printDocument.PrinterSettings.DefaultPageSettings.Landscape = true;

            _printDocument.SellerAdress = new PrintDocErfassung.SellerAdressElem();
            _printDocument.SellerAdress.Id = this.m_supplierSelection.ActualSupplier.SupplierNo.ToString();
            _printDocument.SellerAdress.Titel = this.m_supplierSelection.ActualSupplier.Salutation;
            _printDocument.SellerAdress.VName = this.m_supplierSelection.ActualSupplier.FirstName;
            _printDocument.SellerAdress.NName = this.m_supplierSelection.ActualSupplier.LastName;
            _printDocument.SellerAdress.Street = this.m_supplierSelection.ActualSupplier.Adress;
            _printDocument.SellerAdress.Zip = this.m_supplierSelection.ActualSupplier.ZipCode;
            _printDocument.SellerAdress.Town = this.m_supplierSelection.ActualSupplier.Town;

            if (GParams.Instance.SystemParameters.PrintPev)
            {
                var _printPrevDlg = new PrintPreviewDialog();
                _printPrevDlg.Document = _printDocument;
                _printPrevDlg.ShowDialog();
            }
            else
            {
                var _printerFrm = new PrintDialog();
                if (_printerFrm.ShowDialog(this) == DialogResult.OK)
                {
                    _printDocument.PrinterSettings = _printerFrm.PrinterSettings;
                    _printDocument.Print();
                }
            }
        }

        private void m_importBtn_Click(object sender, EventArgs e)
        {
            if (this.m_importOpenFile.ShowDialog(this) == DialogResult.OK)
            {
                ImportPositionForm.HandleImport(this, this.m_importOpenFile.FileName, this.m_supplierSelection.ActualSupplier);
            }

            this.RefreshPositionList();
        }

        private void m_positionGb_Enter(object sender, EventArgs e)
        {

        }

        private void m_matlPosLv_Click(object sender, EventArgs e)
        {
            if (this.m_matlPosLv.SelectedItems.Count == 1 && this.m_matlPosLv.SelectedItems[0] is PositionLvi)
            {
                this.m_selPosSaveEditBtn.Tag = this.m_matlPosLv.SelectedItems[0] as PositionLvi;

                this.BizToScreen(this.ActualEditPosition);

                this.m_selPosSaveNewBtn.Enabled = false;

                this.m_selPosSaveEditBtn.Enabled = true;
                this.m_copyLineBtn.Enabled = true;
                this.m_selPosRemoveBtn.Enabled = true;

                this.m_posNrTb.ReadOnly = true;
                this.m_posTitelTb.Focus();
            }
            else
            {
                this.m_selPosSaveEditBtn.Tag = null;
                this.m_selPosSaveEditBtn.Enabled = false;
                this.m_copyLineBtn.Enabled = false;
                this.m_selPosRemoveBtn.Enabled = this.m_matlPosLv.SelectedItems.Count > 0;
                this.m_posNrTb.ReadOnly = false;

                if (this.m_matlPosLv.SelectedItems.Count > 0)
                {
                    foreach (var _ctrl in this.PosInputSeq)
                    {
                        if (_ctrl is DvTextBox)
                        {
                            ((DvTextBox)_ctrl).ResetText();
                        }
                        else if (_ctrl is DvComboBox)
                        {
                            ((DvComboBox)_ctrl).SelectedIndex = -1;
                            ((DvComboBox)_ctrl).SelectedItem = null;
                        }
                    }
                }
            }
        }


        public void RefreshPositionList()
        {
            this.m_matlPosLv.Items.Clear();
            this.m_printListBtn.Enabled = false;

            try
            {
                if (this.m_supplierSelection.ActualSupplier != null)
                {
                    var _positionArray = GParams.Instance.BasarCom.PositionGetAll(this.m_supplierSelection.ActualSupplier.SupplierId);

                    if (_positionArray != null && _positionArray.Length > 0)
                    {
                        this.m_printListBtn.Enabled = true;

                        foreach (var _position in _positionArray)
                        {
                            this.m_matlPosLv.Items.Add(new PositionLvi(_position));
                        }
                    }
                }
            }
            catch (Exception _ex)
            {
                MessageBox.Show(_ex.Message);
            }
        }

        private bool HasMinForNextPos()
        {
            var _result = true;

            foreach (var _ctrl in this.PosInputSeq)
            {
                if (_ctrl is DvTextBox)
                {
                    _result = _result && (((DvTextBox)_ctrl).HasValueAndLikeWish || !((DvTextBox)_ctrl).IsMargin);
                }
                else if (_ctrl is DvComboBox)
                {
                    _result = _result && (((DvComboBox)_ctrl).SelectedItem != null || !((DvComboBox)_ctrl).IsMargin);
                }
            }

            return _result;
        }
        private void ScreenToBiz(ref BizPosition positionBiz)
        {
            positionBiz.PositionNo = GParams.ToInt32(this.m_posNrTb.Text).Value;
            positionBiz.PositionNoSpecified = true;
            positionBiz.Material = this.m_posTitelTb.Text;

            positionBiz.Category = this.m_posCatCb.Text;
            positionBiz.Manufacturer = this.m_herstellerCb.Text;

            positionBiz.PriceMax = GParams.ToDouble(this.m_posMaxPriceTb.Text).Value;
            positionBiz.PriceMaxSpecified = true;
            positionBiz.PriceMin = GParams.ToDouble(this.m_posMinPriceTb.Text);
            positionBiz.PriceMinSpecified = GParams.ToDouble(this.m_posMinPriceTb.Text).HasValue;

            positionBiz.Memo = this.m_posDescTb.Text;
        }
        private void BizToScreen(BizPosition positionBiz)
        {
            this.m_posNrTb.Text = positionBiz.PositionNo.ToString();
            this.m_posTitelTb.Text = positionBiz.Material;

            this.m_posCatCb.Text = positionBiz.Category;
            this.m_herstellerCb.Text = positionBiz.Manufacturer;

            this.m_posMaxPriceTb.Text = positionBiz.PriceMax.ToString();
            this.m_posMinPriceTb.Text = positionBiz.PriceMin.ToString();

            this.m_posDescTb.Text = positionBiz.Memo;
        }
        private void ReloadManufComboBox()
        {
            try
            {
                this.m_herstellerCb.Items.Clear();

                var _allManufs = GParams.Instance.BasarCom.ManufacturerGetAll();
                if (_allManufs != null && _allManufs.Length > 0)
                {
                    foreach (var _manufItem in _allManufs)
                    {
                        this.m_herstellerCb.Items.Add(new DvComboBoxItem(null, _manufItem.Designation, _manufItem));
                    }
                }
            }
            catch (Exception _ex)
            {
                MessageBox.Show(_ex.Message);
            }
        }
        private void ReloadCategoryComboBox()
        {
            try
            {
                this.m_posCatCb.Items.Clear();

                var _allCateg = GParams.Instance.BasarCom.MaterialCategoryGetAll();

                if (_allCateg != null && _allCateg.Length > 0)
                {
                    var _matlCatList = new List<BizMaterialCategory>(_allCateg);
                    if (_allCateg != null && _allCateg.Length > 0)
                    {
                        foreach (var _categItem in _allCateg)
                        {
                            this.m_posCatCb.Items.Add(new DvComboBoxItem(null, _categItem.Designation, _categItem));
                        }
                    }
                }
            }
            catch (Exception _ex)
            {
                MessageBox.Show(_ex.Message);
            }
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            this.ReloadManufComboBox();
            this.ReloadCategoryComboBox();
        }

        private void OnNewMatlDescItembtn(object sender, EventArgs e)
        {
            string _labelText = null;
            if (sender == this.m_newMatlCatBtn)
            {
                _labelText = "Bitte neue \"Kategorie\" eingeben";
            }
            else if (sender == this.m_newMatlManufBtn)
            {
                _labelText = "Bitte neuen \"Hersteller\" eingeben";
            }
            else
            {
                return;
            }

            var _value = string.Empty;
            if (InputTextForm.RequestInput(this, _labelText, ref _value))
            {
                if (sender == this.m_newMatlCatBtn)
                {
                    var _newCate = GParams.Instance.GetMaterialCategoryByName(_value);
                    if (_newCate == null)
                    {
                        _newCate = new BizMaterialCategory();
                        _newCate.Designation = _value;

                        var _created = false;
                        var _createdSpec = false;

                        GParams.Instance.BasarCom.MaterialCategoryCreate(_newCate, out _created, out _createdSpec);

                        if (_created && _createdSpec)
                        {
                            this.ReloadCategoryComboBox();
                        }
                        else
                        {
                            MessageBox.Show("Kategorie konnte nicht erzeugt werden");
                            _newCate = null;
                        }
                    }
                    if (_newCate != null)
                    {
                        this.m_posCatCb.Text = _newCate.Designation;
                    }
                }
                else if (sender == this.m_newMatlManufBtn)
                {
                    var _newManuf = GParams.Instance.GetManufacturerByName(_value);
                    if (_newManuf == null)
                    {
                        _newManuf = new BizManufacturer();
                        _newManuf.Designation = _value;

                        var _created = false;
                        var _createdSpec = false;

                        GParams.Instance.BasarCom.ManufacturerCreate(_newManuf, out _created, out _createdSpec);

                        if (_created && _createdSpec)
                        {
                            this.ReloadManufComboBox();
                        }
                        else
                        {
                            MessageBox.Show("Hersteller konnte nicht erzeugt werden");
                            _newManuf = null;
                        }
                    }
                    if (_newManuf != null)
                    {
                        this.m_herstellerCb.Text = _newManuf.Designation;
                    }
                }
            }
        }
    }

    public class PositionLvi : ListViewItem
    {
        public BizPosition DataObj { get; set; }

        public PositionLvi(BizPosition position)
        {
            this.DataObj = position;

            this.Text = position.PositionNo.ToString();
            this.SubItems.Add(position.Material);
            this.SubItems.Add(position.Category);
            this.SubItems.Add(position.Manufacturer);
            this.SubItems.Add(position.PriceMax.ToString());
            this.SubItems.Add(position.PriceMin.ToString());
            this.SubItems.Add(position.SoldFor.ToString());
            this.SubItems.Add(position.ReturnedToSupplierAt.ToString());
        }
    }
}
