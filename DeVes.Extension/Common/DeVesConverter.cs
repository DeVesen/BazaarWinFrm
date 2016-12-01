using System;

namespace DeVes.Extension.Common
{
    public static class DeVesConverter
    {
        public static TValue To<TValue>(object value)
        {
            var _defaultValue = DeVesHelper.GetDefaultValue<TValue>();
            return DeVesConverter.To(value, _defaultValue);
        }

        public static TValue To<TValue>(object value, TValue defaultValue)
        {
            if (DeVesValidator.Is<TValue>(typeof(string)))
            {
                return (TValue)(object)DeVesConverter.ToString(value, (string)(object)defaultValue);
            }

            if (DeVesValidator.Is<TValue>(typeof(short), typeof(short?)))
            {
                return (TValue)(object)DeVesConverter.ToShort(value, (short?)(object)defaultValue);
            }
            if (DeVesValidator.Is<TValue>(typeof(int), typeof(int?)))
            {
                return (TValue)(object)DeVesConverter.ToInteger(value, (int?)(object)defaultValue);
            }
            if (DeVesValidator.Is<TValue>(typeof(long), typeof(long?)))
            {
                return (TValue)(object)DeVesConverter.ToLong(value, (long?)(object)defaultValue);
            }

            if (DeVesValidator.Is<TValue>(typeof(double), typeof(double?)))
            {
                return (TValue)(object)DeVesConverter.ToDouble(value, (double?)(object)defaultValue);
            }

            if (DeVesValidator.Is<TValue>(typeof(bool), typeof(bool?)))
            {
                return (TValue)(object)DeVesConverter.ToBool(value, (bool?)(object)defaultValue);
            }

            if (DeVesValidator.Is<TValue>(typeof(DateTime), typeof(DateTime?)))
            {
                return (TValue)(object)DeVesConverter.ToDateTime(value, (DateTime?)(object)defaultValue);
            }

            return defaultValue;
        }



        /// <summary>
        /// returns the converted object or defaultValue if not convertable, object is null, Empty or DBnull. Preceding and trailing white spaces are removed.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="enumAsInteger"></param>
        /// <returns></returns>
        public static string ToString(object value, string defaultValue = null, bool enumAsInteger = true)
        {
            try
            {
                if (!DeVesValidator.IsNullState(value))
                {
                    if (value.GetType().BaseType == typeof(Enum) && enumAsInteger)
                        return ((int)value).ToString();

                    var _value = value.ToString();
                    if (!DeVesValidator.IsNullState(_value))
                    {
                        _value = _value.Trim();
                        return (_value == string.Empty) ? defaultValue : _value;
                    }
                }
            }
            catch (Exception)
            {
                // ignored
            }

            return defaultValue;
        }


        /// <summary>
        /// returns the converted object or defaultValue if not convertable, object is null or DBnull
        /// </summary>
        /// <param name="value">value to be converted</param>
        /// <returns>the converted or default value</returns>
        public static short? ToShort(object value)
        {
            return ToShort(value, null);
        }

        /// <summary>
        /// returns the converted object or defaultValue if not convertable, object is null or DBnull
        /// </summary>
        /// <param name="value">value to be converted</param>
        /// <param name="defaultValue">value to be returned in case of Null-Value</param>
        /// <returns>the converted or default value</returns>
        public static short? ToShort(object value, short? defaultValue)
        {
            return ToShort(value, defaultValue, defaultValue);
        }

        /// <summary>
        /// returns the converted object or errorValue if not convertable, defaultValue if the object is null or DBnull
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue">value to be returned in case of Null-Value</param>
        /// <param name="errorValue">value to be return in case that the vonversion fails</param>
        /// <returns>the converted, default or error value</returns>
        public static short? ToShort(object value, short? defaultValue, short? errorValue)
        {
            if (value is short)
                return (short)value;
            try
            {
                if (!DeVesValidator.IsNullState(value))
                {
                    var _s = value as string;
                    if (_s != null)
                    {
                        short _val;
                        if (short.TryParse(_s, out _val))
                            return _val;
                    }
                    else
                        return Convert.ToInt16(value);
                }
            }
            catch (Exception)
            {
                return errorValue;
            }
            return defaultValue;
        }


        /// <summary>
        /// returns the converted object or defaultValue if not convertable, object is null or DBnull
        /// </summary>
        /// <param name="value">value to be converted</param>
        /// <returns>the converted or default value</returns>
        public static int? ToInteger(object value)
        {
            return ToInteger(value, null, null);
        }

        /// <summary>
        /// returns the converted object or defaultValue if not convertable, object is null or DBnull
        /// </summary>
        /// <param name="value">value to be converted</param>
        /// <param name="defaultValue">value to be returned in case of Null-Value</param>
        /// <returns>the converted or default value</returns>
        public static int? ToInteger(object value, int? defaultValue)
        {
            return ToInteger(value, defaultValue, defaultValue);
        }

