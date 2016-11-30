﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DVes.Basar.Client.SubForms
{
    public partial class InputTextForm : BaseSubForm
    {
        private InputTextForm()
        {
            InitializeComponent();
        }

        private void OnBtnClick(object sender, EventArgs e)
        {
            if (sender == this.m_addValueBtn)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            }
            else if (sender == this.m_cancelActionBtn)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.No;
            }
            else
            {
                return;
            }

            this.Close();
        }


        public static bool RequestInput(IWin32Window owner, string label, ref string value)
        {
            return InputTextForm.RequestInput(owner, string.Empty, label, ref value);
        }
        public static bool RequestInput(IWin32Window owner, string titel, string label, ref string value)
        {
            InputTextForm _form = new InputTextForm();
            bool _result = false;

            _form.Text = titel;
            _form.label1.Text = label;
            _form.textBox1.Text = value;

            if (_form.ShowDialog(owner) == DialogResult.Yes)
            {
                _result = true;
                value = _form.textBox1.Text;
            }

            _form.Dispose();
            _form = null;

            return _result;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.KeyCode == Keys.Return)
            {
                this.OnBtnClick(this.m_addValueBtn, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.OnBtnClick(this.m_cancelActionBtn, e);
            }
        }
    }
}