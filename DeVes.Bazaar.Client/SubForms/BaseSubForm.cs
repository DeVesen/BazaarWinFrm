using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace DeVes.Bazaar.Client.SubForms
{
    public partial class BaseSubForm : Form
    {
        public BaseSubForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.RunAllControls(this.Controls);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {

            e.Graphics.Clear(Color.AliceBlue);


            DrawVerticalGradientRectangle(e.Graphics,
                        new Rectangle(0, 0, this.Width, this.Height), 30, Color.AliceBlue, Color.AliceBlue, Color.FromArgb(255,210,234,255));

            //using(PowderBlue
            //e.Graphics.FillRectangle(
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
            ctrl.KeyUp += new KeyEventHandler(ctrl_OnKeyUp);

            return true;
        }


        protected void PlayBadSound()
        {
            System.Media.SoundPlayer _sp = new System.Media.SoundPlayer(Properties.Resources.Windows_Battery_Critical);
            _sp.Play();
            _sp.Dispose();
            _sp = null;
        }
        protected void PlayGoodSound()
        {
            System.Media.SoundPlayer _sp = new System.Media.SoundPlayer(Properties.Resources.Windows_Print_complete);
            _sp.Play();
            _sp.Dispose();
            _sp = null;
        }
        protected void PlayConfirmedSound()
        {
            System.Media.SoundPlayer _sp = new System.Media.SoundPlayer(Properties.Resources.Speech_Sleep);
            _sp.Play();
            _sp.Dispose();
            _sp = null;
        }

        protected virtual void ctrl_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                this.Close();
            }
        }

        private void DrawVerticalGradientRectangle(Graphics g, Rectangle size, int splitHeight, Color? frameColor, Color backColor1, Color backColor2)
        {
            if (backColor1 == backColor2)
            {
                using (Brush _mbkBrush = new SolidBrush(backColor1))
                {
                    g.FillRectangle(_mbkBrush, size);
                    _mbkBrush.Dispose();
                }
            }
            else if (splitHeight == 0 && backColor1 != backColor2)
            {
                using (Brush _mbkBrush = new LinearGradientBrush(size, backColor1, backColor2, LinearGradientMode.Vertical))
                {
                    g.FillRectangle(_mbkBrush, size);
                    _mbkBrush.Dispose();
                }
            }
            else
            {
                float _F_splitHeight = (float)splitHeight;
                float _F_SizeHeight = (float)size.Height;
                float _prozSplit = (_F_splitHeight * 100) / _F_SizeHeight;
                float _point = (1F * _prozSplit) / 100F;

                using (LinearGradientBrush _pthGrBrush = new LinearGradientBrush(size, backColor1, backColor2, LinearGradientMode.Vertical))
                {
                    ColorBlend _cb = new ColorBlend();
                    _cb.Colors = new Color[] { backColor1, backColor2, backColor2, backColor1 };
                    //_cb.Positions = new float[] { 0, _point, 1F };
                    _cb.Positions = new float[] { 0.0f, 0.1f, 0.8f, 1.0f };

                    _pthGrBrush.InterpolationColors = _cb;

                    g.FillRectangle(_pthGrBrush, size);
                }
            }

            //if (frameColor.HasValue)
            //{
            //    this.DrawFrame(g, size, frameColor.Value, 1, null);
            //}
        }
    }
}
