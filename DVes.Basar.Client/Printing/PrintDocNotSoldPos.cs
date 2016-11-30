﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BHApp.Printing
{
    public class PrintDocNotSoldPos : System.Drawing.Printing.PrintDocument
    {
        public class SellerAdressElem
        {
            public string Titel { get; set; }
            public string VName { get; set; }
            public string NName { get; set; }
            public string Street { get; set; }
            public string Zip { get; set; }
            public string Town { get; set; }

            public string ID { get; set; }

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
                    StringBuilder _retObj = new StringBuilder();

                    _retObj.AppendLine(this.ID);
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

        private int m_pagecounter = 0;
        private TablePrintDef m_tablesToPrint = null;

        public SellerAdressElem SellerAdress { get; set; }

        public PrintDocNotSoldPos()
        {
            this.SellerAdress = null;
            this.m_tablesToPrint = null;
            this.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(OnPrintDoc_PrintPage);
        }
        public PrintDocNotSoldPos(TablePrintDef tablesToPrint)
        {
            this.SellerAdress = null;
            this.m_tablesToPrint = tablesToPrint;
            this.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(OnPrintDoc_PrintPage);
        }

        private void OnPrintDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float leftMargin = 10; // e.MarginBounds.Left;
            float topMargin = 10; // e.MarginBounds.Top;

            float _maxRight = e.PageBounds.Width - 5;
            float _maxBottom = e.PageBounds.Height - 5;

            if (this.SellerAdress != null && this.m_pagecounter == 0)
            {
                using (Brush _textBrush = new SolidBrush(Color.Black))
                {
                    RectangleF _rect = new RectangleF(leftMargin, topMargin, 0, 0);

                    e.Graphics.DrawString("Noch nicht Verkauft von:\n" + this.SellerAdress.AsFinal, this.SellerAdress.Font, _textBrush, _rect);
                }
            }

            e.Graphics.DrawString(string.Format("Seite: {0}", this.m_pagecounter + 1), new Font("ARIAL", 12), Brushes.Black, new PointF((float)_maxRight - (float)leftMargin - 150, (float)topMargin));

            #region . Durcken der Tabelle .

            float _tableRectY = 35;// (e.PageBounds.Height * 20) / 100;

            if (this.m_pagecounter == 0)
            {
                _tableRectY = (e.PageBounds.Height * 20) / 100;
            }

            RectangleF _mainTableFrameRect = new RectangleF(leftMargin, _tableRectY, _maxRight - leftMargin - 50, _maxBottom - _tableRectY - 100);

            if (this.m_tablesToPrint != null)
            {
                this.m_tablesToPrint.ColApear.Height = 45;
                this.m_tablesToPrint.m_startPrintByLine = this.m_tablesToPrint.DrawTable(e.Graphics, _mainTableFrameRect, this.m_tablesToPrint.m_startPrintByLine);

                if (this.m_tablesToPrint.m_startPrintByLine < this.m_tablesToPrint.Lines.Count)
                {
                    m_pagecounter++;
                    e.HasMorePages = true;
                }
                else
                {
                    m_pagecounter = 0;
                    e.HasMorePages = false;
                    this.m_tablesToPrint.m_startPrintByLine = 0;
                }
            }

            #endregion . Durcken der Tabelle .

            string _text = "Die Abholung der nicht verkauften Ware, oder des Erlöses der verkauften Waren, muss am Samstag den 29.10.2011 bis 15:00 Uhr gegen Vorlage des Anmeldezettels erfolgen. Für abhanden gekommene Gegenstände wird von Seiten des Skiclubs Untergrombach e.V. keine Haftung übernommen. Der Verkauf der Ware erfolgt in fremden Namen und auf fremde Rechnung.";
            RectangleF _bottomTextFrameRect = new RectangleF(leftMargin, _mainTableFrameRect.Bottom + 7, _mainTableFrameRect.Width, _maxBottom - (_mainTableFrameRect.Bottom + 7));
            e.Graphics.DrawString(DVes.Basar.Client.GParams.Instance.SystemParameters.SellerInfoText, new Font("ARIAL", 12), Brushes.Black, _bottomTextFrameRect);
        }
    }
}
