using System;
using System.Windows.Forms;
using DeVes.Bazaar.Client.IBasarCom;
using GP.UI.Mobile2.AppParameter;
using System.Net;

namespace DeVes.Bazaar.Client.MdiForms
{
    public partial class PropertyManageForm : BaseMdiForm
    {
        public PropertyManageForm()
        {
            InitializeComponent();
        }

        private void PropertyManageForm_Load(object sender, EventArgs e)
        {
            this.m_machineNameTb.Text = Dns.GetHostName();
            var _localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            if (_localIPs != null && _localIPs.Length > 0)
            {
                foreach (var _localIp in _localIPs)
                {
                    if (_localIp.ToString().Split('.').Length == 4)
                    {
                        this.m_ipListLb.Items.Add(_localIp.ToString());
                    }
                }
            }

            this.m_serverIpTb.Text = GParams.Instance.ServerAdress;
            this.m_serverPortTb.Text = GParams.Instance.PortAdress.ToString();
        }

        private void OnServerAdressCtrlsChanged(object sender, EventArgs e)
        {
            this.CheckBtnEnables();
            this.m_httpComStremTb.Text = string.Format("http://{0}:{1}/DeVes.Bazaar.Integrator/IBasarCom", this.m_serverIpTb.Text, this.m_serverPortTb.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var _comCheckObj = new BasarCom();
            try
            {
                _comCheckObj.Url = string.Format("http://{0}:{1}/DeVes.Bazaar.Integrator/IBasarCom", this.m_serverIpTb.Text, this.m_serverPortTb.Text);
                _comCheckObj.Proxy = WebRequest.DefaultWebProxy;
                _comCheckObj.Timeout = 3000;

                var _result = _comCheckObj.CheckAlive();

                MessageBox.Show("Verbindung ok", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception _ex)
            {
                MessageBox.Show(_ex.Message);
            }

            _comCheckObj.Abort();
            _comCheckObj.Dispose();
            _comCheckObj = null;
        }

        private void m_saveSettingsBtn_Click(object sender, EventArgs e)
        {
            var _cfgFile = new CfgFile(Program.LocalAppParamPath);

            _cfgFile.Read();

            _cfgFile.SetValue("Comunication", "Adress", this.m_serverIpTb.Text, false);
            _cfgFile.SetValue("Comunication", "Port", this.m_serverPortTb.Text, false);

            _cfgFile.Save();
        }


        private bool HasMinFor_Comunication()
        {
            var _result = true;

            _result = _result && !string.IsNullOrEmpty(this.m_serverIpTb.Text) && !string.IsNullOrEmpty(this.m_serverIpTb.Text.Trim());
            _result = _result && !string.IsNullOrEmpty(this.m_serverPortTb.Text) && !string.IsNullOrEmpty(this.m_serverPortTb.Text.Trim()) && GParams.ToInt32(this.m_serverPortTb.Text).HasValue;

            return _result;
        }
        private void CheckBtnEnables()
        {
            this.button1.Enabled = this.HasMinFor_Comunication();
            this.m_saveSettingsBtn.Enabled = HasMinFor_Comunication();
        }
    }
}
