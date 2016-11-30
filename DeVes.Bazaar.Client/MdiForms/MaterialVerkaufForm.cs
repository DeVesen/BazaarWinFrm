using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DeVes.Bazaar.Client.IBasarCom;
using BHApp.Printing;

namespace DeVes.Bazaar.Client.MdiForms
{
    public partial class MaterialVerkaufForm : BaseMdiForm
    {
        public class PositionLvi : ListViewItem
        {
            public BizPosition DataObj { get; set; }

            public PositionLvi(BizPosition position)
            {
                this.DataObj = position;

                this.Text = position.PositionNo.ToString();
                this.SubItems.Add(position.Material);
                this.SubItems.Add(position.SoldFor.ToString());
            }
        }

        private BizPosition ActualToSellPosition
        {
            get
            {
                return this.m_positonNoTb.Tag as BizPosition;
            }
        }

        public MaterialVerkaufForm()
        {
            InitializeComponent();

            this.SetOnKeyUpEvent(this.Controls);

            this.DeActivateConfirmPosMode();
        }


        private void MaterialVerkaufForm_Load(object sender, EventArgs e)
        {
            this.SetTotalMoneySum();
        }


        private void OnCtrlKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (this.ActualToSellPosition != null)
                {
                    this.m_cancelPositionBtn_Click(sender, e);
                }
                else
                {
                    this.m_clearCellPositonsBtn_Click(sender, e);
                }
            }
            else if (e.KeyCode == Keys.F4 && this.ActualToSellPosition != null)
            {
                if (this.m_sellMinPriceBtn.Enabled)
                {
                    this.OnConfirmSellPosBtn(this.m_sellMinPriceBtn, e);
                }
            }
            else if (e.KeyCode == Keys.F5 && this.ActualToSellPosition != null)
            {
                if (this.m_sellMaxPriceBtn.Enabled)
                {
                    this.OnConfirmSellPosBtn(this.m_sellMaxPriceBtn, e);
                }
            }
            else if (e.KeyCode == Keys.F9 && this.m_confirmSellBtn.Enabled)
            {
                this.m_confirmSellBtn_Click(this.m_sellMaxPriceBtn, e);
            }
            else if (sender == this.m_positonNoTb && !this.m_positonNoTb.ReadOnly)
            {
                this.DeActivateConfirmPosMode();

                if (e.KeyCode == Keys.Return)
                {
                    this.ResetBadMsg();

                    try
                    {
                        if (!string.IsNullOrEmpty(this.m_positonNoTb.Text) &&
                            GParams.ToInt32(this.m_positonNoTb.Text).HasValue)
                        {
                            var _positionNo = GParams.ToInt32(this.m_positonNoTb.Text).Value;

                            if (!this.IsPositionAlreadyInList(_positionNo))
                            {
                                var _posToSell =
                                    GParams.Instance.BasarCom.PositionGet(_positionNo, true);

                                var _isSold = _posToSell != null && _posToSell.SoldAt.HasValue && _posToSell.SoldAtSpecified;

                                if (_posToSell != null && !_isSold)
                                {
                                    this.ActivateConfirmPosMode(_posToSell);

                                    this.m_positonNoTb.ReadOnly = true;

                                    this.SetGoodMsg("Position akzeptiert, Bitte Preis wählen...");
                                }
                                else if (_posToSell != null && _isSold)
                                {
                                    this.SetBadMsg("Position bereits verkauft...");

                                    this.DeActivateConfirmPosMode();

                                    this.m_positonNoTb.Focus();
                                    this.m_positonNoTb.SelectAll();
                                }
                                else
                                {
                                    this.SetBadMsg("Position nicht bekannt");

                                    this.DeActivateConfirmPosMode();

                                    this.m_positonNoTb.Focus();
                                    this.m_positonNoTb.SelectAll();
                                }
                            }
                            else
                            {
                                this.SetBadMsg("Position bereits in Liste");

                                this.DeActivateConfirmPosMode();

                                this.m_positonNoTb.Focus();
                                this.m_positonNoTb.SelectAll();
                            }
                        }
                    }
                    catch (Exception _ex)
                    {
                        this.SetBadMsg(_ex.Message);
                    }
                }
            }
        }
        
        private void OnConfirmSellPosBtn(object sender, EventArgs e)
        {
            if (this.ActualToSellPosition == null)
            {
                this.m_cancelPositionBtn_Click(sender, e);
                return;
            }

            if (sender == this.m_sellMinPriceBtn)
            {
                this.ActualToSellPosition.SoldFor = this.ActualToSellPosition.PriceMin;
                this.ActualToSellPosition.SoldForSpecified = true;
            }
            else if (sender == this.m_sellMaxPriceBtn)
            {
                this.ActualToSellPosition.SoldFor = this.ActualToSellPosition.PriceMax;
                this.ActualToSellPosition.SoldForSpecified = true;
            }
            else
            {
                this.m_cancelPositionBtn_Click(sender, e);
                return;
            }

            this.m_matlPosLv.Items.Add(new PositionLvi(this.ActualToSellPosition));
            this.SetTotalMoneySum();

            this.PlayConfirmedSound();

            this.m_cancelPositionBtn_Click(sender, e);
        }

        private void m_cancelPositionBtn_Click(object sender, EventArgs e)
        {
            this.DeActivateConfirmPosMode();

            this.m_positonNoTb.ReadOnly = false;
            this.m_positonNoTb.ResetText();
            this.m_positonNoTb.Focus();

            this.ResetBadMsg();
        }

        private void m_clearCellPositonsBtn_Click(object sender, EventArgs e)
        {
            this.m_matlPosLv.Items.Clear();
            this.SetTotalMoneySum();
            this.m_cancelPositionBtn_Click(sender, e);
        }

        private void m_confirmSellBtn_Click(object sender, EventArgs e)
        {
            if (this.m_matlPosLv.Items.Count <= 0)
                return;

            var _posNoToLine = new Dictionary<int, ListViewItem>();
            var _positionsToConfirm = new List<BizPosition>();

            foreach (ListViewItem _lvItem in this.m_matlPosLv.Items)
            {
                var _posItem = _lvItem as PositionLvi;
                if (_posItem != null)
                {
                    _posNoToLine[_posItem.DataObj.PositionNo] = _posItem;
                    _positionsToConfirm.Add(_posItem.DataObj);
                }
            }


            if (_positionsToConfirm.Count > 0)
            {
                try
                {
                    var _sellResult = GParams.Instance.BasarCom.PositionSell(_positionsToConfirm.ToArray());

                    if (_sellResult != null && _sellResult.NotSoldPosReason != null && _sellResult.NotSoldPosReason.Length > 0)
                    {
                        var _notFound = 0;
                        var _meanSold = 0;
                        var _meanReturned = 0;

                        foreach (var _reasons in _sellResult.NotSoldPosReason)
                        {
                            switch (_reasons)
                            {
                                case PositionSellResultNotSoldPosReasonTypes.MeanTimeChanged:
                                    break;
                                case PositionSellResultNotSoldPosReasonTypes.MeanTimeSold:
                                    _meanSold++;
                                    break;
                                case PositionSellResultNotSoldPosReasonTypes.MeanTimeReturned:
                                    _meanReturned++;
                                    break;
                                case PositionSellResultNotSoldPosReasonTypes.NotFound:
                                    _notFound++;
                                    break;
                            }
                        }

                        var _sb = new StringBuilder();
                        _sb.AppendFormat("{0} \t nicht gefunden\n", _notFound);
                        _sb.AppendFormat("{0} \t zwischenzeitlich verkauft\n", _meanSold);
                        _sb.AppendFormat("{0} \t zwischenzeitlich zurückgegeben\n", _meanReturned);

                        MessageBox.Show(_sb.ToString());
                    }

                    if (_sellResult != null && _sellResult.SoldPositions != null && _sellResult.SoldPositions.Length > 0)
                    {
                        #region . Drucken .

                        var _priceSum = 0.0;
                        var _tableInfo = new TablePrintDef();
                        _tableInfo.AddColumn(new TablePrintDef.ColumnItem("Pos Nr.", 10.60F));
                        _tableInfo.AddColumn(new TablePrintDef.ColumnItem("Kategorie", 15.00F));
                        _tableInfo.AddColumn(new TablePrintDef.ColumnItem("Hersteller", 15.00F));
                        _tableInfo.AddColumn(new TablePrintDef.ColumnItem("Bezeichnung", 47.50F));
                        _tableInfo.AddColumn(new TablePrintDef.ColumnItem("Preis", 11.90F));

                        foreach (var _soldPosition in _sellResult.SoldPositions)
                        {
                            if (_posNoToLine.ContainsKey(_soldPosition.PositionNo))
                            {
                                this.m_matlPosLv.Items.Remove(_posNoToLine[_soldPosition.PositionNo]);
                            }

                            _tableInfo.AddLine(new TablePrintDef.FieldDef(_soldPosition.PositionNo.ToString()),
                                                new TablePrintDef.FieldDef(_soldPosition.Category),
                                                new TablePrintDef.FieldDef(_soldPosition.Manufacturer),
                                                new TablePrintDef.FieldDef(_soldPosition.Material),
                                                new TablePrintDef.FieldDef(_soldPosition.SoldFor.Value.ToString()));

                            if (_soldPosition.SoldFor.HasValue)
                                _priceSum += _soldPosition.SoldFor.Value;
                        }

                        var _sumTextObj = new TablePrintDef.FieldDef("Summe:");
                        var _sumValueObj = new TablePrintDef.FieldDef(_priceSum.ToString());
                        _sumTextObj.Font = new Font("ARIAL", 13, FontStyle.Bold | FontStyle.Underline);
                        _sumValueObj.Font = new Font("ARIAL", 13, FontStyle.Bold | FontStyle.Underline);
                        _tableInfo.AddLine(_sumTextObj,
                                            new TablePrintDef.FieldDef(string.Empty),
                                            new TablePrintDef.FieldDef(string.Empty),
                                            new TablePrintDef.FieldDef(string.Empty),
                                            _sumValueObj);


                        var _printDocument = new PrintDocVerkauf(_tableInfo);
                        _printDocument.DefaultPageSettings.Landscape = true;
                        _printDocument.PrinterSettings.DefaultPageSettings.Landscape = true;

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

                        #endregion . Drucken .
                    }
                }
                catch(Exception _ex)
                {
                    MessageBox.Show(_ex.Message);
                }
            }

            this.m_cancelPositionBtn_Click(sender, e);
        }


        private void ResetBadMsg()
        {
            this.m_badScanLb.ResetText();
            this.m_badScanLb.BackColor = Color.Transparent;
        }
        private void SetBadMsg(string msg)
        {
            this.m_badScanLb.Text = msg;
            this.m_badScanLb.BackColor = Color.FromArgb(150, Color.Red);

            this.PlayBadSound();
        }
        private void SetGoodMsg(string msg)
        {
            this.m_badScanLb.Text = msg;
            this.m_badScanLb.BackColor = Color.FromArgb(150, Color.Green);

            this.PlayGoodSound();
        }

        private void SetOnKeyUpEvent(Control.ControlCollection controls)
        {
            foreach (Control _ctrl in controls)
            {
                _ctrl.KeyUp += new KeyEventHandler(this.OnCtrlKeyUp);

                if (_ctrl is GroupBox)
                {
                    this.SetOnKeyUpEvent(((GroupBox)_ctrl).Controls);
                }
            }
        }

        private void ActivateConfirmPosMode(BizPosition position)
        {
            this.m_positonNoTb.Tag = position;

            if (position.PriceMin.HasValue && position.PriceMinSpecified)
            {
                this.m_sellMinPriceBtn.Enabled = position != null;
                this.m_sellMinPriceBtn.Text = string.Format(this.m_sellMinPriceBtn.Tag.ToString(), position.PriceMin);
            }

            if (position.PriceMaxSpecified)
            {
                this.m_sellMaxPriceBtn.Enabled = position != null;
                this.m_sellMaxPriceBtn.Text = string.Format(this.m_sellMaxPriceBtn.Tag.ToString(), position.PriceMax);
            }
        }
        private void DeActivateConfirmPosMode()
        {
            this.m_positonNoTb.Tag = null;
            this.m_sellMinPriceBtn.Enabled = false;
            this.m_sellMaxPriceBtn.Enabled = false;

            this.m_sellMinPriceBtn.Text = null;
            this.m_sellMaxPriceBtn.Text = null;
        }

        private void SetTotalMoneySum()
        {
            double _qty = 0.0F;

            this.m_qtySum.Text = "0,00";

            foreach (ListViewItem _lvItem in this.m_matlPosLv.Items)
            {
                var _posItem = _lvItem as PositionLvi;
                if (_posItem != null)
                {
                    _qty += _posItem.DataObj.SoldFor.Value;
                }
            }

            this.m_clearCellPositonsBtn.Enabled = this.m_matlPosLv.Items.Count > 0;
            this.m_confirmSellBtn.Enabled = this.m_matlPosLv.Items.Count > 0;
            this.m_qtySum.Text = _qty.ToString();
        }

        private bool IsPositionAlreadyInList(int positionNo)
        {
            foreach (ListViewItem _lvItem in this.m_matlPosLv.Items)
            {
                var _posItem = _lvItem as PositionLvi;

                if (_posItem != null && _posItem.DataObj.PositionNo == positionNo)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
