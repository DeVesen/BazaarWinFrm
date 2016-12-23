using System;
using System.Collections.Generic;
using DeVes.Bazaar.Data.Biz;
using DeVes.Bazaar.Data.DataObjekts;

namespace DeVes.Bazaar.Data.Working
{
    public class Positions
    {
        public BizPosition PositionGet(int positionNo)
        {
            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    var _row = GParams.Instance.PositionsTable.FetchByNo(positionNo);
                    if (_row != null)
                    {
                        return BizPosition.ConvertFromDataRow(_row);
                    }
                }
                catch
                {
                    // ignored
                }
            }

            return null;
        }
        public BizPosition[] PositionGet(Guid? supplierId)
        {
            if (!supplierId.HasValue) return new BizPosition[0];

            var _result = new List<BizPosition>();

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    var _rows = GParams.Instance.PositionsTable.SelectBySupplierId(supplierId);
                    if (_rows != null && _rows.Length > 0)
                    {
                        foreach (var _row in _rows)
                        {
                            _result.Add(BizPosition.ConvertFromDataRow(_row));
                        }
                    }
                }
                catch(Exception)
                {
                    _result.Clear();
                }
            }

            return _result.Count > 0 ? _result.ToArray() : null;
        }
        public BizPosition[] PositionsGet(int supplierNum)
        {
            var _supplier = GParams.Instance.Supplier.SupplierGet_No(supplierNum);

            if (_supplier == null) return new BizPosition[0];

            return PositionGet(_supplier.SupplierId);
        }

        public PositionSellResult PositionSell(BizPosition[] position)
        {
            var _result = new PositionSellResult();

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    var _soldPositions = new List<BizPosition>();
                    var _notPossibleToSell = new List<BizPosition>();
                    var _notSoldPosReason = new List<PositionSellResult.NotSoldPosReasonTypes>();

                    foreach (var _positionToSell in position)
                    {
                        var _orgPositionrow =
                                GParams.Instance.PositionsTable.FetchByNo(_positionToSell.PositionNo);
                        var _orgPosition =
                                BizPosition.ConvertFromDataRow(_orgPositionrow);

                        if (_orgPosition != null)
                        {
                            if (_orgPosition.SoldAt != _positionToSell.SoldAt)
                            {
                                _notPossibleToSell.Add(_positionToSell);
                                _notSoldPosReason.Add(PositionSellResult.NotSoldPosReasonTypes.MeanTimeSold);
                            }
                            else if (_orgPosition.ReturnedToSupplierAt != _positionToSell.ReturnedToSupplierAt)
                            {
                                _notPossibleToSell.Add(_positionToSell);
                                _notSoldPosReason.Add(PositionSellResult.NotSoldPosReasonTypes.MeanTimeReturned);
                            }
                            //else if (_orgPosition.LastChange != _positionToSell.LastChange)
                            //{
                            //    _notPossibleToSell.Add(_positionToSell);
                            //    _notSoldPosReason.Add(PositionSellResult.NotSoldPosReasonTypes.MeanTimeChanged);
                            //}
                            else
                            {
                                try
                                {
                                    _orgPosition.SoldAt = DateTime.Now;
                                    _orgPosition.SoldFor = _positionToSell.SoldFor;

                                    _orgPosition.ConvertToDataRow(ref _orgPositionrow);

                                    GParams.Instance.PositionsTable.SaveDataTable(GParams.Instance.ApplicationDataPath);

                                    _soldPositions.Add(_orgPosition);
                                }
                                catch (Exception)
                                {
                                    // ignored
                                }
                            }
                        }
                        else
                        {
                            _notPossibleToSell.Add(_positionToSell);
                            _notSoldPosReason.Add(PositionSellResult.NotSoldPosReasonTypes.NotFound);
                        }
                    }

                    _result.SoldPositions = (_soldPositions.Count > 0) ? _soldPositions.ToArray() : null;
                    _result.NotPossibleToSell = (_notPossibleToSell.Count > 0) ? _notPossibleToSell.ToArray() : null;
                    _result.NotSoldPosReason = (_notSoldPosReason.Count > 0) ? _notSoldPosReason.ToArray() : null;
                }
                catch
                {
                    // ignored
                }
            }

            return _result;
        }

        public AllPositionResult[] AllSupplierAndPositions()
        {
            var _resultList = new List<AllPositionResult>();
            lock (GParams.Instance.ComLockObj)
            {
                var _suppliers = GParams.Instance.Supplier.SupplierGetAll();
                if (_suppliers != null && _suppliers.Length > 0)
                {
                    foreach (var _supplier in _suppliers)
                    {
                        var _newResultItem = new AllPositionResult();
                        _newResultItem.Supplier = _supplier;
                        _newResultItem.Positions = this.PositionGet(_supplier.SupplierId);

                        if (_newResultItem.Positions != null && _newResultItem.Positions.Length > 0)
                        {
                            _resultList.Add(_newResultItem);
                        }
                    }
                }
            }
            return _resultList.Count > 0 ? _resultList.ToArray() : null;
        }

        
        public PositionReturnedResult PositionReturn(Guid supplierId)
        {
            var _result = new PositionReturnedResult();

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    var _rows = GParams.Instance.PositionsTable.SelectBySupplierId(supplierId);
                    
                    var _alreadyReturnedPositions = new List<BizPosition>();
                    var _soldPositions = new List<BizPosition>();
                    var _notSoldPositions = new List<BizPosition>();

                    for (var _i = 0; _i < _rows.Length; _i++)
                    {
                        var _orgPositionRow = _rows[_i];
                        var _orgPosition = BizPosition.ConvertFromDataRow(_orgPositionRow);

                        if (_orgPosition != null)
                        {
                            if (_orgPosition.SoldAt.HasValue && !_orgPosition.ReturnedToSupplierAt.HasValue)
                            {
                                if (_orgPosition.SoldFor.HasValue)
                                    _result.PositionsToReturnMoney += _orgPosition.SoldFor.Value;

                                _soldPositions.Add(_orgPosition);
                            }
                            else if (!_orgPosition.ReturnedToSupplierAt.HasValue)
                            {
                                _notSoldPositions.Add(_orgPosition);
                            }
                            else
                            {
                                _alreadyReturnedPositions.Add(_orgPosition);
                            }

                            try
                            {
                                if (!_orgPosition.ReturnedToSupplierAt.HasValue)
                                {
                                    _result.PositionsToReturnCountTotal++;

                                    _orgPosition.ReturnedToSupplierAt = DateTime.Now;
                                    _orgPosition.LastChange = DateTime.Now;

                                    _orgPosition.ConvertToDataRow(ref _orgPositionRow);

                                    GParams.Instance.PositionsTable.SaveDataTable(GParams.Instance.ApplicationDataPath);
                                }
                            }
                            catch (Exception)
                            {
                                // ignored
                            }
                        }
                    }

                    _result.AlreadyReturnedPositions = _alreadyReturnedPositions.ToArray();
                    _result.SoldPositions = _soldPositions.ToArray();
                    _result.NotSoldPositions = _notSoldPositions.ToArray();
                }
                catch
                {
                    // ignored
                }
            }

            return _result;
        }
        public BizPosition[] GetSoldPositions(Guid supplierId)
        {
            var _result = new List<BizPosition>();

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    var _rows = GParams.Instance.PositionsTable.SelectBySupplierId(supplierId);

                    for (var _i = 0; _i < _rows.Length; _i++)
                    {
                        var _orgPositionRow = _rows[_i];
                        var _orgPosition = BizPosition.ConvertFromDataRow(_orgPositionRow);
                        if (_orgPosition != null)
                        {
                            if (_orgPosition.SoldAt.HasValue)
                            {
                                _result.Add(_orgPosition);
                            }
                        }
                    }
                }
                catch
                {
                    // ignored
                }
            }

            return _result.Count > 0 ? _result.ToArray() : null;
        }
        public BizPosition[] GetSoldNotReturnedPositions(Guid supplierId)
        {
            var _result = new List<BizPosition>();

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    var _rows = GParams.Instance.PositionsTable.SelectBySupplierId(supplierId);

                    for (var _i = 0; _i < _rows.Length; _i++)
                    {
                        var _orgPositionRow = _rows[_i];
                        var _orgPosition = BizPosition.ConvertFromDataRow(_orgPositionRow);
                        if (_orgPosition != null)
                        {
                            if (_orgPosition.SoldAt.HasValue && !_orgPosition.ReturnedToSupplierAt.HasValue)
                            {
                                _result.Add(_orgPosition);
                            }
                        }
                    }
                }
                catch
                {
                    // ignored
                }
            }

            return _result.Count > 0 ? _result.ToArray() : null;
        }
        public BizPosition[] GetNotSoldNotReturnedPositions(Guid supplierId)
        {
            var _result = new List<BizPosition>();

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    var _rows = GParams.Instance.PositionsTable.SelectBySupplierId(supplierId);

                    for (var _i = 0; _i < _rows.Length; _i++)
                    {
                        var _orgPositionRow = _rows[_i];
                        var _orgPosition = BizPosition.ConvertFromDataRow(_orgPositionRow);
                        if (_orgPosition != null)
                        {
                            if (!_orgPosition.SoldAt.HasValue && !_orgPosition.ReturnedToSupplierAt.HasValue)
                            {
                                _result.Add(_orgPosition);
                            }
                        }
                    }
                }
                catch
                {
                    // ignored
                }
            }

            return _result.Count > 0 ? _result.ToArray() : null;
        }

        public void SetPositionsAsReturned(BizPosition[] positions)
        {
            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    if (positions == null)
                        return;

                    var _suplIdToDateTime = new Dictionary<Guid, DateTime>();
                    //GParams.Instance.Supplier.SetSupplierToReturned(supplierId, isReturned);

                    foreach(var _position in positions)
                    {
                        if (!_suplIdToDateTime.ContainsKey(_position.SupplierId))
                            _suplIdToDateTime[_position.SupplierId] = DateTime.Now;

                        _position.ReturnedToSupplierAt = _suplIdToDateTime[_position.SupplierId];
                        GParams.Instance.Position.PositionUpdate(_position);
                    }

                    foreach (var _suplId in _suplIdToDateTime.Keys)
                    {
                        GParams.Instance.Supplier.SetSupplierToReturned(_suplId, _suplIdToDateTime[_suplId]);
                    }
                }
                catch
                {
                    // ignored
                }
            }
        }

        public bool PositionCreate(BizPosition supplierPosition)
        {
            var _result = true;

            //Check for Min
            if (!supplierPosition.CheckForMin())
            {
                throw new Exception("min Informations not Filled");
            }

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    var _newRow = GParams.Instance.PositionsTable.NewRow();

                    supplierPosition.LastChange = DateTime.Now;

                    supplierPosition.ConvertToDataRow(ref _newRow);

                    GParams.Instance.PositionsTable.Rows.Add(_newRow);
                    GParams.Instance.PositionsTable.SaveDataTable(GParams.Instance.ApplicationDataPath);
                }
                catch (Exception)
                {
                    _result = false;
                }
            }

            return _result;
        }
        public bool PositionUpdate(BizPosition supplierPosition)
        {
            var _result = true;

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    var _row = GParams.Instance.PositionsTable.FetchByNo(supplierPosition.PositionNo);
                    if (_row != null)
                    {
                        supplierPosition.ConvertToDataRow(ref _row);

                        supplierPosition.LastChange = DateTime.Now;

                        GParams.Instance.PositionsTable.SaveDataTable(GParams.Instance.ApplicationDataPath);
                    }
                }
                catch
                {
                    _result = false;
                }
            }

            return _result;
        }
        public bool PositionRemove(int positionNo)
        {
            var _result = true;

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    var _row = GParams.Instance.PositionsTable.FetchByNo(positionNo);
                    if (_row != null)
                    {
                        _row.Delete();

                        GParams.Instance.PositionsTable.SaveDataTable(GParams.Instance.ApplicationDataPath);
                    }
                }
                catch
                {
                    _result = false;
                }
            }

            return _result;
        }



        public void RemovePositionsOfSupplier(int supplierNumber)
        {
            var _supplierBiz = GParams.Instance.Supplier.SupplierGet_No(supplierNumber);

            if (_supplierBiz != null)
            {
                var _posFilter = string.Format("SupplierId = '{0}'", _supplierBiz.SupplierId.ToString());

                var _rows = GParams.Instance.PositionsTable.Select(_posFilter, "PositionNo Asc");

                if (_rows.Length <= 0) return;

                foreach (var _row in _rows)
                {
                    _row.Delete();
                }

                GParams.Instance.PositionsTable.SaveDataTable(GParams.Instance.ApplicationDataPath);
            }
        }
        public void RemoveSoldFromPosition(int positionNumber)
        {
            var _filter = string.Empty;
            if (positionNumber > 0)
                _filter = "PositionNo = " + positionNumber.ToString();

            var _rows = GParams.Instance.PositionsTable.Select(_filter, "PositionNo Asc");

            if (_rows.Length <= 0) return;

            foreach (var _row in _rows)
            {
                _row["SoldAt"] = DBNull.Value;
                _row["SoldFor"] = DBNull.Value;
            }

            GParams.Instance.PositionsTable.SaveDataTable(GParams.Instance.ApplicationDataPath);
        }
        public void RemoveReturnedFromPosition(int positionNumber)
        {
            var _filter = string.Empty;
            if (positionNumber > 0)
                _filter = "PositionNo = " + positionNumber.ToString();

            var _rows = GParams.Instance.PositionsTable.Select(_filter, "PositionNo Asc");

            if (_rows.Length <= 0) return;

            foreach (var _row in _rows)
            {
                _row["ReturnedToSupplierAt"] = DBNull.Value;
            }

            GParams.Instance.PositionsTable.SaveDataTable(GParams.Instance.ApplicationDataPath);
        }


        public void PositionsStats(out int positionsCount, out int notSold, out int isSold, out int isReturn,
                                   out double soldBetrag)
        {
            positionsCount = GParams.Instance.PositionsTable.Rows.Count;

            var _notSold = GParams.Instance.PositionsTable.Select("SoldAt is null and ReturnedToSupplierAt is null");
            notSold = _notSold.Length;

            var _isSold = GParams.Instance.PositionsTable.Select("SoldAt is not null");
            isSold = _isSold.Length;
            soldBetrag = 0;
            foreach (var _isSoldRow in _isSold)
            {
                if (GParams.ToDouble(_isSoldRow["SoldFor"]).HasValue)
                    soldBetrag += GParams.ToDouble(_isSoldRow["SoldFor"]) ?? 0;
            }

            var _isReturn = GParams.Instance.PositionsTable.Select("ReturnedToSupplierAt is not null");
            isReturn = _isReturn.Length;
        }
    }
}
