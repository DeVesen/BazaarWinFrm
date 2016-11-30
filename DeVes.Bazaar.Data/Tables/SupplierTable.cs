using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DeVes.Bazaar.Data.Tables
{
    internal class SupplierTable : BasicTable
    {
        public SupplierTable()
        {
            this.TableName = "Supplier";

            this.Columns.Add("Id", typeof(string));
            this.Columns.Add("SupplierNo", typeof(int));

            this.Columns.Add("Salutation", typeof(string));
            this.Columns.Add("LastName", typeof(string));
            this.Columns.Add("FirstName", typeof(string));

            this.Columns.Add("Adress", typeof(string));
            this.Columns.Add("ZIPCode", typeof(string));
            this.Columns.Add("Town", typeof(string));

            this.Columns.Add("Phone01", typeof(string));
            this.Columns.Add("EMail01", typeof(string));

            this.Columns.Add("Memo", typeof(string));

            this.Columns.Add("ReturnedToSupplier", typeof(DateTime));
        }

        public DataRow FetchById(Guid? id)
        {
            if (id.HasValue)
            {
                DataRow[] _rows = this.Select("Id='" + id.ToString() + "'");
                if (_rows != null && _rows.Length == 1)
                    return _rows[0];
            }
            return null;
        }
        public DataRow FetchByName(string name)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(name.Trim()))
            {
                DataRow[] _rows = this.Select("LastName='" + name + "'");
                if (_rows != null && _rows.Length == 1)
                    return _rows[0];
            }
            return null;
        }
        public DataRow FetchByNo(int no)
        {
            if (no > 0)
            {
                DataRow[] _rows = this.Select("SupplierNo=" + no.ToString());
                if (_rows != null && _rows.Length == 1)
                    return _rows[0];
            }
            return null;
        }

        public int GetNextSupplierNo()
        {
            int _result = 1;
            DataRow[] _rows = this.Select(string.Empty, "SupplierNo desc");

            if (_rows != null && _rows.Length > 0)
            {
                _result = DeVes.Bazaar.Data.Biz.BizBase.ToInt32(_rows[0]["SupplierNo"]).Value + 1;
            }

            return _result;
        }
    }
}
