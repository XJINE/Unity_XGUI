using System;
using System.Collections.Generic;

namespace XGUI
{
    public class TypeInfo
    {
        public bool isIList;
        public Type type;

        internal static TypeInfo GetTypeInfo(Type type)
        {
            TypeInfo typeInfo = new TypeInfo()
            {
                type = type,
                isIList = false
            };

            if (typeInfo.type.IsArray)
            {
                typeInfo.type = typeInfo.type.GetElementType();
                typeInfo.isIList = true;
            }
            else if (typeInfo.type.IsGenericType)
            {
                // NOTE:
                // typeof(IList<>) will not be equaled.

                if (typeInfo.type.GetGenericTypeDefinition() == typeof(List<>))
                {
                    Type[] types = typeInfo.type.GetGenericArguments();

                    if (types.Length == 1)
                    {
                        typeInfo.type = types[0];
                        typeInfo.isIList = true;
                    }
                }
            }

            return typeInfo;
        }
    }
}