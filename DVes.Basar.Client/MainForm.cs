using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DVes.Basar.Client.MdiForms;

namespace DVes.Basar.Client
{
    public partial class MainForm : Form
    {
        private MdiClientManager m_mdiClientManager = null;


        public MainForm()
        {
            InitializeComponent();

            this.m_mdiClientManager = new MdiClientManager(this);
        }

        private void OnToolStripItemClicked(object sender, EventArgs e)
        {
            ToolStripItem _ctrl = sender as ToolStripItem;
            if (_ctrl != null && _ctrl.Tag != null)
            {
                this.m_mdiClientManager.RunForm(_ctrl.Tag.ToString());
            }
        }
    }
}
