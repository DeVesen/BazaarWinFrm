using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DeVes.Bazaar.Data.Biz;
using DeVes.Bazaar.Data;

namespace DeVes.Bazaar.Data.Working
{
    public class MasterData
    {
        #region . Material Category .

        public BizMaterialCategory MaterialCategoryGet(Guid Id)
        {
            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    DataRow _row = GParams.Instance.MaterialCategoryTable.FetchById(Id);
                    if (_row != null)
                    {
                        return BizMaterialCategory.ConvertFromDataRow(_row);
                    }
                }
                catch
                {
                }
            }

            return null;
        }
        public BizMaterialCategory[] MaterialCategoryGetAll()
        {
            List<BizMaterialCategory> _result = new List<BizMaterialCategory>();

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    DataRow[] _rows = GParams.Instance.MaterialCategoryTable.Select(string.Empty, "Designation ASC");
                    if (_rows != null && _rows.Length > 0)
                    {
                        foreach (DataRow _row in _rows)
                        {
                            _result.Add(BizMaterialCategory.ConvertFromDataRow(_row));
                        }
                    }
                }
                catch
                {
                    _result.Clear();
                }
            }

            return _result.Count > 0 ? _result.ToArray() : null;
        }

        public bool MaterialCategoryCreate(BizMaterialCategory materialCategory)
        {
            bool _result = true;

            if (!materialCategory.Id.HasValue)
                materialCategory.Id = Guid.NewGuid();

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    DataRow _newRow = GParams.Instance.MaterialCategoryTable.NewRow();

                    materialCategory.ConvertToDataRow(ref _newRow);

                    GParams.Instance.MaterialCategoryTable.Rows.Add(_newRow);
                    GParams.Instance.MaterialCategoryTable.SaveDataTable(GParams.Instance.ApplicationDataPath);
                }
                catch (Exception ex)
                {
                    _result = false;
                }
            }

            return _result;
        }
        public bool MaterialCategoryUpdate(BizMaterialCategory materialCategory)
        {
            bool _result = true;

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    DataRow _row = GParams.Instance.MaterialCategoryTable.FetchById(materialCategory.Id);
                    if (_row != null)
                    {
                        materialCategory.ConvertToDataRow(ref _row);

                        GParams.Instance.MaterialCategoryTable.SaveDataTable(GParams.Instance.ApplicationDataPath);
                    }
                }
                catch
                {
                    _result = false;
                }
            }

            return _result;
        }
        public bool MaterialCategoryRemove(Guid matlCatId)
        {
            bool _result = true;

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    DataRow _row = GParams.Instance.MaterialCategoryTable.FetchById(matlCatId);
                    if (_row != null)
                    {
                        _row.Delete();

                        GParams.Instance.MaterialCategoryTable.SaveDataTable(GParams.Instance.ApplicationDataPath);
                    }
                }
                catch
                {
                    _result = false;
                }
            }

            return _result;
        }

        #endregion . Material Category .


        #region . Manufacturer .

        public BizManufacturer ManufacturerGet(Guid Id)
        {
            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    DataRow _row = GParams.Instance.ManufacturerTable.FetchById(Id);
                    if (_row != null)
                    {
                        return BizManufacturer.ConvertFromDataRow(_row);
                    }
                }
                catch
                {
                }
            }

            return null;
        }
        public BizManufacturer[] ManufacturerGetAll()
        {
            List<BizManufacturer> _result = new List<BizManufacturer>();

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    DataRow[] _rows = GParams.Instance.ManufacturerTable.Select(string.Empty, "Designation ASC");
                    if (_rows != null && _rows.Length > 0)
                    {
                        foreach (DataRow _row in _rows)
                        {
                            _result.Add(BizManufacturer.ConvertFromDataRow(_row));
                        }
                    }
                }
                catch
                {
                    _result.Clear();
                }
            }

            return _result.Count > 0 ? _result.ToArray() : null;
        }

        public bool ManufacturerCreate(BizManufacturer manufacturer)
        {
            bool _result = true;

            if (!manufacturer.Id.HasValue)
                manufacturer.Id = Guid.NewGuid();

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    DataRow _newRow = GParams.Instance.ManufacturerTable.NewRow();

                    manufacturer.ConvertToDataRow(ref _newRow);

                    GParams.Instance.ManufacturerTable.Rows.Add(_newRow);
                    GParams.Instance.ManufacturerTable.SaveDataTable(GParams.Instance.ApplicationDataPath);
                }
                catch (Exception ex)
                {
                    _result = false;
                }
            }

            return _result;
        }
        public bool ManufacturerUpdate(BizManufacturer materialCategory)
        {
            bool _result = true;

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    DataRow _row = GParams.Instance.ManufacturerTable.FetchById(materialCategory.Id);
                    if (_row != null)
                    {
                        materialCategory.ConvertToDataRow(ref _row);

                        GParams.Instance.ManufacturerTable.SaveDataTable(GParams.Instance.ApplicationDataPath);
                    }
                }
                catch
                {
                    _result = false;
                }
            }

            return _result;
        }
        public bool ManufacturerRemove(Guid matlCatId)
        {
            bool _result = true;

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    DataRow _row = GParams.Instance.ManufacturerTable.FetchById(matlCatId);
                    if (_row != null)
                    {
                        _row.Delete();

                        GParams.Instance.ManufacturerTable.SaveDataTable(GParams.Instance.ApplicationDataPath);
                    }
                }
                catch
                {
                    _result = false;
                }
            }

            return _result;
        }

        #endregion . Manufacturer .
    }
}
