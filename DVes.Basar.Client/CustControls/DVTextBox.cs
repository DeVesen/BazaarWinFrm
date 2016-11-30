using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;

namespace DVes.Basar.Client.CustControls
{
    public class DVTextBox : TextBox
    {
        public enum ResultTypes
        {
            String,
            Int32,
            Double,
            DateTime
        }

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
                bool _result = true;

                switch (this.m_resultType)
                {
                    case ResultTypes.String:
                        _result = true;
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

                }
                return null;
            }
        }

        bool allowSpace = false;
        public bool AllowSpace
        {
            set
            {
                this.allowSpace = value;
            }

            get
            {
                return this.allowSpace;
            }
        }


        public DVTextBox()
        {
            this.m_resultType = ResultTypes.String;
        }



        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (this.m_resultType == ResultTypes.Double || this.m_resultType == ResultTypes.Int32)
            {
                NumberFormatInfo numberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
                string decimalSeparator = numberFormatInfo.NumberDecimalSeparator;
                string groupSeparator = numberFormatInfo.NumberGroupSeparator;
                string negativeSign = numberFormatInfo.NegativeSign;

                string keyInput = e.KeyChar.ToString();

                if (Char.IsDigit(e.KeyChar))
                {
                    // Digits are OK
                }
                else if (this.m_resultType == ResultTypes.Double &&
                        (keyInput.Equals(decimalSeparator) || keyInput.Equals(groupSeparator) || keyInput.Equals(negativeSign)))
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
                else if (this.allowSpace && e.KeyChar == ' ')
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
    }
}
