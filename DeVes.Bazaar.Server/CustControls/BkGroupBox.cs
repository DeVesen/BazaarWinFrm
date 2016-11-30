using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DeVes.Bazaar.Server.CustControls
{
    public sealed class BkGroupBox : GroupBox
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.AliceBlue);


            DrawVerticalGradientRectangle(e.Graphics,
                        new Rectangle(0, 0, this.Width, this.Height), 45, Color.AliceBlue, Color.FromArgb(255, 210, 234, 255));

            base.OnPaint(e);
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
                using (var _pthGrBrush = new LinearGradientBrush(size, backColor1, backColor2, LinearGradientMode.Vertical))
                {
                    var _cb = new ColorBlend
                    {
                        Colors = new[] {backColor1, backColor2, backColor2, backColor1},
                        Positions = new[] {0.0f, 0.11f, 0.89f, 1.0f}
                    };

                    _pthGrBrush.InterpolationColors = _cb;

                    g.FillRectangle(_pthGrBrush, size);
                }
            }
        }

    }
}
