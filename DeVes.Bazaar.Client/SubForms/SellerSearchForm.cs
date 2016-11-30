using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DeVes.Bazaar.Client.IBasarCom;

namespace DeVes.Bazaar.Client.SubForms
{
    public partial class SellerSearchForm : BaseSubForm
    {
        private BizSupplierer[] m_actualKnownSupl = null;

        public SellerSearchForm()
        {
            InitializeComponent();
        }

        private void SellerSearchForm_Load(object sender, EventArgs e)
        {
            this.m_takeBtn.Enabled = false;
            this.m_searchValTb.Enabled = false;
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
            catch(Exception ex)
            {
                this.m_searchValTb.Enabled = false;
                this.m_takeBtn.Enabled = false;

                MessageBox.Show(ex.Message);
            }
        }

        private void m_takeBtn_Click(object sender, EventArgs e)
        {
            if (this.m_takeBtn.Tag != null && this.m_takeBtn.Tag is SupplierLvItem)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void m_cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void m_searchValTb_TextChanged(object sender, EventArgs e)
        {
            this.ViewFilterResult();
        }

        private void m_filterResListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            SupplierLvItem _selItem = e.Item as SupplierLvItem;
            if (e.IsSelected && _selItem != null)
            {
                this.m_takeBtn.Enabled = true;
                this.m_takeBtn.Tag = _selItem;
            }
        }

        private void m_filterResListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.m_takeBtn.Tag != null && this.m_takeBtn.Tag is SupplierLvItem)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
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

        }


        public static BizSupplierer SearchSupl(IWin32Window owner)
        {
            SellerSearchForm _frm = new SellerSearchForm();
            BizSupplierer _result = null;

            if (_frm.ShowDialog(owner) == System.Windows.Forms.DialogResult.OK)
            {
                _result = ((SupplierLvItem)_frm.m_takeBtn.Tag).DataObj;
            }

            return _result;
        }
    }

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
}
