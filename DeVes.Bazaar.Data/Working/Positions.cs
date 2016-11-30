using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeVes.Bazaar.Data.Biz;
using System.Data;
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
                    DataRow _row = GParams.Instance.PositionsTable.FetchByNo(positionNo);
                    if (_row != null)
                    {
                        return BizPosition.ConvertFromDataRow(_row);
                    }
                }
                catch
                {
                }
            }

            return null;
        }
        public BizPosition[] PositionGet(Guid supplierId)
        {
            List<BizPosition> _result = new List<BizPosition>();

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    DataRow[] _rows = GParams.Instance.PositionsTable.SelectBySupplierId(supplierId);
                    if (_rows != null && _rows.Length > 0)
                    {
                        foreach (DataRow _row in _rows)
                        {
                            _result.Add(BizPosition.ConvertFromDataRow(_row));
                        }
                    }
                }
                catch(Exception ex)
                {
                    _result.Clear();
                }
            }

            return _result.Count > 0 ? _result.ToArray() : null;
        }

        public PositionSellResult PositionSell(BizPosition[] position)
        {
            PositionSellResult _result = new PositionSellResult();

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    List<BizPosition> _soldPositions = new List<BizPosition>();
                    List<BizPosition> _notPossibleToSell = new List<BizPosition>();
                    List<PositionSellResult.NotSoldPosReasonTypes> _notSoldPosReason = new List<PositionSellResult.NotSoldPosReasonTypes>();

                    foreach (BizPosition _positionToSell in position)
                    {
                        DataRow _orgPositionrow =
                                GParams.Instance.PositionsTable.FetchByNo(_positionToSell.PositionNo);
                        BizPosition _orgPosition =
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
                                catch(Exception ex2)
                                {

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
                }
            }

            return _result;
        }

        public AllPositionResult[] AllSupplierAndPositions()
        {
            List<AllPositionResult> _resultList = new List<AllPositionResult>();
            lock (GParams.Instance.ComLockObj)
            {
                BizSupplierer[] _suppliers = GParams.Instance.Supplier.SupplierGetAll();
                if (_suppliers != null && _suppliers.Length > 0)
                {
                    foreach (BizSupplierer _supplier in _suppliers)
                    {
                        AllPositionResult _newResultItem = new AllPositionResult();
                        _newResultItem.Supplier = _supplier;
                        _newResultItem.Positions = this.PositionGet(_supplier.SupplierID.Value);

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
            PositionReturnedResult _result = new PositionReturnedResult();

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    DataRow[] _rows = GParams.Instance.PositionsTable.SelectBySupplierId(supplierId);
                    
                    List<BizPosition> _alreadyReturnedPositions = new List<BizPosition>();
                    List<BizPosition> _soldPositions = new List<BizPosition>();
                    List<BizPosition> _notSoldPositions = new List<BizPosition>();

                    for (int _i = 0; _i < _rows.Length; _i++)
                    {
                        DataRow _orgPositionRow = _rows[_i];
                        BizPosition _orgPosition = BizPosition.ConvertFromDataRow(_orgPositionRow);

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
                            else if (_orgPosition.ReturnedToSupplierAt.HasValue)
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
                            catch (Exception ex2)
                            {

                            }
                        }
                    }

                    _result.AlreadyReturnedPositions = _alreadyReturnedPositions.ToArray();
                    _result.SoldPositions = _soldPositions.ToArray();
                    _result.NotSoldPositions = _notSoldPositions.ToArray();
                }
                catch
                {
                }
            }

            return _result;
        }
        public BizPosition[] GetSoldPositions(Guid supplierId)
        {
            List<BizPosition> _result = new List<BizPosition>();

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    DataRow[] _rows = GParams.Instance.PositionsTable.SelectBySupplierId(supplierId);

                    for (int _i = 0; _i < _rows.Length; _i++)
                    {
                        DataRow _orgPositionRow = _rows[_i];
                        BizPosition _orgPosition = BizPosition.ConvertFromDataRow(_orgPositionRow);
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
                }
            }

            return _result.Count > 0 ? _result.ToArray() : null;
        }
        public BizPosition[] GetSoldNotReturnedPositions(Guid supplierId)
        {
            List<BizPosition> _result = new List<BizPosition>();

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    DataRow[] _rows = GParams.Instance.PositionsTable.SelectBySupplierId(supplierId);

                    for (int _i = 0; _i < _rows.Length; _i++)
                    {
                        DataRow _orgPositionRow = _rows[_i];
                        BizPosition _orgPosition = BizPosition.ConvertFromDataRow(_orgPositionRow);
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
                }
            }

            return _result.Count > 0 ? _result.ToArray() : null;
        }
        public BizPosition[] GetNotSoldNotReturnedPositions(Guid supplierId)
        {
            List<BizPosition> _result = new List<BizPosition>();

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    DataRow[] _rows = GParams.Instance.PositionsTable.SelectBySupplierId(supplierId);

                    for (int _i = 0; _i < _rows.Length; _i++)
                    {
                        DataRow _orgPositionRow = _rows[_i];
                        BizPosition _orgPosition = BizPosition.ConvertFromDataRow(_orgPositionRow);
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

                    Dictionary<Guid, DateTime> _suplIdToDateTime = new Dictionary<Guid, DateTime>();
                    //GParams.Instance.Supplier.SetSupplierToReturned(supplierId, isReturned);

                    foreach(BizPosition _position in positions)
                    {
                        if (!_suplIdToDateTime.ContainsKey(_position.SupplierId))
                            _suplIdToDateTime[_position.SupplierId] = DateTime.Now;

                        _position.ReturnedToSupplierAt = _suplIdToDateTime[_position.SupplierId];
                        GParams.Instance.Position.PositionUpdate(_position);
                    }

                    foreach (Guid _suplId in _suplIdToDateTime.Keys)
                    {
                        GParams.Instance.Supplier.SetSupplierToReturned(_suplId, _suplIdToDateTime[_suplId]);
                    }
                }
                catch
                {
                }
            }
        }

        public bool PositionCreate(BizPosition supplierPosition)
        {
            bool _result = true;

            //Check for Min
            if (!supplierPosition.CheckForMin())
            {
                throw new Exception("min Informations not Filled");
            }

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    DataRow _newRow = GParams.Instance.PositionsTable.NewRow();

                    supplierPosition.LastChange = DateTime.Now;

                    supplierPosition.ConvertToDataRow(ref _newRow);

                    GParams.Instance.PositionsTable.Rows.Add(_newRow);
                    GParams.Instance.PositionsTable.SaveDataTable(GParams.Instance.ApplicationDataPath);
                }
                catch (Exception ex)
                {
                    _result = false;
                }
            }

            return _result;
        }
        public bool PositionUpdate(BizPosition supplierPosition)
        {
            bool _result = true;

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    DataRow _row = GParams.Instance.PositionsTable.FetchByNo(supplierPosition.PositionNo);
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
            bool _result = true;

            lock (GParams.Instance.ComLockObj)
            {
                try
                {
                    DataRow _row = GParams.Instance.PositionsTable.FetchByNo(positionNo);
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
            string _filter = string.Empty;
            BizSupplierer _supplierBiz = GParams.Instance.Supplier.SupplierGet_No(supplierNumber);

            if (_supplierBiz != null)
            {
                string _posFilter = string.Format("SupplierId = '{0}'", _supplierBiz.SupplierID.ToString());

                DataRow[] _rows = GParams.Instance.PositionsTable.Select(_posFilter, "PositionNo Asc");

                if (_rows != null && _rows.Length > 0)
                {
                    foreach (DataRow _row in _rows)
                    {
                        _row.Delete();
                    }

                    GParams.Instance.PositionsTable.SaveDataTable(GParams.Instance.ApplicationDataPath);
                }
            }
        }
        public void RemoveSoldFromPosition(int positionNumber)
        {
            string _filter = string.Empty;
            if (positionNumber > 0)
                _filter = "PositionNo = " + positionNumber.ToString();

            DataRow[] _rows = GParams.Instance.PositionsTable.Select(_filter, "PositionNo Asc");

            if (_rows != null && _rows.Length > 0)
            {
                foreach (DataRow _row in _rows)
                {
                    _row["SoldAt"] = DBNull.Value;
                    _row["SoldFor"] = DBNull.Value;
                }

                GParams.Instance.PositionsTable.SaveDataTable(GParams.Instance.ApplicationDataPath);
            }
        }
        public void RemoveReturnedFromPosition(int positionNumber)
        {
            string _filter = string.Empty;
            if (positionNumber > 0)
                _filter = "PositionNo = " + positionNumber.ToString();

            DataRow[] _rows = GParams.Instance.PositionsTable.Select(_filter, "PositionNo Asc");

            if (_rows != null && _rows.Length > 0)
            {
                foreach (DataRow _row in _rows)
                {
                    _row["ReturnedToSupplierAt"] = DBNull.Value;
                }

                GParams.Instance.PositionsTable.SaveDataTable(GParams.Instance.ApplicationDataPath);
            }
        }


        public void PositionsStats(out int positionsCount, out int notSold, out int isSold, out int isReturn,
                                   out double soldBetrag)
        {
            positionsCount = GParams.Instance.PositionsTable.Rows.Count;

            DataRow[] _notSold = GParams.Instance.PositionsTable.Select("SoldAt is null and ReturnedToSupplierAt is null");
            notSold = _notSold != null ? _notSold.Length : 0;

            DataRow[] _isSold = GParams.Instance.PositionsTable.Select("SoldAt is not null");
            isSold = _isSold != null ? _isSold.Length : 0;
            soldBetrag = 0;
            foreach (DataRow _isSoldRow in _isSold)
            {
                if (GParams.ToDouble(_isSoldRow["SoldFor"]).HasValue)
                    soldBetrag += GParams.ToDouble(_isSoldRow["SoldFor"]).Value;
            }

            DataRow[] _isReturn = GParams.Instance.PositionsTable.Select("ReturnedToSupplierAt is not null");
            isReturn = _isReturn != null ? _isReturn.Length : 0;
        }
    }
}
