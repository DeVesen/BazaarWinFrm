using System;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;

namespace DeVes.Bazaar.Client.CustControls
{
    public class DvTextBox : TextBox
    {
        private static Color _isMandatoryColor = Color.Orange;

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
                return m_isMargin;
            }
            set
            {
                m_isMargin = value;

                if (value)
                {
                    m_orgBkColor = BackColor;
                    BackColor = _isMandatoryColor;
                }
                else
                {
                    BackColor = m_orgBkColor;
                }
            }
        }

        private ResultTypes m_resultType;
        public ResultTypes ResultType
        {
            get
            {
                return m_resultType;
            }
            set
            {
                m_resultType = value;
            }
        }

        public bool IsValueLikeWish
        {
            get
            {
                var _result = true;

                switch (m_resultType)
                {
                    case ResultTypes.String:
                        _result = true;
                        break;
                    case ResultTypes.Int32:
                        _result = GParams.ToInt32(Text).HasValue;
                        break;
                    case ResultTypes.Double:
                        _result = GParams.ToDouble(Text).HasValue;
                        break;
                    case ResultTypes.DateTime:
                        _result = GParams.ToDateTime(Text).HasValue;
                        break;
                }


                return _result;
            }
        }
        public bool HasValueAndLikeWish
        {
            get
            {
                if (!string.IsNullOrEmpty(Text) && !string.IsNullOrEmpty(Text.Trim()))
                {
                    return IsValueLikeWish;
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
                    return Convert.ToInt32(Text);
                }
                catch
                {

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
                    return Convert.ToDouble(Text);
                }
                catch
                {

                }
                return null;
            }
        }

        bool _allowSpace;
        public bool AllowSpace
        {
            set
            {
                _allowSpace = value;
            }

            get
            {
                return _allowSpace;
            }
        }


        public DvTextBox()
        {
            m_resultType = ResultTypes.String;
        }


        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (m_resultType == ResultTypes.Double || m_resultType == ResultTypes.Int32)
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
                else if (m_resultType == ResultTypes.Double &&
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
                else if (_allowSpace && e.KeyChar == ' ')
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

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            if (m_isMargin)
            {
                BackColor = string.IsNullOrWhiteSpace(Text) ? _isMandatoryColor : m_orgBkColor;
            }
        }
    }
}
