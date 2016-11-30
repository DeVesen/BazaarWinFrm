using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Description;
using DeVes.Bazaar.Server.Integrator;
using DeVes.Bazaar.Data;
using System.Net;
using DeVes.Bazaar.Server.SubForms;

namespace DeVes.Bazaar.Server
{
    public partial class MainForm : Form
    {
        private List<ServiceHost> m_serviceHosts = new List<ServiceHost>();

        public MainForm()
        {
            InitializeComponent();

            this.m_notifyIcon.Visible = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.m_pcCodeTb.Text = Program.PcCode;
            this.m_lizPb.Image = Program.OptionExist("IsActivated") ? Properties.Resources.check2_32x32 : Properties.Resources.delete2_32x32;

            this.m_machineNameTb.Text = Dns.GetHostName();
            Dns.GetHostAddresses(Dns.GetHostName());
            foreach (var _localIp in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (_localIp.ToString().Split('.').Length == 4)
                {
                    this.m_ipListLb.Items.Add(_localIp.ToString());
                }
            }

            lock (GParams.Instance.ComLockObj)
            {
                Program.CfgFile.Read();
                this.m_prozGewinTb.Text = Program.CfgFile.getValue_AsdDouble("SellParams", "ProzGewin", 15).ToString(CultureInfo.InvariantCulture);
                this.m_infoMsgPosPrintTb.Text = Program.CfgFile.getValue_AsString("SellParams", "InfoMsgPosPrint", "");
                this.m_printPrevCb.Checked = Program.CfgFile.getValue_AsBool("General", "PrintPev", true);

                this.m_ownPort.Text = Program.CfgFile.getValue_AsInt("General", "OwnPort", 1353).ToString();
                if (this.StartServices(Program.CfgFile.getValue_AsInt("General", "PrintPev", 1353)))
                {
                    //this.m_startUpTimer.Start();
                }
            }

            this.ShowStatic();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var _serviceHost in m_serviceHosts)
            {
                _serviceHost.Close();
            }
            m_serviceHosts.Clear();
        }

        private bool StartServiceHost(bool secureCommunication, int communicationPort, Type implementationClass, Type contract, out string errorMsg)
        {
            try
            {
                var _protocol = secureCommunication ? "https://" : "http://";

                var _binding = new BasicHttpBinding();
                _binding.MaxReceivedMessageSize = 1000000;
                if (secureCommunication)
                {
                    _binding.Security.Mode = BasicHttpSecurityMode.Transport;
                }


                //http://localhost:1353/GP.CrossEnterpriseUnit.Integrator/ISession
                //https://localhost:1354/GP.CrossEnterpriseUnit.Integrator/ISession
                var _baseAddress = new Uri(_protocol + Environment.MachineName + ":" + communicationPort.ToString() + "/DeVes.Bazaar.Integrator/" + contract.Name);

                var _serviceHost = new ServiceHost(implementationClass, _baseAddress);

                _serviceHost.AddServiceEndpoint(contract, _binding, _baseAddress);

                var _serviceMetaDataBehavior = new ServiceMetadataBehavior();
                _serviceMetaDataBehavior.HttpGetEnabled = !secureCommunication;
                _serviceMetaDataBehavior.HttpsGetEnabled = secureCommunication;

                var _throttle = new ServiceThrottlingBehavior();
                _throttle.MaxConcurrentCalls = 1000;
                _throttle.MaxConcurrentInstances = 1000;
                _throttle.MaxConcurrentSessions = 1000;

                _serviceHost.Description.Behaviors.Add(_serviceMetaDataBehavior);
                _serviceHost.Description.Behaviors.Add(_throttle);

                _serviceHost.OpenTimeout = new TimeSpan(1, 0, 0);
                _serviceHost.CloseTimeout = new TimeSpan(1, 0, 0);

                var _debugBehavior = _serviceHost.Description.Behaviors[typeof(ServiceDebugBehavior)] as ServiceDebugBehavior;
                if (_debugBehavior != null)
                {
                    _debugBehavior.IncludeExceptionDetailInFaults = true;
                }


                _serviceHost.Open();

                this.m_serviceHosts.Add(_serviceHost);

                errorMsg = string.Format("Port '{0}' gestartet", communicationPort);
                return true;
            }
            catch (Exception _exp)
            {
                errorMsg = _exp.Message;
            }
            return false;
        }

        private void m_notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.BringToFront();
            this.Focus();

