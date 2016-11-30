using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DeVes.Bazaar.Client.CustControls
{
    class BkGroupBox : GroupBox
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                e.Graphics.Clear(Color.AliceBlue);

                DrawVerticalGradientRectangle(e.Graphics,
                            new Rectangle(0, 0, this.Width, this.Height), 45, Color.AliceBlue, Color.AliceBlue, Color.FromArgb(255, 210, 234, 255));
            }
            catch
            {

            }

            base.OnPaint(e);
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
                    _cb.Positions = new float[] { 0.0f, 0.11f, 0.89f, 1.0f };

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
