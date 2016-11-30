using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DVes.Basar.Data.Biz;

namespace DVes.Basar.Data.Working
{
    public class Supplier
    {
        public BizSupplierer SupplierGet_ByID(Guid id)
        {
            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    DataRow _row = GParams.Instance.SupplierTable.FetchById(id);

                    return BizSupplierer.ConvertFromDataRow(_row);
                }
                catch
                {
                }
            }

            return null;
        }
        public BizSupplierer SupplierGet_ByName(string supplierName)
        {
            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    DataRow _row = GParams.Instance.SupplierTable.FetchByName(supplierName);

                    return BizSupplierer.ConvertFromDataRow(_row);
                }
                catch
                {
                }
            }

            return null;
        }
        public BizSupplierer SupplierGet_No(int supplierNumber)
        {
            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    DataRow _row = GParams.Instance.SupplierTable.FetchByNo(supplierNumber);

                    return BizSupplierer.ConvertFromDataRow(_row);
                }
                catch
                {
                }
            }

            return null;
        }

        public BizSupplierer[] SupplierGetAll()
        {
            List<BizSupplierer> _resultList = new List<BizSupplierer>();

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    DataRow[] _rows = GParams.Instance.SupplierTable.Select(string.Empty, "SupplierNo ASC");
                    if (_rows != null && _rows.Length > 0)
                    {
                        foreach (DataRow _row in _rows)
                        {
                            _resultList.Add(BizSupplierer.ConvertFromDataRow(_row));
                        }
                    }
                }
                catch
                {
                }
            }

            return _resultList.Count > 0 ? _resultList.ToArray() : null;
        }


        public Guid? SupplierCreate(BizSupplierer supplier)
        {
            if(!supplier.SupplierID.HasValue)
                supplier.SupplierID = Guid.NewGuid();

            supplier.SupplierNo = GParams.Instance.SupplierTable.GetNextSupplierNo();

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    DataRow _newRow = GParams.Instance.SupplierTable.NewRow();

                    supplier.ConvertToDataRow(ref _newRow);

                    GParams.Instance.SupplierTable.Rows.Add(_newRow);
                    GParams.Instance.SupplierTable.SaveDataTable(GParams.Instance.ApplicationDataPath);
                }
                catch (Exception ex)
                {
                    supplier.SupplierID = null;
                }
            }

            return supplier.SupplierID;
        }
        public bool SupplierUpdate(BizSupplierer supplier)
        {
            bool _result = true;

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    DataRow _row = GParams.Instance.SupplierTable.FetchById(supplier.SupplierID);
                    if (_row != null)
                    {
                        supplier.ConvertToDataRow(ref _row);

                        GParams.Instance.SupplierTable.SaveDataTable(GParams.Instance.ApplicationDataPath);
                    }
                }
                catch
                {
                    _result = false;
                }
            }

            return _result;
        }
        public bool SupplierRemove(Guid supplierId)
        {
            bool _result = true;

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    DataRow _row = GParams.Instance.SupplierTable.FetchById(supplierId);
                    if (_row != null)
                    {
                        _row.Delete();

                        GParams.Instance.SupplierTable.SaveDataTable(GParams.Instance.ApplicationDataPath);
                    }
                }
                catch
                {
                    _result = false;
                }
            }

            return _result;
        }



        public void SupplierStats(out int supplCount)
        {
            supplCount = GParams.Instance.SupplierTable.Rows.Count;
        }

        public bool SetSupplierToReturned(Guid? supplierId, DateTime? dateTime)
        {
            bool _result = true;

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    DataRow _row = GParams.Instance.SupplierTable.FetchById(supplierId);
                    if (_row != null)
                    {
                        BizSupplierer _supplierObj = BizSupplierer.ConvertFromDataRow(_row);

                        if (dateTime.HasValue)
                        {
                            _supplierObj.ReturnedToSupplier = dateTime.Value;
                        }
                        else
                        {
                            _supplierObj.ReturnedToSupplier = null;
                        }

                        this.SupplierUpdate(_supplierObj);
                    }
                }
                catch
                {
                    _result = false;
                }
            }

            return _result;
        }
    }
}
