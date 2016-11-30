using System;
using System.Windows.Forms;

namespace DeVes.Bazaar.Client.CustControls
{
    public class DvListView : ListView
    {
        private bool m_resizeColumns;
        public bool ResizeColumns
        {
            get
            {
                return this.m_resizeColumns;
            }
            set
            {
                this.m_resizeColumns = value;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            var _width = (float)this.Width - 5;
            var _colCount = (float)this.Columns.Count;
            var _widthPerCol = _width / _colCount;

            if (_widthPerCol > 10 && this.m_resizeColumns)
            {
                foreach (ColumnHeader _col in this.Columns)
                {
                    _col.Width = (int)_widthPerCol;
                }
            }
        }
    }
}
