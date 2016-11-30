using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DeVes.Bazaar.Client.IBasarCom;
using BHApp.Printing;
using DeVes.Bazaar.Client.SubForms;

namespace DeVes.Bazaar.Client.MdiForms
{
    public partial class ReturnToSupplier : BaseMdiForm
    {
        public class SoldPositionLvi : ListViewItem
        {
            public BizPosition DataObj { get; set; }

            public SoldPositionLvi(BizPosition position)
            {
                this.DataObj = position;

                this.Text = position.PositionNo.ToString();
                this.SubItems.Add(position.Material);
                this.SubItems.Add(position.PriceMax.ToString());
                this.SubItems.Add(position.PriceMin.ToString());

                this.SubItems.Add(position.SoldFor.ToString());
                this.SubItems.Add(position.SoldAt.ToString());
                
                this.SubItems.Add(position.ReturnedToSupplierAt.ToString());
                if (position.ReturnedToSupplierAt.HasValue)
                    this.BackColor = Color.Orange;
            }
        }
        public class NonSoldPositionLvi : ListViewItem
        {
            public BizPosition DataObj { get; set; }

            public NonSoldPositionLvi(BizPosition position)
            {
                this.DataObj = position;

                this.Text = position.PositionNo.ToString();
                this.SubItems.Add(position.Material);
                this.SubItems.Add(position.PriceMax.ToString());
                this.SubItems.Add(position.PriceMin.ToString());
                this.SubItems.Add(position.ReturnedToSupplierAt.ToString());

                if (position.ReturnedToSupplierAt.HasValue)
                    this.BackColor = Color.Orange;
            }
        }

        public ReturnToSupplier()
        {
            InitializeComponent();
        }

        private void ReturnToSupplier_Load(object sender, EventArgs e)
        {
            this.m_supplierSelection.Reset();
            this.m_supplierSelection.m_supplierNoTb.Focus();
        }

        private void m_supplierSelection_SupplierSet(object sender, CustControls.SupplierSetArgs e)
        {
            this.ShowActualSupplierInfos();
        }


        private void ShowActualSupplierInfos()
        {
            this.ResetPositionLists();

            try
            {
                if (this.m_supplierSelection.ActualSupplier != null)
                {
                    var _soldTotalPrice = 0.0;

                    var _positions =
                        GParams.Instance.BasarCom.PositionGetAll(this.m_supplierSelection.ActualSupplier.SupplierID);

                    if (_positions != null && _positions.Length > 0)
                    {
                        foreach (var _position in _positions)
                        {
                            if (_position.SoldAt.HasValue && _position.SoldFor.HasValue)
                            {
                                _soldTotalPrice += _position.SoldFor.Value;

                                this.m_soldPosLv.Items.Add(new SoldPositionLvi(_position));
                            }
                            else
                            {
                                this.m_notSoldPosLv.Items.Add(new NonSoldPositionLvi(_position));
                            }
                        }

                        var _eigenGeld = (_soldTotalPrice * GParams.Instance.SystemParameters.ProzSoldGewein) / 100;

                        this.m_eigenGeld.Tag = _eigenGeld;
                        this.m_eigenGeld.Text = _eigenGeld.ToString() + " €";
                        this.m_qtySum.Tag = _soldTotalPrice - _eigenGeld;
                        this.m_qtySum.Text = this.m_qtySum.Tag.ToString() + " €";

                        this.m_confirmAbhulungBtn.Enabled = true;
                        this.m_printNotSoldPositionsBtn.Enabled = this.m_notSoldPosLv.Items.Count > 0;

                        //if (this.m_supplierSelection.ActualSupplier.ReturnedToSupplier.HasValue)
                        //{
                        //    MessageBox.Show("Lieferant erhielt schon mal eine Auszahlung!");
                        //}
                    }
                }
            }
            catch (Exception _ex)
            {
                MessageBox.Show(_ex.Message);
            }
        }

        private void ResetPositionLists()
        {
            this.m_confirmAbhulungBtn.Enabled = false;
            this.m_printNotSoldPositionsBtn.Enabled = false;

            this.m_eigenGeld.Text = "0,00 €";
            this.m_qtySum.Text = "0,00 €";

            this.m_soldPosLv.Items.Clear();
            this.m_notSoldPosLv.Items.Clear();
        }

