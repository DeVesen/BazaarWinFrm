using System.Windows.Forms;
using System.Drawing;

namespace DeVes.Bazaar.Client.CustControls
{
    public class DvComboBox : ComboBox
    {
        private Color m_orgBkColor;
        private bool m_isMargin;
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

        public DvComboBox()
        {
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (this.DropDownStyle != ComboBoxStyle.DropDownList)
            {
                try
                {
                    DvComboBox.AutoComplete(this, e, true);
                }
                catch
                {

                }
            }
        }

        // AutoComplete
        public static void AutoComplete(ComboBox cb, KeyPressEventArgs e, bool blnLimitToList)
        {
            var _strFindStr = "";

            if (e.KeyChar == (char)8)
            {
                if (cb.SelectionStart <= 1)
                {
                    cb.SelectedItem = null;
                    cb.Text = "";
                    return;
                }

                if (cb.SelectionLength == 0)
                    _strFindStr = cb.Text.Substring(0, cb.Text.Length - 1);
                else
                    _strFindStr = cb.Text.Substring(0, cb.SelectionStart - 1);
            }
            else
            {
                if (cb.SelectionLength == 0)
                    _strFindStr = cb.Text + e.KeyChar;
                else
                    _strFindStr = cb.Text.Substring(0, cb.SelectionStart) + e.KeyChar;
            }

            var _intIdx = -1;

            // Search the string in the ComboBox list.

            _intIdx = cb.FindString(_strFindStr);

            if (_intIdx != -1)
            {
                cb.SelectedText = "";
                cb.SelectedIndex = _intIdx;
                cb.SelectionStart = _strFindStr.Length;
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
