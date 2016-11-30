using System;
using System.Runtime.Serialization;
using System.Data;

namespace DeVes.Bazaar.Data.Biz
{
    [DataContract]
    public class BizBase
    {
        //[DataContract]
        //public enum BizStates
        //{
        //    [EnumMember]
        //    none,
        //    [EnumMember]
        //    MarkedNew,
        //    [EnumMember]
        //    MarkedEdit,
        //    [EnumMember]
        //    MarkedDelete,
        //}

        //[DataMember]
        //public BizStates State = BizStates.none;


        public static Guid? ToGuid(object value)
        {
            try
            {
                return new Guid(BizBase.ToString(value));
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

        public static void SetValue(DataRow row, string column, string value)
        {
            try
            {
                if (!string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(value.Trim()))
                    row[column] = value;
                else
                    row[column] = null;
            }
            catch
            {

                try
                {
                    if (!string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(value.Trim()))
                        row[column] = value;
                    else
                        row[column] = DBNull.Value;
                }
                catch
                {
                    // ignored
                }
            }
        }
        public static void SetValue(DataRow row, string column, Guid? value)
        {
            try
            {
                if (value.HasValue)
                    row[column] = value;
                else
                    row[column] = null;
            }
            catch
            {

                try
                {
                    if (value.HasValue)
                        row[column] = value;
                    else
                        row[column] = DBNull.Value;
                }
                catch
                {
                    // ignored
                }
            }
        }
        public static void SetValue(DataRow row, string column, int? value)
        {
            try
            {
                if (value.HasValue)
                    row[column] = value;
                else
                    row[column] = null;
            }
            catch
            {
                try
                {
                    if (value.HasValue)
                        row[column] = value;
                    else
                        row[column] = DBNull.Value;
                }
                catch
                {
                    // ignored
                }
            }
        }
        public static void SetValue(DataRow row, string column, double? value)
        {
            try
            {
                if (value.HasValue)
                    row[column] = value;
                else
                    row[column] = null;
            }
            catch
            {

                try
                {
                    if (value.HasValue)
                        row[column] = value;
                    else
                        row[column] = DBNull.Value;
                }
                catch
                {
                    // ignored
                }
            }
        }
        public static void SetValue(DataRow row, string column, bool? value)
        {
            try
            {
                if (value.HasValue)
                    row[column] = value;
                else
                    row[column] = null;
            }
            catch
            {

                try
                {
                    if (value.HasValue)
                        row[column] = value;
                    else
                        row[column] = DBNull.Value;
                }
                catch
                {
                    // ignored
                }
            }
        }
        public static void SetValue(DataRow row, string column, DateTime? value)
        {
            try
            {
                if (value.HasValue)
                    row[column] = value;
                else
                    row[column] = null;
            }
            catch
            {

                try
                {
                    if (value.HasValue)
                        row[column] = value;
                    else
                        row[column] = DBNull.Value;
                }
                catch
                {
                    // ignored
                }
            }
        }
    }
}
