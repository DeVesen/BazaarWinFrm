using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace DeVes.Bazaar.Server.CustControls
{
    public partial class TitelBarCtrl : UserControl
    {
        public string TitelText { get; set; }

        public TitelBarCtrl()
        {
            InitializeComponent();

            this.Text = null;
            this.DoubleBuffered = true;
        }

        private void TitelBarCtrl_Load(object sender, EventArgs e)
        {

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
                        new Rectangle(0, 0, this.Width, this.Height), 30, Color.AliceBlue, Color.AliceBlue, Color.FromArgb(255, 187, 223, 255));

            using (Brush _textBrush = new SolidBrush(Color.Black))
            {
                RectangleF _rF = new RectangleF(this.Bounds.X, this.Bounds.Y, this.Bounds.Width, this.Bounds.Height);
                StringFormat _sf = new StringFormat();
                _sf.Alignment = StringAlignment.Center;
                _sf.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(this.TitelText, this.Font, _textBrush, _rF, _sf);
            }

            //using(PowderBlue
            //e.Graphics.FillRectangle(
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
                    _cb.Colors = new Color[] { backColor1, backColor2, backColor1 };
                    _cb.Positions = new float[] { 0, _point, 1F };

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
