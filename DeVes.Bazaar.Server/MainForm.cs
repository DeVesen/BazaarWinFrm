using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            this.m_lizPb.Image = Program.OptionExist("IsActivated") ? DeVes.Bazaar.Server.Properties.Resources.check2_32x32 : DeVes.Bazaar.Server.Properties.Resources.delete2_32x32;

            this.m_machineNameTb.Text = Dns.GetHostName();
            IPAddress[] _localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress _localIP in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (_localIP.ToString().Split('.').Length == 4)
                {
                    this.m_ipListLb.Items.Add(_localIP.ToString());
                }
            }

            lock (GParams.Instance.ComLockObj)
            {
                Program.CfgFile.Read();
                this.m_prozGewinTb.Text = Program.CfgFile.getValue_AsdDouble("SellParams", "ProzGewin", 15).Value.ToString();
                this.m_infoMsgPosPrintTb.Text = Program.CfgFile.getValue_AsString("SellParams", "InfoMsgPosPrint", "");
                this.m_printPrevCb.Checked = Program.CfgFile.getValue_AsBool("General", "PrintPev", true).Value;

                this.m_ownPort.Text = Program.CfgFile.getValue_AsInt("General", "OwnPort", 1353).ToString();
                if (this.StartServices(Program.CfgFile.getValue_AsInt("General", "PrintPev", 1353).Value))
                {
                    //this.m_startUpTimer.Start();
                }
            }

            this.ShowStatic();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (ServiceHost _serviceHost in m_serviceHosts)
            {
                _serviceHost.Close();
            }
            m_serviceHosts.Clear();
        }

        private bool StartServiceHost(bool secureCommunication, int communicationPort, Type implementationClass, Type contract)
        {
            string _errorMsg = null;
            return this.StartServiceHost(secureCommunication, communicationPort, implementationClass, contract, out _errorMsg);
        }
        private bool StartServiceHost(bool secureCommunication, int communicationPort, Type implementationClass, Type contract, out string errorMsg)
        {
            try
            {
                string protocol = secureCommunication ? "https://" : "http://";

                // Due to the reason that a service is supposed to be accessable for
                // mobile devices, we stick to BasicHttpBinding and use Transport mode
                // to provide secure communication.

                BasicHttpBinding _binding = new BasicHttpBinding();
                _binding.MaxReceivedMessageSize = 1000000;
                if (secureCommunication)
                {
                    _binding.Security.Mode = BasicHttpSecurityMode.Transport;
                }


                //http://localhost:1353/GP.CrossEnterpriseUnit.Integrator/ISession
                //https://localhost:1354/GP.CrossEnterpriseUnit.Integrator/ISession
                Uri _baseAddress = new Uri(protocol + Environment.MachineName + ":" + communicationPort.ToString() + "/DeVes.Bazaar.Integrator/" + contract.Name);

                //Create new service host for service
                ServiceHost _serviceHost = new ServiceHost(implementationClass, _baseAddress);

                //_serviceHost.Credentials.WindowsAuthentication.AllowAnonymousLogons = true;

                _serviceHost.AddServiceEndpoint(contract, _binding, _baseAddress);
                // if secure web services are enabled add another endpoint1


                ServiceMetadataBehavior _serviceMetaDataBehavior = new ServiceMetadataBehavior();
                _serviceMetaDataBehavior.HttpGetEnabled = secureCommunication ? false : true;
                // also make service metadata available if secure communication is desired
                _serviceMetaDataBehavior.HttpsGetEnabled = secureCommunication ? true : false;

                ServiceThrottlingBehavior _throttle = new ServiceThrottlingBehavior();
                _throttle.MaxConcurrentCalls = 1000;
                _throttle.MaxConcurrentInstances = 1000;
                _throttle.MaxConcurrentSessions = 1000;

                _serviceHost.Description.Behaviors.Add(_serviceMetaDataBehavior);
                _serviceHost.Description.Behaviors.Add(_throttle);

                _serviceHost.OpenTimeout = new TimeSpan(1, 0, 0);
                _serviceHost.CloseTimeout = new TimeSpan(1, 0, 0);

                ServiceDebugBehavior _debugBehavior = _serviceHost.Description.Behaviors[typeof(ServiceDebugBehavior)] as ServiceDebugBehavior;
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
            e.Cancel = !(MessageBox.Show(this, "Server wirklich beenden?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes);

            base.OnClosing(e);
        }

        private void m_saveBtn_Click(object sender, EventArgs e)
        {
            lock (GParams.Instance.ComLockObj)
            {
                Program.CfgFile.Read();
                Program.CfgFile.setValue("SellParams", "ProzGewin", this.m_prozGewinTb.Text);
                Program.CfgFile.setValue("SellParams", "InfoMsgPosPrint", this.m_infoMsgPosPrintTb.Text);
                Program.CfgFile.setValue("General", "PrintPev", this.m_printPrevCb.Checked);
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

            int _supplCount = 0;
            int positionsCount, notSold, isSold, isReturn;
            double _prozValue, soldBetrag, _eigenBetrag;

            lock (GParams.Instance.ComLockObj)
            {
                GParams.Instance.Supplier.SupplierStats(out _supplCount);
                GParams.Instance.Position.PositionsStats(out positionsCount, out notSold, out isSold, out isReturn,
                                                         out soldBetrag);

                _prozValue = Program.CfgFile.getValue_AsdDouble("SellParams", "ProzGewin", 15).Value;
                _eigenBetrag = soldBetrag * _prozValue / 100;
            }


            this.m_numSuplTb.Text = _supplCount.ToString();

            this.m_notSoldPosCountTb.Text = notSold.ToString();
            this.m_soldPosCountTb.Text = isSold.ToString();
            this.m_returnPosCountTb.Text = isReturn.ToString();

            this.m_einnahmenTb.Text = soldBetrag.ToString();
            this.m_eigenBetragTb.Text = _eigenBetrag.ToString();
            this.m_lieferGewinnTb.Text = (soldBetrag - _eigenBetrag).ToString();
        }

        private bool StartServices(int port)
        {
            bool _allStarted = true;
            string _errorMsg = null;
            _allStarted = _allStarted && StartServiceHost(false, port, typeof(BasarCom), typeof(IBasarCom), out _errorMsg);

            this.m_conStatePb.Image = _allStarted ? DeVes.Bazaar.Server.Properties.Resources.check2_16x16 : DeVes.Bazaar.Server.Properties.Resources.delete2_16x16;
            this.m_conStatePb.Tag = _errorMsg;

            return _allStarted;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.m_ownPort.IntValue.HasValue)
            {
                foreach (ServiceHost _serviceHost in m_serviceHosts)
                {
                    _serviceHost.Close();
                }
                m_serviceHosts.Clear();

                Program.CfgFile.Read();
                Program.CfgFile.setValue("General", "OwnPort", this.m_ownPort.IntValue.Value);
                Program.CfgFile.Save();

                Program.CfgFile.Read();
                this.StartServices(Program.CfgFile.getValue_AsInt("General", "OwnPort", 1353).Value);
            }
            else
            {
                this.m_ownPort.Text = Program.CfgFile.getValue_AsInt("General", "OwnPort", 1353).ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.CfgFile.Read();
            Program.CfgFile.setValue("General", "License", this.m_licenseTb.Text);
            Program.CfgFile.Save();

            Program.ActivateLizence();
            this.m_lizPb.Image = Program.OptionExist("IsActivated") ? DeVes.Bazaar.Server.Properties.Resources.check2_32x32 : DeVes.Bazaar.Server.Properties.Resources.delete2_32x32;
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
