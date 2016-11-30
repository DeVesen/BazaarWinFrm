using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using DVes.Basar.Client;

namespace BHApp.Printing
{
    public class TablePrintDef
    {
        public class ColumnDef
        {
            public Font Font { get; set; }
            public float Height { get; set; }

            public Color BkColor { get; set; }
            public Color ForeColor { get; set; }

            public ColumnDef()
            {
                this.Font = new Font("ARIAL", 14, FontStyle.Bold);
                this.Height = 35;
                this.ForeColor = Color.Black;
                this.BkColor = Color.AliceBlue;
            }
        }
        public class ColumnItem
        {
            public string Text { get; set; }
            public float Width { get; set; }

            public ColumnItem(string text, float width)
            {
                this.Text = text;
                this.Width = width;
            }
        }
        public class FieldDef
        {
            public Font Font { get; set; }
            public Color BkColor { get; set; }
            public Color ForeColor { get; set; }

            public string Text { get; set; }
            public StringFormat StringFormat { get; set; }

            public FieldDef()
            {
                this.Font = new Font("ARIAL", 11);
                this.ForeColor = Color.Black;
                this.BkColor = Color.White;

                this.StringFormat = new StringFormat();
                this.StringFormat.Alignment = StringAlignment.Near;
                this.StringFormat.LineAlignment = StringAlignment.Near;
            }
            public FieldDef(string text)
                : this()
            {
                this.Text = text;
            }
        }

        internal int m_startPrintByLine = 0;

        public ColumnDef ColApear { get; set; }
        public List<ColumnItem> Columns { get; set; }

        public List<List<FieldDef>> Lines { get; set; }

        public TablePrintDef()
        {
            this.ColApear = new ColumnDef();

            this.Columns = new List<ColumnItem>();
            this.Lines = new List<List<FieldDef>>();
        }

        public void AddColumn(ColumnItem column)
        {
            this.Columns.Add(column);
        }
        public void AddLine(List<FieldDef> lineFields)
        {
            this.Lines.Add(lineFields);
        }
        public void AddLine(params FieldDef[] lineValue)
        {
            List<FieldDef> _line = new List<FieldDef>();

            foreach (FieldDef _fieldValue in lineValue)
            {
                _line.Add(_fieldValue);
            }

            AddLine(_line);
        }

        public float GetBiggestHeightOfLine(Graphics g, int lineIndex)
        {
            if (lineIndex >= 0 && lineIndex < this.Lines.Count)
            {
                if (this.Lines[lineIndex].Count > 0)
                {
                    List<float> _values = new List<float>();
                    foreach (FieldDef _field in this.Lines[lineIndex])
                    {
                        SizeF _sizeF = g.MeasureString(_field.Text, _field.Font);

                        _values.Add(_sizeF.Height);
                    }

                    _values.Sort(delegate(float v1, float v2)
                    {
                        if (v1 < v2)
                            return -1;
                        else if (v1 > v2)
                            return 1;
                        return 0;
                    });


                    return _values[_values.Count - 1];
                }
            }
            return 0;
        }

        private float CalcWidth(float maxWidth, float prozVal)
        {
            try
            {
                return (maxWidth * prozVal) / 100;
            }
            catch
            {

            }
            return 0;
        }