            this.m_notifyIcon.Visible = false;
        }

        private void m_startUpTimer_Tick(object sender, EventArgs e)
        {
            this.m_startUpTimer.Stop();

            this.m_notifyIcon.Visible = true;
            this.m_notifyIcon.ShowBalloonTip(500, "Deves Basar Server", "Minimized", ToolTipIcon.Info);

            this.Hide();
        }


        protected override void OnResize(EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                this.m_notifyIcon.Visible = true;
                this.m_notifyIcon.ShowBalloonTip(500, "Deves Basar Server", "Minimized", ToolTipIcon.Info);
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                this.m_notifyIcon.Visible = false;
            }

            base.OnResize(e);
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = MessageBox.Show(this, @"Server wirklich beenden?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes;

            base.OnClosing(e);
        }

        private void m_saveBtn_Click(object sender, EventArgs e)
        {
            lock (GParams.Instance.ComLockObj)
            {
                Program.CfgFile.Read();
                Program.CfgFile.SetValue("SellParams", "ProzGewin", this.m_prozGewinTb.Text);
                Program.CfgFile.SetValue("SellParams", "InfoMsgPosPrint", this.m_infoMsgPosPrintTb.Text);
                Program.CfgFile.SetValue("General", "PrintPev", this.m_printPrevCb.Checked);
                Program.CfgFile.Save();
            }   
        }


        public delegate void StaticInfo();
        public void ShowStatic()
        {
            if (this.bkGroupBox2.InvokeRequired)
            {
                this.bkGroupBox2.Invoke(new StaticInfo(this.ShowStatic));
            }

            int _supplCount;
            int _notSold, _isSold, _isReturn;
            double _soldBetrag, _eigenBetrag;

            lock (GParams.Instance.ComLockObj)
            {
                GParams.Instance.Supplier.SupplierStats(out _supplCount);
                int _positionsCount;
                GParams.Instance.Position.PositionsStats(out _positionsCount, out _notSold, out _isSold, out _isReturn,
                                                         out _soldBetrag);

                var _prozValue = Program.CfgFile.getValue_AsdDouble("SellParams", "ProzGewin", 15);
                _eigenBetrag = _soldBetrag * _prozValue / 100;
            }


            this.m_numSuplTb.Text = _supplCount.ToString();

            this.m_notSoldPosCountTb.Text = _notSold.ToString();
            this.m_soldPosCountTb.Text = _isSold.ToString();
            this.m_returnPosCountTb.Text = _isReturn.ToString();

            this.m_einnahmenTb.Text = _soldBetrag.ToString(CultureInfo.InvariantCulture);
            this.m_eigenBetragTb.Text = _eigenBetrag.ToString(CultureInfo.InvariantCulture);
            this.m_lieferGewinnTb.Text = (_soldBetrag - _eigenBetrag).ToString(CultureInfo.InvariantCulture);
        }

        private bool StartServices(int port)
        {
            string _errorMsg;
            var _allStarted = StartServiceHost(false, port, typeof(BasarCom), typeof(IBasarCom), out _errorMsg);

            this.m_conStatePb.Image = _allStarted ? Properties.Resources.check2_16x16 : Properties.Resources.delete2_16x16;
            this.m_conStatePb.Tag = _errorMsg;

            return _allStarted;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.m_ownPort.IntValue.HasValue)
            {
                foreach (var _serviceHost in m_serviceHosts)
                {
                    _serviceHost.Close();
                }
                m_serviceHosts.Clear();

                Program.CfgFile.Read();
                Program.CfgFile.SetValue("General", "OwnPort", this.m_ownPort.IntValue.Value);
                Program.CfgFile.Save();

                Program.CfgFile.Read();
                this.StartServices(Program.CfgFile.getValue_AsInt("General", "OwnPort", 1353));
            }
            else
            {
                this.m_ownPort.Text = Program.CfgFile.getValue_AsInt("General", "OwnPort", 1353).ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.CfgFile.Read();
            Program.CfgFile.SetValue("General", "License", this.m_licenseTb.Text);
            Program.CfgFile.Save();

            Program.ActivateLizence();
            this.m_lizPb.Image = Program.OptionExist("IsActivated") ? Properties.Resources.check2_32x32 : Properties.Resources.delete2_32x32;
        }

        private void m_conStatePb_Click(object sender, EventArgs e)
        {
            if (this.m_conStatePb.Tag != null)
            {
                MessageBox.Show(this.m_conStatePb.Tag.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RemoveSoldFromPosition.AskForNumber(this, RemoveSoldFromPosition.FrmTypes.RemoveSold);

            this.ShowStatic();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RemoveSoldFromPosition.AskForNumber(this, RemoveSoldFromPosition.FrmTypes.RemoveReturned);

            this.ShowStatic();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RemoveSoldFromPosition.AskForNumber(this, RemoveSoldFromPosition.FrmTypes.RemoveSuplPos);

            this.ShowStatic();
        }
    }
}
