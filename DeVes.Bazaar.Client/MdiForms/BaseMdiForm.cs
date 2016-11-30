using System;
using System.Windows.Forms;

namespace DeVes.Bazaar.Client.MdiForms
{
    public partial class BaseMdiForm : Form
    {
        public BaseMdiForm()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
        }

        private void titelBarCtrl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                this.Close();
            }
        }

        protected override void  OnLoad(EventArgs e)
        {
 	         base.OnLoad(e);

             this.RunAllControls(this.Controls);
        }

        private void RunAllControls(Control.ControlCollection ctrolCol)
        {
            foreach (Control _ctrl in ctrolCol)
            {
                if (this.SetInfoToCtrl(_ctrl))
                {
                    if (_ctrl is GroupBox)
                    {
                        this.RunAllControls(((GroupBox)_ctrl).Controls);
                    }
                    else if (_ctrl is UserControl)
                    {
                        this.RunAllControls(((UserControl)_ctrl).Controls);
                    }
                }
            }
        }
        protected virtual bool SetInfoToCtrl(Control ctrl)
        {
            ctrl.KeyUp += new KeyEventHandler(Onctrl_KeyUp);
            return true;
        }


        protected virtual void Onctrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {

            }
        }


        protected void PlayBadSound()
        {
            var _sp = new System.Media.SoundPlayer(Properties.Resources.Windows_Battery_Critical);
            _sp.Play();
            _sp.Dispose();
            _sp = null;
        }
        protected void PlayGoodSound()
        {
            var _sp = new System.Media.SoundPlayer(Properties.Resources.Windows_Print_complete);
            _sp.Play();
            _sp.Dispose();
            _sp = null;
        }
        protected void PlayConfirmedSound()
        {
            var _sp = new System.Media.SoundPlayer(Properties.Resources.Speech_Sleep);
            _sp.Play();
            _sp.Dispose();
            _sp = null;
        }
    }
}
