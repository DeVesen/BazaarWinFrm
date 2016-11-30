using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BHApp.Printing
{
    public class PrintDocVerkauf : System.Drawing.Printing.PrintDocument
    {
        private TablePrintDef m_tablesToPrint = null;

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
            float leftMargin = 10; // e.MarginBounds.Left;
            float topMargin = 10; // e.MarginBounds.Top;

            float _maxRight = e.PageBounds.Width - 5;
            float _maxBottom = e.PageBounds.Height - 5;

            using (Brush _textBrush = new SolidBrush(Color.Black))
            {
                using (Font _font = new Font("ARIAL", 14))
                {
                    RectangleF _rect = new RectangleF(leftMargin, topMargin, 0, 0);

                    e.Graphics.DrawString("Verkauf", _font, _textBrush, _rect);
                }
            }

            #region . Durcken der Tabelle .

            if (this.m_tablesToPrint != null)
            {
                float _tableRectY = (e.PageBounds.Height * 10) / 100;
                RectangleF _mainTableFrameRect = new RectangleF(leftMargin, _tableRectY, _maxRight - leftMargin - 30, _maxBottom - _tableRectY - 100);

                this.m_tablesToPrint.m_startPrintByLine = this.m_tablesToPrint.DrawTable(e.Graphics, _mainTableFrameRect, this.m_tablesToPrint.m_startPrintByLine);

                if (this.m_tablesToPrint.m_startPrintByLine < this.m_tablesToPrint.Lines.Count)
                {
                    e.HasMorePages = true;
                }
                else
                {
                    e.HasMorePages = false;
                    this.m_tablesToPrint.m_startPrintByLine = 0;
                }
            }

            #endregion . Durcken der Tabelle .
        }
    }
}
