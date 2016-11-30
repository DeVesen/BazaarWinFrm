using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace DVes.Barsar.ClientExt.CustControls
{
    public class DVComboBox : ComboBox
    {
        private Color m_orgBkColor;
        private bool m_isMargin = false;
        public bool IsMargin
        {
            get
            {
                return this.m_isMargin;
            }
            set
            {
                this.m_isMargin = value;

                if (value)
                {
                    this.m_orgBkColor = this.BackColor;
                    this.BackColor = Color.PapayaWhip;
                }
                else
                {
                    this.BackColor = this.m_orgBkColor;
                }
            }
        }

        public DVComboBox()
        {
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            DVComboBox.AutoComplete(this, e, true);
        }

        // AutoComplete
        public static void AutoComplete(ComboBox cb, System.Windows.Forms.KeyPressEventArgs e, bool blnLimitToList)
        {
            string strFindStr = "";

            if (e.KeyChar == (char)8)
            {
                if (cb.SelectionStart <= 1)
                {
                    cb.SelectedItem = null;
                    cb.Text = "";
                    return;
                }

                if (cb.SelectionLength == 0)
                    strFindStr = cb.Text.Substring(0, cb.Text.Length - 1);
                else
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart - 1);
            }
            else
            {
                if (cb.SelectionLength == 0)
                    strFindStr = cb.Text + e.KeyChar;
                else
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart) + e.KeyChar;
            }

            int intIdx = -1;

            // Search the string in the ComboBox list.

            intIdx = cb.FindString(strFindStr);

            if (intIdx != -1)
            {
                cb.SelectedText = "";
                cb.SelectedIndex = intIdx;
                cb.SelectionStart = strFindStr.Length;
                cb.SelectionLength = cb.Text.Length;
                e.Handled = true;
            }
            else
            {
                e.Handled = blnLimitToList;
            }

        }
    }

    public class DvComboBoxItem
    {
        public string Key { get; set; }
        public string DisplayText { get; set; }
        public object Tag { get; set; }

        public DvComboBoxItem(string displayText)
            : this(null, displayText, null)
        {

        }
        public DvComboBoxItem(string key, string displayText)
            : this(key, displayText, null)
        {

        }
        public DvComboBoxItem(string key, string displayText, object tag)
        {
            this.Key = key;
            this.DisplayText = displayText;
            this.Tag = tag;
        }

        public override string ToString()
        {
            return this.DisplayText;
        }
    }
}
