using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DeVes.Bazaar.Data;
using DeVes.Bazaar.Data.Biz;
using DeVes.Bazaar.Data.Tables;
using DeVes.Bazaar.Data.DataObjekts;

namespace DeVes.Bazaar.Server.Integrator
{
    class BasarCom : IBasarCom
    {
        private static int ComCounter = 0;
        private static bool CheckComCounter()
        {
            //if (!Program.OptionExist("IsActivated"))
            //{
            //    BasarCom.ComCounter++;
            //    return BasarCom.ComCounter <= 10;
            //}
            return true;
        }


        public string CheckAlive()
        {
            return "I am ready";
        }

        public ParameterResult GetParameters()
        {
            lock (GParams.Instance.ComLockObj)
            {
                ParameterResult _result = new ParameterResult();

                _result.ProzSoldGewein = 15;
                _result.SellerInfoText = "Die Abholung der nicht verkauften Ware, oder des Erlöses der verkauften Waren, muss am Samstag den 29.10.2011 bis 15:00 Uhr gegen Vorlage des Anmeldezettels erfolgen. Für abhanden gekommene Gegenstände wird von Seiten des Skiclubs Untergrombach e.V. keine Haftung übernommen. Der Verkauf der Ware erfolgt in fremden Namen und auf fremde Rechnung.";

                Program.CfgFile.Read();

                _result.ProzSoldGewein = Program.CfgFile.getValue_AsdDouble("SellParams", "ProzGewin", _result.ProzSoldGewein).Value;
                _result.SellerInfoText = Program.CfgFile.getValue_AsString("SellParams", "InfoMsgPosPrint", _result.SellerInfoText);
                _result.PrintPev = Program.CfgFile.getValue_AsBool("General", "PrintPev", true).Value;

                return _result;
            }
        }


        private static void ShowStati()
        {
            Program.MainFormHwnd.ShowStatic();
        }



        #region . Material Category .

        public BizMaterialCategory MaterialCategoryGet(Guid Id)
        {
            return GParams.Instance.MasterData.MaterialCategoryGet(Id);
        }
        public BizMaterialCategory[] MaterialCategoryGetAll()
        {
            return GParams.Instance.MasterData.MaterialCategoryGetAll();
        }

        public bool MaterialCategoryCreate(BizMaterialCategory materialCategory)
        {
            if (!BasarCom.CheckComCounter())
            {
                throw new Exception("Maximale Anzahl der Aufrufe erreicht!");
            }

            return GParams.Instance.MasterData.MaterialCategoryCreate(materialCategory);
        }
        public bool MaterialCategoryUpdate(BizMaterialCategory materialCategory)
        {
            if (!BasarCom.CheckComCounter())
            {
                throw new Exception("Maximale Anzahl der Aufrufe erreicht!");
            }

            return GParams.Instance.MasterData.MaterialCategoryUpdate(materialCategory);
        }
        public bool MaterialCategoryRemove(Guid matlCatId)
        {
            if (!BasarCom.CheckComCounter())
            {
                throw new Exception("Maximale Anzahl der Aufrufe erreicht!");
            }

            return GParams.Instance.MasterData.MaterialCategoryRemove(matlCatId);
        }

        #endregion . Material Category .


        #region . Manufacturer .

        public BizManufacturer ManufacturerGet(Guid Id)
        {
            return GParams.Instance.MasterData.ManufacturerGet(Id);
        }
        public BizManufacturer[] ManufacturerGetAll()
        {
            return GParams.Instance.MasterData.ManufacturerGetAll();
        }

        public bool ManufacturerCreate(BizManufacturer materialCategory)
        {
            if (!BasarCom.CheckComCounter())
            {
                throw new Exception("Maximale Anzahl der Aufrufe erreicht!");
            }

            return GParams.Instance.MasterData.ManufacturerCreate(materialCategory);
        }
        public bool ManufacturerUpdate(BizManufacturer materialCategory)
        {
            if (!BasarCom.CheckComCounter())
            {
                throw new Exception("Maximale Anzahl der Aufrufe erreicht!");
            }

            return GParams.Instance.MasterData.ManufacturerUpdate(materialCategory);
        }
        public bool ManufacturerRemove(Guid matlCatId)
        {
            if (!BasarCom.CheckComCounter())
            {
                throw new Exception("Maximale Anzahl der Aufrufe erreicht!");
            }

            return GParams.Instance.MasterData.ManufacturerRemove(matlCatId);
        }

        #endregion . Manufacturer .


        #region . Supplier .

        public BizSupplierer SupplierGet_ByID(Guid id)
        {
            return GParams.Instance.Supplier.SupplierGet_ByID(id);
        }
        public BizSupplierer SupplierGet_ByName(string supplierName)
        {
            return GParams.Instance.Supplier.SupplierGet_ByName(supplierName);
        }
        public BizSupplierer SupplierGet_No(int supplierNumber)
        {
            return GParams.Instance.Supplier.SupplierGet_No(supplierNumber);
        }

