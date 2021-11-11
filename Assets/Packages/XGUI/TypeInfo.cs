using System;
using System.Collections.Generic;

namespace XGUI
{
    public class TypeInfo
    {
        public bool IsIList;
        public Type Type;

        private TypeInfo(bool isIList, Type type)
        {
            IsIList = isIList;
            Type    = type;
        }

        internal static TypeInfo GetTypeInfo(Type type)
        {
            if (type.IsArray)
            {
                return new TypeInfo(true, type.GetElementType());
            }
            if (type.IsGenericType)
            {
                // NOTE:
                // typeof(IList<>) will not be equaled.

                if (type.GetGenericTypeDefinition() != typeof(List<>))
                {
                    return new TypeInfo(false, type);
                }

                var types = type.GetGenericArguments();

                if (types.Length == 1)
                {
                    return new TypeInfo(true, types[0]);
                }
            }

            return new TypeInfo(false, type);
        }
    }
}