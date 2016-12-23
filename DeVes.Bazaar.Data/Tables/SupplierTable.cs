using System;
using System.Data;
using DeVes.Bazaar.Data.Biz;

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
                var _rows = this.Select("Id='" + id.ToString() + "'");
                if (_rows.Length == 1)
                    return _rows[0];
            }
            return null;
        }
        public DataRow FetchByName(string name)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(name.Trim()))
            {
                var _rows = this.Select("LastName='" + name + "'");
                if (_rows.Length == 1)
                    return _rows[0];
            }
            return null;
        }
        public DataRow FetchByNo(int no)
        {
            if (no > 0)
            {
                var _rows = this.Select("SupplierNo=" + no.ToString());
                if (_rows.Length == 1)
                    return _rows[0];
            }
            return null;
        }

        public int GetNextSupplierNo()
        {
            var _result = 1;
            var _rows = this.Select(string.Empty, "SupplierNo desc");

            if (_rows.Length > 0)
            {
                var _toInt = BizBase.ToInt32(_rows[0]["SupplierNo"]);
                _result = (_toInt ?? 0) + 1;
            }

            return _result;
        }
    }
}
