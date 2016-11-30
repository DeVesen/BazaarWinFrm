using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace DeVes.Bazaar.Server.CustControls
{
    public sealed partial class TitelBarCtrl : UserControl
    {
        public string TitelText { get; set; }

        public TitelBarCtrl()
        {
            InitializeComponent();

            this.Text = null;
            this.DoubleBuffered = true;
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
                        new Rectangle(0, 0, this.Width, this.Height), 30, Color.AliceBlue, Color.FromArgb(255, 187, 223, 255));

            using (Brush _textBrush = new SolidBrush(Color.Black))
            {
                var _rF = new RectangleF(this.Bounds.X, this.Bounds.Y, this.Bounds.Width, this.Bounds.Height);
                var _sf = new StringFormat();
                _sf.Alignment = StringAlignment.Center;
                _sf.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(this.TitelText, this.Font, _textBrush, _rF, _sf);
            }
        }


        private void DrawVerticalGradientRectangle(Graphics g, Rectangle size, int splitHeight, Color backColor1, Color backColor2)
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
                var _fSplitHeight = (float)splitHeight;
                var _fSizeHeight = (float)size.Height;
                var _prozSplit = (_fSplitHeight * 100) / _fSizeHeight;
                var _point = (1F * _prozSplit) / 100F;

                using (var _pthGrBrush = new LinearGradientBrush(size, backColor1, backColor2, LinearGradientMode.Vertical))
                {
                    var _cb = new ColorBlend
                    {
                        Colors = new[] {backColor1, backColor2, backColor1},
                        Positions = new[] {0, _point, 1F}
                    };

                    _pthGrBrush.InterpolationColors = _cb;

                    g.FillRectangle(_pthGrBrush, size);
                }
            }
        }

    }
}
