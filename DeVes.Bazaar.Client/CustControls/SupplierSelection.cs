using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DeVes.Bazaar.Client.IBasarCom;
using DeVes.Bazaar.Client.SubForms;

namespace DeVes.Bazaar.Client.CustControls
{
    public partial class SupplierSelection : UserControl
    {
        public delegate void OnSupplierSet(object sender, SupplierSetArgs e);
        public event OnSupplierSet SupplierSet = null;

        public bool ViewSupplierAdd
        {
            get
            {
                return this.m_newSellerBtn.Visible;
            }
            set
            {
                this.m_newSellerBtn.Visible = value;
            }
        }

        public BizSupplierer ActualSupplier
        {
            get
            {
                return this.m_supplierInfoGb.Tag as BizSupplierer;
            }
        }

        public SupplierSelection()
        {
            InitializeComponent();
        }

        private void m_supplierNoTb_KeyUp(object sender, KeyEventArgs e)
        {
            if (sender == this.m_supplierNoTb && e.KeyCode == Keys.Return)
            {
                if (!string.IsNullOrEmpty(this.m_supplierNoTb.Text) && !string.IsNullOrEmpty(this.m_supplierNoTb.Text.Trim()) &&
                    GParams.ToInt32(this.m_supplierNoTb.Text).HasValue)
                {
                    try
                    {
                        this.SetActualSupplier(GParams.Instance.BasarCom.SupplierGet_No(GParams.ToInt32(this.m_supplierNoTb.Text).Value, true));
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    this.Reset();
                }
            }
        }

        private void m_searchSellerBtn_Click(object sender, EventArgs e)
        {
            this.SetActualSupplier(SellerSearchForm.SearchSupl(this));

            this.m_supplierNoTb.Focus();
            this.m_supplierNoTb.SelectAll();
        }

        private void m_newSellerBtn_Click(object sender, EventArgs e)
        {
            this.Reset();

            try
            {
                BizSupplierer _supplier = NewSellerform.EnterNewSupplier(this);
                if (_supplier != null)
                {
                    _supplier.SupplierID = GParams.Instance.BasarCom.SupplierCreate(_supplier);
                    if (!string.IsNullOrEmpty(_supplier.SupplierID))
                    {
                        _supplier = GParams.Instance.BasarCom.SupplierGet_ByID(_supplier.SupplierID);
                        if (_supplier != null)
                        {
                            this.SetActualSupplier(_supplier);
                        }
                        else
                        {
                            this.Reset();
                            MessageBox.Show("Fehler beim erstellen");

                            this.m_supplierNoTb.Focus();
                            this.m_supplierNoTb.SelectAll();
                        }
                    }
                    else
                    {
                        this.Reset();
                        MessageBox.Show("Fehler beim erstellen");

                        this.m_supplierNoTb.Focus();
                        this.m_supplierNoTb.SelectAll();
                    }
                    GParams.Instance.DisposeCom();
                }
                else
                {
                    this.m_supplierNoTb.Focus();
                    this.m_supplierNoTb.SelectAll();
                }
            }
            catch (Exception ex)
            {
                this.Reset();
                MessageBox.Show(ex.Message);

                this.m_supplierNoTb.Focus();
                this.m_supplierNoTb.SelectAll();
            }
        }

        private void m_changeBtn_Click(object sender, EventArgs e)
        {

        }

        private void SetActualSupplier(BizSupplierer supplier)
        {
            this.Reset();

            if (supplier != null)
            {
                this.m_supplierInfoGb.Tag = supplier;

                this.m_supplierNoTb.Text = supplier.SupplierNo.ToString();
                this.m_suplTitelTb.Text = supplier.Salutation;
                this.m_suplNameTb.Text = string.Format("{0}, {1}", supplier.LastName, supplier.FirstName);
                this.m_suplAdressTb.Text = string.Format("{0}\r\n{1} {2}", supplier.Adress, supplier.ZIPCode, supplier.Town);

                this.m_returnedTb.Text = "Rückgabe am / um:   " + supplier.ReturnedToSupplier.ToString();
                this.m_returnedTb.Visible = supplier.ReturnedToSupplier.HasValue;
            }

            if (this.SupplierSet != null)
            {
                this.SupplierSet(this, new SupplierSetArgs(this.ActualSupplier));
            }
        }

        public void Reset()
        {
            this.m_supplierInfoGb.Tag = null;

            this.m_supplierNoTb.ResetText();
            this.m_suplTitelTb.ResetText();
            this.m_suplNameTb.ResetText();
            this.m_suplAdressTb.ResetText();

            if (this.SupplierSet != null)
            {
                this.SupplierSet(this, new SupplierSetArgs(this.ActualSupplier));
            }

            this.Focus();
        }
    }

    public class SupplierSetArgs : EventArgs
    {
        public BizSupplierer Supplier { get; set; }

        public SupplierSetArgs(BizSupplierer supplier)
        {
            this.Supplier = supplier;
        }
    }
}
