﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DVes.Basar.Client.IBasarCom;

namespace DVes.Basar.Client.SubForms
{
    public partial class NewSellerform : BaseSubForm
    {
        public NewSellerform()
        {
            InitializeComponent();
        }

        private bool CheckIfValid()
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

        private void m_takeBtn_Click(object sender, EventArgs e)
        {
            if (this.CheckIfValid())
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




        public static BizSupplierer EnterNewSupplier(IWin32Window owner)
        {
            NewSellerform _frm = new NewSellerform();
            BizSupplierer _result = null;

            if (_frm.ShowDialog(owner) == DialogResult.OK)
            {
                _result = new BizSupplierer();

                _result.Salutation = _frm.m_sellerTitelCb.Text;
                _result.LastName = _frm.m_sellerNameTb.Text;
                _result.FirstName = _frm.m_sellerVNameTb.Text;

                _result.Adress = _frm.m_sellerStreetTb.Text;
                _result.ZIPCode = _frm.m_sellerZipTb.Text;
                _result.Town = _frm.m_sellerTownTb.Text;

                _result.Phone01 = _frm.m_sellerPhoneTb.Text;

                _result.Memo = _frm.m_sellerDescRtb.Text;
            }

            return _result;
        }
    }
}
