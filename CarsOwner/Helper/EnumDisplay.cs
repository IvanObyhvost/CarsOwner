using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using CarsOwner.Core.Enum;

namespace CarsOwner.Helper
{
    public static class EnumDisplay
    {
        public static MvcHtmlString EnumDisplayName(this HtmlHelper hpmlHelper, TypeCar typeCar)
        {
            var nameTypeCar = typeCar.GetType().GetMember(typeCar.ToString()).First().GetCustomAttributes<DisplayAttribute>();
            //var nameTypeCar = Enum.GetName(typeof (TypeCar), typeCar);

            return new MvcHtmlString(nameTypeCar.First().Name);
        }
    }
}