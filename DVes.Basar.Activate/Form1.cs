using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DVes.Basar.Activate
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void m_groundCodeTb_TextChanged(object sender, EventArgs e)
        {
            this.m_finalLizTb.ResetText();

            if ((this.m_groundCodeTb.Text.Length / 2) > 4)
            {
                this.m_finalLizTb.Text = DVes.Basar.Data.Security.Encryption.EncryptString(this.GetLizenceDeEncryStream(), this.GetEncryCode());
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.m_groundCodeTb.Text = DVes.Basar.Data.Security.GandingSecurity.CreateBaseAccessCode();
        }

        private string GetLizenceDeEncryStream()
        {
            int _baseKeyLengthHalf = this.m_groundCodeTb.Text.Length / 2;
            string _baseLeft = this.m_groundCodeTb.Text.Substring(0, _baseKeyLengthHalf);
            string _baseRight = this.m_groundCodeTb.Text.Substring(_baseKeyLengthHalf);

            string _additionalElements = "40F57A8BC94B44E384700288818902FE";

            return _baseRight + ":" + _additionalElements + ":" + _baseLeft;
        }

        private string GetEncryCode()
        {
            try
            {
                int _baseKeyLengthHalf = this.m_groundCodeTb.Text.Length / 2;
                string _baseLeft = this.m_groundCodeTb.Text.Substring(0, _baseKeyLengthHalf);
                string _baseRight = this.m_groundCodeTb.Text.Substring(_baseKeyLengthHalf);
                string _deKey = _baseRight + "-7498D128-23BD-4D80-A0CD-DFAAF12719BC-" + _baseLeft;

                return _deKey;
            }
            catch
            {

            }
            return null;
        }
    }
}
