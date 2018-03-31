﻿using System;
using Foundation.ObjectHydrator.Interfaces;
using System.Reflection;
using Foundation.ObjectHydrator.Generators;

namespace Foundation.ObjectHydrator
{
    public class EnumMap:IMap
    {

        #region IMap Members

        Type IMap.Type => typeof(object);

        bool IMap.Match(PropertyInfo info)
        {
            return info.PropertyType.IsEnum;
        }

        IMapping IMap.Mapping(PropertyInfo info)
        {
            return new Mapping<object>(info, new EnumGenerator(Enum.GetValues(info.PropertyType)));
        }

        #endregion
    }
}
