using System;
using System.Linq;

namespace DeVes.Extension.Common
{
    public static class DeVesValidator
    {
        /// <summary>
        /// return true if the value is null or DB-Null
        /// </summary>
        /// <param name="value">value object to text Null state</param>
        /// <returns>true if null, false if not null</returns>
        public static bool IsNullState(object value)
        {
            if (value == null || Convert.IsDBNull(value))
                return true;

            if (value is string)
                return value.ToString().Trim() == string.Empty;

            return false;
        }


        //public static bool Is(Type inheritedType, Type baseType)
        //{
        //    if (inheritedType.BaseType != null && inheritedType.BaseType == baseType)
        //        return true;

        //    if (inheritedType.BaseType != null)
        //        return DeVesValidator.Is(inheritedType.BaseType, baseType);

        //    return inheritedType == baseType;
        //}

        public static bool Is<TValue>(params Type[] findTypes)
        {
            return DeVesValidator.Is(typeof(TValue), findTypes);
        }

        public static bool Is(Type valueType, params Type[] findTypes)
        {
            if (findTypes == null) return false;
            if (!findTypes.Any()) return false;

            if (findTypes.Contains(valueType)) return true;

            return !DeVesValidator.IsNullState(valueType.BaseType) && DeVesValidator.Is(valueType.BaseType, findTypes);
        }
    }
}
