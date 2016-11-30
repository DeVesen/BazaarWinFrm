using System.Drawing;

namespace BHApp.Printing
{
    public class PrintDocVerkauf : System.Drawing.Printing.PrintDocument
    {
        private TablePrintDef m_tablesToPrint;

        public PrintDocVerkauf()
        {
            this.m_tablesToPrint = null;
            this.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(OnPrintDoc_PrintPage);
        }
        public PrintDocVerkauf(TablePrintDef tablesToPrint)
        {
            this.m_tablesToPrint = tablesToPrint;
            this.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(OnPrintDoc_PrintPage);
        }

        private void OnPrintDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float _leftMargin = 10; // e.MarginBounds.Left;
            float _topMargin = 10; // e.MarginBounds.Top;

            float _maxRight = e.PageBounds.Width - 5;
            float _maxBottom = e.PageBounds.Height - 5;

            using (Brush _textBrush = new SolidBrush(Color.Black))
            {
                using (var _font = new Font("ARIAL", 14))
                {
                    var _rect = new RectangleF(_leftMargin, _topMargin, 0, 0);

                    e.Graphics.DrawString("Verkauf", _font, _textBrush, _rect);
                }
            }

            #region . Durcken der Tabelle .

            if (this.m_tablesToPrint != null)
            {
                float _tableRectY = (e.PageBounds.Height * 10) / 100;
                var _mainTableFrameRect = new RectangleF(_leftMargin, _tableRectY, _maxRight - _leftMargin - 30, _maxBottom - _tableRectY - 100);

                this.m_tablesToPrint.StartPrintByLine = this.m_tablesToPrint.DrawTable(e.Graphics, _mainTableFrameRect, this.m_tablesToPrint.StartPrintByLine);

                if (this.m_tablesToPrint.StartPrintByLine < this.m_tablesToPrint.Lines.Count)
                {
                    e.HasMorePages = true;
                }
                else
                {
                    e.HasMorePages = false;
                    this.m_tablesToPrint.StartPrintByLine = 0;
                }
            }

            #endregion . Durcken der Tabelle .
        }
    }
}
