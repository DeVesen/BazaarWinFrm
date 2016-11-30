using System;
using System.Collections.Generic;
using DeVes.Bazaar.Data.Biz;

namespace DeVes.Bazaar.Data.Working
{
    public class Supplier
    {
        public BizSupplierer SupplierGet_ByID(Guid id)
        {
            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    var _row = GParams.Instance.SupplierTable.FetchById(id);

                    return BizSupplierer.ConvertFromDataRow(_row);
                }
                catch
                {
                    // ignored
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
                    var _row = GParams.Instance.SupplierTable.FetchByName(supplierName);

                    return BizSupplierer.ConvertFromDataRow(_row);
                }
                catch
                {
                    // ignored
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
                    var _row = GParams.Instance.SupplierTable.FetchByNo(supplierNumber);

                    return BizSupplierer.ConvertFromDataRow(_row);
                }
                catch
                {
                    // ignored
                }
            }

            return null;
        }

        public BizSupplierer[] SupplierGetAll()
        {
            var _resultList = new List<BizSupplierer>();

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    var _rows = GParams.Instance.SupplierTable.Select(string.Empty, "SupplierNo ASC");
                    if (_rows.Length > 0)
                    {
                        foreach (var _row in _rows)
                        {
                            _resultList.Add(BizSupplierer.ConvertFromDataRow(_row));
                        }
                    }
                }
                catch
                {
                    // ignored
                }
            }

            return _resultList.Count > 0 ? _resultList.ToArray() : null;
        }


        public Guid? SupplierCreate(BizSupplierer supplier)
        {
            if(!supplier.SupplierId.HasValue)
                supplier.SupplierId = Guid.NewGuid();

            supplier.SupplierNo = GParams.Instance.SupplierTable.GetNextSupplierNo();

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    var _newRow = GParams.Instance.SupplierTable.NewRow();

                    supplier.ConvertToDataRow(ref _newRow);

                    GParams.Instance.SupplierTable.Rows.Add(_newRow);
                    GParams.Instance.SupplierTable.SaveDataTable(GParams.Instance.ApplicationDataPath);
                }
                catch (Exception)
                {
                    supplier.SupplierId = null;
                }
            }

            return supplier.SupplierId;
        }
        public bool SupplierUpdate(BizSupplierer supplier)
        {
            var _result = true;

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    var _row = GParams.Instance.SupplierTable.FetchById(supplier.SupplierId);
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
            var _result = true;

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    var _row = GParams.Instance.SupplierTable.FetchById(supplierId);
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
            var _result = true;

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    var _row = GParams.Instance.SupplierTable.FetchById(supplierId);
                    if (_row != null)
                    {
                        var _supplierObj = BizSupplierer.ConvertFromDataRow(_row);

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
