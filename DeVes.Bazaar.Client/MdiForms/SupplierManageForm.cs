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
    public partial class SupplierManageForm : BaseMdiForm
    {
        class SupplierLvItem : ListViewItem
        {
            public BizSupplierer DataObj { get; set; }

            public SupplierLvItem(BizSupplierer supl)
            {
                this.DataObj = supl;

                this.Text = supl.SupplierNo.ToString();
                this.SubItems.Add(supl.Salutation);
                this.SubItems.Add(supl.LastName + ", " + supl.FirstName);
                this.SubItems.Add(supl.Adress);
                this.SubItems.Add(supl.ZIPCode);
                this.SubItems.Add(supl.Town);
            }
        }

        private SupplierLvItem ActiveSupplierLv
        {
            get
            {
                return this.m_supplierInfoGb.Tag as SupplierLvItem;
            }
        }

        private BizSupplierer[] m_actualKnownSupl = null;

        public SupplierManageForm()
        {
            InitializeComponent();

            this.ResetSupplArea();
        }

        private void SupplierManageForm_Load(object sender, EventArgs e)
        {
            this.ReLoadSupplList();
        }

        private void m_searchValTb_TextChanged(object sender, EventArgs e)
        {
            this.ViewFilterResult();
        }

        private void m_filterResListView_DoubleClick(object sender, EventArgs e)
        {
            if (this.m_filterResListView.SelectedItems.Count == 1 &&
                this.m_filterResListView.SelectedItems[0] is SupplierLvItem)
            {
                this.SetActiveSupplier(this.m_filterResListView.SelectedItems[0] as SupplierLvItem);
            }
            else
            {
                this.ResetSupplArea();
            }
        }

        private void m_cancelBtn_Click(object sender, EventArgs e)
        {
            this.ResetSupplArea();

            this.ReLoadSupplList();
        }

        private void m_updateBtn_Click(object sender, EventArgs e)
        {
            if (!this.HasMinInformations() || this.ActiveSupplierLv == null)
                return;

            BizSupplierer _supplierBiz = this.ActiveSupplierLv.DataObj;

            _supplierBiz.Salutation = this.m_sellerTitelCb.Text;
            _supplierBiz.LastName = this.m_sellerNameTb.Text;
            _supplierBiz.FirstName = this.m_sellerVNameTb.Text;
            _supplierBiz.Adress = this.m_sellerStreetTb.Text;
            _supplierBiz.ZIPCode = this.m_sellerZipTb.Text;
            _supplierBiz.Town = this.m_sellerTownTb.Text;
            _supplierBiz.Phone01 = this.m_sellerPhoneTb.Text;
            _supplierBiz.Memo = this.m_sellerDescRtb.Text;

            try
            {
                bool _updated = false;
                bool _updatedSpecified = false;

                GParams.Instance.BasarCom.SupplierUpdate(_supplierBiz, out _updated, out _updatedSpecified);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.ResetSupplArea();

            this.ReLoadSupplList();
        }

        private void m_removeBtn_Click(object sender, EventArgs e)
        {
            if (this.ActiveSupplierLv != null)
            {
                if (MessageBox.Show("Lieferant wirklich löschen?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        bool _removed = false;
                        bool _removedSpecified = false;

                        GParams.Instance.BasarCom.SupplierRemove(this.ActiveSupplierLv.DataObj.SupplierID, out _removed, out _removedSpecified);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            this.ResetSupplArea();

            this.ReLoadSupplList();
        }


        protected override void Onctrl_KeyUp(object sender, KeyEventArgs e)
        {
            this.ResetSupplArea();
            this.ReLoadSupplList();
        }


        private bool HasMinInformations()
        {
            bool _result = true;

            _result = (_result && !string.IsNullOrEmpty(this.m_sellerTitelCb.Text));
            _result = _result && (!string.IsNullOrEmpty(this.m_sellerNameTb.Text) || !this.m_sellerNameTb.IsMargin);
            _result = _result && (!string.IsNullOrEmpty(this.m_sellerVNameTb.Text) || !this.m_sellerVNameTb.IsMargin);

            _result = _result && (!string.IsNullOrEmpty(this.m_sellerStreetTb.Text) || !this.m_sellerStreetTb.IsMargin);
            _result = _result && (!string.IsNullOrEmpty(this.m_sellerZipTb.Text) || !this.m_sellerZipTb.IsMargin);
            _result = _result && (!string.IsNullOrEmpty(this.m_sellerTownTb.Text) || !this.m_sellerTownTb.IsMargin);

            _result = _result && (!string.IsNullOrEmpty(this.m_sellerPhoneTb.Text) || !this.m_sellerPhoneTb.IsMargin);

            return _result;
        }

        private void ResetSupplArea()
        {
            this.m_sellerTitelCb.SelectedIndex = -1;
            this.m_sellerNameTb.ResetText();
            this.m_sellerVNameTb.ResetText();
            this.m_sellerStreetTb.ResetText();
            this.m_sellerZipTb.ResetText();
            this.m_sellerTownTb.ResetText();
            this.m_sellerPhoneTb.ResetText();
            this.m_sellerDescRtb.ResetText();

            this.m_supplierInfoGb.Enabled = false;

            this.m_cancelBtn.Enabled = false;
            this.m_updateBtn.Enabled = false;
            this.m_removeBtn.Enabled = false;
        }
        private void SetActiveSupplier(SupplierLvItem supplierLv)
        {
            this.m_supplierInfoGb.Tag = supplierLv;
            if (this.ActiveSupplierLv == null)
            {
                this.ResetSupplArea();
                return;
            }

            this.m_sellerTitelCb.SelectedIndex = this.m_sellerTitelCb.FindStringExact(supplierLv.DataObj.Salutation);
            this.m_sellerNameTb.Text = supplierLv.DataObj.LastName;
            this.m_sellerVNameTb.Text = supplierLv.DataObj.FirstName;
            this.m_sellerStreetTb.Text = supplierLv.DataObj.Adress;
            this.m_sellerZipTb.Text = supplierLv.DataObj.ZIPCode;
            this.m_sellerTownTb.Text = supplierLv.DataObj.Town;
            this.m_sellerPhoneTb.Text = supplierLv.DataObj.Phone01;
            this.m_sellerDescRtb.Text = supplierLv.DataObj.Memo;

            this.m_supplierInfoGb.Enabled = true;

            this.m_cancelBtn.Enabled = true;
            this.m_updateBtn.Enabled = true;
            this.m_removeBtn.Enabled = true;
        }

        private void ReLoadSupplList()
        {
            this.m_searchValTb.ResetText();

            try
            {
                this.m_actualKnownSupl = GParams.Instance.BasarCom.SupplierGetAll();
                GParams.Instance.DisposeCom();
                if (this.m_actualKnownSupl != null)
                {
                    this.m_searchValTb.Enabled = true;
                    this.ViewFilterResult();
                }
                else
                {
                    this.m_searchValTb.Enabled = false;
                    MessageBox.Show("Keine Verkäufer gefunden!");
                }
            }
            catch (Exception ex)
            {
                this.m_searchValTb.Enabled = false;

                MessageBox.Show(ex.Message);
            }
        }
        private void ViewFilterResult()
        {
            this.m_filterResListView.Items.Clear();

            if (!string.IsNullOrEmpty(this.m_searchValTb.Text))
            {

                var _qResult =
                    from a in m_actualKnownSupl
                    where (a.LastName.ToLower().IndexOf(this.m_searchValTb.Text) >= 0 || a.FirstName.ToLower().IndexOf(this.m_searchValTb.Text) >= 0)
                    select a;

                foreach (BizSupplierer _supl in _qResult)
                {
                    this.m_filterResListView.Items.Add(new SupplierLvItem(_supl));
                }
            }
            else
            {
                foreach (BizSupplierer _supl in m_actualKnownSupl)
                {
                    this.m_filterResListView.Items.Add(new SupplierLvItem(_supl));
                }
            }

            this.m_filterResListView.Refresh();
        }
    }
}
