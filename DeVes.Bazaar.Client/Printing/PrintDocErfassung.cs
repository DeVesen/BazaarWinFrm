using System.Text;
using System.Drawing;

namespace BHApp.Printing
{
    public class PrintDocErfassung : System.Drawing.Printing.PrintDocument
    {
        public class SellerAdressElem
        {
            public string Titel { get; set; }
            public string VName { get; set; }
            public string NName { get; set; }
            public string Street { get; set; }
            public string Zip { get; set; }
            public string Town { get; set; }

            public string Id { get; set; }

            public Font Font { get; set; }

            public string AsFinalName
            {
                get
                {
                    if (!string.IsNullOrEmpty(this.VName))
                    {
                        return this.NName + ", " + this.VName;
                    }
                    return this.NName;
                }
            }
            public string AsFinal
            {
                get
                {
                    var _retObj = new StringBuilder();

                    _retObj.AppendLine(this.Id);
                    _retObj.AppendLine(this.Titel);
                    _retObj.AppendLine(this.AsFinalName);
                    _retObj.AppendLine(this.Street);
                    _retObj.AppendLine(this.Zip + " " + this.Town);

                    return _retObj.ToString();
                }
            }


            public SellerAdressElem()
            {
                this.Font = new Font("ARIAL", 14);
            }
        }

        private int m_pagecounter;
        private TablePrintDef m_tablesToPrint;

        public SellerAdressElem SellerAdress { get; set; }

        public PrintDocErfassung()
        {
            this.SellerAdress = null;
            this.m_tablesToPrint = null;
            this.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(OnPrintDoc_PrintPage);
        }
        public PrintDocErfassung(TablePrintDef tablesToPrint)
        {
            this.SellerAdress = null;
            this.m_tablesToPrint = tablesToPrint;
            this.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(OnPrintDoc_PrintPage);
        }

        private void OnPrintDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float _leftMargin = 10; // e.MarginBounds.Left;
            float _topMargin = 10; // e.MarginBounds.Top;

            float _maxRight = e.PageBounds.Width - 5;
            float _maxBottom = e.PageBounds.Height - 5;

            if (this.SellerAdress != null && this.m_pagecounter == 0)
            {
                using (Brush _textBrush = new SolidBrush(Color.Black))
                {
                    var _rect = new RectangleF(_leftMargin, _topMargin, 0, 0);

                    e.Graphics.DrawString(this.SellerAdress.AsFinal, this.SellerAdress.Font, _textBrush, _rect);
                }
            }

            e.Graphics.DrawString(string.Format("Seite: {0}", this.m_pagecounter + 1), new Font("ARIAL", 12), Brushes.Black, new PointF((float)_maxRight - (float)_leftMargin - 150, (float)_topMargin));

            #region . Durcken der Tabelle .

            float _tableRectY = 35;// (e.PageBounds.Height * 20) / 100;

            if (this.m_pagecounter == 0)
            {
                _tableRectY = (e.PageBounds.Height * 20) / 100;
            }

            var _mainTableFrameRect = new RectangleF(_leftMargin, _tableRectY, _maxRight - _leftMargin - 50, _maxBottom - _tableRectY - 125);

            if (this.m_tablesToPrint != null)
            {
                this.m_tablesToPrint.ColApear.Height = 45;
                this.m_tablesToPrint.StartPrintByLine = this.m_tablesToPrint.DrawTable(e.Graphics, _mainTableFrameRect, this.m_tablesToPrint.StartPrintByLine);

                if (this.m_tablesToPrint.StartPrintByLine < this.m_tablesToPrint.Lines.Count)
                {
                    m_pagecounter++;
                    e.HasMorePages = true;
                }
                else
                {
                    m_pagecounter = 0;
                    e.HasMorePages = false;
                    this.m_tablesToPrint.StartPrintByLine = 0;
                }
            }

            #endregion . Durcken der Tabelle .

            var _text = "Die Abholung der nicht verkauften Ware, oder des Erlöses der verkauften Waren, muss am Samstag den 29.10.2011 bis 15:00 Uhr gegen Vorlage des Anmeldezettels erfolgen. Für abhanden gekommene Gegenstände wird von Seiten des Skiclubs Untergrombach e.V. keine Haftung übernommen. Der Verkauf der Ware erfolgt in fremden Namen und auf fremde Rechnung.";
            var _bottomTextFrameRect = new RectangleF(_leftMargin, _mainTableFrameRect.Bottom + 7, _mainTableFrameRect.Width, _maxBottom - (_mainTableFrameRect.Bottom + 7));
            e.Graphics.DrawString(DeVes.Bazaar.Client.GParams.Instance.SystemParameters.SellerInfoText, new Font("ARIAL", 12), Brushes.Black, _bottomTextFrameRect);
        }
    }
}
