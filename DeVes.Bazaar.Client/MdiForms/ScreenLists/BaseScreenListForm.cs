using System;
using System.Windows.Forms;

namespace DeVes.Bazaar.Client.MdiForms.ScreenLists
{
    public partial class BaseScreenListForm : BaseMdiForm
    {
        public BaseScreenListForm()
        {
            InitializeComponent();
        }

        private void BaseScreenListForm_Load(object sender, EventArgs e)
        {
            this.RefreshList();
        }

        public virtual void RefreshList()
        {

        }

        protected override void Onctrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                this.RefreshList();
            }
        }

    }
}
