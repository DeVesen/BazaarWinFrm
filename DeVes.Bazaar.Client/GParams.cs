using System;
using System.Drawing;

namespace DeVes.Bazaar.Client
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

        private string m_serverAdress;
        public string ServerAdress
        {
            get
            {
                return this.m_serverAdress;
            }
            set
            {
                this.m_serverAdress = value;
            }
        }

        private int m_portAdress;
        public int PortAdress
        {
            get
            {
                return this.m_portAdress;
            }
            set
            {
                this.m_portAdress = value;
            }
        }

        private int m_timeOut = 50000;
        public int TimeOut
        {
            get
            {
                return this.m_timeOut;
            }
            set
            {
                this.m_timeOut = value;
            }
        }

        public IBasarCom.ParameterResult SystemParameters
        {
            get
            {
                return this.BasarCom.GetParameters();
            }
        }
        
        private IBasarCom.BasarCom m_basarCom;
        public IBasarCom.BasarCom BasarCom
        {
            get
            {
                if (this.m_basarCom == null)
                {
                    this.m_basarCom = new IBasarCom.BasarCom();
                    this.m_basarCom.Url = string.Format("http://{0}:{1}/DeVes.Bazaar.Integrator/IBasarCom", this.m_serverAdress, this.m_portAdress);
                    this.m_basarCom.Proxy = System.Net.WebRequest.DefaultWebProxy;
                    this.m_basarCom.Timeout = this.m_timeOut;
                }
                return this.m_basarCom;
            }
        }

        public IBasarCom.BizMaterialCategory GetMaterialCategoryByName(string name)
        {
            var _list = GParams.Instance.BasarCom.MaterialCategoryGetAll();
            foreach (var _catItem in _list)
            {
                if (string.Compare(name, _catItem.Designation, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    return _catItem;
                }
            }
            return null;
        }
        public IBasarCom.BizManufacturer GetManufacturerByName(string name)
        {
            var _list = GParams.Instance.BasarCom.ManufacturerGetAll();
            foreach (var _manufItem in _list)
            {
                if (string.Compare(name, _manufItem.Designation, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    return _manufItem;
                }
            }
            return null;
        }

        public void DisposeCom()
        {
            if (this.m_basarCom != null)
            {
                this.m_basarCom.Abort();
                this.m_basarCom.Dispose();
            }
            this.m_basarCom = null;
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
