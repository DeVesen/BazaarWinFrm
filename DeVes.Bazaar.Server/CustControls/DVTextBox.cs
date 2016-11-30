using System;
using System.Windows.Forms;
using System.Drawing;
using DeVes.Bazaar.Data;
using System.Globalization;

namespace DeVes.Bazaar.Server.CustControls
{
    public sealed class DvTextBox : TextBox
    {
        public enum ResultTypes
        {
            String,
            Int32,
            Double,
            DateTime
        }

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

        private ResultTypes m_resultType;
        public ResultTypes ResultType
        {
            get
            {
                return this.m_resultType;
            }
            set
            {
                this.m_resultType = value;
            }
        }

        public bool IsValueLikeWish
        {
            get
            {
                var _result = true;

                switch (this.m_resultType)
                {
                    case ResultTypes.String:
                        break;
                    case ResultTypes.Int32:
                        _result = GParams.ToInt32(this.Text).HasValue;
                        break;
                    case ResultTypes.Double:
                        _result = GParams.ToDouble(this.Text).HasValue;
                        break;
                    case ResultTypes.DateTime:
                        _result = GParams.ToDateTime(this.Text).HasValue;
                        break;
                }


                return _result;
            }
        }
        public bool HasValueAndLikeWish
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Text) && !string.IsNullOrEmpty(this.Text.Trim()))
                {
                    return this.IsValueLikeWish;
                }
                return false;
            }
        }


        public int? IntValue
        {
            get
            {
                try
                {
                    return Convert.ToInt32(this.Text);
                }
                catch
                {
                    // ignored
                }
                return null;
            }
        }

        public double? DoubleValue
        {
            get
            {
                try
                {
                    return Convert.ToDouble(this.Text);
                }
                catch
                {
                    // ignored
                }
                return null;
            }
        }

        bool _allowSpace;
        public bool AllowSpace
        {
            set
            {
                this._allowSpace = value;
            }

            get
            {
                return this._allowSpace;
            }
        }


        public DvTextBox()
        {
            this.m_resultType = ResultTypes.String;
        }



        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (this.m_resultType == ResultTypes.Double || this.m_resultType == ResultTypes.Int32)
            {
                var _numberFormatInfo = CultureInfo.CurrentCulture.NumberFormat;
                var _decimalSeparator = _numberFormatInfo.NumberDecimalSeparator;
                var _groupSeparator = _numberFormatInfo.NumberGroupSeparator;
                var _negativeSign = _numberFormatInfo.NegativeSign;

                var _keyInput = e.KeyChar.ToString();

                if (Char.IsDigit(e.KeyChar))
                {
                    // Digits are OK
                }
                else if (this.m_resultType == ResultTypes.Double &&
                        (_keyInput.Equals(_decimalSeparator) || _keyInput.Equals(_groupSeparator) || _keyInput.Equals(_negativeSign)))
                {
                    // Decimal separator is OK
                }
                else if (e.KeyChar == '\b')
                {
                    // Backspace key is OK
                }
                //    else if ((ModifierKeys & (Keys.Control | Keys.Alt)) != 0)
                //    {
                //     // Let the edit control handle control and alt key combinations
                //    }
                else if (this._allowSpace && e.KeyChar == ' ')
                {

                }
                else
                {
                    // Swallow this invalid key and beep
                    e.Handled = true;
                    //    MessageBeep();
                }
            }
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                this.SelectAll();
            }

            base.OnKeyUp(e);
        }
    }
}
