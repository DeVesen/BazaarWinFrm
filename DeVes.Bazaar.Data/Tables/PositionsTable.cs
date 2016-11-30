using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DeVes.Bazaar.Data.Tables
{
    internal class PositionsTable : BasicTable
    {
        public PositionsTable()
        {
            this.TableName = "Positions";

            this.Columns.Add("SupplierId", typeof(string));

            this.Columns.Add("PositionNo", typeof(int));

            this.Columns.Add("Material", typeof(string));
            this.Columns.Add("Category", typeof(string));
            this.Columns.Add("Manufacturer", typeof(string));

            this.Columns.Add("PriceMin", typeof(double));
            this.Columns.Add("PriceMax", typeof(double));

            this.Columns.Add("SoldFor", typeof(double));
            this.Columns.Add("SoldAt", typeof(DateTime));

            this.Columns.Add("ReturnedToSupplierAt", typeof(DateTime));

            this.Columns.Add("Memo", typeof(string));

            this.Columns.Add("LastChange", typeof(DateTime));
        }

        public DataRow FetchByNo(int lineNo)
        {
            if (lineNo > 0)
            {
                DataRow[] _rows = this.Select("PositionNo = " + lineNo.ToString());
                if (_rows != null && _rows.Length == 1)
                    return _rows[0];
            }
            return null;
        }

        public DataRow[] SelectBySupplierId(Guid? supplierId)
        {
            if (supplierId.HasValue)
            {
                return this.Select("SupplierId='" + supplierId.ToString() + "'", "PositionNo ASC");
            }
            return null;
        }
    }
}