        /// <summary>
        /// returns the converted object or errorValue if not convertable, defaultValue if the object is null or DBnull
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue">value to be returned in case of Null-Value</param>
        /// <param name="errorValue">value to be return in case that the vonversion fails</param>
        /// <returns>the converted, default or error value</returns>
        public static int? ToInteger(object value, int? defaultValue, int? errorValue)
        {
            if (value is int)
                return (int)value;
            try
            {
                if (!DeVesValidator.IsNullState(value))
                {
                    var _s = value as string;
                    if (_s != null)
                    {
                        int _val;
                        if (int.TryParse(_s, out _val))
                            return _val;
                    }
                    else
                        return Convert.ToInt32(value);
                }
            }
            catch (Exception)
            {
                return errorValue;
            }
            return defaultValue;
        }


        /// <summary>
        /// returns the converted object or defaultValue if not convertable, object is null or DBnull
        /// </summary>
        /// <param name="value">value to be converted</param>
        /// <returns>the converted or default value</returns>
        public static long? ToLong(object value)
        {
            return ToLong(value, null);
        }

        /// <summary>
        /// returns the converted object or errorValue if not convertable, defaultValue if the object is null or DBnull
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue">value to be returned in case of Null-Value</param>
        /// <returns>the converted, default or error value</returns>
        public static long? ToLong(object value, long? defaultValue)
        {
            return ToLong(value, defaultValue, defaultValue);
        }

        /// <summary>
        /// returns the converted object or errorValue if not convertable, defaultValue if the object is null or DBnull
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue">value to be returned in case of Null-Value</param>
        /// <param name="errorValue">value to be return in case that the vonversion fails</param>
        /// <returns>the converted, default or error value</returns>
        public static long? ToLong(object value, long? defaultValue, long? errorValue)
        {
            if (value is long)
                return (long)value;
            try
            {
                if (!DeVesValidator.IsNullState(value))
                {
                    var _s = value as string;
                    if (_s != null)
                    {
                        long _val;
                        if (long.TryParse(_s, out _val))
                            return _val;
                    }
                    else
                        return Convert.ToInt64(value);
                }
            }
            catch (Exception)
            {
                return errorValue;
            }
            return defaultValue;
        }


        /// <summary>
        /// returns the converted object or defaultValue if not convertable, object is null or DBnull
        /// </summary>
        /// <param name="value">value to be converted</param>
        /// <returns>the converted or default value</returns>
        public static double? ToDouble(object value)
        {
            return ToDouble(value, null);
        }

        /// <summary>
        /// returns the converted object or errorValue if not convertable, defaultValue if the object is null or DBnull
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue">value to be returned in case of Null-Value</param>
        /// <returns>the converted, default or error value</returns>
        public static double? ToDouble(object value, double? defaultValue)
        {
            return ToDouble(value, defaultValue, defaultValue);
        }

        /// <summary>
        /// returns the converted object or errorValue if not convertable, defaultValue if the object is null or DBnull
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue">value to be returned in case of Null-Value</param>
        /// <param name="errorValue">value to be return in case that the vonversion fails</param>
        /// <returns>the converted, default or error value</returns>
        public static double? ToDouble(object value, double? defaultValue, double? errorValue)
        {
            if (value is double)
                return (double)value;

            try
            {
                if (!DeVesValidator.IsNullState(value))
                {
                    var _s = value as string;
                    if (_s != null)
                    {
                        double _val;
                        if (double.TryParse(_s, out _val))
                            return _val;
                    }
                    else
                        return Convert.ToDouble(value);
                }
            }
            catch (Exception)
            {
                return errorValue;
            }
            return defaultValue;
        }


        /// <summary>
        /// returns the converted object or null if not convertable, object is null or DBnull
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool? ToBool(object value)
        {
            return ToBool(value, null);
        }

        /// <summary>
        /// returns the converted object or defaultValue if not convertable, object is null or DBnull
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static bool? ToBool(object value, bool? defaultValue)
        {
            if (value is bool)
                return (bool)value;
            try
            {
                if (!DeVesValidator.IsNullState(value))
                {
                    switch (value.ToString().ToLower())
                    {
                        case "true":
                            return true;
                        case "false":
                            return false;
                        default:
                            return Convert.ToInt32(value) != 0;
                    }
                }
            }
            catch (Exception)
            {
                // ignored
            }
            return defaultValue;
        }


        /// <summary>
        /// returns the converted object or null if not convertable, object is null or DBnull
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime? ToDateTime(object value)
        {
            return ToDateTime(value, null);
        }

        /// <summary>
        /// returns the converted object or defaultValue if not convertable, object is null or DBnull
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime? ToDateTime(object value, DateTime? defaultValue)
        {
            if (value is DateTime)
                return (DateTime)value;

            try
            {
                if (!DeVesValidator.IsNullState(value))
                {
                    var _s = value as string;
                    if (_s != null)
                    {
                        DateTime _val;
                        if (DateTime.TryParse(_s, out _val))
                            return _val;
                    }
                    else
                        return Convert.ToDateTime(value);
                }
            }
            catch (Exception)
            {
                // ignored
            }
            return defaultValue;
        }
    }
}
