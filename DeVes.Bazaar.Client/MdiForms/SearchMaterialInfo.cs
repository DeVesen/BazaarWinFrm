using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DeVes.Bazaar.Client.IBasarCom;

namespace DeVes.Bazaar.Client.MdiForms
{
    public partial class SearchMaterialInfo : BaseMdiForm
    {
        private Timer m_initFocusTimer = null;

        public SearchMaterialInfo()
        {
            InitializeComponent();
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

        private void ResetSupplier()
        {
            this.m_supplierNoTb.ResetText();
            this.m_suplTitelTb.ResetText();
            this.m_suplNameTb.ResetText();
            this.m_suplAdressTb.ResetText();
        }
        private void ResetPositions()
        {
            this.m_posNrTb.ResetText();
            this.m_posTitelTb.ResetText();

            this.m_posCatTb.ResetText();
            this.m_herstellerTb.ResetText();

            this.m_posMaxPriceTb.ResetText();
            this.m_posMinPriceTb.ResetText();

            this.m_posDescTb.ResetText();
        }

        private void SupplierToSceen(BizSupplierer supplier)
        {
            this.m_supplierNoTb.Text = supplier.SupplierNo.ToString();
            this.m_suplTitelTb.Text = supplier.Salutation;
            this.m_suplNameTb.Text = string.Format("{0}, {1}", supplier.LastName, supplier.FirstName);
            this.m_suplAdressTb.Text = string.Format("{0}\r\n{1} {2}", supplier.Adress, supplier.ZIPCode, supplier.Town);
        }
        private void PositionsToSceen(BizPosition positionBiz)
        {
            this.m_posNrTb.Text = positionBiz.PositionNo.ToString();
            this.m_posTitelTb.Text = positionBiz.Material;

            this.m_posCatTb.Text = positionBiz.Category;
            this.m_herstellerTb.Text = positionBiz.Manufacturer;

            this.m_posMaxPriceTb.Text = positionBiz.PriceMax.ToString();
            this.m_posMinPriceTb.Text = positionBiz.PriceMin.ToString();

            this.m_posDescTb.Text = positionBiz.Memo;

            this.m_returnSellBtn.Enabled = positionBiz.SoldAt.HasValue && !positionBiz.ReturnedToSupplierAt.HasValue;
            this.m_returnSellBtn.Tag = positionBiz;
        }

        private void SearchMaterialInfo_Load(object sender, EventArgs e)
        {
            this.ResetSupplier();
            this.ResetPositions();

            this.m_posNrToFindTb.Focus();
            this.m_posNrToFindTb.SelectAll();

            this.m_initFocusTimer = new Timer();
            this.m_initFocusTimer.Interval = 250;
            this.m_initFocusTimer.Tick += new EventHandler(this.OnInitFocusTimer_Tick);
            this.m_initFocusTimer.Start();
        }

        private void OnInitFocusTimer_Tick(object sender, EventArgs e)
        {
            this.m_initFocusTimer.Stop();
            this.m_initFocusTimer.Tick -= new EventHandler(this.OnInitFocusTimer_Tick);
            this.m_initFocusTimer.Dispose();
            this.m_initFocusTimer = null;

            this.m_posNrToFindTb.Focus();
            this.m_posNrToFindTb.SelectAll();
        }

        private void m_posNrToFindTb_KeyUp(object sender, KeyEventArgs e)
        {
            if (sender == this.m_posNrToFindTb && e.KeyCode == Keys.Escape)
            {
                this.m_posNrToFindTb.ResetText();

                this.ResetBadMsg();
                this.ResetSupplier();
                this.ResetPositions();

                this.m_posNrToFindTb.Focus();
                this.m_posNrToFindTb.SelectAll();
            }
            else if (sender == this.m_posNrToFindTb && e.KeyCode == Keys.Return)
            {
                e.Handled = true;

                this.ResetBadMsg();
                this.ResetSupplier();
                this.ResetPositions();

                if (!GParams.ToInt32(this.m_posNrToFindTb.Text).HasValue)
                {
                    this.SetBadMsg("Fehlerhafte Eingabe");
                    this.m_posNrToFindTb.Focus();
                    this.m_posNrToFindTb.SelectAll();
                    return;
                }

                int _positionNo = GParams.ToInt32(this.m_posNrToFindTb.Text).Value;
                BizPosition _posToSell = GParams.Instance.BasarCom.PositionGet(_positionNo, true);

                if (_posToSell == null)
                {
                    this.SetBadMsg("Nummer nicht als Position bekannt!");
                    this.m_posNrToFindTb.Focus();
                    this.m_posNrToFindTb.SelectAll();
                    return;
                }

                this.PositionsToSceen(_posToSell);

                SetGoodMsg("Position gefunden...");

                BizSupplierer _supplierBiz = GParams.Instance.BasarCom.SupplierGet_ByID(_posToSell.SupplierId);

                if (_supplierBiz == null)
                {
                    this.SetBadMsg("Lieferant nicht gefunden!");
                    this.m_posNrToFindTb.Focus();
                    this.m_posNrToFindTb.SelectAll();
                    return;
                }

                this.SupplierToSceen(_supplierBiz);

                SetGoodMsg("Lieferant und Position gefunden...");

                this.m_posNrToFindTb.Focus();
                this.m_posNrToFindTb.SelectAll();
            }
        }

        private void m_returnSellBtn_Click(object sender, EventArgs e)
        {
            BizPosition _position = this.m_returnSellBtn.Tag as BizPosition;

            if (_position != null && _position.SoldAt.HasValue && !_position.ReturnedToSupplierAt.HasValue)
            {
                _position.SoldAt = null;
                _position.SoldFor = null;


                bool _result = false;
                bool _resultIsSep = false;
                GParams.Instance.BasarCom.PositionUpdate(_position, out _result, out _resultIsSep);

                if (_result && _resultIsSep)
                {
                    PlayGoodSound();
                    MessageBox.Show("Position wurde freigegeben...");
                }
                else
                {
                    PlayBadSound();
                    MessageBox.Show("Position konnte nicht freigegeben werden...");
                }

                this.m_posNrToFindTb_KeyUp(this.m_posNrToFindTb, new KeyEventArgs(Keys.Return));
            }
        }
    }
}
