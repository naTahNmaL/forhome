using PIM.BusinessService.Common.Constants;
using System;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace PIM.BusinessService.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime ParseDateTime(string date)
        {
            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;
            return currentCulture.Contains("en")? DateTime.ParseExact(date, ProjectConstant.AcceptDateFormatForEn,
                System.Globalization.CultureInfo.InvariantCulture) : DateTime.ParseExact(date, ProjectConstant.AcceptDateFormatForVi,
                System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}