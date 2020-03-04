using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Utility
{
    public class EnumExtensions
    {
        /// <summary>
        /// 获取枚举描述值
        /// </summary>
        /// <param name="statusEnum">枚举项</param>
        /// <returns></returns>
        public static string EnumDescriptionStr(Enum statusEnum)
        {
            string htmlString = "";
            Type enumType = statusEnum.GetType();
            string name = Enum.GetName(enumType, statusEnum);
            if (name != null)
            {
                FieldInfo fieldInfo = enumType.GetField(name);
                if (fieldInfo != null)
                {
                    DescriptionAttribute attr = Attribute.GetCustomAttribute(fieldInfo,
                    typeof(DescriptionAttribute), false) as DescriptionAttribute;
                    if (attr != null)
                    {
                        htmlString = attr.Description.ToString();
                    }
                }
            }

            return htmlString;
        }
    }
}
