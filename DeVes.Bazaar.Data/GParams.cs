using System;
using DeVes.Bazaar.Data.Tables;
using System.Drawing;

namespace DeVes.Bazaar.Data
{
    public class GParams
    {
        private static GParams _instance;
        public static GParams Instance
        {
            get
            {
                if (GParams._instance == null)
                {
                    GParams._instance = new GParams();
                }
                return GParams._instance;
            }
        }


        private object m_comLockObj;
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

        private string m_applicationPath;
        public string ApplicationPath
        {
            get
            {
                return this.m_applicationPath;
            }
        }

        private string m_applicationDataPath;
        public string ApplicationDataPath
        {
            get
            {
                return this.m_applicationDataPath;
            }
        }


        private Working.MasterData m_masterData;
        public Working.MasterData MasterData
        {
            get
            {
                return this.m_masterData;
            }
        }

        private Working.Supplier m_supplier;
        public Working.Supplier Supplier
        {
            get
            {
                return this.m_supplier;
            }
        }

        private Working.Positions m_position;
        public Working.Positions Position
        {
            get
            {
                return this.m_position;
            }
        }



        #region . for Dll Internal .

        private MaterialCategoryTable m_materialCategoryTable;
        internal MaterialCategoryTable MaterialCategoryTable
        {
            get
            {
                return this.m_materialCategoryTable;
            }
        }

        private ManufacturerTable m_manufacturerTable;
        internal ManufacturerTable ManufacturerTable
        {
            get
            {
                return this.m_manufacturerTable;
            }
        }

        private SupplierTable m_supplierTable;
        internal SupplierTable SupplierTable
        {
            get
            {
                return this.m_supplierTable;
            }
        }

        private PositionsTable m_positionsTable;
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

            this.m_materialCategoryTable = BasicTable.OpenDataTable<MaterialCategoryTable>(applicationDataPath);
            this.m_manufacturerTable = BasicTable.OpenDataTable<ManufacturerTable>(applicationDataPath);
            this.m_supplierTable = BasicTable.OpenDataTable<SupplierTable>(applicationDataPath);
            this.m_positionsTable = BasicTable.OpenDataTable<PositionsTable>(applicationDataPath);
        }




        public static Guid? ToGuid(object value)
        {
            try
            {
                return new Guid(GParams.ToString(value));
            }
            catch
            {
                // ignored
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
                // ignored
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
                // ignored
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
                // ignored
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
                // ignored
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
                // ignored
            }
            return null;
        }

        public static Rectangle ToRectangle(RectangleF rectF)
        {
            return new Rectangle((int)rectF.X, (int)rectF.Y, (int)rectF.Width, (int)rectF.Height);
        }
        public static RectangleF ToRectangle(Rectangle rectF)
        {
            return new RectangleF(rectF.X, rectF.Y, rectF.Width, rectF.Height);
        }
    }
}
