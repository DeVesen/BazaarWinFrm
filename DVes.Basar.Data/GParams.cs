using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DVes.Basar.Data.Biz;
using DVes.Basar.Data.Tables;
using System.Drawing;

namespace DVes.Basar.Data
{
    public class GParams
    {
        private static GParams m_instance = null;
        public static GParams Instance
        {
            get
            {
                if (GParams.m_instance == null)
                {
                    GParams.m_instance = new GParams();
                }
                return GParams.m_instance;
            }
        }


        private object m_comLockObj = null;
        public object ComLockObj
        {
            get
            {
                if (this.m_comLockObj == null)
                {
                    this.m_comLockObj = Guid.NewGuid();
                }
                return this.m_comLockObj;
            }
        }

        private string m_applicationPath = null;
        public string ApplicationPath
        {
            get
            {
                return this.m_applicationPath;
            }
        }

        private string m_applicationDataPath = null;
        public string ApplicationDataPath
        {
            get
            {
                return this.m_applicationDataPath;
            }
        }


        private DVes.Basar.Data.Working.MasterData m_masterData = null;
        public DVes.Basar.Data.Working.MasterData MasterData
        {
            get
            {
                return this.m_masterData;
            }
        }

        private DVes.Basar.Data.Working.Supplier m_supplier = null;
        public DVes.Basar.Data.Working.Supplier Supplier
        {
            get
            {
                return this.m_supplier;
            }
        }

        private DVes.Basar.Data.Working.Positions m_position = null;
        public DVes.Basar.Data.Working.Positions Position
        {
            get
            {
                return this.m_position;
            }
        }



        #region . for Dll Internal .

        private MaterialCategoryTable m_materialCategoryTable = null;
        internal MaterialCategoryTable MaterialCategoryTable
        {
            get
            {
                return this.m_materialCategoryTable;
            }
        }

        private ManufacturerTable m_manufacturerTable = null;
        internal ManufacturerTable ManufacturerTable
        {
            get
            {
                return this.m_manufacturerTable;
            }
        }

        private SupplierTable m_supplierTable = null;
        internal SupplierTable SupplierTable
        {
            get
            {
                return this.m_supplierTable;
            }
        }

        private PositionsTable m_positionsTable = null;
        internal PositionsTable PositionsTable
        {
            get
            {
                return this.m_positionsTable;
            }
        }

        #endregion . for Dll Internal .



        private GParams()
        {
        }

        public void Initialice(string applicationPath, string applicationDataPath)
        {
            this.m_comLockObj = Guid.NewGuid();
            this.m_applicationPath = applicationPath;
            this.m_applicationDataPath = applicationDataPath;

            this.m_masterData = new Working.MasterData();
            this.m_supplier = new Working.Supplier();
            this.m_position = new Working.Positions();

            this.m_materialCategoryTable = MaterialCategoryTable.OpenDataTable<MaterialCategoryTable>(applicationDataPath);
            this.m_manufacturerTable = ManufacturerTable.OpenDataTable<ManufacturerTable>(applicationDataPath);
            this.m_supplierTable = SupplierTable.OpenDataTable<SupplierTable>(applicationDataPath);
            this.m_positionsTable = PositionsTable.OpenDataTable<PositionsTable>(applicationDataPath);
        }




        public static Guid? ToGuid(object value)
        {
            try
            {
                return new Guid(GParams.ToString(value));
            }
            catch
            {

            }
            return null;
        }
        public static string ToString(object value)
        {
            try
            {
                return Convert.ToString(value);
            }
            catch
            {

            }
            return null;
        }
        public static int? ToInt32(object value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {

            }
            return null;
        }
        public static double? ToDouble(object value)
        {
            try
            {
                return Convert.ToDouble(value);
            }
            catch
            {

            }
            return null;
        }
        public static bool? ToBoolean(object value)
        {
            try
            {
                return Convert.ToBoolean(value);
            }
            catch
            {

            }
            return null;
        }
        public static DateTime? ToDateTime(object value)
        {
            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {

            }
            return null;
        }

        public static Rectangle ToRectangle(RectangleF rectF)
        {
            return new Rectangle((int)rectF.X, (int)rectF.Y, (int)rectF.Width, (int)rectF.Height);
        }
        public static RectangleF ToRectangle(Rectangle rectF)
        {
            return new RectangleF((float)rectF.X, (float)rectF.Y, (float)rectF.Width, (float)rectF.Height);
        }
    }
}