        private void PrintRueckgabe(List<BizPosition> itemsToPrint)
        {
            var _tableInfo = new TablePrintDef();
            _tableInfo.AddColumn(new TablePrintDef.ColumnItem("Pos Nr.", 10.00F));
            _tableInfo.AddColumn(new TablePrintDef.ColumnItem("Bezeichnung", 50.00F));
            _tableInfo.AddColumn(new TablePrintDef.ColumnItem("Regel Preis", 11.00F));
            _tableInfo.AddColumn(new TablePrintDef.ColumnItem("Min. Preis", 11.00F));
            _tableInfo.AddColumn(new TablePrintDef.ColumnItem("Verk. Preis", 11.00F));

            var _soldTotalPrice = 0.0;

            itemsToPrint.Sort(delegate(BizPosition position01, BizPosition position02)
            {
                if (position01.PositionNo > position02.PositionNo)
                    return 1;
                else if (position01.PositionNo < position02.PositionNo)
                    return -1;
                else
                    return 0;
            });

            foreach (var _position in itemsToPrint)
            {
                _soldTotalPrice += _position.SoldFor.Value;

                _tableInfo.AddLine(new TablePrintDef.FieldDef(_position.PositionNo.ToString()),
                                    new TablePrintDef.FieldDef(_position.Material),
                                    new TablePrintDef.FieldDef(_position.PriceMax.ToString()),
                                    new TablePrintDef.FieldDef(_position.PriceMin.ToString()),
                                    new TablePrintDef.FieldDef(_position.SoldFor.ToString()));
            }

            var _emptyPlace = new TablePrintDef.FieldDef("  ");
            var _totalGeldText = new TablePrintDef.FieldDef("Verkauft (€):");
            var _totalGeldQty = new TablePrintDef.FieldDef(_soldTotalPrice.ToString() + " €");
            var _ownGeldText = new TablePrintDef.FieldDef(string.Format("- {0}%", GParams.Instance.SystemParameters.ProzSoldGewein));
            var _ownGeldQty = new TablePrintDef.FieldDef("- " + this.m_eigenGeld.Text);
            var _sellerGeldText = new TablePrintDef.FieldDef("Rückgabe (€):");
            var _sellerGeldQty = new TablePrintDef.FieldDef(this.m_qtySum.Text);

            _emptyPlace.Font = new Font("ARIAL", 13, FontStyle.Bold | FontStyle.Underline);
            _emptyPlace.BkColor = Color.FromArgb(192, 192, 192);
            _totalGeldText.Font = _totalGeldQty.Font = new Font("ARIAL", 13, FontStyle.Bold | FontStyle.Underline);
            _totalGeldText.BkColor = _totalGeldQty.BkColor = Color.FromArgb(192, 192, 192);
            _ownGeldText.Font = _ownGeldQty.Font = new Font("ARIAL", 13, FontStyle.Bold | FontStyle.Underline);
            _ownGeldText.BkColor = _ownGeldQty.BkColor = Color.FromArgb(192, 192, 192);
            _sellerGeldText.Font = _sellerGeldQty.Font = new Font("ARIAL", 13, FontStyle.Bold | FontStyle.Underline);
            _sellerGeldText.BkColor = _sellerGeldQty.BkColor = Color.FromArgb(192, 192, 192);

            _tableInfo.AddLine(_emptyPlace, _totalGeldText, _emptyPlace,
                                _emptyPlace, _totalGeldQty);
            _tableInfo.AddLine(_emptyPlace, _ownGeldText, _emptyPlace,
                                _emptyPlace, _ownGeldQty);
            _tableInfo.AddLine(_emptyPlace, _sellerGeldText, _emptyPlace,
                                _emptyPlace, _sellerGeldQty);


            var _printDocument = new PrintDocRueckgabe(_tableInfo);
            _printDocument.DefaultPageSettings.Landscape = true;
            _printDocument.PrinterSettings.DefaultPageSettings.Landscape = true;

            _printDocument.SellerAdress = new PrintDocRueckgabe.SellerAdressElem();
            _printDocument.SellerAdress.Id = this.m_supplierSelection.ActualSupplier.SupplierNo.ToString();
            _printDocument.SellerAdress.Titel = this.m_supplierSelection.ActualSupplier.Salutation;
            _printDocument.SellerAdress.VName = this.m_supplierSelection.ActualSupplier.FirstName;
            _printDocument.SellerAdress.NName = this.m_supplierSelection.ActualSupplier.LastName;
            _printDocument.SellerAdress.Street = this.m_supplierSelection.ActualSupplier.Adress;
            _printDocument.SellerAdress.Zip = this.m_supplierSelection.ActualSupplier.ZIPCode;
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

        private void m_confirmAbhulungBtn_Click(object sender, EventArgs e)
        {
            var _positions = GParams.Instance.BasarCom.GetNotSoldNotReturnedPositions(this.m_supplierSelection.ActualSupplier.SupplierID);
            if (_positions != null && _positions.Length > 0)
            {
                this.m_printNotSoldPositionsBtn_Click(sender, e);
            }

            try
            {
                this.ShowActualSupplierInfos();

                if (_positions != null && _positions.Length > 0)
                {
                    if (ReturnPositionsForm.HandleReturn(this, this.m_supplierSelection.ActualSupplier, _positions) == DialogResult.Abort)
                    {
                        MessageBox.Show("Keine weiteren offnen Positionen gefunden!", "Rückgabe Kontrolle...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                var _soldLines = GParams.Instance.BasarCom.GetSoldPositions(this.m_supplierSelection.ActualSupplier.SupplierID);
                var _soldNotReturnedLines = GParams.Instance.BasarCom.GetSoldNotReturnedPositions(this.m_supplierSelection.ActualSupplier.SupplierID);

                if (_soldNotReturnedLines != null && _soldNotReturnedLines.Length > 0)
                {
                    this.PrintRueckgabe(new List<BizPosition>(_soldNotReturnedLines));

                    GParams.Instance.BasarCom.SetPositionsAsReturned(_soldNotReturnedLines);
                }
                else if (_soldLines != null && _soldLines.Length > 0)
                {
                    MessageBox.Show("Auszahlung bereits erfolgt ...", "Rückgabe Kontrolle...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Keine verkaufte Position gefunden ...", "Rückgabe Kontrolle...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception _ex)
            {
                MessageBox.Show(_ex.Message);
            }

            this.ShowActualSupplierInfos();
        }

        private void m_printNotSoldPositionsBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowActualSupplierInfos();

                if (this.m_notSoldPosLv.Items.Count <= 0)
                    return;

                var _tableInfo = new TablePrintDef();
                _tableInfo.AddColumn(new TablePrintDef.ColumnItem("Pos Nr.", 8.50F));
                _tableInfo.AddColumn(new TablePrintDef.ColumnItem("Kategorie", 14.50F));
                _tableInfo.AddColumn(new TablePrintDef.ColumnItem("Hersteller", 14.50F));
                _tableInfo.AddColumn(new TablePrintDef.ColumnItem("Bezeichnung", 40.50F));
                _tableInfo.AddColumn(new TablePrintDef.ColumnItem("Regel Preis", 11.00F));
                _tableInfo.AddColumn(new TablePrintDef.ColumnItem("Min. Preis", 11.00F));

                
                var _itemsToPrint = new List<ListViewItem>();
                var _returndGoodCounter = 0;
                foreach (ListViewItem _lvItem in this.m_notSoldPosLv.Items)
                {
                    if (_lvItem is NonSoldPositionLvi && ((NonSoldPositionLvi)_lvItem).DataObj.ReturnedToSupplierAt.HasValue)
                    {
                        _returndGoodCounter++;
                    }
                    else if (_lvItem is SoldPositionLvi && ((SoldPositionLvi)_lvItem).DataObj.ReturnedToSupplierAt.HasValue)
                    {
                        _returndGoodCounter++;
                    }
                    _itemsToPrint.Add(_lvItem);
                }

                if (_returndGoodCounter == _itemsToPrint.Count)
                    MessageBox.Show("Ware wurde bereits zurück gegeben...");
                else if (_returndGoodCounter > 0 && _returndGoodCounter != _itemsToPrint.Count)
                    MessageBox.Show("Ein Teil der Ware wurde bereits zurück gegeben...");

                if (_itemsToPrint.Count > 0)
                {
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
                        var _notSoldLvItem = _lvItem as NonSoldPositionLvi;

                        if (_notSoldLvItem != null)
                        {
                            var _posNoInfo = new TablePrintDef.FieldDef(_notSoldLvItem.DataObj.PositionNo.ToString());
                            var _kategorie = new TablePrintDef.FieldDef(_notSoldLvItem.DataObj.Category);
                            var _hersteller = new TablePrintDef.FieldDef(_notSoldLvItem.DataObj.Manufacturer);
                            var _bezeichnung = new TablePrintDef.FieldDef(_notSoldLvItem.DataObj.Material);
                            var _minPreis = new TablePrintDef.FieldDef(_notSoldLvItem.DataObj.PriceMin.ToString());
                            var _regelPreis = new TablePrintDef.FieldDef(_notSoldLvItem.DataObj.PriceMax.ToString());

                            _posNoInfo.StringFormat.Alignment = StringAlignment.Center;
                            _regelPreis.StringFormat.Alignment = StringAlignment.Far;
                            _minPreis.StringFormat.Alignment = StringAlignment.Far;

                            _tableInfo.AddLine(_posNoInfo,
                                                _kategorie,
                                                _hersteller,
                                                _bezeichnung,
                                                _regelPreis,
                                                _minPreis);
                        }
                        else
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
                    }


                    //PrintDocErfassung _printDocument = new PrintDocErfassung(_tableInfo);
                    var _printDocument = new PrintDocNotSoldPos(_tableInfo);
                    _printDocument.DefaultPageSettings.Landscape = true;
                    _printDocument.PrinterSettings.DefaultPageSettings.Landscape = true;

                    _printDocument.SellerAdress = new PrintDocNotSoldPos.SellerAdressElem();
                    _printDocument.SellerAdress.Id = this.m_supplierSelection.ActualSupplier.SupplierNo.ToString();
                    _printDocument.SellerAdress.Titel = this.m_supplierSelection.ActualSupplier.Salutation;
                    _printDocument.SellerAdress.VName = this.m_supplierSelection.ActualSupplier.FirstName;
                    _printDocument.SellerAdress.NName = this.m_supplierSelection.ActualSupplier.LastName;
                    _printDocument.SellerAdress.Street = this.m_supplierSelection.ActualSupplier.Adress;
                    _printDocument.SellerAdress.Zip = this.m_supplierSelection.ActualSupplier.ZIPCode;
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
            }
            catch (Exception _ex)
            {
                MessageBox.Show(_ex.Message);
            }

            this.ShowActualSupplierInfos();
        }
    }
}