        public BizSupplierer[] SupplierGetAll()
        {
            return GParams.Instance.Supplier.SupplierGetAll();
        }

        public Guid? SupplierCreate(BizSupplierer supplier)
        {
            if (!BasarCom.CheckComCounter())
            {
                throw new Exception("Maximale Anzahl der Aufrufe erreicht!");
            }

            Guid? _result = GParams.Instance.Supplier.SupplierCreate(supplier);
            BasarCom.ShowStati();
            return _result;
        }
        public bool SupplierUpdate(BizSupplierer supplier)
        {
            if (!BasarCom.CheckComCounter())
            {
                throw new Exception("Maximale Anzahl der Aufrufe erreicht!");
            }

            bool _result = GParams.Instance.Supplier.SupplierUpdate(supplier);
            BasarCom.ShowStati();
            return _result;
        }
        public bool SupplierRemove(Guid supplierId)
        {
            if (!BasarCom.CheckComCounter())
            {
                throw new Exception("Maximale Anzahl der Aufrufe erreicht!");
            }

            bool _result = GParams.Instance.Supplier.SupplierRemove(supplierId);
            BasarCom.ShowStati();
            return _result;
        }

        public bool SetSupplierToReturned(Guid? supplierId, bool isReturned)
        {
            if (!BasarCom.CheckComCounter())
            {
                throw new Exception("Maximale Anzahl der Aufrufe erreicht!");
            }

            DateTime? _timeToSet = null;
            if (isReturned)
                _timeToSet = DateTime.Now;

            bool _result = GParams.Instance.Supplier.SetSupplierToReturned(supplierId, _timeToSet);
            BasarCom.ShowStati();
            return _result;
        }

        #endregion . Supplier .


        #region . Supplierer Position .

        public BizPosition PositionGet(int positionNo)
        {
            return GParams.Instance.Position.PositionGet(positionNo);
        }
        public BizPosition[] PositionGetAll(Guid supplierId)
        {
            return GParams.Instance.Position.PositionGet(supplierId);
        }

        public AllPositionResult[] AllSupplierAndPositions()
        {
            return GParams.Instance.Position.AllSupplierAndPositions();
        }

        public PositionSellResult PositionSell(BizPosition[] position)
        {
            PositionSellResult _result = GParams.Instance.Position.PositionSell(position);
            BasarCom.ShowStati();
            return _result;
        }
        public PositionReturnedResult PositionReturn(Guid supplierId)
        {
            PositionReturnedResult _result = GParams.Instance.Position.PositionReturn(supplierId);
            BasarCom.ShowStati();
            return _result;
        }

        public BizPosition[] GetSoldPositions(Guid supplierId)
        {
            BizPosition[] _result = GParams.Instance.Position.GetSoldPositions(supplierId);
            BasarCom.ShowStati();
            return _result;
        }
        public BizPosition[] GetSoldNotReturnedPositions(Guid supplierId)
        {
            BizPosition[] _result = GParams.Instance.Position.GetSoldNotReturnedPositions(supplierId);
            BasarCom.ShowStati();
            return _result;
        }
        public BizPosition[] GetNotSoldNotReturnedPositions(Guid supplierId)
        {
            BizPosition[] _result = GParams.Instance.Position.GetNotSoldNotReturnedPositions(supplierId);
            BasarCom.ShowStati();
            return _result;
        }

        public void SetPositionsAsReturned(BizPosition[] positions)
        {
            GParams.Instance.Position.SetPositionsAsReturned(positions);
            BasarCom.ShowStati();
        }

        public bool PositionCreate(BizPosition supplierPosition)
        {
            if (!BasarCom.CheckComCounter())
            {
                throw new Exception("Maximale Anzahl der Aufrufe erreicht!");
            }

            bool _result = GParams.Instance.Position.PositionCreate(supplierPosition);
            BasarCom.ShowStati();
            return _result;
        }
        public bool PositionUpdate(BizPosition supplierPosition)
        {
            if (!BasarCom.CheckComCounter())
            {
                throw new Exception("Maximale Anzahl der Aufrufe erreicht!");
            }

            bool _result = GParams.Instance.Position.PositionUpdate(supplierPosition);
            BasarCom.ShowStati();
            return _result;
        }
        public bool PositionRemove(int positionNo)
        {
            if (!BasarCom.CheckComCounter())
            {
                throw new Exception("Maximale Anzahl der Aufrufe erreicht!");
            }

            bool _result = GParams.Instance.Position.PositionRemove(positionNo);
            BasarCom.ShowStati();
            return _result;
        }

        #endregion . Supplierer Position .
    }
}
