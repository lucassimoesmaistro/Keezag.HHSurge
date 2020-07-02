using System;
using System.Collections.Generic;
using System.Text;

namespace Keezag.Common.Extensions
{
    public static class EnumExtension
    {
        public static bool TryParse<T>(int value) where T : struct, IConvertible
        {
            return TryParse<T>(value.ToString());
        }

        public static bool TryParse<T>(string value) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new Exception("This method is only for Enums");

            T tempResult = default(T);

            var eTipo = Enum.TryParse(value, true, out tempResult);

            foreach (T item in Enum.GetValues(typeof(T)))
            {
                if (item.Equals(tempResult))
                {
                    return true;
                }
            }

            return false;
        }

        public static T? Parse<T>(int value) where T : struct, IConvertible
        {
            return Parse<T>(value.ToString());
        }

        public static T? Parse<T>(string value) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new Exception("This method is only for Enums");

            T tempResult = default(T);

            var eTipo = Enum.TryParse(value, true, out tempResult);

            foreach (T item in Enum.GetValues(typeof(T)))
            {
                if (item.Equals(tempResult))
                {
                    return item;
                }
            }

            return null;
        }
    }
}
