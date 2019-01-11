﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace msac_competition.Classes
{
    public static class Extentions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue?.GetType().GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>().Name;
        }

        //public static string GetDisplayName(this Enum enumValue)
        //{
        //    return enumValue.GetType()?
        //        .GetMember(enumValue.ToString())?
        //        .First()?
        //        .GetCustomAttribute<DisplayAttribute>()?
        //        .Name;
        //}
    }
}
