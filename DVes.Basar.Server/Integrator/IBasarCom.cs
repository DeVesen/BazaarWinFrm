﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using DVes.Basar.Data.Biz;
using DVes.Basar.Data.Tables;
using DVes.Basar.Data.DataObjekts;

namespace DVes.Basar.Server.Integrator
{
    [ServiceContract]
    public interface IBasarCom
    {
        [OperationContract]
        string CheckAlive();
        
        [OperationContract]
        ParameterResult GetParameters();


        #region . Material Category .

        [OperationContract]
        BizMaterialCategory MaterialCategoryGet(Guid Id);
        [OperationContract]
        BizMaterialCategory[] MaterialCategoryGetAll();

        [OperationContract]
        bool MaterialCategoryCreate(BizMaterialCategory materialCategory);
        [OperationContract]
        bool MaterialCategoryUpdate(BizMaterialCategory materialCategory);
        [OperationContract]
        bool MaterialCategoryRemove(Guid matlCatId);

        #endregion . Material Category .


        #region . Manufacturer .

        [OperationContract]
        BizManufacturer ManufacturerGet(Guid Id);
        [OperationContract]
        BizManufacturer[] ManufacturerGetAll();

        [OperationContract]
        bool ManufacturerCreate(BizManufacturer manufacturer);
        [OperationContract]
        bool ManufacturerUpdate(BizManufacturer materialCategory);
        [OperationContract]
        bool ManufacturerRemove(Guid matlCatId);

        #endregion . Manufacturer .


        #region . Supplier .

        [OperationContract]
        BizSupplierer SupplierGet_ByID(Guid id);
        [OperationContract]
        BizSupplierer SupplierGet_ByName(string supplierName);
        [OperationContract]
        BizSupplierer SupplierGet_No(int supplierNumber);

        [OperationContract]
        BizSupplierer[] SupplierGetAll();
        
        [OperationContract]
        Guid? SupplierCreate(BizSupplierer supplier);
        [OperationContract]
        bool SupplierUpdate(BizSupplierer supplier);
        [OperationContract]
        bool SupplierRemove(Guid supplierId);
        [OperationContract]
        bool SetSupplierToReturned(Guid? supplierId, bool isReturned);

        #endregion . Supplier .


        #region . Supplierer Position .

        [OperationContract]
        bool PositionCreate(BizPosition supplierPosition);
        [OperationContract]
        bool PositionUpdate(BizPosition supplierPosition);
        [OperationContract]
        bool PositionRemove(int positionNo);

        [OperationContract]
        PositionSellResult PositionSell(BizPosition[] position);
        [OperationContract]
        PositionReturnedResult PositionReturn(Guid supplierId);

        [OperationContract]
        BizPosition[] GetSoldPositions(Guid supplierId);
        [OperationContract]
        BizPosition[] GetSoldNotReturnedPositions(Guid supplierId);
        [OperationContract]
        BizPosition[] GetNotSoldNotReturnedPositions(Guid supplierId);
        [OperationContract]
        void SetPositionsAsReturned(BizPosition[] positions);

        [OperationContract]
        BizPosition PositionGet(int positionNo);
        [OperationContract]
        BizPosition[] PositionGetAll(Guid supplierId);
        [OperationContract]
        AllPositionResult[] AllSupplierAndPositions();

        #endregion . Supplierer Position .
    }
}
