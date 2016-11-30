using System;
using System.Windows.Forms;
using DeVes.Bazaar.Client.MdiForms;

namespace DeVes.Bazaar.Client
{
    public partial class MainForm : Form
    {
        private MdiClientManager m_mdiClientManager;


        public MainForm()
        {
            InitializeComponent();

            this.m_mdiClientManager = new MdiClientManager(this);
        }

        private void OnToolStripItemClicked(object sender, EventArgs e)
        {
            var _ctrl = sender as ToolStripItem;
            if (_ctrl != null && _ctrl.Tag != null)
            {
                this.m_mdiClientManager.RunForm(_ctrl.Tag.ToString());
            }
        }
    }
}
