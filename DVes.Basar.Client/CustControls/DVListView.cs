using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DVes.Basar.Client.CustControls
{
    public class DVListView : ListView
    {
        private bool m_resizeColumns = false;
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

            float _width = (float)this.Width - 5;
            float _colCount = (float)this.Columns.Count;
            float _widthPerCol = _width / _colCount;

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
