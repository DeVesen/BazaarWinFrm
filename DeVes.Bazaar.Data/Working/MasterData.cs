using System;
using System.Collections.Generic;
using System.Linq;
using DeVes.Bazaar.Data.Biz;

namespace DeVes.Bazaar.Data.Working
{
    public class MasterData
    {
        #region . Material Category .

        public BizMaterialCategory MaterialCategoryGet(Guid id)
        {
            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    var _row = GParams.Instance.MaterialCategoryTable.FetchById(id);
                    if (_row != null)
                    {
                        return BizMaterialCategory.ConvertFromDataRow(_row);
                    }
                }
                catch
                {
                    // ignored
                }
            }

            return null;
        }
        public BizMaterialCategory[] MaterialCategoryGetAll()
        {
            var _result = new List<BizMaterialCategory>();

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    var _rows = GParams.Instance.MaterialCategoryTable.Select(string.Empty, "Designation ASC");
                    if (_rows.Length > 0)
                    {
                        foreach (var _row in _rows)
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
            var _result = true;

            if (!materialCategory.Id.HasValue)
                materialCategory.Id = Guid.NewGuid();

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    var _newRow = GParams.Instance.MaterialCategoryTable.NewRow();

                    materialCategory.ConvertToDataRow(ref _newRow);

                    GParams.Instance.MaterialCategoryTable.Rows.Add(_newRow);
                    GParams.Instance.MaterialCategoryTable.SaveDataTable(GParams.Instance.ApplicationDataPath);
                }
                catch (Exception)
                {
                    _result = false;
                }
            }

            return _result;
        }
        public bool MaterialCategoryUpdate(BizMaterialCategory materialCategory)
        {
            var _result = true;

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    var _row = GParams.Instance.MaterialCategoryTable.FetchById(materialCategory.Id);
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
            var _result = true;

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    var _row = GParams.Instance.MaterialCategoryTable.FetchById(matlCatId);
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

        public BizManufacturer ManufacturerGet(Guid id)
        {
            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    var _row = GParams.Instance.ManufacturerTable.FetchById(id);
                    if (_row != null)
                    {
                        return BizManufacturer.ConvertFromDataRow(_row);
                    }
                }
                catch
                {
                    // ignored
                }
            }

            return null;
        }
        public BizManufacturer[] ManufacturerGetAll()
        {
            var _result = new List<BizManufacturer>();

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    var _rows = GParams.Instance.ManufacturerTable.Select(string.Empty, "Designation ASC");
                    if (_rows.Length > 0)
                    {
                        _result.AddRange(_rows.Select(BizManufacturer.ConvertFromDataRow));
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
            var _result = true;

            if (!manufacturer.Id.HasValue)
                manufacturer.Id = Guid.NewGuid();

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    var _newRow = GParams.Instance.ManufacturerTable.NewRow();

                    manufacturer.ConvertToDataRow(ref _newRow);

                    GParams.Instance.ManufacturerTable.Rows.Add(_newRow);
                    GParams.Instance.ManufacturerTable.SaveDataTable(GParams.Instance.ApplicationDataPath);
                }
                catch (Exception)
                {
                    _result = false;
                }
            }

            return _result;
        }
        public bool ManufacturerUpdate(BizManufacturer materialCategory)
        {
            var _result = true;

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    var _row = GParams.Instance.ManufacturerTable.FetchById(materialCategory.Id);
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
            var _result = true;

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    var _row = GParams.Instance.ManufacturerTable.FetchById(matlCatId);
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
