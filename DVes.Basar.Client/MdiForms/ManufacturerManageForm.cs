using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DVes.Basar.Client.IBasarCom;

namespace DVes.Basar.Client.MdiForms
{
    public partial class ManufacturerManageForm : BaseMdiForm
    {
        private ManufacturerListViewItem ActualSelectedItem
        {
            get
            {
                return this.m_removeCatBtn.Tag as ManufacturerListViewItem;
            }
        }

        public ManufacturerManageForm()
        {
            InitializeComponent();
        }

        private void ManufacturerManageForm_Load(object sender, EventArgs e)
        {
            this.ReloadList();
        }

        private void m_catInputTb_Enter(object sender, EventArgs e)
        {
            this.m_removeCatBtn.Tag = null;
            this.m_removeCatBtn.Enabled = false;

            this.m_catLv.SelectedItems.Clear();
        }
        private void m_catInputTb_KeyUp(object sender, KeyEventArgs e)
        {
            this.m_addCatBtn.Enabled = !string.IsNullOrEmpty(this.m_catInputTb.Text) && !string.IsNullOrEmpty(this.m_catInputTb.Text.Trim());

            if (e.KeyCode == Keys.Return)
            {
                this.m_addCatBtn_Click(sender, e);
            }
        }

        private void m_addCatBtn_Click(object sender, EventArgs e)
        {
            if (!this.m_addCatBtn.Enabled)
                return;

            try
            {
                BizManufacturer _newManuf = new BizManufacturer();
                _newManuf.Designation = this.m_catInputTb.Text;

                bool _created = false;
                bool _createdSpec = false;

                GParams.Instance.BasarCom.ManufacturerCreate(_newManuf, out _created, out _createdSpec);

                if (_created && _createdSpec)
                {
                    this.ReloadList();

                    this.m_addCatBtn.Enabled = false;

                    this.m_catInputTb.ResetText();
                    this.m_catInputTb.Focus();
                }
                else
                {
                    MessageBox.Show("Hersteller konnte nicht erzeugt werden");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void m_removeCatBtn_Click(object sender, EventArgs e)
        {
            if (this.ActualSelectedItem != null)
            {
                try
                {
                    bool _removed = false;
                    bool _removedSpec = false;

                    GParams.Instance.BasarCom.ManufacturerRemove(this.ActualSelectedItem.DataObj.Id, out _removed, out _removedSpec);

                    if (_removed && _removedSpec)
                    {
                        this.ReloadList();
                    }
                    else
                    {
                        MessageBox.Show("Hersteller konnte nicht gelöscht werden");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void m_catLv_Click(object sender, EventArgs e)
        {
            this.m_removeCatBtn.Tag = null;
            this.m_removeCatBtn.Enabled = false;

            if (this.m_catLv.SelectedItems.Count == 1 && this.m_catLv.SelectedItems[0] is ManufacturerListViewItem)
            {
                this.m_removeCatBtn.Tag = this.m_catLv.SelectedItems[0] as ManufacturerListViewItem;
                this.m_removeCatBtn.Enabled = true;
            }
        }


        private void ReloadList()
        {
            this.m_catLv.Items.Clear();

            this.m_removeCatBtn.Tag = null;
            this.m_removeCatBtn.Enabled = false;

            try
            {
                BizManufacturer[] _manufArray = GParams.Instance.BasarCom.ManufacturerGetAll();

                if (_manufArray != null && _manufArray.Length > 0)
                {
                    foreach (BizManufacturer _manuf in _manufArray)
                    {
                        this.m_catLv.Items.Add(new ManufacturerListViewItem(_manuf));
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    class ManufacturerListViewItem : ListViewItem
    {
        public BizManufacturer DataObj { get; set; }

        public ManufacturerListViewItem(BizManufacturer manuf)
        {
            this.DataObj = manuf;

            this.Text = this.DataObj.Designation;
        }
    }
}