        public int DrawTable(Graphics g, RectangleF mainRect, int startByLine)
        {
            Pen _gridLinePen1 = new Pen(Color.Black, 1);

            Dictionary<int, int> _colToWidth = new Dictionary<int,int>();

            #region . columns .

            Rectangle _colRect = GParams.ToRectangle(new RectangleF(mainRect.X, mainRect.Y, 10, this.ColApear.Height));

            Brush _colBkBrush = new SolidBrush(this.ColApear.BkColor);
            Brush _colTextBrush = new SolidBrush(this.ColApear.ForeColor);

            foreach (TablePrintDef.ColumnItem _colValue in this.Columns)
            {
                bool _isLastCol = this.Columns.IndexOf(_colValue) == this.Columns.Count - 1;

                if (this.CalcWidth(mainRect.Width, _colValue.Width) <= 0)
                    continue;

                //Widht anpassen
                _colToWidth[this.Columns.IndexOf(_colValue)] = (int)this.CalcWidth(mainRect.Width, _colValue.Width);
                _colRect.Width = (int)this.CalcWidth(mainRect.Width, _colValue.Width);
                if (_isLastCol)
                {
                    _colRect.Width = (int)(mainRect.Right - (float)_colRect.X);
                }

                //Hindergrund zeichnen
                g.FillRectangle(_colBkBrush, _colRect);

                //Text
                StringFormat _stringFormat = new StringFormat();
                _stringFormat.Alignment = StringAlignment.Near;
                _stringFormat.LineAlignment = StringAlignment.Center;
                g.DrawString(_colValue.Text, this.ColApear.Font, _colTextBrush, _colRect, _stringFormat);

                //Rahmen um den Text
                g.DrawRectangle(_gridLinePen1, _colRect);

                ////Sencrechte linie zeichnen
                //g.DrawLine(_gridLinePen1, new Point((int)_colRect.Right, (int)mainRect.Top), new Point((int)_colRect.Right, (int)mainRect.Bottom));

                //Nach rechts erweitern
                _colRect.X += _colRect.Width;
            }

            _colBkBrush.Dispose();
            _colTextBrush.Dispose();

            #endregion . columns .


            #region . Zeilen .

            Rectangle _lineRect = GParams.ToRectangle(new RectangleF(mainRect.X, _colRect.Bottom + 2, 50, this.ColApear.Height));

            for (; startByLine < this.Lines.Count; startByLine++)
            {
                List<TablePrintDef.FieldDef> _line = this.Lines[startByLine];
                int _lineIndex = this.Lines.IndexOf(_line);
                float _biggestHeightOfLine = this.GetBiggestHeightOfLine(g, _lineIndex);

                if (_biggestHeightOfLine <= 0)
                {
                    continue;
                }

                //Recht zurück auf X=0 setzten
                _lineRect.X = (int)mainRect.X;

                //Rechteck auf die höhe anpassen
                _lineRect.Height = (int)_biggestHeightOfLine;

                //Points ermitteln
                PointF _pointStart1 = new PointF(_lineRect.X + 1, _lineRect.Y + 1);
                PointF _pointStart2 = new PointF(_lineRect.Right, _lineRect.Bottom);

                //Prüfen ob das nächste noch passt
                if (!mainRect.Contains(_pointStart1) || !mainRect.Contains(_pointStart2))
                {
                    break;
                }

                //Zeile durchlaufen
                for(int _colIndex = 0; _colIndex < _line.Count; _colIndex++)
                {
                    TablePrintDef.FieldDef _field = _line[_colIndex];
                    TablePrintDef.ColumnItem _colItem = this.Columns[_colIndex];
                    bool _isLastCol = this.Columns.Count - 1 == _colIndex;

                    if (!_colToWidth.ContainsKey(_colIndex))
                        continue;

                    //Rechteck auf die Länge anpassen
                    if (_isLastCol)
                    {
                        _lineRect.Width = (int)(mainRect.Right - (float)_lineRect.X);
                    }
                    else
                    {
                        _lineRect.Width = _colToWidth[_colIndex];
                    }

                    //Hindergrund
                    using (Brush _ftBK = new SolidBrush(_field.BkColor))
                    {
                        g.FillRectangle(_ftBK, new Rectangle(_lineRect.X + 1, _lineRect.Y + 1, _lineRect.Width - 1, _lineRect.Height - 1));
                    }

                    //Text zeichnen
                    using (Brush _ftF = new SolidBrush(_field.ForeColor))
                    {
                        g.DrawString(_field.Text, _field.Font, _ftF, new Rectangle(_lineRect.X + 1, _lineRect.Y, _lineRect.Width - 2, _lineRect.Height), _field.StringFormat);
                    }

                    //Zeilenlinie zeichnen
                    g.DrawLine(_gridLinePen1, new Point((int)_lineRect.X, (int)mainRect.Top), new Point((int)_lineRect.X, (int)_lineRect.Bottom));
                    g.DrawLine(_gridLinePen1, new Point((int)_lineRect.Right, (int)mainRect.Top), new Point((int)_lineRect.Right, (int)_lineRect.Bottom));

                    //Um die aktuelle Zeile erhöhen
                    _lineRect.X += _lineRect.Width;
                }

                //Zeilenlinie zeichnen
                g.DrawLine(_gridLinePen1, new Point((int)mainRect.Left + 1, (int)_lineRect.Bottom), new Point((int)_lineRect.Left + 1, (int)_lineRect.Bottom));

                //Um die aktuelle Zeile erhöhen
                _lineRect.Y += _lineRect.Height;
            }

            #endregion . Zeilen .

            _gridLinePen1.Dispose();

            return startByLine;
        }
    }
}
